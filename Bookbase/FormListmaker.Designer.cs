namespace Bookbase
{
    partial class FormListmaker
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
            this.Generatebutton = new System.Windows.Forms.Button();
            this.Quitbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RB_byauthor = new System.Windows.Forms.RadioButton();
            this.CB_count = new System.Windows.Forms.CheckBox();
            this.CB_location = new System.Windows.Forms.CheckBox();
            this.RB_subjectlist = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Generatebutton
            // 
            this.Generatebutton.Location = new System.Drawing.Point(366, 208);
            this.Generatebutton.Name = "Generatebutton";
            this.Generatebutton.Size = new System.Drawing.Size(91, 67);
            this.Generatebutton.TabIndex = 0;
            this.Generatebutton.Text = "Generate";
            this.Generatebutton.UseVisualStyleBackColor = true;
            this.Generatebutton.Click += new System.EventHandler(this.Generatebutton_Click);
            // 
            // Quitbutton
            // 
            this.Quitbutton.Location = new System.Drawing.Point(366, 292);
            this.Quitbutton.Name = "Quitbutton";
            this.Quitbutton.Size = new System.Drawing.Size(91, 54);
            this.Quitbutton.TabIndex = 1;
            this.Quitbutton.Text = "Quit";
            this.Quitbutton.UseVisualStyleBackColor = true;
            this.Quitbutton.Click += new System.EventHandler(this.Quitbutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RB_subjectlist);
            this.groupBox1.Controls.Add(this.RB_byauthor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // RB_byauthor
            // 
            this.RB_byauthor.AutoSize = true;
            this.RB_byauthor.Checked = true;
            this.RB_byauthor.Location = new System.Drawing.Point(16, 24);
            this.RB_byauthor.Name = "RB_byauthor";
            this.RB_byauthor.Size = new System.Drawing.Size(130, 17);
            this.RB_byauthor.TabIndex = 0;
            this.RB_byauthor.TabStop = true;
            this.RB_byauthor.Text = "Works by author/artist";
            this.RB_byauthor.UseVisualStyleBackColor = true;
            // 
            // CB_count
            // 
            this.CB_count.AutoSize = true;
            this.CB_count.Checked = true;
            this.CB_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_count.Location = new System.Drawing.Point(12, 132);
            this.CB_count.Name = "CB_count";
            this.CB_count.Size = new System.Drawing.Size(191, 17);
            this.CB_count.TabIndex = 3;
            this.CB_count.Text = "Include count of albums and songs";
            this.CB_count.UseVisualStyleBackColor = true;
            // 
            // CB_location
            // 
            this.CB_location.AutoSize = true;
            this.CB_location.Location = new System.Drawing.Point(12, 155);
            this.CB_location.Name = "CB_location";
            this.CB_location.Size = new System.Drawing.Size(89, 17);
            this.CB_location.TabIndex = 4;
            this.CB_location.Text = "Location only";
            this.CB_location.UseVisualStyleBackColor = true;
            // 
            // RB_subjectlist
            // 
            this.RB_subjectlist.AutoSize = true;
            this.RB_subjectlist.Location = new System.Drawing.Point(16, 47);
            this.RB_subjectlist.Name = "RB_subjectlist";
            this.RB_subjectlist.Size = new System.Drawing.Size(96, 17);
            this.RB_subjectlist.TabIndex = 1;
            this.RB_subjectlist.TabStop = true;
            this.RB_subjectlist.Text = "Article subjects";
            this.RB_subjectlist.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 196);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(266, 296);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // FormListmaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 587);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.CB_location);
            this.Controls.Add(this.CB_count);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Quitbutton);
            this.Controls.Add(this.Generatebutton);
            this.Name = "FormListmaker";
            this.Text = "FormListmaker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generatebutton;
        private System.Windows.Forms.Button Quitbutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RB_byauthor;
        private System.Windows.Forms.CheckBox CB_count;
        private System.Windows.Forms.CheckBox CB_location;
        private System.Windows.Forms.RadioButton RB_subjectlist;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}