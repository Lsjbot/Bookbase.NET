namespace Bookbase
{
    partial class FormDelete
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
            this.Bookbutton = new System.Windows.Forms.Button();
            this.Closebutton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Bookbutton
            // 
            this.Bookbutton.Location = new System.Drawing.Point(63, 45);
            this.Bookbutton.Name = "Bookbutton";
            this.Bookbutton.Size = new System.Drawing.Size(176, 49);
            this.Bookbutton.TabIndex = 0;
            this.Bookbutton.Text = "Delete book/album";
            this.Bookbutton.UseVisualStyleBackColor = true;
            this.Bookbutton.Click += new System.EventHandler(this.Bookbutton_Click);
            // 
            // Closebutton
            // 
            this.Closebutton.Location = new System.Drawing.Point(271, 306);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(154, 37);
            this.Closebutton.TabIndex = 1;
            this.Closebutton.Text = "Close";
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(63, 124);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(266, 121);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // FormDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 355);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Closebutton);
            this.Controls.Add(this.Bookbutton);
            this.Name = "FormDelete";
            this.Text = "FormDelete";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Bookbutton;
        private System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}