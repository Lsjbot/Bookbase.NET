namespace Bookbase
{
    partial class FormSubject
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
            this.QuitButton = new System.Windows.Forms.Button();
            this.CBmysubj = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBcrossref = new System.Windows.Forms.CheckedListBox();
            this.CBpubmed = new System.Windows.Forms.CheckedListBox();
            this.CBsubj1 = new System.Windows.Forms.CheckBox();
            this.CBsubj2 = new System.Windows.Forms.CheckBox();
            this.CBsubj3 = new System.Windows.Forms.CheckBox();
            this.CBevolang = new System.Windows.Forms.CheckedListBox();
            this.NumbersButton = new System.Windows.Forms.Button();
            this.AnyButton = new System.Windows.Forms.Button();
            this.Bookbutton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(529, 486);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 0;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // CBmysubj
            // 
            this.CBmysubj.FormattingEnabled = true;
            this.CBmysubj.HorizontalScrollbar = true;
            this.CBmysubj.Location = new System.Drawing.Point(12, 34);
            this.CBmysubj.Name = "CBmysubj";
            this.CBmysubj.Size = new System.Drawing.Size(201, 229);
            this.CBmysubj.Sorted = true;
            this.CBmysubj.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "My subjects";
            // 
            // CBcrossref
            // 
            this.CBcrossref.FormattingEnabled = true;
            this.CBcrossref.HorizontalScrollbar = true;
            this.CBcrossref.Location = new System.Drawing.Point(219, 34);
            this.CBcrossref.Name = "CBcrossref";
            this.CBcrossref.Size = new System.Drawing.Size(198, 229);
            this.CBcrossref.Sorted = true;
            this.CBcrossref.TabIndex = 3;
            // 
            // CBpubmed
            // 
            this.CBpubmed.FormattingEnabled = true;
            this.CBpubmed.HorizontalScrollbar = true;
            this.CBpubmed.Location = new System.Drawing.Point(423, 34);
            this.CBpubmed.Name = "CBpubmed";
            this.CBpubmed.Size = new System.Drawing.Size(202, 229);
            this.CBpubmed.Sorted = true;
            this.CBpubmed.TabIndex = 4;
            // 
            // CBsubj1
            // 
            this.CBsubj1.AutoSize = true;
            this.CBsubj1.Checked = true;
            this.CBsubj1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBsubj1.Location = new System.Drawing.Point(12, 269);
            this.CBsubj1.Name = "CBsubj1";
            this.CBsubj1.Size = new System.Drawing.Size(71, 17);
            this.CBsubj1.TabIndex = 5;
            this.CBsubj1.Text = "Subject 1";
            this.CBsubj1.UseVisualStyleBackColor = true;
            // 
            // CBsubj2
            // 
            this.CBsubj2.AutoSize = true;
            this.CBsubj2.Location = new System.Drawing.Point(12, 292);
            this.CBsubj2.Name = "CBsubj2";
            this.CBsubj2.Size = new System.Drawing.Size(71, 17);
            this.CBsubj2.TabIndex = 6;
            this.CBsubj2.Text = "Subject 2";
            this.CBsubj2.UseVisualStyleBackColor = true;
            // 
            // CBsubj3
            // 
            this.CBsubj3.AutoSize = true;
            this.CBsubj3.Location = new System.Drawing.Point(12, 315);
            this.CBsubj3.Name = "CBsubj3";
            this.CBsubj3.Size = new System.Drawing.Size(71, 17);
            this.CBsubj3.TabIndex = 7;
            this.CBsubj3.Text = "Subject 3";
            this.CBsubj3.UseVisualStyleBackColor = true;
            // 
            // CBevolang
            // 
            this.CBevolang.FormattingEnabled = true;
            this.CBevolang.HorizontalScrollbar = true;
            this.CBevolang.Location = new System.Drawing.Point(631, 34);
            this.CBevolang.Name = "CBevolang";
            this.CBevolang.Size = new System.Drawing.Size(200, 229);
            this.CBevolang.Sorted = true;
            this.CBevolang.TabIndex = 8;
            // 
            // NumbersButton
            // 
            this.NumbersButton.Location = new System.Drawing.Point(21, 361);
            this.NumbersButton.Name = "NumbersButton";
            this.NumbersButton.Size = new System.Drawing.Size(75, 23);
            this.NumbersButton.TabIndex = 9;
            this.NumbersButton.Text = "Get numbers";
            this.NumbersButton.UseVisualStyleBackColor = true;
            this.NumbersButton.Click += new System.EventHandler(this.NumbersButton_Click);
            // 
            // AnyButton
            // 
            this.AnyButton.Location = new System.Drawing.Point(169, 290);
            this.AnyButton.Name = "AnyButton";
            this.AnyButton.Size = new System.Drawing.Size(140, 64);
            this.AnyButton.TabIndex = 10;
            this.AnyButton.Text = "Articles with any marked subject";
            this.AnyButton.UseVisualStyleBackColor = true;
            this.AnyButton.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // Bookbutton
            // 
            this.Bookbutton.Location = new System.Drawing.Point(169, 372);
            this.Bookbutton.Name = "Bookbutton";
            this.Bookbutton.Size = new System.Drawing.Size(140, 54);
            this.Bookbutton.TabIndex = 11;
            this.Bookbutton.Text = "Books with marked subject";
            this.Bookbutton.UseVisualStyleBackColor = true;
            this.Bookbutton.Click += new System.EventHandler(this.Bookbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(433, 310);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 96);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // FormSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 521);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Bookbutton);
            this.Controls.Add(this.AnyButton);
            this.Controls.Add(this.NumbersButton);
            this.Controls.Add(this.CBevolang);
            this.Controls.Add(this.CBsubj3);
            this.Controls.Add(this.CBsubj2);
            this.Controls.Add(this.CBsubj1);
            this.Controls.Add(this.CBpubmed);
            this.Controls.Add(this.CBcrossref);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBmysubj);
            this.Controls.Add(this.QuitButton);
            this.Name = "FormSubject";
            this.Text = "FormSubject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.CheckedListBox CBmysubj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox CBcrossref;
        private System.Windows.Forms.CheckedListBox CBpubmed;
        private System.Windows.Forms.CheckBox CBsubj1;
        private System.Windows.Forms.CheckBox CBsubj2;
        private System.Windows.Forms.CheckBox CBsubj3;
        private System.Windows.Forms.CheckedListBox CBevolang;
        private System.Windows.Forms.Button NumbersButton;
        private System.Windows.Forms.Button AnyButton;
        private System.Windows.Forms.Button Bookbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}