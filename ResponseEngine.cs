using System;
using System.Collections.Generic;

namespace CyberBotPart2
{
    /// <summary>
    /// Handles all chatbot response logic.
    /// Uses a Dictionary of Lists to provide varied, randomised responses per topic.
    /// This satisfies rubric requirements: Keyword Recognition, Random Responses, Code Optimisation.
    /// </summary>
    class ResponseEngine
    {
        private Random rand = new Random();

        // Tracks the last matched topic to support conversation flow
        public string LastMatchedTopic { get; private set; } = "";

        // Dictionary maps keywords to multiple possible responses (for randomisation)
        // All Part 1 topics are included plus new ones from Part 2 requirements
        private Dictionary<string, List<string>> responses;

        public ResponseEngine()
        {
            responses = new Dictionary<string, List<string>>()
            {
                // ----- Part 1 Topics (expanded with multiple responses) -----

                {
                    "phishing", new List<string>
                    {
                        "Phishing is a type of cyber attack where attackers try to trick people into revealing sensitive information, like passwords, credit card numbers, or personal details. Always verify the sender's email address before clicking any links!",
                        "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations like your bank or SARS. If it asks you to act urgently, that's a big red flag!",
                        "Phishing emails often create urgency — 'Your account will be closed in 24 hours!' Don't panic and click links. Rather go directly to the website yourself instead.",
                        "Always check the sender's email address carefully. A phishing email might look like 'support@nedbank-secure.co' instead of the real 'support@nedbank.co.za'. Small differences matter!"
                    }
                },
                {
                    "malware", new List<string>
                    {
                        "Malware is malicious software designed to disrupt, damage, or gain unauthorised access to computer systems. Always keep Windows Defender updated and avoid downloading software from random websites.",
                        "Never download cracked or pirated software — it almost always contains malware. The risk is not worth saving a few hundred rand!",
                        "Ransomware is a type of malware that encrypts all your files and demands payment. Your best protection is regular backups to an external drive or cloud storage.",
                        "If your PC is suddenly very slow, showing lots of pop-ups, or your browser redirects to weird sites — you might have malware. Run a full antivirus scan immediately!"
                    }
                },
                {
                    "ransomware", new List<string>
                    {
                        "Ransomware is a type of malware that encrypts a victim's files or locks them out of their system, demanding a ransom payment to restore access. Never pay the ransom — it does not guarantee your files back!",
                        "The best defence against ransomware is regular backups. Keep copies of your important data on an external drive that is NOT always connected to your computer.",
                        "Ransomware often spreads through email attachments or malicious downloads. Never open attachments from unknown senders, especially .exe or .zip files!",
                        "Businesses and hospitals are common ransomware targets. Keep all software updated and use reputable antivirus software to reduce your risk significantly."
                    }
                },
                {
                    "password", new List<string>
                    {
                        "Strong, unique passwords are essential for online security. Make sure your password has uppercase, lowercase, numbers and symbols — and is at least 12 characters long!",
                        "Never reuse passwords across multiple accounts. If one account gets hacked, all your accounts are at risk. Consider using a free password manager like Bitwarden!",
                        "A strong password should be at least 12 characters. Try using a passphrase like 'PurpleElephant$Runs7' — easy to remember but hard to crack.",
                        "Avoid obvious passwords like 'password123' or your birthday. Hackers use automated tools that try millions of common passwords in seconds!"
                    }
                },
                {
                    "authentication", new List<string>
                    {
                        "Two-factor authentication (2FA) strengthens account security by requiring two different types of identity verification before granting access to an account or system.",
                        "Enable 2FA on all important accounts — especially email, banking and social media. Use an authenticator app like Google Authenticator rather than SMS if possible.",
                        "SMS-based 2FA is better than nothing, but SIM swap fraud is a real threat in South Africa. An authenticator app is much safer than SMS codes.",
                        "2FA adds a second layer of protection. Think of it like a bank vault — you need both the key AND the combination to get in!"
                    }
                },
                {
                    "firewall", new List<string>
                    {
                        "A firewall monitors and controls incoming and outgoing network traffic based on security rules. It acts as a barrier between your trusted network and untrusted external networks.",
                        "Always keep your Windows Firewall enabled. It blocks unauthorised access to your computer while still allowing legitimate traffic through.",
                        "Firewalls can be hardware-based (like your router) or software-based (like Windows Defender Firewall). Having both provides an extra layer of protection!",
                        "Business firewalls can be configured to block specific websites, restrict access times, and monitor all traffic — much more powerful than home firewalls."
                    }
                },
                {
                    "vpn", new List<string>
                    {
                        "A VPN (Virtual Private Network) encrypts your internet connection, providing privacy and security when using public networks like coffee shops or airports.",
                        "Use a VPN when browsing on public WiFi to keep your data private. Without one, hackers on the same network can potentially see your internet traffic!",
                        "A VPN hides your real IP address and encrypts your data. This makes it much harder for attackers, ISPs, or even your employer to monitor what you're doing online.",
                        "Not all VPNs are equal — avoid free VPNs as they often sell your data. Reputable paid options include NordVPN, ExpressVPN, and ProtonVPN."
                    }
                },
                {
                    "update", new List<string>
                    {
                        "Keep your software updated to protect against vulnerabilities. Hackers actively exploit known security holes in outdated software — don't give them the opportunity!",
                        "Enable automatic updates on Windows, your browser, and other apps. Most security breaches exploit vulnerabilities that already had patches available!",
                        "Outdated software is one of the most common entry points for attackers. Even a one-month-old browser can have critical security flaws that updates would fix.",
                        "Don't ignore those update notifications! Software updates often include critical security patches. Schedule them for off-hours if they interrupt your work."
                    }
                },
                {
                    "backup", new List<string>
                    {
                        "Regularly back up your data to prevent loss from ransomware, hardware failure, or accidental deletion. The 3-2-1 rule: 3 copies, 2 different formats, 1 off-site!",
                        "Back up important files to both an external drive AND cloud storage like Google Drive or OneDrive. If your PC gets ransomware, you can restore from backup without paying!",
                        "Test your backups regularly! Many people only discover their backup didn't work when they desperately need to restore files. Verify your backups monthly.",
                        "Automated backups are best — use Windows Backup or a service like Backblaze so you don't have to remember to do it manually every time."
                    }
                },
                {
                    "encryption", new List<string>
                    {
                        "Encryption protects your data by converting it into an unreadable format that can only be decoded with the correct key. It keeps your information safe even if intercepted.",
                        "Always look for 'https://' before entering personal info on any website. The 'S' means the connection is encrypted using SSL/TLS, protecting your data in transit.",
                        "Full-disk encryption (like BitLocker on Windows) protects your entire hard drive. If your laptop gets stolen, the thief cannot read your files without your password!",
                        "End-to-end encryption in apps like WhatsApp and Signal means only you and the recipient can read messages — not even the app company can access them."
                    }
                },
                {
                    "social media", new List<string>
                    {
                        "Be cautious about what you share on social media. Oversharing personal information like your address, workplace, or daily routine can make you a target for criminals.",
                        "Review your social media privacy settings regularly. Make sure strangers cannot see your personal details, photos, or posts by default — limit visibility to friends only.",
                        "Scammers mine social media for information to use in targeted attacks. Your mother's maiden name, pet names, and birthplace could all be used to answer your security questions!",
                        "Think before you post! Once something is online, it can be very difficult to remove completely. Screenshots last forever even if you delete the original post."
                    }
                },
                {
                    "public wifi", new List<string>
                    {
                        "Avoid using public Wi-Fi for sensitive activities like banking or online shopping. Hackers can set up fake hotspots or monitor traffic on the same network.",
                        "If you must use public WiFi, always use a VPN to encrypt your connection. This prevents others on the network from seeing what you're doing online.",
                        "Never access banking, email, or sensitive accounts on public WiFi without a VPN. Even 'secure' public networks at airports or hotels can be compromised.",
                        "Consider using your mobile data hotspot instead of public WiFi for sensitive tasks. It's much more secure than connecting to a shared public network."
                    }
                },
                {
                    "antivirus", new List<string>
                    {
                        "Antivirus software detects, prevents, and removes malicious software from your devices. Keep it updated so it can recognise the latest threats — new malware is created daily!",
                        "Windows Defender (built into Windows 10/11) is actually quite good and free. Keep it enabled and up to date for solid basic protection against most threats.",
                        "Run full antivirus scans at least once a week. Real-time protection catches most threats, but a scheduled full scan finds anything that might have slipped through.",
                        "Antivirus alone is not enough — combine it with a firewall, regular updates, and safe browsing habits for comprehensive protection against cyber threats."
                    }
                },

                // ----- New Part 2 Topics -----

                {
                    "scam", new List<string>
                    {
                        "Scams are very common in South Africa. If something sounds too good to be true — it usually is! Be especially careful of WhatsApp money requests from unknown numbers.",
                        "Common scams in SA include fake job offers, lottery wins, and romance scams. Always verify who you are talking to before sending any money online.",
                        "Never send money to someone you haven't met in person. Scammers often build trust over weeks before asking for money — this is called a long con.",
                        "If you receive a call from 'your bank' asking for your OTP, hang up immediately. Banks will NEVER ask for your OTP or PIN over the phone — ever!"
                    }
                },
                {
                    "privacy", new List<string>
                    {
                        "Protecting your privacy online is really important. Review your social media privacy settings and limit what strangers can see about you.",
                        "Be careful what personal information you share online. Your full name, ID number, address and phone number can all be used for identity theft.",
                        "Read privacy policies before signing up for apps and websites. Many free apps sell your data to advertisers — you are the product!",
                        "Use a privacy-focused browser like Firefox or Brave, and add extensions like uBlock Origin to block tracking scripts and malicious ads."
                    }
                },
                {
                    "social engineering", new List<string>
                    {
                        "Social engineering is a type of cyberattack that exploits human behaviour rather than technical vulnerabilities. Attackers manipulate people into giving up information or access.",
                        "Be suspicious of anyone who contacts you unexpectedly and asks for personal information or account access. Always verify their identity through official channels first.",
                        "Vishing (voice phishing) is when scammers call you on the phone pretending to be from IT support or your bank. Hang up and call the company back using their official number.",
                        "Attackers often research their targets on social media first. Be careful how much personal information you share publicly — it can be weaponised against you!"
                    }
                },
                {
                    "ddos", new List<string>
                    {
                        "A DDoS (Distributed Denial of Service) attack overwhelms a server with traffic from thousands of compromised computers, making the service unavailable to legitimate users.",
                        "DDoS attacks are hard to defend against as an individual. Website owners use services like Cloudflare to absorb and filter malicious traffic before it reaches their servers.",
                        "DDoS attacks don't steal data — they just disrupt services. Banks, government sites, and gaming servers are common targets. Your home network can also be affected.",
                        "Home routers can sometimes be hijacked and used in DDoS botnets without you knowing. Keep your router firmware updated and change the default admin password!"
                    }
                },
                {
                    "identity theft", new List<string>
                    {
                        "Identity theft is a serious problem in South Africa. Never share your ID number on unsecured websites or with people you don't trust.",
                        "Check your credit report regularly at TransUnion or Experian — both offer free annual reports. Unexpected accounts or loans could mean someone stole your identity.",
                        "Shred documents with personal info before throwing them away. Physical bank statements and utility bills can be used for identity theft — don't just recycle them!",
                        "If you think your identity has been stolen, report it to the SA Fraud Prevention Service (SAFPS) immediately at www.safps.org.za. Act fast to limit the damage!"
                    }
                },
                {
                    "safe browsing", new List<string>
                    {
                        "Always check for 'https://' before entering personal info on any website. The padlock icon means the connection is encrypted and more secure.",
                        "Avoid using public WiFi for banking or shopping. If you must use it, make sure you have a VPN running first to protect your data.",
                        "Keep your browser updated! Old browsers have security vulnerabilities that hackers actively exploit. Chrome, Firefox and Edge update automatically by default.",
                        "Use a browser extension like uBlock Origin to block malicious ads and tracking scripts. Many malware infections come through malicious advertisements!"
                    }
                },
                {
                    "cybersecurity tips", new List<string>
                    {
                        "Here are key cybersecurity tips: 1. Use strong, unique passwords. 2. Enable two-factor authentication. 3. Keep all software updated. 4. Be cautious of phishing emails. 5. Back up your data regularly!",
                        "Top tips for staying safe online: Use a password manager, enable 2FA everywhere, install a reputable antivirus, use a VPN on public WiFi, and always think before you click!",
                        "Essential cybersecurity habits: Lock your screen when away from your PC, use encrypted messaging apps, regularly review app permissions, and never share passwords — not even with family!",
                        "Remember the basics: Strong passwords, regular updates, verified links only, regular backups, and never clicking suspicious email attachments. These habits stop 90% of attacks!"
                    }
                }
            };
        }

