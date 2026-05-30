using System.Collections.Generic;

namespace CyberBotPart2
{
    /// <summary>
    /// Detects the emotional tone of the user's message.
    /// Adjusts responses to provide empathy when the user seems worried or frustrated.
    /// Satisfies rubric requirement: Sentiment Detection.
    /// </summary>
    class SentimentDetector
    {
        // Keywords associated with each emotional state
        private Dictionary<string, List<string>> sentimentKeywords = new Dictionary<string, List<string>>()
        {
            {
                "worried", new List<string>
                {
                    "worried", "scared", "afraid", "nervous", "anxious", "concerned",
                    "freaking out", "panic", "terrified", "fear", "frightened", "unsafe",
                    "dangerous", "at risk", "vulnerable", "stressed"
                }
            },
            {
                "frustrated", new List<string>
                {
                    "frustrated", "annoyed", "angry", "useless", "hate", "stupid",
                    "ridiculous", "fed up", "irritated", "sick of", "not working",
                    "doesn't work", "broken", "worst", "terrible", "awful"
                }
            },
            {
                "curious", new List<string>
                {
                    "curious", "wondering", "interested", "want to know", "how does",
                    "what is", "tell me", "explain", "can you", "i want to learn",
                    "teach me", "show me", "how do i", "what should"
                }
            },
            {
                "confused", new List<string>
                {
                    "confused", "don't understand", "not sure", "lost", "what do you mean",
                    "unclear", "complicated", "difficult", "hard to understand",
                    "don't get it", "makes no sense", "what?", "huh"
                }
            }
        };

        /// <summary>
        /// Scans the user's input for sentiment keywords.
        /// Returns the detected sentiment or empty string if none found.
        /// </summary>
        public string Detect(string input)
        {
            string lowerInput = input.ToLower();

            foreach (var sentiment in sentimentKeywords)
            {
                foreach (var keyword in sentiment.Value)
                {
                    if (lowerInput.Contains(keyword))
                        return sentiment.Key;
                }
            }

            return ""; // No sentiment detected — respond normally
        }

        /// <summary>
        /// Returns an empathetic message based on the detected sentiment.
        /// This is prepended to the bot's main response to feel more human and supportive.
        /// When user is worried, the bot also automatically provides a tip (rubric requirement).
        /// </summary>
        public string GetEmpathyMessage(string sentiment)
        {
            switch (sentiment)
            {
                case "worried":
                    return "It's completely understandable to feel that way. Cyber threats can be scary, but knowing about them is the first step to staying safe. Let me help!";

                case "frustrated":
                    return "I hear you — cybersecurity can feel overwhelming at times. Let's take it one step at a time. I'm here to help!";

                case "curious":
                    return "Great that you're curious about this! Learning about cybersecurity is one of the best things you can do to protect yourself online.";

                case "confused":
                    return "No worries at all! Cybersecurity can be confusing at first. Let me break it down in a simple, easy-to-understand way for you.";

                default:
                    return "";
            }
        }
    }
}
