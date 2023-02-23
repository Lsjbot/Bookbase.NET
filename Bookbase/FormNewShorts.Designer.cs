namespace Bookbase
{
    partial class FormNewShorts
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
            this.Anotherbutton = new System.Windows.Forms.Button();
            this.Donebutton = new System.Windows.Forms.Button();
            this.TB_author = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_title = new System.Windows.Forms.TextBox();
            this.Coauthorbutton = new System.Windows.Forms.Button();
            this.LB_coauthor = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Anotherbutton
            // 
            this.Anotherbutton.Location = new System.Drawing.Point(59, 139);
            this.Anotherbutton.Name = "Anotherbutton";
            this.Anotherbutton.Size = new System.Drawing.Size(145, 54);
            this.Anotherbutton.TabIndex = 7;
            this.Anotherbutton.TabStop = false;
            this.Anotherbutton.Text = "Another";
            this.Anotherbutton.UseVisualStyleBackColor = true;
            this.Anotherbutton.Click += new System.EventHandler(this.Anotherbutton_Click);
            // 
            // Donebutton
            // 
            this.Donebutton.Location = new System.Drawing.Point(282, 139);
            this.Donebutton.Name = "Donebutton";
            this.Donebutton.Size = new System.Drawing.Size(119, 54);
            this.Donebutton.TabIndex = 2;
            this.Donebutton.TabStop = false;
            this.Donebutton.Text = "Done";
            this.Donebutton.UseVisualStyleBackColor = true;
            this.Donebutton.Click += new System.EventHandler(this.Donebutton_Click);
            // 
            // TB_author
            // 
            this.TB_author.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TB_author.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TB_author.Location = new System.Drawing.Point(59, 22);
            this.TB_author.Name = "TB_author";
            this.TB_author.Size = new System.Drawing.Size(352, 20);
            this.TB_author.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Author:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Title:";
            // 
            // TB_title
            // 
            this.TB_title.Location = new System.Drawing.Point(59, 52);
            this.TB_title.Name = "TB_title";
            this.TB_title.Size = new System.Drawing.Size(720, 20);
            this.TB_title.TabIndex = 1;
            // 
            // Coauthorbutton
            // 
            this.Coauthorbutton.Location = new System.Drawing.Point(417, 19);
            this.Coauthorbutton.Name = "Coauthorbutton";
            this.Coauthorbutton.Size = new System.Drawing.Size(91, 23);
            this.Coauthorbutton.TabIndex = 6;
            this.Coauthorbutton.TabStop = false;
            this.Coauthorbutton.Text = "Add coauthor";
            this.Coauthorbutton.UseVisualStyleBackColor = true;
            this.Coauthorbutton.Click += new System.EventHandler(this.Coauthorbutton_Click);
            // 
            // LB_coauthor
            // 
            this.LB_coauthor.FormattingEnabled = true;
            this.LB_coauthor.Location = new System.Drawing.Point(519, 93);
            this.LB_coauthor.Name = "LB_coauthor";
            this.LB_coauthor.Size = new System.Drawing.Size(260, 95);
            this.LB_coauthor.TabIndex = 0;
            this.LB_coauthor.TabStop = false;
            // 
            // FormNewShorts
            // 
            this.AcceptButton = this.Anotherbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 205);
            this.Controls.Add(this.LB_coauthor);
            this.Controls.Add(this.Coauthorbutton);
            this.Controls.Add(this.TB_title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_author);
            this.Controls.Add(this.Donebutton);
            this.Controls.Add(this.Anotherbutton);
            this.Name = "FormNewShorts";
            this.Text = "FormNewShorts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Anotherbutton;
        private System.Windows.Forms.Button Donebutton;
        private System.Windows.Forms.TextBox TB_author;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_title;
        private System.Windows.Forms.Button Coauthorbutton;
        private System.Windows.Forms.ListBox LB_coauthor;
    }
}