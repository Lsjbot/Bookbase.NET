namespace Bookbase
{
    partial class FormModifyPublisher
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
            this.Savebutton = new System.Windows.Forms.Button();
            this.Quitbutton = new System.Windows.Forms.Button();
            this.TB_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_URL = new System.Windows.Forms.TextBox();
            this.TB_location = new System.Windows.Forms.TextBox();
            this.Mergebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(587, 395);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(109, 54);
            this.Savebutton.TabIndex = 0;
            this.Savebutton.Text = "Save changes";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // Quitbutton
            // 
            this.Quitbutton.Location = new System.Drawing.Point(587, 469);
            this.Quitbutton.Name = "Quitbutton";
            this.Quitbutton.Size = new System.Drawing.Size(109, 39);
            this.Quitbutton.TabIndex = 1;
            this.Quitbutton.Text = "Cancel";
            this.Quitbutton.UseVisualStyleBackColor = true;
            this.Quitbutton.Click += new System.EventHandler(this.Quitbutton_Click);
            // 
            // TB_name
            // 
            this.TB_name.Location = new System.Drawing.Point(85, 40);
            this.TB_name.Name = "TB_name";
            this.TB_name.Size = new System.Drawing.Size(242, 20);
            this.TB_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Location";
            // 
            // TB_URL
            // 
            this.TB_URL.Location = new System.Drawing.Point(85, 77);
            this.TB_URL.Name = "TB_URL";
            this.TB_URL.Size = new System.Drawing.Size(242, 20);
            this.TB_URL.TabIndex = 6;
            // 
            // TB_location
            // 
            this.TB_location.Location = new System.Drawing.Point(85, 113);
            this.TB_location.Name = "TB_location";
            this.TB_location.Size = new System.Drawing.Size(242, 20);
            this.TB_location.TabIndex = 7;
            // 
            // Mergebutton
            // 
            this.Mergebutton.Location = new System.Drawing.Point(561, 138);
            this.Mergebutton.Name = "Mergebutton";
            this.Mergebutton.Size = new System.Drawing.Size(135, 96);
            this.Mergebutton.TabIndex = 8;
            this.Mergebutton.Text = "Merge other publisher into this one";
            this.Mergebutton.UseVisualStyleBackColor = true;
            this.Mergebutton.Click += new System.EventHandler(this.Mergebutton_Click);
            // 
            // FormModifyPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 539);
            this.Controls.Add(this.Mergebutton);
            this.Controls.Add(this.TB_location);
            this.Controls.Add(this.TB_URL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_name);
            this.Controls.Add(this.Quitbutton);
            this.Controls.Add(this.Savebutton);
            this.Name = "FormModifyPublisher";
            this.Text = "FormModifyPublisher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button Quitbutton;
        private System.Windows.Forms.TextBox TB_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_URL;
        private System.Windows.Forms.TextBox TB_location;
        private System.Windows.Forms.Button Mergebutton;
    }
}