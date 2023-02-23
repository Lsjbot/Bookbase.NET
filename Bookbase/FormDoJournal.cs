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
    public partial class FormDoJournal : Form
    {
        Librarydb db;
        Journal jj;

        public FormDoJournal(Librarydb dbpar, int jid)
        {
            InitializeComponent();
            db = dbpar;
            jj = (from c in db.Journal where c.Id == jid select c).FirstOrDefault();
            if (jj == null)
                this.Text = "(invalid journal)";
            else
            {
                this.Text = jj.Name;
                if (jj.Publisher != null)
                    Publisherlabel.Text = jj.PublisherPublisher.Name;
                if (jj.ISSN != null)
                    ISSNlabel.Text = jj.ISSN;
            }

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ArticleButton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            var q = from c in db.Article where c.Journal == jj.Id select c;
            Articlecountlabel.Text = q.Count().ToString() + " articles";
            if (q.Count() > 0)
            {
                foreach (Article art in q)
                {
                    string s = art.Authorstring + " (" + art.Year + ") " + art.Title + ", " + art.Refstring;
                    //memo(s);
                    CB_articles.Items.Add("(" + art.Year + ") " + util.addid(art.Title, art.Id, 100));
                }
            }
            else
                CB_articles.Items.Add("(no articles)");
            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        private void CB_articles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_articles.CheckedItems.Count != 1)
                return;

            string s = CB_articles.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            //memo(s);
            int aid = util.getid(s);
            //memo("aid = " + aid);
            CB_articles.SetItemCheckState(CB_articles.CheckedIndices[0], CheckState.Unchecked);
            CB_articles.ClearSelected();

            FormDoArticle fd = new FormDoArticle(db, aid);
            fd.Show();

        }

        private void Authorbutton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            Dictionary<string, int> authordict = new Dictionary<string, int>();

            var q = from c in db.Article where c.Journal == jj.Id select c;
            if (q.Count() > 0)
            {
                foreach (Article art in q)
                {
                    var qa = (from c in db.AuthorArticle where c.Article == art.Id select c);
                    foreach (AuthorArticle aa in qa)
                    {
                        string s = util.addid(aa.AuthorAuthor.Name, aa.Author, 100);
                        if (!authordict.ContainsKey(s))
                            authordict.Add(s, 0);
                        authordict[s]++;
                        //CB_author.Items.Add(s);
                    }
                }
                Authorcountlabel.Text = authordict.Count().ToString() + " authors";
                if (CB_topauthor.Checked && authordict.Count > 20)
                {
                    List<int> ll = authordict.Values.ToList();
                    ll.Sort();
                    
                    int ntop = 10 + ll.Count / 20;
                    int nmin = ll[ll.Count-ntop];
                    for (int i = 0; i < ll.Count; i++)
                        memo(i + ": " + ll[i]);
                    memo("ntop = " + ntop);
                    memo("nmin = " + nmin);
                    memo("max = " + ll.Max());
                    if ((nmin == 1) && (ll[ll.Count-1] > 1))
                        nmin = 2;
                    memo("nmin = " + nmin);

                    foreach (string s in authordict.Keys)
                        if (authordict[s] >= nmin)
                        {
                            CB_author.Items.Add(authordict[s].ToString().PadLeft(4) + ": " + s);
                        }
                }
                else
                {
                    List<string> ll = authordict.Keys.ToList();
                    ll.Sort();
                    foreach (string ss in ll)
                        CB_author.Items.Add(authordict[ss].ToString().PadLeft(4) + ": " + ss);
                }
            }
            else
            {
                CB_author.Items.Add("(no authors)");
                Authorcountlabel.Text = "0 authors";
            }
            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void Publisherlabel_Click(object sender, EventArgs e)
        {

        }

        private void CB_author_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_author.CheckedItems.Count != 1)
                return;

            string s = CB_author.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            //memo(s);
            int aid = util.getid(s);
            //memo("aid = " + aid);
            CB_author.SetItemCheckState(CB_author.CheckedIndices[0], CheckState.Unchecked);
            CB_author.ClearSelected();

            FormDoAuthor fd = new FormDoAuthor(db, aid);
            fd.Show();

        }
    }
}
