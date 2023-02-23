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
    public partial class FormListmaker : Form
    {
        private Librarydb db;
        bool music;

        public FormListmaker(Librarydb dbpar,bool musicpar)
        {
            InitializeComponent();
            db = dbpar;
            music = musicpar;

        }

        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void Generatebutton_Click(object sender, EventArgs e)
        {

            //var q = from c in db.Author where c.Id > 63000 select c;

            if (RB_byauthor.Checked)
            {
                List<Author> alist = new List<Author>();
                foreach (Author aa in (from c in db.Author orderby c.Name select c))
                {
                    bool found = false;
                    foreach (AuthorBook ab in aa.AuthorBook)
                    {
                        if ((ab.BookAlbumBookAlbum.Type == 0) != music)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        alist.Add(aa);
                }
                FormBookList fb = new FormBookList(db, alist,music,CB_count.Checked,CB_location.Checked);
                fb.Show();
            }
            else if (RB_subjectlist.Checked)
            {
                Dictionary<string, int> subjdict = new Dictionary<string, int>();
                foreach (Article aa in (from c in db.Article select c))
                {
                    string s = aa.Subj1 + "." + aa.Subj2 + "." + aa.Subj3;
                    if (!subjdict.ContainsKey(s))
                        subjdict.Add(s, 0);
                    subjdict[s]++;
                }
                foreach (string s in subjdict.Keys)
                {
                    memo(s + ": " + subjdict[s]);
                }
            }
        }
    }
}
