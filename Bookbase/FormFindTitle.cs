using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookbase
{
    public partial class FormFindTitle : Form
    {
        public int titleid = -1;
        public int titletype = -1;

        private Button[] Letterbuttons = new Button[35];
        private Dictionary<int, string> buttondict = new Dictionary<int, string>();

        private Librarydb db;


        public FormFindTitle(Librarydb dbpar)
        {
            db = dbpar;

            InitializeComponent();

            Init_Letterbuttons();
            foreach (int i in buttondict.Keys)
            {
                this.Controls.Add(Letterbuttons[i]);
                Letterbuttons[i].Click += new System.EventHandler(Letterbutton_Click);
            }


        }

        private void Init_Letterbuttons()
        {
            int sizex = 66;
            int sizey = 23;
            int basex = 15;
            int basey = 200;
            int perrow = 5;


            if (buttondict.Count == 0)
            {
                for (int i = 0; i < Letterbuttons.Length; i++)
                {
                    Letterbuttons[i] = new Button();
                }

                for (int i = 0; i < 26; i++)
                {
                    buttondict.Add(i, ((char)('A' + i)).ToString());
                }
                buttondict.Add(26, "Å");
                buttondict.Add(27, "Ä");
                buttondict.Add(28, "Ö");
                buttondict.Add(29, "[");
                buttondict.Add(30, " ");
            }

            foreach (int i in buttondict.Keys)
            {
                int row = i / perrow;
                int col = i % perrow;
                Letterbuttons[i].Location = new Point(basex + col * sizex, basey + row * sizey);
                Letterbuttons[i].Text = buttondict[i];
                Letterbuttons[i].Size = new System.Drawing.Size(sizex, sizey);
                //Letterbuttons[i].TabIndex = 0;
                Letterbuttons[i].UseVisualStyleBackColor = true;
                Letterbuttons[i].Enabled = true;
                //this.Controls.Add(Letterbuttons[i]);
            }
            BackButton.Enabled = false;
        }

        private List<string> GetAllTitles(string s)
        {
            List<string> ls = new List<string>();
            var q1 = (from c in db.Article where c.Title.ToLower().StartsWith(s) select c);
            foreach (Article a1 in q1)
            {
                ls.Add(util.addid(a1.Title, a1.Id + 1000000, 200));
            }
            var q2 = (from c in db.BookAlbum where c.Title.ToLower().StartsWith(s) select c);
            foreach (BookAlbum a2 in q2)
            {
                ls.Add(util.addid(a2.Title, a2.Id + 2000000, 200));
            }
            var q3 = (from c in db.ChapterSong where c.Title.ToLower().StartsWith(s) select c);
            foreach (ChapterSong a3 in q3)
            {
                ls.Add(util.addid(a3.Title, a3.Id + 3000000, 200));
            }
            return ls;
        }

        private void Letterbutton_handler(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                Init_Letterbuttons();
                return;
            }

            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            List<string> ls = GetAllTitles(s);
            int nq = ls.Count;

            label1.Text = nq.ToString() + " titles selected.";
            if (nq == 0)
            {
                label1.Text = "No titles found";
                //comboBox1.Items.Clear();
            }
            else
            {
                if (nq < 100)
                {
                    comboBox1.Items.Clear();
                    foreach (string ss in ls)
                    {
                        comboBox1.Items.Add(ss);
                    }
                    comboBox1.DroppedDown = true;
                }
                foreach (int i in buttondict.Keys)
                {
                    Letterbuttons[i].Text = s + buttondict[i].ToLower();
                    Letterbuttons[i].Enabled = (GetAllTitles(Letterbuttons[i].Text).Count > 0);
                }
            }
            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        private void Letterbutton_Click(object sender, EventArgs e)
        {
            string s = ((Button)sender).Text.ToLower();
            Letterbutton_handler(s);
            BackButton.Enabled = true;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            titleid = -1;
            this.Close();
        }


        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedItem.ToString();
            titleid = util.getid(s) % 1000000;
            titletype = util.getid(s) / 1000000;
            label1.Text = "Selected " + s;
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            string s = Letterbuttons[0].Text;
            label2.Text = "Backbutton " + s + "|";
            if (s.Length > 2)
                Letterbutton_handler(s.Substring(0, s.Length - 2));
            else
                Letterbutton_handler("");
        }
    }
}