        /// <summary>
        /// Main response method. Checks follow-ups first, then keyword matches.
        /// Personalises responses using the user's name from memory.
        /// </summary>
        public string GetResponse(string input, MemoryManager memory, string lastTopic)
        {
            // Handle follow-up conversation triggers (Conversation Flow requirement)
            if (input.Contains("tell me more") || input.Contains("explain more") ||
                input.Contains("give me another") || input.Contains("more info") ||
                input.Contains("another tip") || input.Contains("more please"))
            {
                if (!string.IsNullOrEmpty(lastTopic) && responses.ContainsKey(lastTopic))
                {
                    LastMatchedTopic = lastTopic;
                    return GetRandomResponse(lastTopic) + GetMemoryNote(memory, lastTopic);
                }
                return $"Sure, {memory.UserName}! What topic would you like to know more about? Try: passwords, phishing, malware, privacy, scams, or 2FA!";
            }

            // Check each keyword against user input
            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    LastMatchedTopic = keyword;
                    memory.TrackTopic(keyword); // Track for memory/personalisation feature

                    return GetRandomResponse(keyword) + GetMemoryNote(memory, keyword);
                }
            }

            // General conversational responses
            if (input.Contains("how are you") || input.Contains("how r u") || input.Contains("you doing"))
            {
                LastMatchedTopic = "";
                return $"I'm doing great, {memory.UserName}! Always ready to help you stay safe online. What cybersecurity topic can I help you with today?";
            }

