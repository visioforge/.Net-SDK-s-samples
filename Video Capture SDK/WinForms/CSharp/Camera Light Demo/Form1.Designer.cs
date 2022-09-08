namespace Camera_Light_Demo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btTurnOn = new System.Windows.Forms.Button();
            this.btTurnOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.Color.White;
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontDialog1.FontMustExist = true;
            this.fontDialog1.ShowColor = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*";
            // 
            // btTurnOn
            // 
            this.btTurnOn.Location = new System.Drawing.Point(145, 57);
            this.btTurnOn.Name = "btTurnOn";
            this.btTurnOn.Size = new System.Drawing.Size(145, 63);
            this.btTurnOn.TabIndex = 0;
            this.btTurnOn.Text = "TURN ON";
            this.btTurnOn.UseVisualStyleBackColor = true;
            this.btTurnOn.Click += new System.EventHandler(this.btTurnOn_Click);
            // 
            // btTurnOff
            // 
            this.btTurnOff.Location = new System.Drawing.Point(296, 57);
            this.btTurnOff.Name = "btTurnOff";
            this.btTurnOff.Size = new System.Drawing.Size(145, 63);
            this.btTurnOff.TabIndex = 1;
            this.btTurnOff.Text = "TURN OFF";
            this.btTurnOff.UseVisualStyleBackColor = true;
            this.btTurnOff.Click += new System.EventHandler(this.btTurnOff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 201);
            this.Controls.Add(this.btTurnOff);
            this.Controls.Add(this.btTurnOn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Camera Light Demo - Video Capture SDK .Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btTurnOn;
        private System.Windows.Forms.Button btTurnOff;
    }
}
