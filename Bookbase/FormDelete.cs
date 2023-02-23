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
    public partial class FormDelete : Form
    {
        private Librarydb db;

        public FormDelete(Librarydb dbpar)
        {
            db = dbpar;
            InitializeComponent();

        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void delete_book(int bookid)
        {
            var qcs = from c in db.ChapterSong
                      where c.BookAlbum == bookid
                      select c.Id;
            foreach (int csid in qcs)
            {
                delete_chapter(csid);
            }

            var qab = from c in db.AuthorBook
                      where c.BookAlbum == bookid
                      select c;
            memo("qab " + qab.Count());
            db.AuthorBook.DeleteAllOnSubmit(qab);
            db.SubmitChanges();
            BookAlbum ba = (from c in db.BookAlbum
                            where c.Id == bookid
                            select c).FirstOrDefault();
            memo("ba = " + ba.Title);
            if ( ba != null)
            {
                db.BookAlbum.DeleteOnSubmit(ba);
                db.SubmitChanges();
            }
        }

        private void delete_chapter(int csid)
        {
            var qac = from c in db.AuthorChapter
                      where c.ChapterSong == csid
                      select c;
            memo("qac " + qac.Count());
            db.AuthorChapter.DeleteAllOnSubmit(qac);
            db.SubmitChanges();
            ChapterSong cs = (from c in db.ChapterSong
                            where c.Id == csid
                            select c).FirstOrDefault();
            memo("cs = " + cs.Title);
            if (cs != null)
            {
                db.ChapterSong.DeleteOnSubmit(cs);
                db.SubmitChanges();
            }
        }

        private void Bookbutton_Click(object sender, EventArgs e)
        {
            FormFindTitle fa = new FormFindTitle(db);

            DialogResult faresult = fa.ShowDialog();
            var tid = fa.titleid;
            var tit = fa.titletype;

            if (faresult == DialogResult.OK)
            {
                //if (tit == 1) //article
                //{
                //    FormDoArticle faa = new FormDoArticle(db, tid);
                //    faa.Show();
                //}
                //else 
                if (tit == 2) //book
                {
                    delete_book(tid);
                }
                //else //chapter
                //{
                //    ChapterSong cs = (from c in db.ChapterSong where c.Id == tid select c).FirstOrDefault();
                //    if (cs != null)
                //    {
                //        FormDoBook fb = new FormDoBook(db, cs.BookAlbum);
                //        fb.Show();
                //    }
                //}
            }

        }
    }
}
