namespace Bookbase
{
    partial class FormLook
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.FindAuthorButton = new System.Windows.Forms.Button();
            this.SubjectButton = new System.Windows.Forms.Button();
            this.Titlebutton = new System.Windows.Forms.Button();
            this.Publisherbutton = new System.Windows.Forms.Button();
            this.Statisticsbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(37, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 414);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(635, 488);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(133, 49);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // FindAuthorButton
            // 
            this.FindAuthorButton.Location = new System.Drawing.Point(657, 20);
            this.FindAuthorButton.Name = "FindAuthorButton";
            this.FindAuthorButton.Size = new System.Drawing.Size(138, 42);
            this.FindAuthorButton.TabIndex = 2;
            this.FindAuthorButton.Text = "Find author";
            this.FindAuthorButton.UseVisualStyleBackColor = true;
            this.FindAuthorButton.Click += new System.EventHandler(this.FindAuthorButton_Click);
            // 
            // SubjectButton
            // 
            this.SubjectButton.Location = new System.Drawing.Point(657, 84);
            this.SubjectButton.Name = "SubjectButton";
            this.SubjectButton.Size = new System.Drawing.Size(138, 44);
            this.SubjectButton.TabIndex = 3;
            this.SubjectButton.Text = "Find subject";
            this.SubjectButton.UseVisualStyleBackColor = true;
            this.SubjectButton.Click += new System.EventHandler(this.SubjectButton_Click);
            // 
            // Titlebutton
            // 
            this.Titlebutton.Location = new System.Drawing.Point(657, 152);
            this.Titlebutton.Name = "Titlebutton";
            this.Titlebutton.Size = new System.Drawing.Size(138, 47);
            this.Titlebutton.TabIndex = 4;
            this.Titlebutton.Text = "Find title";
            this.Titlebutton.UseVisualStyleBackColor = true;
            this.Titlebutton.Click += new System.EventHandler(this.Titlebutton_Click);
            // 
            // Publisherbutton
            // 
            this.Publisherbutton.Location = new System.Drawing.Point(657, 221);
            this.Publisherbutton.Name = "Publisherbutton";
            this.Publisherbutton.Size = new System.Drawing.Size(138, 50);
            this.Publisherbutton.TabIndex = 5;
            this.Publisherbutton.Text = "Find publisher";
            this.Publisherbutton.UseVisualStyleBackColor = true;
            this.Publisherbutton.Click += new System.EventHandler(this.Publisherbutton_Click);
            // 
            // Statisticsbutton
            // 
            this.Statisticsbutton.Location = new System.Drawing.Point(657, 295);
            this.Statisticsbutton.Name = "Statisticsbutton";
            this.Statisticsbutton.Size = new System.Drawing.Size(125, 49);
            this.Statisticsbutton.TabIndex = 6;
            this.Statisticsbutton.Text = "Show statistics";
            this.Statisticsbutton.UseVisualStyleBackColor = true;
            this.Statisticsbutton.Click += new System.EventHandler(this.Statisticsbutton_Click);
            // 
            // FormLook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 549);
            this.Controls.Add(this.Statisticsbutton);
            this.Controls.Add(this.Publisherbutton);
            this.Controls.Add(this.Titlebutton);
            this.Controls.Add(this.SubjectButton);
            this.Controls.Add(this.FindAuthorButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FormLook";
            this.Text = "FormLook";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button FindAuthorButton;
        private System.Windows.Forms.Button SubjectButton;
        private System.Windows.Forms.Button Titlebutton;
        private System.Windows.Forms.Button Publisherbutton;
        private System.Windows.Forms.Button Statisticsbutton;
    }
}