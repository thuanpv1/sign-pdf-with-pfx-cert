namespace sign_pdf_with_pfx_cert
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPathToPdf = new System.Windows.Forms.TextBox();
            this.textBoxPathToPfx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCoordinateX = new System.Windows.Forms.TextBox();
            this.textBoxCoordinateY = new System.Windows.Forms.TextBox();
            this.textBoxPageNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPfxPassword = new System.Windows.Forms.TextBox();
            this.buttonBrowsePdf = new System.Windows.Forms.Button();
            this.buttonBrowsePfx = new System.Windows.Forms.Button();
            this.labelPdfSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sign";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPathToPdf
            // 
            this.textBoxPathToPdf.Location = new System.Drawing.Point(175, 82);
            this.textBoxPathToPdf.Name = "textBoxPathToPdf";
            this.textBoxPathToPdf.Size = new System.Drawing.Size(541, 22);
            this.textBoxPathToPdf.TabIndex = 1;
            // 
            // textBoxPathToPfx
            // 
            this.textBoxPathToPfx.Location = new System.Drawing.Point(175, 148);
            this.textBoxPathToPfx.Name = "textBoxPathToPfx";
            this.textBoxPathToPfx.Size = new System.Drawing.Size(541, 22);
            this.textBoxPathToPfx.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path to pdf";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path to pfx file";
            // 
            // textBoxCoordinateX
            // 
            this.textBoxCoordinateX.Location = new System.Drawing.Point(175, 225);
            this.textBoxCoordinateX.Name = "textBoxCoordinateX";
            this.textBoxCoordinateX.Size = new System.Drawing.Size(205, 22);
            this.textBoxCoordinateX.TabIndex = 5;
            // 
            // textBoxCoordinateY
            // 
            this.textBoxCoordinateY.Location = new System.Drawing.Point(175, 264);
            this.textBoxCoordinateY.Name = "textBoxCoordinateY";
            this.textBoxCoordinateY.Size = new System.Drawing.Size(204, 22);
            this.textBoxCoordinateY.TabIndex = 6;
            // 
            // textBoxPageNumber
            // 
            this.textBoxPageNumber.Location = new System.Drawing.Point(175, 306);
            this.textBoxPageNumber.Name = "textBoxPageNumber";
            this.textBoxPageNumber.Size = new System.Drawing.Size(203, 22);
            this.textBoxPageNumber.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Coordinate X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Coordinate Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Page number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Pfx password";
            // 
            // textBoxPfxPassword
            // 
            this.textBoxPfxPassword.Location = new System.Drawing.Point(175, 187);
            this.textBoxPfxPassword.Name = "textBoxPfxPassword";
            this.textBoxPfxPassword.Size = new System.Drawing.Size(205, 22);
            this.textBoxPfxPassword.TabIndex = 11;
            // 
            // buttonBrowsePdf
            // 
            this.buttonBrowsePdf.Location = new System.Drawing.Point(744, 78);
            this.buttonBrowsePdf.Name = "buttonBrowsePdf";
            this.buttonBrowsePdf.Size = new System.Drawing.Size(75, 28);
            this.buttonBrowsePdf.TabIndex = 13;
            this.buttonBrowsePdf.Text = "Browse...";
            this.buttonBrowsePdf.UseVisualStyleBackColor = true;
            this.buttonBrowsePdf.Click += new System.EventHandler(this.buttonBrowsePdf_Click);
            // 
            // buttonBrowsePfx
            // 
            this.buttonBrowsePfx.Location = new System.Drawing.Point(744, 144);
            this.buttonBrowsePfx.Name = "buttonBrowsePfx";
            this.buttonBrowsePfx.Size = new System.Drawing.Size(75, 28);
            this.buttonBrowsePfx.TabIndex = 14;
            this.buttonBrowsePfx.Text = "Browse...";
            this.buttonBrowsePfx.UseVisualStyleBackColor = true;
            this.buttonBrowsePfx.Click += new System.EventHandler(this.buttonBrowsePfx_Click);
            // 
            // labelPdfSize
            // 
            this.labelPdfSize.AutoSize = true;
            this.labelPdfSize.Location = new System.Drawing.Point(179, 116);
            this.labelPdfSize.Name = "labelPdfSize";
            this.labelPdfSize.Size = new System.Drawing.Size(60, 17);
            this.labelPdfSize.TabIndex = 15;
            this.labelPdfSize.Text = "PdfSize:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.labelPdfSize);
            this.Controls.Add(this.buttonBrowsePfx);
            this.Controls.Add(this.buttonBrowsePdf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPfxPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPageNumber);
            this.Controls.Add(this.textBoxCoordinateY);
            this.Controls.Add(this.textBoxCoordinateX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPathToPfx);
            this.Controls.Add(this.textBoxPathToPdf);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPathToPdf;
        private System.Windows.Forms.TextBox textBoxPathToPfx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCoordinateX;
        private System.Windows.Forms.TextBox textBoxCoordinateY;
        private System.Windows.Forms.TextBox textBoxPageNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPfxPassword;
        private System.Windows.Forms.Button buttonBrowsePdf;
        private System.Windows.Forms.Button buttonBrowsePfx;
        private System.Windows.Forms.Label labelPdfSize;
    }
}

