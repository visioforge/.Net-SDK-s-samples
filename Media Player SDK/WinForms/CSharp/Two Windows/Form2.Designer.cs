namespace Two_Windows_Demo
{
    using VisioForge.Core.Types;

    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            groupBox1 = new System.Windows.Forms.GroupBox();
            cbDebugMode = new System.Windows.Forms.CheckBox();
            cbLicensing = new System.Windows.Forms.CheckBox();
            mmError = new System.Windows.Forms.TextBox();
            pnScreen = new System.Windows.Forms.Panel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(cbDebugMode);
            groupBox1.Controls.Add(cbLicensing);
            groupBox1.Controls.Add(mmError);
            groupBox1.Location = new System.Drawing.Point(20, 929);
            groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Size = new System.Drawing.Size(1067, 229);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Errors and warnings";
            // 
            // cbDebugMode
            // 
            cbDebugMode.AutoSize = true;
            cbDebugMode.Checked = true;
            cbDebugMode.CheckState = System.Windows.Forms.CheckState.Checked;
            cbDebugMode.Location = new System.Drawing.Point(791, 37);
            cbDebugMode.Name = "cbDebugMode";
            cbDebugMode.Size = new System.Drawing.Size(92, 29);
            cbDebugMode.TabIndex = 5;
            cbDebugMode.Text = "Debug";
            cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // cbLicensing
            // 
            cbLicensing.AutoSize = true;
            cbLicensing.Location = new System.Drawing.Point(905, 37);
            cbLicensing.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cbLicensing.Name = "cbLicensing";
            cbLicensing.Size = new System.Drawing.Size(146, 29);
            cbLicensing.TabIndex = 4;
            cbLicensing.Text = "Licensing info";
            cbLicensing.UseVisualStyleBackColor = true;
            // 
            // mmError
            // 
            mmError.Location = new System.Drawing.Point(10, 81);
            mmError.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            mmError.Multiline = true;
            mmError.Name = "mmError";
            mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            mmError.Size = new System.Drawing.Size(1044, 125);
            mmError.TabIndex = 3;
            // 
            // pnScreen
            // 
            pnScreen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnScreen.BackColor = System.Drawing.Color.Black;
            pnScreen.Location = new System.Drawing.Point(20, 23);
            pnScreen.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            pnScreen.Name = "pnScreen";
            pnScreen.Size = new System.Drawing.Size(1065, 881);
            pnScreen.TabIndex = 34;
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1107, 1162);
            Controls.Add(pnScreen);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "Form2";
            Text = "Media Player SDK - Two Windows Demo - Window 2";
            Load += Form2_Load;
            SizeChanged += Form2_SizeChanged;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox mmError;
        private System.Windows.Forms.CheckBox cbLicensing;
        private System.Windows.Forms.Panel pnScreen;
        private System.Windows.Forms.CheckBox cbDebugMode;
    }
}

