using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace CyberBotPart2
{
    /// <summary>
    /// Main GUI form for the Cybersecurity Awareness Chatbot — Part 2.
    /// Translates all Part 1 console features into a Windows Forms application.
    /// 
    /// Features implemented:
    ///   - Voice greeting on startup (Part 1 requirement translated to GUI)
    ///   - ASCII art logo displayed in header panel
    ///   - User name collection and personalised responses
    ///   - Keyword recognition (15+ topics)
    ///   - Random responses per topic
    ///   - Sentiment detection with empathetic responses
    ///   - Memory and recall (tracks favourite topics)
    ///   - Conversation flow (follow-up questions)
    ///   - Error handling for unknown input
    ///   - Clean, dark-themed cybersecurity UI
    /// </summary>
    public partial class MainForm : Form
    {
        // Helper class instances — clean OOP structure
        private ResponseEngine responseEngine;
        private MemoryManager memory;
        private SentimentDetector sentiment;

        // Tracks the last matched topic to support conversation flow
        private string lastTopic = "";

        public MainForm()
        {
            InitializeComponent();

            // Initialise the helper classes
            responseEngine = new ResponseEngine();
            memory = new MemoryManager();
            sentiment = new SentimentDetector();
        }

        // ═══════════════════════════════════════════════════
        //  FORM LOAD — plays greeting, shows welcome message
        // ═══════════════════════════════════════════════════

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Play voice greeting in a background thread so the UI doesn't freeze
            Thread audioThread = new Thread(() =>
            {
                try
                {
                    string wavPath = "greeting.wav";
                    if (File.Exists(wavPath))
                    {
                        SoundPlayer player = new SoundPlayer(wavPath);
                        player.PlaySync();
                    }
                }
                catch (Exception ex)
                {
                    // Audio errors should never crash the chatbot
                    Console.WriteLine("Audio error: " + ex.Message);
                }
            });
            audioThread.IsBackground = true;
            audioThread.Start();

            // Show the welcome message in the chat area
            AppendMessage("CyberBot", "Hello! Welcome to the Cybersecurity Awareness Bot.", BotColour);
            AppendMessage("CyberBot", "I'm here to help South Africans stay safe online!", BotColour);
            AppendMessage("CyberBot", "What is your name?", BotColour);
        }

        // ═══════════════════════════════════════════════════
        //  EVENT HANDLERS
        // ═══════════════════════════════════════════════════

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the ding sound on Enter
                SendMessage();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChat.Clear();
            AppendMessage("CyberBot", "Chat cleared! How can I help you, " + (memory.UserName ?? "there") + "?", BotColour);
        }

        private void btnMemory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memory.UserName))
            {
                AppendMessage("CyberBot", "I don't remember anything yet — tell me your name first!", BotColour);
            }
            else
            {
                AppendMessage("CyberBot", memory.GetMemorySummary(), MemoryColour);
            }
        }

        // ═══════════════════════════════════════════════════
        //  CORE LOGIC — processes user input and generates response
        // ═══════════════════════════════════════════════════

        private void SendMessage()
        {
            string userInput = txtInput.Text.Trim();

            // Error handling: ignore empty input
            if (string.IsNullOrWhiteSpace(userInput))
                return;

            // Show the user's message on the right with green colour
            AppendMessage(memory.UserName ?? "You", userInput, UserColour);
            txtInput.Clear();

            // --- Name collection phase ---
            if (string.IsNullOrEmpty(memory.UserName))
            {
                // Validate the name — shouldn't be empty or too short
                if (userInput.Length < 2)
                {
                    AppendMessage("CyberBot", "Please enter a valid name (at least 2 characters).", BotColour);
                    return;
                }

                // Capitalise the name properly
                string name = userInput.Trim();
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                memory.UserName = name;

                AppendMessage("CyberBot", $"Hello {name}, let's explore safe online practices together!", BotColour);
                AppendMessage("CyberBot", $"You can ask me about: passwords, phishing, malware, safe browsing, 2FA, privacy, scams, and much more!", BotColour);
                return;
            }

            // --- Check for memory recall trigger ---
            if (userInput.ToLower().Contains("what do you remember") ||
                userInput.ToLower().Contains("what have you remembered") ||
                userInput.ToLower().Contains("do you remember me"))
            {
                AppendMessage("CyberBot", memory.GetMemorySummary(), MemoryColour);
                return;
            }

            // --- Sentiment detection — check emotional tone before getting response ---
            string detectedSentiment = sentiment.Detect(userInput);

            // If the user seems worried or frustrated, add an empathetic opener
            if (!string.IsNullOrEmpty(detectedSentiment))
            {
                string empathy = sentiment.GetEmpathyMessage(detectedSentiment);
                if (!string.IsNullOrEmpty(empathy))
                {
                    AppendMessage("CyberBot", empathy, EmpathyColour);
                }
            }

            // --- Get main response from the response engine ---
            string response = responseEngine.GetResponse(userInput.ToLower(), memory, lastTopic);

            // Update last topic for conversation flow
            lastTopic = responseEngine.LastMatchedTopic;

            AppendMessage("CyberBot", response, BotColour);
        }

        // ═══════════════════════════════════════════════════
        //  UI HELPER — appends a formatted message to the chat
        // ═══════════════════════════════════════════════════

        private void AppendMessage(string sender, string message, Color colour)
        {
            // Cross-thread safety — update UI from the main thread
            if (rtbChat.InvokeRequired)
            {
                rtbChat.Invoke(new Action(() => AppendMessage(sender, message, colour)));
                return;
            }

            rtbChat.AppendText("\n");

            // Sender name in the chosen colour, bold
            rtbChat.SelectionColor = colour;
            rtbChat.SelectionFont = new Font("Consolas", 9.5F, FontStyle.Bold);
            rtbChat.AppendText($"  {sender}:\n");

            // Message body in light grey
            rtbChat.SelectionColor = Color.FromArgb(220, 220, 235);
            rtbChat.SelectionFont = new Font("Consolas", 9.5F, FontStyle.Regular);
            rtbChat.AppendText($"  {message}\n");

            // Divider line
            rtbChat.SelectionColor = Color.FromArgb(40, 40, 65);
            rtbChat.AppendText("  ──────────────────────────────────────────────\n");

            // Auto-scroll to the latest message
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.ScrollToCaret();
        }

        // ═══════════════════════════════════════════════════
        //  COLOUR CONSTANTS — consistent cybersecurity theme
        // ═══════════════════════════════════════════════════

        private Color BotColour    => Color.FromArgb(0, 210, 210);    // Cyan — bot messages
        private Color UserColour   => Color.FromArgb(100, 220, 100);  // Green — user messages
        private Color EmpathyColour => Color.FromArgb(255, 200, 80);  // Amber — empathy messages
        private Color MemoryColour  => Color.FromArgb(180, 120, 255); // Purple — memory recall
    }
}
