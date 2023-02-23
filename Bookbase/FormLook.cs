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

    public partial class FormLook : Form
    {
        private Librarydb db;

        public FormLook(Librarydb dbpar)
        {
            InitializeComponent();
            db = dbpar;
        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindAuthorButton_Click(object sender, EventArgs e)
        {
            FormFindAuthor fa = new FormFindAuthor(db);

            DialogResult faresult = fa.ShowDialog();
            var auid = fa.authorid;
            memo("authorid = "+auid.ToString());

            if ((faresult == DialogResult.OK) && (auid >= 0))
            {
                FormDoAuthor fd = new FormDoAuthor(db, auid);
                fd.Show();
            }
        }

        private void SubjectButton_Click(object sender, EventArgs e)
        {
            FormSubject fs = new FormSubject(db);
            fs.Show();
        }

        private void Titlebutton_Click(object sender, EventArgs e)
        {
            FormFindTitle fa = new FormFindTitle(db);

            DialogResult faresult = fa.ShowDialog();
            var tid = fa.titleid;
            var tit = fa.titletype;
            memo("titleid = " + tid.ToString());
            memo("titletype = " + tit.ToString());

            if (faresult == DialogResult.OK)
            {
                if ( tit == 1)
                {
                    FormDoArticle faa = new FormDoArticle(db, tid);
                    faa.Show();
                }
                else if ( tit == 2)
                {
                    FormDoBook fb = new FormDoBook(db, tid);
                    fb.Show();
                }
                else
                {
                    ChapterSong cs = (from c in db.ChapterSong where c.Id == tid select c).FirstOrDefault();
                    if ( cs != null)
                    {
                        FormDoBook fb = new FormDoBook(db, cs.BookAlbum);
                        fb.Show();
                    }
                }
            }

        }

        private void Publisherbutton_Click(object sender, EventArgs e)
        {
            FormFindPublisher fa = new FormFindPublisher(db);

            DialogResult faresult = fa.ShowDialog();
            var pid = fa.pubid;
            memo("pubid = " + pid.ToString());

            if ((faresult == DialogResult.OK) && (pid >= 0))
            {
                FormDoPublisher fd = new FormDoPublisher(db, pid);
                fd.Show();
            }

        }

        private void Statisticsbutton_Click(object sender, EventArgs e)
        {
            var qa = from c in db.Author select c;
            memo("Authors/creators in total: " + qa.Count());

            int n = 0;

            int nhasart = 0;
            int nhasbook = 0;
            int nhasmusic = 0;
            int nhasartbook = 0;
            int nhasartmusic = 0;
            int nhasbookmusic = 0;
            int nhas3 = 0;
            foreach (Author aa in qa)
            {
                bool hasart = (aa.AuthorArticle.Count() > 0);
                bool hasbook = false;
                bool hasmusic = false;
                if (aa.AuthorBook.Count() > 0)
                {
                    var qb = from c in aa.AuthorBook where c.BookAlbumBookAlbum.Type == 0 select c;
                    hasbook = (qb.Count() > 0);
                    var qm = from c in aa.AuthorBook where c.BookAlbumBookAlbum.Type != 0 select c;
                    hasmusic = (qm.Count() > 0);
                }
                if (aa.AuthorChapter.Count() > 0)
                {
                    var qb = from c in aa.AuthorChapter where c.ChapterSongChapterSong.BookAlbumBookAlbum.Type == 0 select c;
                    hasbook = hasbook || (qb.Count() > 0);
                    var qm = from c in aa.AuthorChapter where c.ChapterSongChapterSong.BookAlbumBookAlbum.Type != 0 select c;
                    hasmusic = hasmusic || (qm.Count() > 0);
                }
                if (hasart)
                    nhasart++;
                if (hasbook)
                    nhasbook++;
                if (hasmusic)
                    nhasmusic++;
                if (hasart && hasbook)
                {
                    nhasartbook++;
                    if (hasmusic)
                    {
                        nhas3++;
                        memo("Has 3: " + aa.Name);
                    }
                }
                if (hasart && hasmusic)
                {
                    nhasartmusic++;
                    memo("Has art & music: " + aa.Name);
                }
                if (hasbook && hasmusic)
                {
                    nhasbookmusic++;
                    memo("Has book & music: " + aa.Name);
                }

                n++;
                if (n % 1000 == 0)
                    memo(n.ToString());
            }
            memo("Authors of articles: " + nhasart);
            memo("Authors of books/chapters: " + nhasbook);
            memo("Creators of music: " + nhasmusic);
            memo("Both articles and books/chapters: " + nhasartbook);
            memo("Both articles and music: " + nhasartmusic);
            memo("Both books/chapters and music: " + nhasbookmusic);
            memo("Both articles, music and books/chapters: " + nhas3);

        }
    }
}
