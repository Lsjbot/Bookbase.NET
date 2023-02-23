namespace Bookbase
{
    partial class FormModifyAuthor
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
            this.Savebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_familyname = new System.Windows.Forms.TextBox();
            this.TB_givenname = new System.Windows.Forms.TextBox();
            this.Mergebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Quitbutton
            // 
            this.Quitbutton.Location = new System.Drawing.Point(484, 357);
            this.Quitbutton.Name = "Quitbutton";
            this.Quitbutton.Size = new System.Drawing.Size(111, 23);
            this.Quitbutton.TabIndex = 0;
            this.Quitbutton.Text = "Cancel";
            this.Quitbutton.UseVisualStyleBackColor = true;
            this.Quitbutton.Click += new System.EventHandler(this.Quitbutton_Click);
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(484, 292);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(111, 45);
            this.Savebutton.TabIndex = 1;
            this.Savebutton.Text = "Save changes";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Family name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Given name";
            // 
            // TB_familyname
            // 
            this.TB_familyname.Location = new System.Drawing.Point(118, 38);
            this.TB_familyname.Name = "TB_familyname";
            this.TB_familyname.Size = new System.Drawing.Size(255, 20);
            this.TB_familyname.TabIndex = 4;
            // 
            // TB_givenname
            // 
            this.TB_givenname.Location = new System.Drawing.Point(118, 79);
            this.TB_givenname.Name = "TB_givenname";
            this.TB_givenname.Size = new System.Drawing.Size(255, 20);
            this.TB_givenname.TabIndex = 5;
            // 
            // Mergebutton
            // 
            this.Mergebutton.Location = new System.Drawing.Point(484, 41);
            this.Mergebutton.Name = "Mergebutton";
            this.Mergebutton.Size = new System.Drawing.Size(111, 81);
            this.Mergebutton.TabIndex = 6;
            this.Mergebutton.Text = "Merge another author into this one";
            this.Mergebutton.UseVisualStyleBackColor = true;
            this.Mergebutton.Click += new System.EventHandler(this.Mergebutton_Click);
            // 
            // FormModifyAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 392);
            this.Controls.Add(this.Mergebutton);
            this.Controls.Add(this.TB_givenname);
            this.Controls.Add(this.TB_familyname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.Quitbutton);
            this.Name = "FormModifyAuthor";
            this.Text = "FormModifyAuthor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Quitbutton;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_familyname;
        private System.Windows.Forms.TextBox TB_givenname;
        private System.Windows.Forms.Button Mergebutton;
    }
}