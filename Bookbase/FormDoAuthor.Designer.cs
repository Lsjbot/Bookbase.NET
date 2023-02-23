namespace Bookbase
{
    partial class FormDoAuthor
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ArticleButton = new System.Windows.Forms.Button();
            this.CB_articles = new System.Windows.Forms.CheckedListBox();
            this.AliasBox = new System.Windows.Forms.ListBox();
            this.AliasButton = new System.Windows.Forms.Button();
            this.CoauthorButton = new System.Windows.Forms.Button();
            this.CB_coauthor = new System.Windows.Forms.CheckedListBox();
            this.SubjectButton = new System.Windows.Forms.Button();
            this.CB_subjects = new System.Windows.Forms.CheckedListBox();
            this.CB_crossref = new System.Windows.Forms.CheckedListBox();
            this.CB_pubmed = new System.Windows.Forms.CheckedListBox();
            this.CB_books = new System.Windows.Forms.CheckedListBox();
            this.BookButton = new System.Windows.Forms.Button();
            this.CB_shorts = new System.Windows.Forms.CheckedListBox();
            this.ShortsButton = new System.Windows.Forms.Button();
            this.Articlecountlabel = new System.Windows.Forms.Label();
            this.Bookcountlabel = new System.Windows.Forms.Label();
            this.Shortcountlabel = new System.Windows.Forms.Label();
            this.CB_affiliation = new System.Windows.Forms.CheckedListBox();
            this.AffButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(863, 568);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 49);
            this.OKbutton.TabIndex = 0;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 485);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(297, 132);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // ArticleButton
            // 
            this.ArticleButton.Location = new System.Drawing.Point(12, 12);
            this.ArticleButton.Name = "ArticleButton";
            this.ArticleButton.Size = new System.Drawing.Size(75, 23);
            this.ArticleButton.TabIndex = 2;
            this.ArticleButton.Text = "List Articles";
            this.ArticleButton.UseVisualStyleBackColor = true;
            this.ArticleButton.Click += new System.EventHandler(this.ArticleButton_Click);
            // 
            // CB_articles
            // 
            this.CB_articles.FormattingEnabled = true;
            this.CB_articles.HorizontalScrollbar = true;
            this.CB_articles.Location = new System.Drawing.Point(12, 41);
            this.CB_articles.Name = "CB_articles";
            this.CB_articles.Size = new System.Drawing.Size(673, 124);
            this.CB_articles.Sorted = true;
            this.CB_articles.TabIndex = 3;
            this.CB_articles.SelectedIndexChanged += new System.EventHandler(this.CB_articles_SelectedIndexChanged);
            // 
            // AliasBox
            // 
            this.AliasBox.FormattingEnabled = true;
            this.AliasBox.Location = new System.Drawing.Point(324, 522);
            this.AliasBox.Name = "AliasBox";
            this.AliasBox.Size = new System.Drawing.Size(169, 95);
            this.AliasBox.TabIndex = 4;
            // 
            // AliasButton
            // 
            this.AliasButton.Location = new System.Drawing.Point(324, 494);
            this.AliasButton.Name = "AliasButton";
            this.AliasButton.Size = new System.Drawing.Size(75, 23);
            this.AliasButton.TabIndex = 5;
            this.AliasButton.Text = "List aliases";
            this.AliasButton.UseVisualStyleBackColor = true;
            this.AliasButton.Click += new System.EventHandler(this.AliasButton_Click);
            // 
            // CoauthorButton
            // 
            this.CoauthorButton.Location = new System.Drawing.Point(514, 494);
            this.CoauthorButton.Name = "CoauthorButton";
            this.CoauthorButton.Size = new System.Drawing.Size(99, 23);
            this.CoauthorButton.TabIndex = 7;
            this.CoauthorButton.Text = "List coauthors";
            this.CoauthorButton.UseVisualStyleBackColor = true;
            this.CoauthorButton.Click += new System.EventHandler(this.CoauthorButton_Click);
            // 
            // CB_coauthor
            // 
            this.CB_coauthor.FormattingEnabled = true;
            this.CB_coauthor.Location = new System.Drawing.Point(514, 522);
            this.CB_coauthor.Name = "CB_coauthor";
            this.CB_coauthor.Size = new System.Drawing.Size(171, 94);
            this.CB_coauthor.TabIndex = 8;
            this.CB_coauthor.SelectedIndexChanged += new System.EventHandler(this.CB_coauthor_SelectedIndexChanged);
            // 
            // SubjectButton
            // 
            this.SubjectButton.Location = new System.Drawing.Point(762, 33);
            this.SubjectButton.Name = "SubjectButton";
            this.SubjectButton.Size = new System.Drawing.Size(75, 23);
            this.SubjectButton.TabIndex = 9;
            this.SubjectButton.Text = "List subjects";
            this.SubjectButton.UseVisualStyleBackColor = true;
            this.SubjectButton.Click += new System.EventHandler(this.SubjectButton_Click);
            // 
            // CB_subjects
            // 
            this.CB_subjects.FormattingEnabled = true;
            this.CB_subjects.Location = new System.Drawing.Point(760, 62);
            this.CB_subjects.Name = "CB_subjects";
            this.CB_subjects.Size = new System.Drawing.Size(178, 94);
            this.CB_subjects.TabIndex = 10;
            // 
            // CB_crossref
            // 
            this.CB_crossref.FormattingEnabled = true;
            this.CB_crossref.Location = new System.Drawing.Point(760, 162);
            this.CB_crossref.Name = "CB_crossref";
            this.CB_crossref.Size = new System.Drawing.Size(178, 94);
            this.CB_crossref.TabIndex = 11;
            // 
            // CB_pubmed
            // 
            this.CB_pubmed.FormattingEnabled = true;
            this.CB_pubmed.Location = new System.Drawing.Point(760, 262);
            this.CB_pubmed.Name = "CB_pubmed";
            this.CB_pubmed.Size = new System.Drawing.Size(178, 94);
            this.CB_pubmed.TabIndex = 12;
            // 
            // CB_books
            // 
            this.CB_books.FormattingEnabled = true;
            this.CB_books.HorizontalScrollbar = true;
            this.CB_books.Location = new System.Drawing.Point(12, 200);
            this.CB_books.Name = "CB_books";
            this.CB_books.Size = new System.Drawing.Size(673, 124);
            this.CB_books.Sorted = true;
            this.CB_books.TabIndex = 13;
            this.CB_books.SelectedIndexChanged += new System.EventHandler(this.CB_books_SelectedIndexChanged);
            // 
            // BookButton
            // 
            this.BookButton.Location = new System.Drawing.Point(12, 171);
            this.BookButton.Name = "BookButton";
            this.BookButton.Size = new System.Drawing.Size(75, 23);
            this.BookButton.TabIndex = 14;
            this.BookButton.Text = "List books";
            this.BookButton.UseVisualStyleBackColor = true;
            this.BookButton.Click += new System.EventHandler(this.BookButton_Click);
            // 
            // CB_shorts
            // 
            this.CB_shorts.FormattingEnabled = true;
            this.CB_shorts.HorizontalScrollbar = true;
            this.CB_shorts.Location = new System.Drawing.Point(12, 355);
            this.CB_shorts.Name = "CB_shorts";
            this.CB_shorts.Size = new System.Drawing.Size(673, 124);
            this.CB_shorts.Sorted = true;
            this.CB_shorts.TabIndex = 15;
            this.CB_shorts.SelectedIndexChanged += new System.EventHandler(this.CB_shorts_SelectedIndexChanged);
            // 
            // ShortsButton
            // 
            this.ShortsButton.Location = new System.Drawing.Point(11, 331);
            this.ShortsButton.Name = "ShortsButton";
            this.ShortsButton.Size = new System.Drawing.Size(75, 23);
            this.ShortsButton.TabIndex = 16;
            this.ShortsButton.Text = "List shorts";
            this.ShortsButton.UseVisualStyleBackColor = true;
            this.ShortsButton.Click += new System.EventHandler(this.ShortsButton_Click);
            // 
            // Articlecountlabel
            // 
            this.Articlecountlabel.AutoSize = true;
            this.Articlecountlabel.Location = new System.Drawing.Point(115, 17);
            this.Articlecountlabel.Name = "Articlecountlabel";
            this.Articlecountlabel.Size = new System.Drawing.Size(10, 13);
            this.Articlecountlabel.TabIndex = 17;
            this.Articlecountlabel.Text = ".";
            // 
            // Bookcountlabel
            // 
            this.Bookcountlabel.AutoSize = true;
            this.Bookcountlabel.Location = new System.Drawing.Point(115, 175);
            this.Bookcountlabel.Name = "Bookcountlabel";
            this.Bookcountlabel.Size = new System.Drawing.Size(10, 13);
            this.Bookcountlabel.TabIndex = 18;
            this.Bookcountlabel.Text = ".";
            // 
            // Shortcountlabel
            // 
            this.Shortcountlabel.AutoSize = true;
            this.Shortcountlabel.Location = new System.Drawing.Point(101, 336);
            this.Shortcountlabel.Name = "Shortcountlabel";
            this.Shortcountlabel.Size = new System.Drawing.Size(10, 13);
            this.Shortcountlabel.TabIndex = 19;
            this.Shortcountlabel.Text = ".";
            this.Shortcountlabel.Click += new System.EventHandler(this.Shortcountlabel_Click);
            // 
            // CB_affiliation
            // 
            this.CB_affiliation.FormattingEnabled = true;
            this.CB_affiliation.Location = new System.Drawing.Point(760, 395);
            this.CB_affiliation.Name = "CB_affiliation";
            this.CB_affiliation.Size = new System.Drawing.Size(178, 109);
            this.CB_affiliation.TabIndex = 20;
            // 
            // AffButton
            // 
            this.AffButton.Location = new System.Drawing.Point(760, 366);
            this.AffButton.Name = "AffButton";
            this.AffButton.Size = new System.Drawing.Size(119, 23);
            this.AffButton.TabIndex = 21;
            this.AffButton.Text = "List affiliations";
            this.AffButton.UseVisualStyleBackColor = true;
            this.AffButton.Click += new System.EventHandler(this.AffButton_Click);
            // 
            // FormDoAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 629);
            this.Controls.Add(this.AffButton);
            this.Controls.Add(this.CB_affiliation);
            this.Controls.Add(this.Shortcountlabel);
            this.Controls.Add(this.Bookcountlabel);
            this.Controls.Add(this.Articlecountlabel);
            this.Controls.Add(this.ShortsButton);
            this.Controls.Add(this.CB_shorts);
            this.Controls.Add(this.BookButton);
            this.Controls.Add(this.CB_books);
            this.Controls.Add(this.CB_pubmed);
            this.Controls.Add(this.CB_crossref);
            this.Controls.Add(this.CB_subjects);
            this.Controls.Add(this.SubjectButton);
            this.Controls.Add(this.CB_coauthor);
            this.Controls.Add(this.CoauthorButton);
            this.Controls.Add(this.AliasButton);
            this.Controls.Add(this.AliasBox);
            this.Controls.Add(this.CB_articles);
            this.Controls.Add(this.ArticleButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.OKbutton);
            this.Name = "FormDoAuthor";
            this.Text = "FormDoAuthor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button ArticleButton;
        private System.Windows.Forms.CheckedListBox CB_articles;
        private System.Windows.Forms.ListBox AliasBox;
        private System.Windows.Forms.Button AliasButton;
        private System.Windows.Forms.Button CoauthorButton;
        private System.Windows.Forms.CheckedListBox CB_coauthor;
        private System.Windows.Forms.Button SubjectButton;
        private System.Windows.Forms.CheckedListBox CB_subjects;
        private System.Windows.Forms.CheckedListBox CB_crossref;
        private System.Windows.Forms.CheckedListBox CB_pubmed;
        private System.Windows.Forms.CheckedListBox CB_books;
        private System.Windows.Forms.Button BookButton;
        private System.Windows.Forms.CheckedListBox CB_shorts;
        private System.Windows.Forms.Button ShortsButton;
        private System.Windows.Forms.Label Articlecountlabel;
        private System.Windows.Forms.Label Bookcountlabel;
        private System.Windows.Forms.Label Shortcountlabel;
        private System.Windows.Forms.CheckedListBox CB_affiliation;
        private System.Windows.Forms.Button AffButton;
    }
}