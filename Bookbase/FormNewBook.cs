using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReadCrossref;

namespace Bookbase
{
    public partial class FormNewBook : Form
    {
        Librarydb db;
        int auid;
        Author au;
        List<int> coauthorlist = new List<int>();
        int pubid = -1;
        public List<ChapterSong> shortslist = new List<ChapterSong>();
        public List<AuthorChapter> shortsauthorlist = new List<AuthorChapter>();
        BookAlbum ba = null;

        public FormNewBook(Librarydb dbpar, int authorid, BookAlbum bapar)
        {
            InitializeComponent();
            db = dbpar;
            ba = bapar;
            auid = authorid;
            //if (( auid < 0 ) && (ba == null))
            //{
            //    string message = "Must have either author or book in FormNewBook";
            //    string caption = "No title";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    DialogResult result = MessageBox.Show(message, caption, buttons);
            //    return;
            //}

            if (auid > 0)
            {
                au = (from c in db.Author where c.Id == auid select c).FirstOrDefault();
                if (au != null)
                    TB_author.Text = au.Name;
                populate_booklist();
            }
            else
            {
                TB_isbn.Focus();
            }

            populate_subjectlist();
            populate_typelist();

            if ( ba != null)
            {
                int i = 1;
                foreach (Author aa in (from c in db.AuthorBook where c.BookAlbum == ba.Id select c.AuthorAuthor))
                {
                    if ( i==1)
                    {
                        TB_author.Text = aa.Name;
                    }
                    else
                    {
                        LB_coauthor.Items.Add(aa.Name);
                    }
                    i++;
                }
                TB_title.Text = ba.Title;
                TB_publisher.Text = ba.PublisherPublisher.Name;

                Object qsel = null;
                foreach ( Object q in LB_subject.Items)
                {
                    memo(q.ToString());
                    if (q.ToString().Contains(ba.Subject.PadRight(7) + "| "))
                        qsel = q;

                }
                LB_subject.SelectedItem = qsel;

                if (ba.Liked != null)
                    hScrollBar1.Value = (int)ba.Liked;
            }

        }

        private void populate_subjectlist()
        {
            string[] subjects = { "sf", "fict", "bio", "phys", "hist", "geo", "lang", "ling", "math", "nf", "phil", "rel", "comp", "sex", "baby", "humor", "travel" };
            foreach (string subject in subjects)
            {
                string name = (from c in db.Subject where c.Id == subject select c.Name).FirstOrDefault();
                if (name != null)
                    LB_subject.Items.Add(subject.PadRight(7) + "| " + name);
            }
            LB_subject.SelectedItem = LB_subject.Items[0];
        }

        private void populate_typelist()
        {
            
            foreach (string typename in (from c in db.Bookmusictype select c.Type))
            {
                LB_type.Items.Add(typename);
            }
            LB_type.SelectedItem = LB_type.Items[0];
        }

