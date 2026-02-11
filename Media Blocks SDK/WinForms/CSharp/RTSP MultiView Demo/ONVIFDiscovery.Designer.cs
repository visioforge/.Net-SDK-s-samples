namespace MediaBlocks_RTSP_MultiView_Demo
{
    partial class ONVIFDiscovery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ONVIFDiscovery));
            this.label1 = new System.Windows.Forms.Label();
            this.cbSources = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.btReadProfiles = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.edUsername = new System.Windows.Forms.TextBox();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sources";
            //
            // cbSources
            //
            this.cbSources.FormattingEnabled = true;
            this.cbSources.Location = new System.Drawing.Point(26, 105);
            this.cbSources.Name = "cbSources";
            this.cbSources.Size = new System.Drawing.Size(752, 28);
            this.cbSources.TabIndex = 1;
            //
            // btSearch
            //
            this.btSearch.Location = new System.Drawing.Point(291, 21);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(229, 49);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "Search sources";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            //
            // btReadProfiles
            //
            this.btReadProfiles.Location = new System.Drawing.Point(255, 147);
            this.btReadProfiles.Name = "btReadProfiles";
            this.btReadProfiles.Size = new System.Drawing.Size(135, 49);
            this.btReadProfiles.TabIndex = 3;
            this.btReadProfiles.Text = "Read profiles";
            this.btReadProfiles.UseVisualStyleBackColor = true;
            this.btReadProfiles.Click += new System.EventHandler(this.btReadProfiles_Click);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Profiles";
            //
            // cbProfiles
            //
            this.cbProfiles.FormattingEnabled = true;
            this.cbProfiles.Location = new System.Drawing.Point(26, 246);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(752, 28);
            this.cbProfiles.TabIndex = 5;
            //
            // edUsername
            //
            this.edUsername.Location = new System.Drawing.Point(26, 158);
            this.edUsername.Name = "edUsername";
            this.edUsername.Size = new System.Drawing.Size(100, 26);
            this.edUsername.TabIndex = 6;
            this.edUsername.Text = "admin";
            //
            // edPassword
            //
            this.edPassword.Location = new System.Drawing.Point(132, 158);
            this.edPassword.Name = "edPassword";
            this.edPassword.Size = new System.Drawing.Size(100, 26);
            this.edPassword.TabIndex = 7;
            this.edPassword.Text = "";
            //
            // ONVIFDiscovery
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.edPassword);
            this.Controls.Add(this.edUsername);
            this.Controls.Add(this.cbProfiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btReadProfiles);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.cbSources);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ONVIFDiscovery";
            this.Text = "ONVIFDiscovery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSources;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btReadProfiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.TextBox edUsername;
        private System.Windows.Forms.TextBox edPassword;
    }
}
