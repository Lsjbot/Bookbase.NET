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
using System.IO;

namespace Bookbase
{
    public partial class FormBookList : Form
    {
        Librarydb db;

        public FormBookList(Librarydb dbpar, List<BookAlbum> booklist)
        {
            InitializeComponent();
            db = dbpar;
            foreach (BookAlbum ba in booklist)
            {
                string s = authorclass.BookAuthorString(db, ba) + " (" + dbutil.bkbprice(ba.YearThis) + ") " + ba.Title;
                listBox1.Items.Add(s);
            }
        }

        public FormBookList(Librarydb dbpar, List<Author> authorlist, bool music, bool count, bool location)
        {
            InitializeComponent();
            db = dbpar;
            string indrag = "   ";
            Dictionary<int, string> typenamedict = new Dictionary<int, string>();
            foreach (Bookmusictype bm in (from c in db.Bookmusictype select c))
                typenamedict.Add(bm.Id, bm.Type);
            foreach (Author aa in authorlist)
            {
                int nb = 0;
                //listBox1.Items.Add(aa.Name);
                List<int> books = new List<int>();
                List<string> bookitems = new List<string>();
                List<string> chapteritems = new List<string>();
                List<int> cassettes = new List<int>();
                Dictionary<int, int> typedict = new Dictionary<int, int>();

                foreach (AuthorBook ab in aa.AuthorBook)
                {
                    books.Add(ab.BookAlbum);
                    string s = indrag + ab.BookAlbumBookAlbum.Title + " (" + dbutil.bkbprice(ab.BookAlbumBookAlbum.YearThis) + ")";
                    if ((ab.BookAlbumBookAlbum.Type == 0) != music)
                    {
                        if (!typedict.ContainsKey(ab.BookAlbumBookAlbum.Type))
                            typedict.Add(ab.BookAlbumBookAlbum.Type, 1);
                        else
                            typedict[ab.BookAlbumBookAlbum.Type]++;
                        
                            
                        if (ab.BookAlbumBookAlbum.Type > 0)
                        {
                            s += " " + ab.BookAlbumBookAlbum.Bookmusictype.Type;
                            if (ab.BookAlbumBookAlbum.Price > 0)
                            {
                                s += ab.BookAlbumBookAlbum.Price.ToString();
                                if ( !cassettes.Contains((int)ab.BookAlbumBookAlbum.Price))
                                    cassettes.Add((int)ab.BookAlbumBookAlbum.Price);
                            }
                        }
                        //listBox1.Items.Add(s);
                        bookitems.Add(s);
                        nb++;
                    }
                }
                //if (nb > 0)
                //    listBox1.Items.Add("");
                int nc = 0;
                //int ncall = 0;
                foreach (AuthorChapter ac in aa.AuthorChapter)
                {
                    if (!books.Contains(ac.ChapterSongChapterSong.BookAlbum))
                    {
                        string s = indrag + indrag + ac.ChapterSongChapterSong.Title + ". in: ";
                        BookAlbum ba = ac.ChapterSongChapterSong.BookAlbumBookAlbum;
                        s += authorclass.BookAuthorString(db, ba) + " (" + dbutil.bkbprice(ba.YearThis) + ") " + ba.Title;
                        if ((ba.Type == 0) != music)
                        {
                            if (ba.Type > 0)
                            {
                                s += " " + ba.Bookmusictype.Type;
                                if (ba.Price > 0)
                                    s += ba.Price.ToString();
                            }
                            //listBox1.Items.Add(s);
                            chapteritems.Add(s);
                            nc++;
                        }
                    }
                }
                //if (nc > 0)
                //    listBox1.Items.Add("");
                string aas = aa.Name;
                string bookalbum = "books";
                string chaptersong = "chapters";
                if (music)
                {
                    bookalbum = "albums";
                    chaptersong = "songs";
                }
                if ( count)
                {
                    if (nb > 0)
                        aas += ", " + nb.ToString() + " " + bookalbum;
                    if ( aa.AuthorChapter.Count > 0)
                        aas += ", " + aa.AuthorChapter.Count.ToString() + " " + chaptersong;
                }
                listBox1.Items.Add(aas);
                if ( location)
                {
                    cassettes.Sort();
                    string locs = indrag;
                    foreach (int itype in typedict.Keys)
                    {
                        locs += " "+typedict[itype] + " " + typenamedict[itype];
                        if (itype == 2)
                            foreach (int ic in cassettes)
                                locs += " "+ic;
                        locs += ";";
                    }
                    listBox1.Items.Add(locs);
                }
                else
                {
                    foreach (string s in bookitems)
                        listBox1.Items.Add(s);
                    foreach (string s in chapteritems)
                        listBox1.Items.Add(s);
                }




            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file|*.txt";
            saveFileDialog1.Title = "Save list as text file";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (string s in listBox1.Items)
                    {
                        sw.WriteLine(s);
                    }
                }
            }
        }
    }
}
