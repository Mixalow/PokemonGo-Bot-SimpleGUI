namespace PokemonGo.RocketAPI.GUI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnGoogleLogin = new System.Windows.Forms.Button();
            this.boxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxUsername = new System.Windows.Forms.TextBox();
            this.accLogins = new System.Windows.Forms.MenuStrip();
            this.addAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAccountToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createPTCAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.accLogins.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGoogleLogin
            // 
            this.btnGoogleLogin.Location = new System.Drawing.Point(12, 106);
            this.btnGoogleLogin.Name = "btnGoogleLogin";
            this.btnGoogleLogin.Size = new System.Drawing.Size(270, 23);
            this.btnGoogleLogin.TabIndex = 3;
            this.btnGoogleLogin.Text = "Login";
            this.btnGoogleLogin.UseVisualStyleBackColor = true;
            this.btnGoogleLogin.Click += new System.EventHandler(this.btnGoogleLogin_Click);
            // 
            // boxPassword
            // 
            this.boxPassword.Location = new System.Drawing.Point(12, 80);
            this.boxPassword.Name = "boxPassword";
            this.boxPassword.PasswordChar = '*';
            this.boxPassword.Size = new System.Drawing.Size(173, 20);
            this.boxPassword.TabIndex = 1;
            this.boxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxPassword_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            // 
            // boxUsername
            // 
            this.boxUsername.Location = new System.Drawing.Point(12, 41);
            this.boxUsername.Name = "boxUsername";
            this.boxUsername.Size = new System.Drawing.Size(173, 20);
            this.boxUsername.TabIndex = 0;
            this.boxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxUsername.TextChanged += new System.EventHandler(this.boxUsername_TextChanged);
            // 
            // accLogins
            // 
            this.accLogins.BackColor = System.Drawing.SystemColors.ControlLight;
            this.accLogins.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountToolStripMenuItem});
            this.accLogins.Location = new System.Drawing.Point(0, 0);
            this.accLogins.Name = "accLogins";
            this.accLogins.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.accLogins.Size = new System.Drawing.Size(294, 24);
            this.accLogins.TabIndex = 10;
            this.accLogins.TabStop = true;
            this.accLogins.Text = "Accounts";
            this.accLogins.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.accLogins_ItemClicked);
            // 
            // addAccountToolStripMenuItem
            // 
            this.addAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountToolStripMenuItem1,
            this.createPTCAccountToolStripMenuItem});
            this.addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            this.addAccountToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.addAccountToolStripMenuItem.Text = "Settings";
            this.addAccountToolStripMenuItem.Click += new System.EventHandler(this.addAccountToolStripMenuItem_Click);
            // 
            // addAccountToolStripMenuItem1
            // 
            this.addAccountToolStripMenuItem1.Name = "addAccountToolStripMenuItem1";
            this.addAccountToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.addAccountToolStripMenuItem1.Text = "Add Account";
            this.addAccountToolStripMenuItem1.Click += new System.EventHandler(this.addAccountToolStripMenuItem1_Click);
            // 
            // createPTCAccountToolStripMenuItem
            // 
            this.createPTCAccountToolStripMenuItem.Name = "createPTCAccountToolStripMenuItem";
            this.createPTCAccountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createPTCAccountToolStripMenuItem.Text = "Create PTC Account";
            this.createPTCAccountToolStripMenuItem.Click += new System.EventHandler(this.createPTCAccountToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(191, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 67);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Type";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(46, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "PTC";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Google";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 137);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.accLogins);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxPassword);
            this.Controls.Add(this.btnGoogleLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.accLogins;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.accLogins.ResumeLayout(false);
            this.accLogins.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoogleLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox boxPassword;
        public System.Windows.Forms.TextBox boxUsername;
        private System.Windows.Forms.MenuStrip accLogins;
        private System.Windows.Forms.ToolStripMenuItem addAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAccountToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createPTCAccountToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}