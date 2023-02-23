namespace Bookbase
{
    partial class FormDoPublisher
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
            this.CB_books = new System.Windows.Forms.CheckedListBox();
            this.CB_journals = new System.Windows.Forms.CheckedListBox();
            this.Bookcountlabel = new System.Windows.Forms.Label();
            this.Journalcountlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(446, 550);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 0;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // CB_books
            // 
            this.CB_books.FormattingEnabled = true;
            this.CB_books.HorizontalScrollbar = true;
            this.CB_books.Location = new System.Drawing.Point(12, 306);
            this.CB_books.Name = "CB_books";
            this.CB_books.Size = new System.Drawing.Size(454, 184);
            this.CB_books.Sorted = true;
            this.CB_books.TabIndex = 14;
            this.CB_books.SelectedIndexChanged += new System.EventHandler(this.CB_books_SelectedIndexChanged);
            // 
            // CB_journals
            // 
            this.CB_journals.FormattingEnabled = true;
            this.CB_journals.Location = new System.Drawing.Point(12, 66);
            this.CB_journals.Name = "CB_journals";
            this.CB_journals.Size = new System.Drawing.Size(454, 184);
            this.CB_journals.TabIndex = 15;
            this.CB_journals.SelectedIndexChanged += new System.EventHandler(this.CB_journals_SelectedIndexChanged);
            // 
            // Bookcountlabel
            // 
            this.Bookcountlabel.AutoSize = true;
            this.Bookcountlabel.Location = new System.Drawing.Point(11, 285);
            this.Bookcountlabel.Name = "Bookcountlabel";
            this.Bookcountlabel.Size = new System.Drawing.Size(35, 13);
            this.Bookcountlabel.TabIndex = 16;
            this.Bookcountlabel.Text = "label1";
            // 
            // Journalcountlabel
            // 
            this.Journalcountlabel.AutoSize = true;
            this.Journalcountlabel.Location = new System.Drawing.Point(18, 42);
            this.Journalcountlabel.Name = "Journalcountlabel";
            this.Journalcountlabel.Size = new System.Drawing.Size(35, 13);
            this.Journalcountlabel.TabIndex = 17;
            this.Journalcountlabel.Text = "label1";
            // 
            // FormDoPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 586);
            this.Controls.Add(this.Journalcountlabel);
            this.Controls.Add(this.Bookcountlabel);
            this.Controls.Add(this.CB_journals);
            this.Controls.Add(this.CB_books);
            this.Controls.Add(this.OKbutton);
            this.Name = "FormDoPublisher";
            this.Text = "FormDoPublisher";
            this.Load += new System.EventHandler(this.FormDoPublisher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.CheckedListBox CB_books;
        private System.Windows.Forms.CheckedListBox CB_journals;
        private System.Windows.Forms.Label Bookcountlabel;
        private System.Windows.Forms.Label Journalcountlabel;
    }
}