using System.Collections.Generic;

namespace CyberBotPart2
{
    /// <summary>
    /// Manages user memory throughout the conversation session.
    /// Stores the user's name and tracks their favourite cybersecurity topics.
    /// Satisfies rubric requirement: Memory and Recall.
    /// </summary>
    class MemoryManager
    {
        // User's name — collected at the start of the conversation
        public string UserName { get; set; } = "";

        // The topic the user asks about most often
        public string FavouriteTopic { get; private set; } = "";

        // How many times the favourite topic has been mentioned
        public int TopicMentionCount { get; private set; } = 0;

        // Tracks how many times each topic has been mentioned this session
        private Dictionary<string, int> topicCounts = new Dictionary<string, int>();

        /// <summary>
        /// Called every time a topic is matched so we can track user interests.
        /// Updates the favourite topic if this one has now been mentioned more.
        /// </summary>
        public void TrackTopic(string topic)
        {
            if (topicCounts.ContainsKey(topic))
                topicCounts[topic]++;
            else
                topicCounts[topic] = 1;

            // Update favourite if this topic now has the highest count
            if (topicCounts[topic] > TopicMentionCount)
            {
                FavouriteTopic = topic;
                TopicMentionCount = topicCounts[topic];
            }
        }

        /// <summary>
        /// Returns a formatted summary of what the bot remembers about the user.
        /// Can be triggered by the user asking "what do you remember?"
        /// </summary>
        public string GetMemorySummary()
        {
            string summary = $"Here's what I remember about you:\n• Name: {UserName}";

            if (!string.IsNullOrEmpty(FavouriteTopic))
            {
                summary += $"\n• Most asked topic: {FavouriteTopic} (mentioned {TopicMentionCount} time(s))";
                summary += $"\n• It looks like {FavouriteTopic} is very important to you — that's great!";
            }

            return summary;
        }
    }
}
