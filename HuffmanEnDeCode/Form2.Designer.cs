namespace HuffmanEnDeCode
{
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
            this.upload_file = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // upload_file
            // 
            this.upload_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.upload_file.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.upload_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.upload_file.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.upload_file.Font = new System.Drawing.Font("Viner Hand ITC", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upload_file.Location = new System.Drawing.Point(260, 146);
            this.upload_file.Name = "upload_file";
            this.upload_file.Size = new System.Drawing.Size(235, 81);
            this.upload_file.TabIndex = 0;
            this.upload_file.Text = "Upload File...";
            this.upload_file.UseVisualStyleBackColor = false;
            this.upload_file.Click += new System.EventHandler(this.brwosefiles_click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // back_button
            // 
            this.back_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.back_button.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.back_button.Location = new System.Drawing.Point(51, 369);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(72, 25);
            this.back_button.TabIndex = 1;
            this.back_button.Text = "<- Back";
            this.back_button.UseVisualStyleBackColor = false;
            this.back_button.Click += new System.EventHandler(this.back_click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.upload_file);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Huffman Decoding";
            this.Load += new System.EventHandler(this.en_load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button upload_file;
        private OpenFileDialog openFileDialog1;
        private Button back_button;
    }
}