namespace Bookbase
{
    partial class FormDoBook
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
            this.OKbutton = new System.Windows.Forms.Button();
            this.Titlelabel = new System.Windows.Forms.Label();
            this.CB_author = new System.Windows.Forms.CheckedListBox();
            this.CB_chapter = new System.Windows.Forms.CheckedListBox();
            this.Publisherlabel = new System.Windows.Forms.Label();
            this.Yearlabel = new System.Windows.Forms.Label();
            this.Shortsbutton = new System.Windows.Forms.Button();
            this.Refbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(798, 490);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 0;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // Titlelabel
            // 
            this.Titlelabel.AutoSize = true;
            this.Titlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlelabel.Location = new System.Drawing.Point(45, 31);
            this.Titlelabel.Name = "Titlelabel";
            this.Titlelabel.Size = new System.Drawing.Size(60, 24);
            this.Titlelabel.TabIndex = 1;
            this.Titlelabel.Text = "label1";
            // 
            // CB_author
            // 
            this.CB_author.FormattingEnabled = true;
            this.CB_author.Location = new System.Drawing.Point(41, 76);
            this.CB_author.Name = "CB_author";
            this.CB_author.Size = new System.Drawing.Size(486, 94);
            this.CB_author.TabIndex = 2;
            // 
            // CB_chapter
            // 
            this.CB_chapter.FormattingEnabled = true;
            this.CB_chapter.Location = new System.Drawing.Point(39, 204);
            this.CB_chapter.Name = "CB_chapter";
            this.CB_chapter.Size = new System.Drawing.Size(488, 289);
            this.CB_chapter.TabIndex = 3;
            // 
            // Publisherlabel
            // 
            this.Publisherlabel.AutoSize = true;
            this.Publisherlabel.Location = new System.Drawing.Point(682, 106);
            this.Publisherlabel.Name = "Publisherlabel";
            this.Publisherlabel.Size = new System.Drawing.Size(50, 13);
            this.Publisherlabel.TabIndex = 4;
            this.Publisherlabel.Text = "Publisher";
            // 
            // Yearlabel
            // 
            this.Yearlabel.AutoSize = true;
            this.Yearlabel.Location = new System.Drawing.Point(690, 149);
            this.Yearlabel.Name = "Yearlabel";
            this.Yearlabel.Size = new System.Drawing.Size(29, 13);
            this.Yearlabel.TabIndex = 5;
            this.Yearlabel.Text = "Year";
            // 
            // Shortsbutton
            // 
            this.Shortsbutton.Location = new System.Drawing.Point(643, 261);
            this.Shortsbutton.Name = "Shortsbutton";
            this.Shortsbutton.Size = new System.Drawing.Size(112, 36);
            this.Shortsbutton.TabIndex = 6;
            this.Shortsbutton.Text = "Edit book";
            this.Shortsbutton.UseVisualStyleBackColor = true;
            this.Shortsbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Refbutton
            // 
            this.Refbutton.Location = new System.Drawing.Point(643, 328);
            this.Refbutton.Name = "Refbutton";
            this.Refbutton.Size = new System.Drawing.Size(112, 31);
            this.Refbutton.TabIndex = 7;
            this.Refbutton.Text = "Generate references";
            this.Refbutton.UseVisualStyleBackColor = true;
            this.Refbutton.Click += new System.EventHandler(this.Refbutton_Click);
            // 
            // FormDoBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 524);
            this.Controls.Add(this.Refbutton);
            this.Controls.Add(this.Shortsbutton);
            this.Controls.Add(this.Yearlabel);
            this.Controls.Add(this.Publisherlabel);
            this.Controls.Add(this.CB_chapter);
            this.Controls.Add(this.CB_author);
            this.Controls.Add(this.Titlelabel);
            this.Controls.Add(this.OKbutton);
            this.Name = "FormDoBook";
            this.Text = "FormDoBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label Titlelabel;
        private System.Windows.Forms.CheckedListBox CB_author;
        private System.Windows.Forms.CheckedListBox CB_chapter;
        private System.Windows.Forms.Label Publisherlabel;
        private System.Windows.Forms.Label Yearlabel;
        private System.Windows.Forms.Button Shortsbutton;
        private System.Windows.Forms.Button Refbutton;
    }
}