        private void populate_booklist()
        {

            foreach (AuthorBook ab in au.AuthorBook)
            {
                memo(ab.BookAlbumBookAlbum.Title);
            }
            memo(au.AuthorBook.Count().ToString() + " books already in database");
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            string message = "Exit without saving changes?";
            string caption = "Really exit?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool savebook()
        {
            memo("Saving book...");
            if (String.IsNullOrEmpty(TB_title.Text))
            {
                string message = "Cannot save book with empty title";
                string caption = "No title";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                return false;
            }

            if (auid <= 0 && String.IsNullOrEmpty(TB_author.Text))
            {
                string message = "Cannot save book with no author";
                string caption = "No author";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                return false;
            }

            //The book itself:
            bool wasnull = (ba == null);
            if (ba == null)
            {
                ba = new BookAlbum();
                ba.Id = (from c in db.BookAlbum select c.Id).Max() + 1;
            }
            ba.Title = TB_title.Text;

            if (!String.IsNullOrEmpty(TB_firstyear.Text))
            {
                ba.YearFirst = util.tryconvert(TB_firstyear.Text);
                if (ba.YearFirst <= DateTime.Now.Year % 100)
                    ba.YearFirst += 2000;
                else
                    ba.YearFirst += 1900;
            }

            if (!String.IsNullOrEmpty(TB_thisyear.Text))
            {
                ba.YearThis = util.tryconvert(TB_thisyear.Text);
                if (ba.YearThis <= DateTime.Now.Year % 100)
                    ba.YearThis += 2000;
                else
                    ba.YearThis += 1900;
            }

            if (pubid >= 0)
                ba.Publisher = pubid;
            else
            {
                if (!String.IsNullOrEmpty(TB_publisher.Text))
                {
                    var q = from c in db.Publisher where c.Name == TB_publisher.Text select c;
                    if (q.Count() > 0)
                        ba.PublisherPublisher = q.First();
                    else
                    {
                        Publisher pp = new Publisher();
                        pp.Id = (from c in db.Publisher select c.Id).Max() + 1;
                        pp.Name = TB_publisher.Text;
                        db.Publisher.InsertOnSubmit(pp);
                        db.SubmitChanges();
                        ba.Publisher = pp.Id;
                    }
                }
                else
                    ba.Publisher = null;

            }

            ba.Subject = LB_subject.SelectedItem.ToString().Split('|')[0].Trim();

            if (!String.IsNullOrEmpty(TB_when.Text))
            {
                try
                {
                    string s = TB_when.Text;
                    if (s.Length < 2)
                        s = s.PadLeft(2, '0');
                    if (s.Length < 6)
                        s = s.PadRight(6, '0');
                    int year = util.tryconvert(TB_when.Text.Substring(0, 2));
                    if (year < 50)
                        year += 2000;
                    else
                        year += 1900;
                    int month = util.tryconvert(TB_when.Text.Substring(2, 2));
                    if (month == 0)
                        month = 1;
                    int day = util.tryconvert(TB_when.Text.Substring(4, 2));
                    if (day == 0)
                        day = 1;
                    ba.DateBought = new DateTime(year, month, day);
                }
                catch (Exception ee)
                {
                    ba.DateBought = null;
                }
            }

            if (String.IsNullOrEmpty(TB_where.Text) || (TB_where.Text == "?"))
            {
                if ( String.IsNullOrEmpty(ba.WhereBought))
                    ba.WhereBought = null;
            }
            else
                ba.WhereBought = TB_where.Text;

            if (String.IsNullOrEmpty(TB_price.Text) || (TB_price.Text == "?"))
            {
                if (!(ba.Price > 0))
                    ba.Price = null;
            }
            else
                ba.Price = util.tryconvert(TB_price.Text);

            ba.Type = LB_type.SelectedIndex;
            ba.Liked = hScrollBar1.Value;
            ba.Havecopy = CB_havecopy.Checked;
            if (wasnull)
                db.BookAlbum.InsertOnSubmit(ba);
            db.SubmitChanges();

            //Author(s):
            if (wasnull)
            {
                int iab = (from c in db.AuthorBook select c.Id).Max() + 1;

                if (auid <= 0)
                {
                    foreach (authorclass ac in authorclass.Parse(TB_author.Text))
                    {
                        AuthorBook ab = new AuthorBook();
                        ab.Id = iab;
                        iab++;
                        int ai = ac.AuthorToDB(db);
                        ab.Author = ai;
                        ab.BookAlbum = ba.Id;
                        db.AuthorBook.InsertOnSubmit(ab);
                    }
                }
                else
                {
                    AuthorBook ab = new AuthorBook();
                    ab.Id = iab;
                    iab++;
                    ab.Author = auid;
                    ab.BookAlbum = ba.Id;
                    db.AuthorBook.InsertOnSubmit(ab);
                }
                foreach (string s in LB_coauthor.Items)
                {
                    AuthorBook abb = new AuthorBook();
                    abb.Id = iab;
                    iab++;
                    abb.BookAlbum = ba.Id;
                    abb.Author = util.getid(s);
                    db.AuthorBook.InsertOnSubmit(abb);
                }

                db.SubmitChanges();
            }

            memo("... book saved.");
            return true;
        }

        public void saveshorts()
        {
            if (ba == null)
                savebook();
            if (ba == null)
            {
                string message = "Savebook failed";
                string caption = "Fail";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                return;
            }
            memo("Saving shorts...");

            foreach (ChapterSong cs in shortslist)
            {
                cs.BookAlbum = ba.Id;
                db.ChapterSong.InsertOnSubmit(cs);
            }
            db.SubmitChanges();

            foreach (AuthorChapter ac in shortsauthorlist)
            {
                db.AuthorChapter.InsertOnSubmit(ac);
            }
            db.SubmitChanges();

            memo("..." + shortslist.Count + " shorts saved.");
            shortslist.Clear();
            shortsauthorlist.Clear();

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (savebook())
            {
                saveshorts();
                //Shorts:

                if (CB_another.Checked)
                {
                    FormNewBook fd = new FormNewBook(db, auid, null);
                    fd.Show();
                }

                this.Close();
            }
        }

        private void Publisherbutton_Click(object sender, EventArgs e)
        {
            FormFindPublisher fa = new FormFindPublisher(db);

            DialogResult faresult = fa.ShowDialog();
            var pid = fa.pubid;
            memo("pubid = " + pid.ToString());
            pubid = pid;
            if ( faresult == DialogResult.OK)
            {
                Publisher pp = (from c in db.Publisher where c.Id == pubid select c).FirstOrDefault();
                if (pp != null)
                    TB_publisher.Text = pp.Name;
                else
                    pubid = -1;
            }

        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void TB_firstyear_TextChanged(object sender, EventArgs e)
        {
            if ( TB_firstyear.Text.Length > 0)
                TB_thisyear.Text = TB_firstyear.Text;
        }

        private void Coauthorbutton_Click(object sender, EventArgs e)
        {
            FormFindAuthor fa = new FormFindAuthor(db);

            DialogResult faresult = fa.ShowDialog();
            var auid = fa.authorid;
            memo("authorid = " + auid.ToString());

            if ((faresult == DialogResult.OK) && (auid >= 0))
            {
                Author aa = (from c in db.Author where c.Id == auid select c).FirstOrDefault();
                if ( aa != null)
                {
                    LB_coauthor.Items.Add(util.addid(aa.Name,aa.Id,100));
                }
            }

        }

        private void Shortsbutton_Click(object sender, EventArgs e)
        {
            FormNewShorts fs = new FormNewShorts(db,this,TB_author.Text);
            fs.Show();

        }

        public void showshorts()
        {
            foreach (ChapterSong cs in shortslist)
            {
                LB_shorts.Items.Add(cs.Title);
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Likelabel.Text = hScrollBar1.Value.ToString();
        }

        private void TB_isbn_TextChanged(object sender, EventArgs e)
        {
            if (TB_isbn.Text.Length >=13)
            {
                string csv = util.csvFromISBN(TB_isbn.Text);
                if (string.IsNullOrEmpty(csv))
                    return;
                TB_title.Text = util.get_csvpart(csv, 1);
                TB_author.Text = util.get_csvpart(csv, 0);
                TB_publisher.Text = util.get_csvpart(csv, 2);
                TB_firstyear.Text = util.get_csvpart(csv, 4);
                TB_thisyear.Text = util.get_csvpart(csv, 5);
            }
        }
    }
}
