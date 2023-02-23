namespace Bookbase
{
    partial class FormNewBook
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
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.TB_author = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_title = new System.Windows.Forms.TextBox();
            this.Publisherbutton = new System.Windows.Forms.Button();
            this.TB_publisher = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TB_firstyear = new System.Windows.Forms.TextBox();
            this.TB_thisyear = new System.Windows.Forms.TextBox();
            this.Publisherlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_where = new System.Windows.Forms.TextBox();
            this.TB_when = new System.Windows.Forms.TextBox();
            this.TB_price = new System.Windows.Forms.TextBox();
            this.LB_coauthor = new System.Windows.Forms.ListBox();
            this.Coauthorbutton = new System.Windows.Forms.Button();
            this.LB_subject = new System.Windows.Forms.ListBox();
            this.LB_shorts = new System.Windows.Forms.ListBox();
            this.Shortsbutton = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label9 = new System.Windows.Forms.Label();
            this.Likelabel = new System.Windows.Forms.Label();
            this.LB_type = new System.Windows.Forms.ListBox();
            this.CB_havecopy = new System.Windows.Forms.CheckBox();
            this.CB_another = new System.Windows.Forms.CheckBox();
            this.TB_isbn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Cancelbutton.Location = new System.Drawing.Point(245, 459);
            this.Cancelbutton.Margin = new System.Windows.Forms.Padding(4);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(165, 94);
            this.Cancelbutton.TabIndex = 0;
            this.Cancelbutton.TabStop = false;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.Location = new System.Drawing.Point(26, 459);
            this.OKbutton.Margin = new System.Windows.Forms.Padding(4);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(197, 94);
            this.OKbutton.TabIndex = 1;
            this.OKbutton.TabStop = false;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // TB_author
            // 
            this.TB_author.Location = new System.Drawing.Point(75, 16);
            this.TB_author.Margin = new System.Windows.Forms.Padding(4);
            this.TB_author.Name = "TB_author";
            this.TB_author.Size = new System.Drawing.Size(666, 30);
            this.TB_author.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Author:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title:";
            // 
            // TB_title
            // 
            this.TB_title.Location = new System.Drawing.Point(75, 50);
            this.TB_title.Margin = new System.Windows.Forms.Padding(4);
            this.TB_title.Name = "TB_title";
            this.TB_title.Size = new System.Drawing.Size(946, 30);
            this.TB_title.TabIndex = 5;
            // 
            // Publisherbutton
            // 
            this.Publisherbutton.Location = new System.Drawing.Point(86, 110);
            this.Publisherbutton.Margin = new System.Windows.Forms.Padding(4);
            this.Publisherbutton.Name = "Publisherbutton";
            this.Publisherbutton.Size = new System.Drawing.Size(153, 28);
            this.Publisherbutton.TabIndex = 6;
            this.Publisherbutton.TabStop = false;
            this.Publisherbutton.Text = "Find publisher";
            this.Publisherbutton.UseVisualStyleBackColor = true;
            this.Publisherbutton.Click += new System.EventHandler(this.Publisherbutton_Click);
            // 
            // TB_publisher
            // 
            this.TB_publisher.Location = new System.Drawing.Point(86, 146);
            this.TB_publisher.Margin = new System.Windows.Forms.Padding(4);
            this.TB_publisher.Name = "TB_publisher";
            this.TB_publisher.Size = new System.Drawing.Size(152, 30);
            this.TB_publisher.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(787, 461);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(236, 118);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // TB_firstyear
            // 
            this.TB_firstyear.Location = new System.Drawing.Point(98, 204);
            this.TB_firstyear.Margin = new System.Windows.Forms.Padding(4);
            this.TB_firstyear.Name = "TB_firstyear";
            this.TB_firstyear.Size = new System.Drawing.Size(79, 30);
            this.TB_firstyear.TabIndex = 9;
            this.TB_firstyear.TextChanged += new System.EventHandler(this.TB_firstyear_TextChanged);
            // 
            // TB_thisyear
            // 
            this.TB_thisyear.Location = new System.Drawing.Point(98, 238);
            this.TB_thisyear.Margin = new System.Windows.Forms.Padding(4);
            this.TB_thisyear.Name = "TB_thisyear";
            this.TB_thisyear.Size = new System.Drawing.Size(79, 30);
            this.TB_thisyear.TabIndex = 10;
            // 
            // Publisherlabel
            // 
            this.Publisherlabel.AutoSize = true;
            this.Publisherlabel.Location = new System.Drawing.Point(12, 149);
            this.Publisherlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Publisherlabel.Name = "Publisherlabel";
            this.Publisherlabel.Size = new System.Drawing.Size(99, 25);
            this.Publisherlabel.TabIndex = 11;
            this.Publisherlabel.Text = "Publisher:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 238);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Year (this)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Year (first)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bought";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Where:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "When:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Price:";
            // 
            // TB_where
            // 
            this.TB_where.Location = new System.Drawing.Point(98, 320);
            this.TB_where.Name = "TB_where";
            this.TB_where.Size = new System.Drawing.Size(140, 30);
            this.TB_where.TabIndex = 18;
            // 
            // TB_when
            // 
            this.TB_when.Location = new System.Drawing.Point(98, 351);
            this.TB_when.Name = "TB_when";
            this.TB_when.Size = new System.Drawing.Size(79, 30);
            this.TB_when.TabIndex = 19;
            // 
            // TB_price
            // 
            this.TB_price.Location = new System.Drawing.Point(98, 383);
            this.TB_price.Name = "TB_price";
            this.TB_price.Size = new System.Drawing.Size(79, 30);
            this.TB_price.TabIndex = 20;
            // 
            // LB_coauthor
            // 
            this.LB_coauthor.FormattingEnabled = true;
            this.LB_coauthor.ItemHeight = 25;
            this.LB_coauthor.Location = new System.Drawing.Point(470, 80);
            this.LB_coauthor.Name = "LB_coauthor";
            this.LB_coauthor.Size = new System.Drawing.Size(188, 129);
            this.LB_coauthor.TabIndex = 21;
            // 
            // Coauthorbutton
            // 
            this.Coauthorbutton.Location = new System.Drawing.Point(470, 218);
            this.Coauthorbutton.Name = "Coauthorbutton";
            this.Coauthorbutton.Size = new System.Drawing.Size(188, 30);
            this.Coauthorbutton.TabIndex = 22;
            this.Coauthorbutton.Text = "Add coauthor";
            this.Coauthorbutton.UseVisualStyleBackColor = true;
            this.Coauthorbutton.Click += new System.EventHandler(this.Coauthorbutton_Click);
            // 
            // LB_subject
            // 
            this.LB_subject.FormattingEnabled = true;
            this.LB_subject.ItemHeight = 25;
            this.LB_subject.Location = new System.Drawing.Point(263, 80);
            this.LB_subject.Name = "LB_subject";
            this.LB_subject.Size = new System.Drawing.Size(176, 329);
            this.LB_subject.TabIndex = 23;
            // 
            // LB_shorts
            // 
            this.LB_shorts.FormattingEnabled = true;
            this.LB_shorts.ItemHeight = 25;
            this.LB_shorts.Location = new System.Drawing.Point(469, 273);
            this.LB_shorts.Name = "LB_shorts";
            this.LB_shorts.Size = new System.Drawing.Size(552, 129);
            this.LB_shorts.TabIndex = 24;
            // 
            // Shortsbutton
            // 
            this.Shortsbutton.Location = new System.Drawing.Point(469, 427);
            this.Shortsbutton.Name = "Shortsbutton";
            this.Shortsbutton.Size = new System.Drawing.Size(127, 41);
            this.Shortsbutton.TabIndex = 25;
            this.Shortsbutton.Text = "Add shorts";
            this.Shortsbutton.UseVisualStyleBackColor = true;
            this.Shortsbutton.Click += new System.EventHandler(this.Shortsbutton_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(808, 16);
            this.hScrollBar1.Maximum = 10;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(174, 23);
            this.hScrollBar1.TabIndex = 26;
            this.hScrollBar1.Value = 7;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(748, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Liked it:";
            // 
            // Likelabel
            // 
            this.Likelabel.AutoSize = true;
            this.Likelabel.Location = new System.Drawing.Point(985, 20);
            this.Likelabel.Name = "Likelabel";
            this.Likelabel.Size = new System.Drawing.Size(23, 25);
            this.Likelabel.TabIndex = 28;
            this.Likelabel.Text = "7";
            // 
            // LB_type
            // 
            this.LB_type.FormattingEnabled = true;
            this.LB_type.ItemHeight = 25;
            this.LB_type.Location = new System.Drawing.Point(685, 80);
            this.LB_type.Name = "LB_type";
            this.LB_type.Size = new System.Drawing.Size(120, 79);
            this.LB_type.TabIndex = 29;
            // 
            // CB_havecopy
            // 
            this.CB_havecopy.AutoSize = true;
            this.CB_havecopy.Checked = true;
            this.CB_havecopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_havecopy.Location = new System.Drawing.Point(98, 412);
            this.CB_havecopy.Name = "CB_havecopy";
            this.CB_havecopy.Size = new System.Drawing.Size(131, 29);
            this.CB_havecopy.TabIndex = 30;
            this.CB_havecopy.Text = "Have copy";
            this.CB_havecopy.UseVisualStyleBackColor = true;
            // 
            // CB_another
            // 
            this.CB_another.AutoSize = true;
            this.CB_another.Location = new System.Drawing.Point(26, 560);
            this.CB_another.Name = "CB_another";
            this.CB_another.Size = new System.Drawing.Size(332, 29);
            this.CB_another.TabIndex = 31;
            this.CB_another.Text = "Add another book by same author";
            this.CB_another.UseVisualStyleBackColor = true;
            // 
            // TB_isbn
            // 
            this.TB_isbn.Location = new System.Drawing.Point(544, 524);
            this.TB_isbn.Name = "TB_isbn";
            this.TB_isbn.Size = new System.Drawing.Size(216, 30);
            this.TB_isbn.TabIndex = 32;
            this.TB_isbn.TextChanged += new System.EventHandler(this.TB_isbn_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(474, 527);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "ISBN:";
            // 
            // FormNewBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 649);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TB_isbn);
            this.Controls.Add(this.CB_another);
            this.Controls.Add(this.CB_havecopy);
            this.Controls.Add(this.LB_type);
            this.Controls.Add(this.Likelabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.Shortsbutton);
            this.Controls.Add(this.LB_shorts);
            this.Controls.Add(this.LB_subject);
            this.Controls.Add(this.Coauthorbutton);
            this.Controls.Add(this.LB_coauthor);
            this.Controls.Add(this.TB_price);
            this.Controls.Add(this.TB_when);
            this.Controls.Add(this.TB_where);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Publisherlabel);
            this.Controls.Add(this.TB_thisyear);
            this.Controls.Add(this.TB_firstyear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.TB_publisher);
            this.Controls.Add(this.Publisherbutton);
            this.Controls.Add(this.TB_title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_author);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormNewBook";
            this.Text = "FormNewBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox TB_author;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_title;
        private System.Windows.Forms.Button Publisherbutton;
        private System.Windows.Forms.TextBox TB_publisher;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox TB_firstyear;
        private System.Windows.Forms.TextBox TB_thisyear;
        private System.Windows.Forms.Label Publisherlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_where;
        private System.Windows.Forms.TextBox TB_when;
        private System.Windows.Forms.TextBox TB_price;
        private System.Windows.Forms.ListBox LB_coauthor;
        private System.Windows.Forms.Button Coauthorbutton;
        private System.Windows.Forms.ListBox LB_subject;
        private System.Windows.Forms.ListBox LB_shorts;
        private System.Windows.Forms.Button Shortsbutton;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Likelabel;
        private System.Windows.Forms.ListBox LB_type;
        private System.Windows.Forms.CheckBox CB_havecopy;
        private System.Windows.Forms.CheckBox CB_another;
        private System.Windows.Forms.TextBox TB_isbn;
        private System.Windows.Forms.Label label10;
    }
}