namespace Bookbase
{
    partial class FormArticleList
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
            this.CBart = new System.Windows.Forms.CheckedListBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBart
            // 
            this.CBart.FormattingEnabled = true;
            this.CBart.HorizontalScrollbar = true;
            this.CBart.Location = new System.Drawing.Point(33, 22);
            this.CBart.Name = "CBart";
            this.CBart.Size = new System.Drawing.Size(1000, 304);
            this.CBart.TabIndex = 0;
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(1015, 390);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // FormArticleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 430);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.CBart);
            this.Name = "FormArticleList";
            this.Text = "FormArticleList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CBart;
        private System.Windows.Forms.Button QuitButton;
    }
}