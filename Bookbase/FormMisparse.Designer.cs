
namespace Bookbase
{
    partial class FormMisparse
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.mergebutton = new System.Windows.Forms.Button();
            this.quitbutton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 28);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(479, 439);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // mergebutton
            // 
            this.mergebutton.Location = new System.Drawing.Point(591, 99);
            this.mergebutton.Name = "mergebutton";
            this.mergebutton.Size = new System.Drawing.Size(105, 39);
            this.mergebutton.TabIndex = 1;
            this.mergebutton.Text = "Merge checked items";
            this.mergebutton.UseVisualStyleBackColor = true;
            this.mergebutton.Click += new System.EventHandler(this.mergebutton_Click);
            // 
            // quitbutton
            // 
            this.quitbutton.Location = new System.Drawing.Point(595, 560);
            this.quitbutton.Name = "quitbutton";
            this.quitbutton.Size = new System.Drawing.Size(101, 35);
            this.quitbutton.TabIndex = 2;
            this.quitbutton.Text = "Quit";
            this.quitbutton.UseVisualStyleBackColor = true;
            this.quitbutton.Click += new System.EventHandler(this.quitbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(521, 202);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(175, 265);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // FormMisparse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 607);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.quitbutton);
            this.Controls.Add(this.mergebutton);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "FormMisparse";
            this.Text = "FormMisparse";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button mergebutton;
        private System.Windows.Forms.Button quitbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}