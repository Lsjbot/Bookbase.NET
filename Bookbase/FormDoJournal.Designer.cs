namespace Bookbase
{
    partial class FormDoJournal
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
            this.CB_articles = new System.Windows.Forms.CheckedListBox();
            this.ArticleButton = new System.Windows.Forms.Button();
            this.Articlecountlabel = new System.Windows.Forms.Label();
            this.Publisherlabel = new System.Windows.Forms.Label();
            this.ISSNlabel = new System.Windows.Forms.Label();
            this.CB_author = new System.Windows.Forms.CheckedListBox();
            this.Authorbutton = new System.Windows.Forms.Button();
            this.CB_topauthor = new System.Windows.Forms.CheckBox();
            this.Authorcountlabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(759, 448);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 0;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // CB_articles
            // 
            this.CB_articles.FormattingEnabled = true;
            this.CB_articles.HorizontalScrollbar = true;
            this.CB_articles.Location = new System.Drawing.Point(12, 39);
            this.CB_articles.Name = "CB_articles";
            this.CB_articles.Size = new System.Drawing.Size(607, 124);
            this.CB_articles.Sorted = true;
            this.CB_articles.TabIndex = 4;
            this.CB_articles.SelectedIndexChanged += new System.EventHandler(this.CB_articles_SelectedIndexChanged);
            // 
            // ArticleButton
            // 
            this.ArticleButton.Location = new System.Drawing.Point(12, 10);
            this.ArticleButton.Name = "ArticleButton";
            this.ArticleButton.Size = new System.Drawing.Size(75, 23);
            this.ArticleButton.TabIndex = 5;
            this.ArticleButton.Text = "List Articles";
            this.ArticleButton.UseVisualStyleBackColor = true;
            this.ArticleButton.Click += new System.EventHandler(this.ArticleButton_Click);
            // 
            // Articlecountlabel
            // 
            this.Articlecountlabel.AutoSize = true;
            this.Articlecountlabel.Location = new System.Drawing.Point(135, 15);
            this.Articlecountlabel.Name = "Articlecountlabel";
            this.Articlecountlabel.Size = new System.Drawing.Size(10, 13);
            this.Articlecountlabel.TabIndex = 18;
            this.Articlecountlabel.Text = ".";
            // 
            // Publisherlabel
            // 
            this.Publisherlabel.AutoSize = true;
            this.Publisherlabel.Location = new System.Drawing.Point(659, 20);
            this.Publisherlabel.Name = "Publisherlabel";
            this.Publisherlabel.Size = new System.Drawing.Size(50, 13);
            this.Publisherlabel.TabIndex = 19;
            this.Publisherlabel.Text = "Publisher";
            this.Publisherlabel.Click += new System.EventHandler(this.Publisherlabel_Click);
            // 
            // ISSNlabel
            // 
            this.ISSNlabel.AutoSize = true;
            this.ISSNlabel.Location = new System.Drawing.Point(659, 59);
            this.ISSNlabel.Name = "ISSNlabel";
            this.ISSNlabel.Size = new System.Drawing.Size(32, 13);
            this.ISSNlabel.TabIndex = 20;
            this.ISSNlabel.Text = "ISSN";
            // 
            // CB_author
            // 
            this.CB_author.FormattingEnabled = true;
            this.CB_author.Location = new System.Drawing.Point(12, 201);
            this.CB_author.Name = "CB_author";
            this.CB_author.Size = new System.Drawing.Size(607, 94);
            this.CB_author.TabIndex = 21;
            this.CB_author.SelectedIndexChanged += new System.EventHandler(this.CB_author_SelectedIndexChanged);
            // 
            // Authorbutton
            // 
            this.Authorbutton.Location = new System.Drawing.Point(12, 172);
            this.Authorbutton.Name = "Authorbutton";
            this.Authorbutton.Size = new System.Drawing.Size(75, 23);
            this.Authorbutton.TabIndex = 22;
            this.Authorbutton.Text = "List authors";
            this.Authorbutton.UseVisualStyleBackColor = true;
            this.Authorbutton.Click += new System.EventHandler(this.Authorbutton_Click);
            // 
            // CB_topauthor
            // 
            this.CB_topauthor.AutoSize = true;
            this.CB_topauthor.Checked = true;
            this.CB_topauthor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_topauthor.Location = new System.Drawing.Point(212, 173);
            this.CB_topauthor.Name = "CB_topauthor";
            this.CB_topauthor.Size = new System.Drawing.Size(105, 17);
            this.CB_topauthor.TabIndex = 23;
            this.CB_topauthor.Text = "Top authors only";
            this.CB_topauthor.UseVisualStyleBackColor = true;
            // 
            // Authorcountlabel
            // 
            this.Authorcountlabel.AutoSize = true;
            this.Authorcountlabel.Location = new System.Drawing.Point(113, 177);
            this.Authorcountlabel.Name = "Authorcountlabel";
            this.Authorcountlabel.Size = new System.Drawing.Size(10, 13);
            this.Authorcountlabel.TabIndex = 24;
            this.Authorcountlabel.Text = ".";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(30, 350);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(231, 96);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            // 
            // FormDoJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 483);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Authorcountlabel);
            this.Controls.Add(this.CB_topauthor);
            this.Controls.Add(this.Authorbutton);
            this.Controls.Add(this.CB_author);
            this.Controls.Add(this.ISSNlabel);
            this.Controls.Add(this.Publisherlabel);
            this.Controls.Add(this.Articlecountlabel);
            this.Controls.Add(this.ArticleButton);
            this.Controls.Add(this.CB_articles);
            this.Controls.Add(this.OKbutton);
            this.Name = "FormDoJournal";
            this.Text = "FormDoJournal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.CheckedListBox CB_articles;
        private System.Windows.Forms.Button ArticleButton;
        private System.Windows.Forms.Label Articlecountlabel;
        private System.Windows.Forms.Label Publisherlabel;
        private System.Windows.Forms.Label ISSNlabel;
        private System.Windows.Forms.CheckedListBox CB_author;
        private System.Windows.Forms.Button Authorbutton;
        private System.Windows.Forms.CheckBox CB_topauthor;
        private System.Windows.Forms.Label Authorcountlabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}