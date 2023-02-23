namespace Bookbase
{
    partial class FormDoArticle
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
            this.CB_author = new System.Windows.Forms.CheckedListBox();
            this.TB_title = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Yearlabel = new System.Windows.Forms.Label();
            this.Journallabel = new System.Windows.Forms.Label();
            this.Volumelabel = new System.Windows.Forms.Label();
            this.Pageslabel = new System.Windows.Forms.Label();
            this.AbstractBox = new System.Windows.Forms.RichTextBox();
            this.Journalbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CB_author
            // 
            this.CB_author.FormattingEnabled = true;
            this.CB_author.Location = new System.Drawing.Point(12, 52);
            this.CB_author.Name = "CB_author";
            this.CB_author.Size = new System.Drawing.Size(779, 94);
            this.CB_author.TabIndex = 0;
            this.CB_author.SelectedIndexChanged += new System.EventHandler(this.CB_author_SelectedIndexChanged);
            // 
            // TB_title
            // 
            this.TB_title.Location = new System.Drawing.Point(14, 23);
            this.TB_title.Name = "TB_title";
            this.TB_title.Size = new System.Drawing.Size(777, 20);
            this.TB_title.TabIndex = 1;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(952, 483);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 2;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // Yearlabel
            // 
            this.Yearlabel.AutoSize = true;
            this.Yearlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yearlabel.Location = new System.Drawing.Point(873, 25);
            this.Yearlabel.Name = "Yearlabel";
            this.Yearlabel.Size = new System.Drawing.Size(22, 31);
            this.Yearlabel.TabIndex = 3;
            this.Yearlabel.Text = ".";
            // 
            // Journallabel
            // 
            this.Journallabel.AutoSize = true;
            this.Journallabel.Location = new System.Drawing.Point(842, 100);
            this.Journallabel.Name = "Journallabel";
            this.Journallabel.Size = new System.Drawing.Size(35, 13);
            this.Journallabel.TabIndex = 4;
            this.Journallabel.Text = "label1";
            this.Journallabel.Click += new System.EventHandler(this.Journallabel_Click);
            // 
            // Volumelabel
            // 
            this.Volumelabel.AutoSize = true;
            this.Volumelabel.Location = new System.Drawing.Point(842, 133);
            this.Volumelabel.Name = "Volumelabel";
            this.Volumelabel.Size = new System.Drawing.Size(35, 13);
            this.Volumelabel.TabIndex = 5;
            this.Volumelabel.Text = "label1";
            // 
            // Pageslabel
            // 
            this.Pageslabel.AutoSize = true;
            this.Pageslabel.Location = new System.Drawing.Point(844, 167);
            this.Pageslabel.Name = "Pageslabel";
            this.Pageslabel.Size = new System.Drawing.Size(35, 13);
            this.Pageslabel.TabIndex = 6;
            this.Pageslabel.Text = "label1";
            // 
            // AbstractBox
            // 
            this.AbstractBox.Location = new System.Drawing.Point(12, 167);
            this.AbstractBox.Name = "AbstractBox";
            this.AbstractBox.Size = new System.Drawing.Size(779, 222);
            this.AbstractBox.TabIndex = 7;
            this.AbstractBox.Text = "";
            // 
            // Journalbutton
            // 
            this.Journalbutton.Enabled = false;
            this.Journalbutton.Location = new System.Drawing.Point(1000, 12);
            this.Journalbutton.Name = "Journalbutton";
            this.Journalbutton.Size = new System.Drawing.Size(50, 23);
            this.Journalbutton.TabIndex = 8;
            this.Journalbutton.Text = "Journalbutton";
            this.Journalbutton.UseVisualStyleBackColor = true;
            this.Journalbutton.Visible = false;
            this.Journalbutton.Click += new System.EventHandler(this.Journalbutton_Click);
            // 
            // FormDoArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 511);
            this.Controls.Add(this.Journalbutton);
            this.Controls.Add(this.AbstractBox);
            this.Controls.Add(this.Pageslabel);
            this.Controls.Add(this.Volumelabel);
            this.Controls.Add(this.Journallabel);
            this.Controls.Add(this.Yearlabel);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.TB_title);
            this.Controls.Add(this.CB_author);
            this.Name = "FormDoArticle";
            this.Text = "FormDoArticle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CB_author;
        private System.Windows.Forms.TextBox TB_title;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label Yearlabel;
        private System.Windows.Forms.Label Journallabel;
        private System.Windows.Forms.Label Volumelabel;
        private System.Windows.Forms.Label Pageslabel;
        private System.Windows.Forms.RichTextBox AbstractBox;
        private System.Windows.Forms.Button Journalbutton;
    }
}