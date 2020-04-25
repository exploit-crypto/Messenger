namespace InstantMessenger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registerButton = new System.Windows.Forms.ToolStripMenuItem();
            this.loginButton = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.sendTo = new System.Windows.Forms.TextBox();
            this.talkButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerButton,
            this.loginButton,
            this.logoutButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 63);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(416, 49);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registerButton
            // 
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(124, 45);
            this.registerButton.Text = "Register";
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(96, 45);
            this.loginButton.Text = "Login";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(114, 45);
            this.logoutButton.Text = "Logout";
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(14, 112);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:                         ";
            // 
            // sendTo
            // 
            this.sendTo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.sendTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sendTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendTo.Location = new System.Drawing.Point(0, 134);
            this.sendTo.Multiline = true;
            this.sendTo.Name = "sendTo";
            this.sendTo.Size = new System.Drawing.Size(416, 35);
            this.sendTo.TabIndex = 2;
            // 
            // talkButton
            // 
            this.talkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.talkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.talkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.talkButton.Location = new System.Drawing.Point(0, 175);
            this.talkButton.Name = "talkButton";
            this.talkButton.Size = new System.Drawing.Size(416, 77);
            this.talkButton.TabIndex = 3;
            this.talkButton.Text = "Confirm";
            this.talkButton.UseVisualStyleBackColor = true;
            this.talkButton.Click += new System.EventHandler(this.talkButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 255);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(420, 30);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(154, 25);
            this.status.Text = "Register or Login";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 285);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.talkButton);
            this.Controls.Add(this.sendTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Chat";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registerButton;
        private System.Windows.Forms.ToolStripMenuItem loginButton;
        private System.Windows.Forms.ToolStripMenuItem logoutButton;
        private MaterialSkin.Controls.MaterialLabel label1;
        private System.Windows.Forms.TextBox sendTo;
        private System.Windows.Forms.Button talkButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel status;
    }
}