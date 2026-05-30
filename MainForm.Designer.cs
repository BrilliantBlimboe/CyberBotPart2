namespace CyberBotPart2
{
    partial class MainForm
    {
        // Required by the Windows Forms Designer
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialises all the visual controls on the form.
        /// Dark cybersecurity-themed design with ASCII art header.
        /// Satisfies rubric requirement: Chat Bot GUI Design.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAscii = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMemory = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════
            //  HEADER PANEL — dark background with ASCII logo
            // ═══════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(10, 10, 25);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblAscii);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 125;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);

            // ASCII Art Logo (translated from Part 1's console Ascii.cs)
            this.lblAscii.AutoSize = false;
            this.lblAscii.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAscii.Height = 75;
            this.lblAscii.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblAscii.ForeColor = System.Drawing.Color.FromArgb(0, 220, 220);
            this.lblAscii.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAscii.Text =
                "   ____      _                 _                 \r\n" +
                "  / ___|   _| |__   ___   ___ | | ___   ___  ___\r\n" +
                " | |  | | | | '_ \\ / _ \\ / _ \\| |/ _ \\ / _ \\/ __|\r\n" +
                " | |__| |_| | |_) | (_) | (_) | |  __/|  __/\\__ \\\r\n" +
                "  \\____\\__,_|_.__/ \\___/ \\___/|_|\\___| \\___||___/";

            // Subtitle below the ASCII logo
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubtitle.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 200);
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Text = "[ Cybersecurity Awareness Bot v2.0  ·  Keeping South Africans Safe Online ]";

            // ═══════════════════════════════════════════════════
            //  CHAT DISPLAY — dark themed RichTextBox
            // ═══════════════════════════════════════════════════
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(15, 15, 30);
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbChat.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbChat.ReadOnly = true;
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChat.Padding = new System.Windows.Forms.Padding(8);

            // ═══════════════════════════════════════════════════
            //  BOTTOM INPUT PANEL
            // ═══════════════════════════════════════════════════
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(20, 20, 40);
            this.pnlBottom.Controls.Add(this.txtInput);
            this.pnlBottom.Controls.Add(this.btnSend);
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnMemory);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 60;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(8);

            // Input TextBox
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(30, 30, 55);
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtInput.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtInput.Location = new System.Drawing.Point(8, 14);
            this.txtInput.Size = new System.Drawing.Size(420, 28);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);

            // Send Button
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(0, 140, 170);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(438, 12);
            this.btnSend.Size = new System.Drawing.Size(75, 32);
            this.btnSend.Text = "▶ Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // Memory Button
            this.btnMemory.BackColor = System.Drawing.Color.FromArgb(30, 100, 60);
            this.btnMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemory.FlatAppearance.BorderSize = 0;
            this.btnMemory.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnMemory.ForeColor = System.Drawing.Color.White;
            this.btnMemory.Location = new System.Drawing.Point(523, 12);
            this.btnMemory.Size = new System.Drawing.Size(90, 32);
            this.btnMemory.Text = "⚙ Memory";
            this.btnMemory.Click += new System.EventHandler(this.btnMemory_Click);

            // Clear Button
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(90, 30, 80);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(623, 12);
            this.btnClear.Size = new System.Drawing.Size(75, 32);
            this.btnClear.Text = "✕ Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ═══════════════════════════════════════════════════
            //  MAIN FORM
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 15, 30);
            this.ClientSize = new System.Drawing.Size(710, 650);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MinimumSize = new System.Drawing.Size(710, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CyberBot — Cybersecurity Awareness Bot v2.0";
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        // Control declarations
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAscii;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMemory;
    }
}
