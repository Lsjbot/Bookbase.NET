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
    public partial class FormDoAuthor : Form
    {
        private Author a;
        private Librarydb db;

        public FormDoAuthor(Librarydb dbpar, int authorid)
        {
            db = dbpar;
            InitializeComponent();

            var q = from c in db.Author where c.Id == authorid select c;
            if ( q.Count() == 0)
            {
                MessageBox.Show("Author not found, Id = "+authorid);
                this.Close();
            }
            else
            {
                a = q.First();
                this.Text = a.Name;
            }

            ArticleButton_Click(null, null);
            BookButton_Click(null, null);
            ShortsButton_Click(null, null);
            if ( CB_articles.Items.Count > 1)
                SubjectButton_Click(null, null);
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<string> AuthorSubjects(Author adb)
        {
            List<string> ls = new List<string>();
            var q = from c in db.AuthorArticle where c.Author == adb.Id select c;
            foreach (AuthorArticle aa in q)
            {
                ls.Add(aa.ArticleArticle.Subj1);
                ls.Add(aa.ArticleArticle.Subj2);
                ls.Add(aa.ArticleArticle.Subj3);
            }
            return ls;
        }

        private List<string> AuthorCrossrefSubjects(Author adb)
        {
            List<string> ls = new List<string>();
            var q = from c in db.AuthorArticle where c.Author == adb.Id select c;
            foreach (AuthorArticle aa in q)
            {
                if ( aa.ArticleArticle.Crossref)
                {
                    var qc = from c in db.ArticleCrossrefSubject where c.Article == aa.Article select c;
                    foreach (ArticleCrossrefSubject acr in qc)
                    {
                        ls.Add(acr.CrossrefSubject.Name);
                    }
                }
            }
            return ls;
        }

        private List<string> AuthorPubmedSubjects(Author adb)
        {
            List<string> ls = new List<string>();
            var q = from c in db.AuthorArticle where c.Author == adb.Id select c;
            foreach (AuthorArticle aa in q)
            {
                if (aa.ArticleArticle.PMID != null)
                {
                    var qc = from c in db.ArticlePubmedSubject where c.Article == aa.Article select c;
                    foreach (ArticlePubmedSubject acr in qc)
                    {
                        ls.Add(acr.PubmedSubject.Name);
                    }
                }
            }
            return ls;
        }

        private void ArticleButton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            var q = from c in db.AuthorArticle where c.Author == a.Id select c;
            Articlecountlabel.Text = q.Count().ToString() + " articles";
            if (q.Count() > 0)
            {
                foreach (AuthorArticle c in q)
                {
                    Article art = c.ArticleArticle;
                    string s = art.Authorstring + " (" + art.Year + ") " + art.Title + ", " + art.Refstring;
                    memo(s);
                    CB_articles.Items.Add("(" + art.Year + ") " + util.addid(art.Title, art.Id, 100));
                }
            }
            else
                CB_articles.Items.Add("(no articles)");
            // Back to normal 
            Cursor.Current = Cursors.Default;
        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void AliasButton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            var q = from c in db.AuthorAlias where c.Author == a.Id select c;
            if (q.Count() == 0)
                AliasBox.Items.Add("(no aliases)");
            else
            {
                foreach (AuthorAlias c in q)
                {
                    AliasBox.Items.Add(c.Name);
                }
            }
            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        private void CoauthorButton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            List<Author> colist = new List<Author>();
            var q = from c in db.AuthorArticle where c.Author == a.Id select c;
            foreach (AuthorArticle aa in q)
            {
                Article art = aa.ArticleArticle;
                var qc = from c in db.AuthorArticle where c.Article == art.Id select c;
                foreach (AuthorArticle aa2 in qc)
                {
                    if ( aa2.Author != a.Id)
                    {
                        if (!colist.Contains(aa2.AuthorAuthor))
                        {
                            colist.Add(aa2.AuthorAuthor);
                        }
                    }
                }
            }
            var qb = from c in db.AuthorBook where c.Author == a.Id select c;
            foreach (AuthorBook aa in qb)
            {
                BookAlbum art = aa.BookAlbumBookAlbum;
                var qc = from c in db.AuthorBook where c.BookAlbum == art.Id select c;
                foreach (AuthorBook aa2 in qc)
                {
                    if (aa2.Author != a.Id)
                    {
                        if (!colist.Contains(aa2.AuthorAuthor))
                        {
                            colist.Add(aa2.AuthorAuthor);
                        }
                    }
                }
            }

            foreach (Author aac in colist)
            {
                CB_coauthor.Items.Add(util.addid(aac.Name, aac.Id, 50));
            }
            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        private void CB_articles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_articles.CheckedItems.Count != 1)
                return;

            string s = CB_articles.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            memo(s);
            int aid = util.getid(s);
            memo("aid = " + aid);
            CB_articles.ClearSelected();

            FormDoArticle fd = new FormDoArticle(db, aid);
            fd.Show();

        }

        private void CB_coauthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_coauthor.CheckedItems.Count == 0)
                return;

            string s = CB_coauthor.CheckedItems[0].ToString();
                //SelectedItem.ToString();
            memo(s);
            int coauid = util.getid(s);
            memo("coauid = " + coauid);

            CB_coauthor.ClearSelected();
            
            FormDoAuthor fd = new FormDoAuthor(db, coauid);
            fd.Show();

        }

        private void SubjectButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> sdict = new Dictionary<string, int>();
            foreach (string s in AuthorSubjects(a))
            {
                if (!sdict.ContainsKey(s))
                    sdict.Add(s, 0);
                sdict[s]++;
            }
            foreach (string s in sdict.Keys)
                CB_subjects.Items.Add("("+sdict[s]+") "+s);

            Dictionary<string, int> pdict = new Dictionary<string, int>();
            foreach (string s in AuthorPubmedSubjects(a))
            {
                if (!pdict.ContainsKey(s))
                    pdict.Add(s, 0);
                pdict[s]++;
            }
            foreach (string s in pdict.Keys)
                CB_pubmed.Items.Add("(" + pdict[s] + ") " +s);

            Dictionary<string, int> cdict = new Dictionary<string, int>();
            foreach (string s in AuthorCrossrefSubjects(a))
            {
                if (!cdict.ContainsKey(s))
                    cdict.Add(s, 0);
                cdict[s]++;
            }
            foreach (string s in cdict.Keys)
                CB_crossref.Items.Add("(" + cdict[s] + ") "+s);

        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            var q = from c in db.AuthorBook where c.Author == a.Id select c;
            Bookcountlabel.Text = q.Count().ToString() + " books";
            if (q.Count() > 0)
            {
                foreach (AuthorBook c in q)
                {
                    BookAlbum art = c.BookAlbumBookAlbum;
                    string s = " (" + art.YearFirst + ") " + art.Title; // + ", " + art.PublisherPublisher.Name;
                    if ( art.PublisherPublisher != null)
                        s += ", " + art.PublisherPublisher.Name;
                    memo(s);
                    CB_books.Items.Add("(" + art.YearFirst + ") " + util.addid(art.Title, art.Id, 100));
                }
            }
            else
                CB_books.Items.Add("(no books)");
            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        private void ShortsButton_Click(object sender, EventArgs e)
        {
            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            var q = from c in db.AuthorChapter where c.Author == a.Id select c;
            Shortcountlabel.Text = q.Count().ToString() + " short stories";
            if (q.Count() > 0)
            {
                foreach (AuthorChapter c in q)
                {
                    ChapterSong art = c.ChapterSongChapterSong;
                    string s = " (" + art.BookAlbumBookAlbum.YearFirst + ") " + art.Title;
                    memo(s);
                    CB_shorts.Items.Add("(" + art.BookAlbumBookAlbum.YearFirst + ") " + util.addid(art.Title, art.Id, 100));
                }
            }
            else
                CB_shorts.Items.Add("(no books)");
            // Back to normal 
            Cursor.Current = Cursors.Default;


        }

        private void Shortcountlabel_Click(object sender, EventArgs e)
        {

        }

        private void AffButton_Click(object sender, EventArgs e)
        {
            var q = (from c in db.Authoraffiliation where c.Author == a.Id select c);
            if (q.Count() == 0)
                CB_affiliation.Items.Add("(no affiliation)");
            foreach ( Authoraffiliation aa in q)
            {
                string s = util.addid(aa.AffiliationAffiliation.Name, aa.Affiliation, 50);
                CB_affiliation.Items.Add(s);

                int? iaff = aa.AffiliationAffiliation.Partof;
                while (iaff != null)
                {
                    Affiliation aff = (from c in db.Affiliation where c.Id == iaff select c).FirstOrDefault();
                    string ss = util.addid(aff.Name, (int)iaff, 50);
                    CB_affiliation.Items.Add(ss);
                    iaff = aff.Partof;
                }

            }
        }

        private void CB_books_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_books.CheckedItems.Count != 1)
                return;

            string s = CB_books.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            memo(s);
            int aid = util.getid(s);
            memo("aid = " + aid);
            CB_books.SetItemCheckState(CB_books.CheckedIndices[0], CheckState.Unchecked);
            CB_books.ClearSelected();

            FormDoBook fd = new FormDoBook(db, aid);
            fd.Show();

        }

        private void CB_shorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_shorts.CheckedItems.Count != 1)
                return;

            string s = CB_shorts.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            memo(s);
            int aid = util.getid(s);
            memo("aid = " + aid);
            CB_shorts.SetItemCheckState(CB_shorts.CheckedIndices[0], CheckState.Unchecked);
            CB_shorts.ClearSelected();
            ChapterSong cs = (from c in db.ChapterSong where c.Id == aid select c).FirstOrDefault();
            if (cs == null)
                return;

            FormDoBook fd = new FormDoBook(db, cs.BookAlbum);
            fd.Show();

        }
    }
}
