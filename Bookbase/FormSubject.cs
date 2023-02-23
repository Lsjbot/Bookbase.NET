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
    public partial class FormSubject : Form
    {
        private Librarydb db;
        public FormSubject(Librarydb dbpar)
        {
            InitializeComponent();
            db = dbpar;

            var qs = from c in db.Subject select c.Name;
            foreach (string s in qs)
            {
                CBmysubj.Items.Add(s);
            }

            var qc = from c in db.CrossrefSubject select c.Name;
            foreach (string s in qc)
            {
                CBcrossref.Items.Add(s);
            }

            var qp = from c in db.PubmedSubject select c.Name;
            foreach (string s in qp)
            {
                CBpubmed.Items.Add(s);
            }

            var qe = from c in db.EvolangSubject select c.Name;
            foreach (string s in qe)
            {
                CBevolang.Items.Add(s);
            }

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NumbersButton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            CBmysubj.Items.Clear();
            var qs = from c in db.Subject select c;
            foreach (Subject cs in qs)
            {
                int n1 = (from c in db.Article where c.Subj1 == cs.Id select c).Count();
                int n2 = (from c in db.Article where c.Subj2 == cs.Id select c).Count();
                int n3 = (from c in db.Article where c.Subj3 == cs.Id select c).Count();
                if (n1 + n2 + n3 > 0)
                {
                    string s = cs.Name + "(" + n1 + "/" + n2 + "/" + n3 + ") ";
                    CBmysubj.Items.Add(s);
                }
            }

            CBcrossref.Items.Clear();
            var qc = from c in db.CrossrefSubject select c;
            foreach (CrossrefSubject cc in qc)
            {
                int n = (from c in db.ArticleCrossrefSubject where c.Subject == cc.Id select c).Count();
                if (n > 0)
                {
                    string s = cc.Name + "(" + n + ") ";
                    CBcrossref.Items.Add(s);
                }
            }

            CBpubmed.Items.Clear();
            var qp = from c in db.PubmedSubject select c;
            foreach (PubmedSubject cc in qp)
            {
                int n = (from c in db.ArticlePubmedSubject where c.Subject == cc.Id select c).Count();
                if (n > 0)
                {
                    string s = cc.Name + "(" + n + ") ";
                    CBpubmed.Items.Add(s);
                }
            }

            CBevolang.Items.Clear();
            var qe = from c in db.EvolangSubject select c;
            foreach (EvolangSubject cc in qe)
            {
                int n = (from c in db.ArticleEvolangSubject where c.Subject == cc.Id select c).Count();
                if (n > 0)
                {
                    string s = cc.Name + "(" + n + ") ";
                    CBevolang.Items.Add(s);
                }
            }

            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        public List<Article> getArticlebyMysubj()
        {
            List<Article> la = new List<Article>();

            if (CBmysubj.CheckedItems.Count > 0)
            {
                foreach (object item in CBmysubj.CheckedItems)
                {
                    string s = item.ToString().Split('(')[0].Trim();
                    Subject cs = (from c in db.Subject where c.Name == s select c).First();
                    if (CBsubj1.Checked)
                        foreach (Article aa in (from c in db.Article where (c.Subj1 == cs.Id) select c))
                            la.Add(aa);
                    if (CBsubj2.Checked)
                        foreach (Article aa in (from c in db.Article where (c.Subj2 == cs.Id) select c))
                            la.Add(aa);
                    if (CBsubj3.Checked)
                        foreach (Article aa in (from c in db.Article where (c.Subj3 == cs.Id) select c))
                            la.Add(aa);
                }
            }

            return la;
        }

        public List<Article> getArticlebyCrossref()
        {
            List<Article> la = new List<Article>();

            if (CBcrossref.CheckedItems.Count > 0)
            {

                foreach (object item in CBcrossref.CheckedItems)
                {
                    string sc = item.ToString().Split('(')[0].Trim();
                    CrossrefSubject cc = (from c in db.CrossrefSubject where c.Name == sc select c).First();
                    foreach (ArticleCrossrefSubject aa in (from c in db.ArticleCrossrefSubject where c.Subject == cc.Id select c))
                        if (!la.Contains(aa.ArticleArticle))
                            la.Add(aa.ArticleArticle);
                }
            }

            return la;
        }

        public List<Article> getArticlebyPubmed()
        {
            List<Article> la = new List<Article>();

            if (CBpubmed.CheckedItems.Count > 0)
            {

                foreach (object item in CBpubmed.CheckedItems)
                {
                    string sc = item.ToString().Split('(')[0].Trim();
                    PubmedSubject cc = (from c in db.PubmedSubject where c.Name == sc select c).First();
                    foreach (ArticlePubmedSubject aa in (from c in db.ArticlePubmedSubject where c.Subject == cc.Id select c))
                        if (!la.Contains(aa.ArticleArticle))
                            la.Add(aa.ArticleArticle);
                }
            }

            return la;
        }

        public List<Evolang> getArticlebyEvolang()
        {
            List<Evolang> la = new List<Evolang>();

            if (CBevolang.CheckedItems.Count > 0)
            {

                foreach (object item in CBevolang.CheckedItems)
                {
                    string sc = item.ToString().Split('(')[0].Trim();
                    EvolangSubject cc = (from c in db.EvolangSubject where c.Name == sc select c).First();
                    foreach (ArticleEvolangSubject aa in (from c in db.ArticleEvolangSubject where c.Subject == cc.Id select c))
                        if (!la.Contains(aa.EvolangEvolang))
                            la.Add(aa.EvolangEvolang);
                }
            }

            return la;
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            List<Article> la = getArticlebyMysubj();

            foreach (Article aa in getArticlebyCrossref())
                if (!la.Contains(aa))
                    la.Add(aa);

            foreach (Article aa in getArticlebyPubmed())
                if (!la.Contains(aa))
                    la.Add(aa);

            FormArticleList fa = new FormArticleList(db, la);
            fa.AddEvolang(getArticlebyEvolang());
            fa.Show();
        }

        private void Bookbutton_Click(object sender, EventArgs e)
        {
            List<BookAlbum> booklist = new List<BookAlbum>();
            foreach (object item in CBmysubj.CheckedItems)
            {
                string s = item.ToString().Split('(')[0].Trim();
                Subject cs = (from c in db.Subject where c.Name == s select c).First();
                memo(s+": "+cs.Id);
                foreach (BookAlbum ba in (from c in db.BookAlbum where c.Subject == cs.Id select c))
                    booklist.Add(ba);
            }
            if ( booklist.Count > 0)
            {
                FormBookList fb = new FormBookList(db, booklist);
                fb.Show();
            }
        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }


    }
}
