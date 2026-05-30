# CyberBot — Cybersecurity Awareness Chatbot (Part 2)

A Windows Forms GUI-based Cybersecurity Awareness Chatbot built in C# (.NET 6).
This is Part 2 of the PROG6221 POE, expanding the console chatbot from Part 1 into a full GUI application.

**Author:** Brilliant Letsoalo  
**Module:** PROG6221 — Programming 2A

---

## What's New in Part 2 (vs Part 1)

| Feature | Part 1 (Console) | Part 2 (GUI) |
|---|---|---|
| Interface | Console (text only) | Windows Forms GUI |
| Responses | Single static response | Multiple randomised responses |
| Sentiment | None | Detects worried/frustrated/curious/confused |
| Memory | None | Remembers name + favourite topic |
| Conversation Flow | Restarts each time | Follow-up questions supported |
| Topics | 15 topics | 18+ topics with 4 responses each |
| Error Handling | Basic | Graceful fallback with suggestions |

---

## Features

- **Voice Greeting** — plays `greeting.wav` on startup (same as Part 1)
- **ASCII Art Header** — the Part 1 console ASCII logo is displayed in the GUI header
- **User Name Collection** — asks for the user's name, uses it in personalised responses
- **Keyword Recognition** — identifies 18+ cybersecurity topics from user input
- **Random Responses** — multiple responses per topic, randomly selected each time
- **Sentiment Detection** — detects worried, frustrated, curious, or confused sentiment
- **Memory & Recall** — remembers the user's name and most-asked topic; click ⚙ Memory to view
- **Conversation Flow** — say "tell me more" or "another tip" to continue a topic
- **Error Handling** — graceful fallback for unrecognised input
- **Clean Dark UI** — cybersecurity-themed dark design with colour-coded messages

---

## Topics the Bot Covers

| Topic | Example Input |
|---|---|
| Passwords | "Tell me about password safety" |
| Phishing | "What is phishing?" |
| Malware | "How does malware work?" |
| Ransomware | "Tell me about ransomware" |
| Scams | "What scams should I watch out for?" |
| Privacy | "How do I protect my privacy?" |
| Safe Browsing | "How do I browse safely?" |
| VPN | "What is a VPN?" |
| 2FA / Authentication | "What is 2FA?" / "authentication" |
| Firewall | "What does a firewall do?" |
| Social Engineering | "What is social engineering?" |
| Identity Theft | "What is identity theft?" |
| Antivirus | "Do I need antivirus?" |
| Social Media | "Is social media safe?" |
| Public WiFi | "Is public wifi safe?" |
| Encryption | "What is encryption?" |
| Backup | "Why should I backup data?" |
| Updates | "Should I update my software?" |
| DDoS | "What is a DDoS attack?" |

---

## How to Run

### Requirements
- Windows OS (required for `System.Windows.Forms` and `System.Media.SoundPlayer`)
- .NET 6 SDK — download from https://dotnet.microsoft.com

### Steps

1. Clone the repository:
```bash
git clone https://github.com/YOUR_USERNAME/CyberBotPart2.git
cd CyberBotPart2
```

2. (Optional) Place your `greeting.wav` file in the project root folder.
   - Record a short voice message such as: *"Hello! Welcome to the Cybersecurity Awareness Bot."*
   - Must be `.wav` format (not `.mp3`)
   - If missing, the bot still runs — it just skips the audio

3. Build and run:
```bash
dotnet build
dotnet run
```

Or open `CyberBotPart2.sln` in Visual Studio 2022 and press **F5** to run.

---

## Project Structure

```
CyberBotPart2/
├── Program.cs              ← Entry point — launches the Windows Forms app
├── MainForm.cs             ← Main GUI window, user interaction logic
├── MainForm.Designer.cs    ← Auto-generated form layout (controls & positioning)
├── ResponseEngine.cs       ← All keyword responses (Dictionary<string, List<string>>)
├── SentimentDetector.cs    ← Detects user emotional tone and returns empathy messages
├── MemoryManager.cs        ← Stores user name, tracks favourite topics
├── CyberBotPart2.csproj    ← Project configuration
├── CyberBotPart2.sln       ← Solution file
├── greeting.wav            ← Voice greeting (place here before running)
└── .github/
    └── workflows/
        └── build.yml       ← GitHub Actions CI — auto-builds on every push to main
```

---

## Using the Chatbot

1. Launch the app — the voice greeting plays and the welcome message appears
2. Type your name and press Enter or click **▶ Send**
3. Ask any cybersecurity question
4. Click **⚙ Memory** to see what the bot remembers about you
5. Click **✕ Clear** to clear the chat history
6. Say "tell me more" or "another tip" to continue on the same topic

---

## CI/CD

This project uses GitHub Actions for Continuous Integration.
On every push to `main`, it automatically:
1. Checks out the code
2. Installs .NET 6
3. Restores dependencies
4. Builds the project in Release mode
5. Publishes the release build

---

## Submission Checklist

- [x] Voice greeting (WAV file supported)
- [x] ASCII art logo translated from Part 1 into GUI header
- [x] User name input with personalised responses throughout
- [x] Keyword recognition for 18+ cybersecurity topics
- [x] Multiple randomised responses per topic (using `Dictionary<string, List<string>>`)
- [x] Sentiment detection (worried, frustrated, curious, confused)
- [x] Empathetic responses — automatically provides a tip when sentiment detected
- [x] Memory and recall — remembers name and favourite topic
- [x] Conversation flow — "tell me more", "another tip", etc.
- [x] Error handling for empty/unrecognised input
- [x] Clean, dark-themed GUI with colour-coded messages
- [x] Modular OOP code — 4 separate well-documented classes
- [x] GitHub Actions CI workflow (`build.yml`)
- [ ] Minimum 6 meaningful commits *(push to GitHub to complete)*
- [ ] 3 Git tags/releases (v1.0, v2.0, v2.1) *(create after pushing)*
- [ ] Video presentation link *(add after recording)*

---

## License
MIT License — see LICENSE file for details.
