using System;
using System.Windows.Forms;

namespace CyberBotPart2
{
    /// <summary>
    /// Entry point for the Cybersecurity Awareness Chatbot - Part 2
    /// Launches the Windows Forms GUI application
    /// Author: Brilliant Letsoalo
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Launch the main chatbot form
            Application.Run(new MainForm());
        }
    }
}
