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
    public partial class FormDoBook : Form
    {
        Librarydb db;
        BookAlbum bb;

        public FormDoBook(Librarydb dbpar, int bookid)
        {
            InitializeComponent();
            db = dbpar;
            bb = (from c in db.BookAlbum where c.Id == bookid select c).FirstOrDefault();
            if (bb == null)
                this.Text = "(invalid book)";
            else
            {
                this.Text = bb.Title;
                Titlelabel.Text = bb.Title;
                if (bb.Publisher != null)
                    Publisherlabel.Text = bb.PublisherPublisher.Name;
                else
                    Publisherlabel.Text = "(no publisher)";
                if ( bb.YearThis != null)
                {
                    Yearlabel.Text = util.addcentury(bb.YearThis);
                    if ((bb.YearFirst != null) && (bb.YearFirst != bb.YearThis))
                        Yearlabel.Text += " (" + util.addcentury(bb.YearFirst) + ")";
                }
                var qa = (from c in db.AuthorBook where c.BookAlbum == bookid select c);
                foreach (AuthorBook ab in qa)
                {
                    string s = util.addid(ab.AuthorAuthor.Name, ab.Author, 100);
                    CB_author.Items.Add(s);
                }
                var qc = (from c in db.ChapterSong where c.BookAlbum == bookid select c);
                foreach (ChapterSong cs in qc)
                {
                    var qac = (from c in db.AuthorChapter where c.ChapterSong == cs.Id select c);
                    List<string> ls = new List<string>();
                    foreach (AuthorChapter ac in qac)
                    {
                        ls.Add(ac.AuthorAuthor.Name);
                    }
                    string s = util.addid(util.format_authorlist(ls) + ": " + cs.Title,cs.Id,100);
                    CB_chapter.Items.Add(s);
                }

            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNewBook fd = new FormNewBook(db, -1, bb);
            fd.Show();

        }

        private void Refbutton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("");
            var qa = (from c in db.AuthorBook where c.BookAlbum == bb.Id select c);
            List<string> ls = new List<string>();
            foreach (AuthorBook ab in qa)
            {
                ls.Add(ab.AuthorAuthor.Name);
            }
            string bookauthor = util.format_authorlist(ls) + ". ";
            sb.Append(bookauthor);
            string yearstring = " (" + util.addcentury(bb.YearThis) + "). ";
            sb.Append(yearstring);
            sb.Append(bb.Title + ". ");
            sb.Append(bb.PublisherPublisher.Name+".");
            string bookref = sb.ToString();

            var qc = (from c in db.ChapterSong where c.BookAlbum == bb.Id select c);
            foreach (ChapterSong cs in qc)
            {
                var qac = (from c in db.AuthorChapter where c.ChapterSong == cs.Id select c);
                List<string> lsc = new List<string>();
                foreach (AuthorChapter ac in qac)
                {
                    lsc.Add(ac.AuthorAuthor.Name);
                }
                string s = util.format_authorlist(lsc) + ". " + yearstring + cs.Title + " In: "+bookauthor+bb.Title+". "+ bb.PublisherPublisher.Name + ".";
                sb.Append("\n"+s);
            }

            Clipboard.SetText(sb.ToString());

        }
    }
}