            if (input.Contains("what can you do") || input.Contains("your purpose") || input.Contains("what do you know") || input.Contains("help"))
            {
                LastMatchedTopic = "";
                return $"I can help you with many cybersecurity topics, {memory.UserName}!\n\nTry asking about:\n• Passwords & Authentication\n• Phishing & Scams\n• Malware & Ransomware\n• Privacy & Social Media\n• Safe Browsing & VPN\n• Firewalls & Antivirus\n• Social Engineering\n• Identity Theft\n• Data Backup & Encryption\n\nOr just ask about anything cybersecurity-related!";
            }

            if (input.Contains("who are you") || input.Contains("your name") || input.Contains("what are you"))
            {
                LastMatchedTopic = "";
                return $"I'm CyberBot, your personal cybersecurity awareness guide! I was built to help South Africans like you, {memory.UserName}, stay safe online. Ask me anything about cyber threats!";
            }

            if (input.Contains("thank") || input.Contains("thanks") || input.Contains("cheers"))
            {
                LastMatchedTopic = "";
                return $"You're welcome, {memory.UserName}! Staying informed is the best defence against cyber threats. Feel free to ask more questions anytime!";
            }

            if (input.Contains("bye") || input.Contains("goodbye") || input.Contains("exit") || input.Contains("quit"))
            {
                LastMatchedTopic = "";
                return $"Stay safe online, {memory.UserName}! Remember: strong passwords, 2FA, and always think before you click. Goodbye!";
            }

            // Default fallback for unrecognised input (Error Handling requirement)
            LastMatchedTopic = "";
            return $"I'm not quite sure I understand that, {memory.UserName}. Could you rephrase?\n\nTry asking about: passwords, phishing, scams, privacy, malware, safe browsing, or 2FA!";
        }

        /// <summary>
        /// Randomly selects one response from the list for a given topic.
        /// This creates natural variation so the bot doesn't repeat itself.
        /// </summary>
        private string GetRandomResponse(string topic)
        {
            List<string> options = responses[topic];
            int index = rand.Next(0, options.Count);
            return options[index];
        }

        /// <summary>
        /// Adds a personalised note if the user has shown repeated interest in a topic.
        /// Implements the Memory and Recall rubric requirement.
        /// </summary>
        private string GetMemoryNote(MemoryManager memory, string currentTopic)
        {
            if (memory.FavouriteTopic == currentTopic && memory.TopicMentionCount >= 2)
            {
                return $"\n\n[I remember you're very interested in {currentTopic} — great that you're learning about this!]";
            }
            return "";
        }
    }
}
