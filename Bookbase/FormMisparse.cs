using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ReadCrossref;

namespace Bookbase
{
    public partial class FormMisparse : Form
    {
        private Librarydb db;

        public FormMisparse(Librarydb dbpar)
        {
            InitializeComponent();

            int startid = 63375;
            db = dbpar;

            foreach (Author au in (from c in db.Author where c.Id > startid select c))
            {
                if (!String.IsNullOrEmpty(au.Givenname))
                {
                    string s = au.Givenname + " " + au.Familyname+".";
                    var q = from c in db.Author
                            where c.Name == s
                            select c;
                    if (q.Count() > 0)
                    {
                        string ss = au.Name + " -> " + q.First().Name+ "["+au.Id+"] -> ["+q.First().Id+"]";
                        checkedListBox1.Items.Add(ss);
                    }

                }
            }
        }
        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }


        private void quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mergebutton_Click(object sender, EventArgs e)
        {
            string rex = @"\[(\d+)\]";
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                string s = checkedListBox1.Items[i].ToString();
                memo(s);

                MatchCollection m = Regex.Matches(s, rex);

                int aufrom = util.tryconvert(m[0].Groups[1].Value);
                int auinto = util.tryconvert(m[1].Groups[1].Value);
                memo("aufrom = " + aufrom + "; auinto = " + auinto);

                authorclass.MergeDB(db, authorclass.AuthorFromId(db, auinto), authorclass.AuthorFromId(db, aufrom));
            }
        }
    }
}
