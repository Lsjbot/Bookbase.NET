namespace Bookbase
{
    partial class FormModify
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
            this.Quitbutton = new System.Windows.Forms.Button();
            this.Authorbutton = new System.Windows.Forms.Button();
            this.Publisherbutton = new System.Windows.Forms.Button();
            this.misparsebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Quitbutton
            // 
            this.Quitbutton.Location = new System.Drawing.Point(414, 367);
            this.Quitbutton.Name = "Quitbutton";
            this.Quitbutton.Size = new System.Drawing.Size(75, 23);
            this.Quitbutton.TabIndex = 0;
            this.Quitbutton.Text = "Quit";
            this.Quitbutton.UseVisualStyleBackColor = true;
            this.Quitbutton.Click += new System.EventHandler(this.Quitbutton_Click);
            // 
            // Authorbutton
            // 
            this.Authorbutton.Location = new System.Drawing.Point(19, 30);
            this.Authorbutton.Name = "Authorbutton";
            this.Authorbutton.Size = new System.Drawing.Size(118, 58);
            this.Authorbutton.TabIndex = 1;
            this.Authorbutton.Text = "Modify author";
            this.Authorbutton.UseVisualStyleBackColor = true;
            this.Authorbutton.Click += new System.EventHandler(this.Authorbutton_Click);
            // 
            // Publisherbutton
            // 
            this.Publisherbutton.Location = new System.Drawing.Point(19, 103);
            this.Publisherbutton.Name = "Publisherbutton";
            this.Publisherbutton.Size = new System.Drawing.Size(118, 64);
            this.Publisherbutton.TabIndex = 2;
            this.Publisherbutton.Text = "Modify publisher";
            this.Publisherbutton.UseVisualStyleBackColor = true;
            this.Publisherbutton.Click += new System.EventHandler(this.Publisherbutton_Click);
            // 
            // misparsebutton
            // 
            this.misparsebutton.Location = new System.Drawing.Point(19, 173);
            this.misparsebutton.Name = "misparsebutton";
            this.misparsebutton.Size = new System.Drawing.Size(118, 53);
            this.misparsebutton.TabIndex = 3;
            this.misparsebutton.Text = "Find misparsed authors";
            this.misparsebutton.UseVisualStyleBackColor = true;
            this.misparsebutton.Click += new System.EventHandler(this.misparsebutton_Click);
            // 
            // FormModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 402);
            this.Controls.Add(this.misparsebutton);
            this.Controls.Add(this.Publisherbutton);
            this.Controls.Add(this.Authorbutton);
            this.Controls.Add(this.Quitbutton);
            this.Name = "FormModify";
            this.Text = "FormModify";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Quitbutton;
        private System.Windows.Forms.Button Authorbutton;
        private System.Windows.Forms.Button Publisherbutton;
        private System.Windows.Forms.Button misparsebutton;
    }
}