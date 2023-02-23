using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ReadCrossref;
using System.Text.RegularExpressions;
using Id3;


namespace Bookbase
{
    public partial class Form1 : Form
    {
        private Button xx = new System.Windows.Forms.Button();

        public Librarydb db = null;
        public static string connectionstring = "Data Source=DESKTOP-G39SBTI;Initial Catalog=\"librarydb\";Integrated Security=True";
        public static int nullauthor = 53839; //pseudo-author for un-authored collections

        public Form1()
        {
            //xx.Location = new Point(100, 100);
            //xx.Text = "Test button";
            //xx.Size = new System.Drawing.Size(75, 23);
            ////xx.TabIndex = 0;
            //xx.UseVisualStyleBackColor = true;
            ////xx.Click += new System.EventHandler(xx_Click);
            //this.Controls.Add(xx);
            InitializeComponent();
            db = new Librarydb(connectionstring);
        }

        private void LookButton_Click(object sender, EventArgs e)
        {
            FormLook fl = new FormLook(db);
            fl.Show();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bookbutton_Click(object sender, EventArgs e)
        {
            util.checkpoint(db);
            FormFindAuthor fa = new FormFindAuthor(db);

            DialogResult faresult = fa.ShowDialog();
            var auid = fa.authorid;
            //memo("authorid = " + auid.ToString());

            if ((faresult == DialogResult.OK) && (auid >= 0))
            {
                FormNewBook fd = new FormNewBook(db, auid,null);
                fd.Show();
            }

        }

        private void BKBbutton_Click(object sender, EventArgs e)
        {
            //Generate BKB file, for backwards compatibility with my old Bookbase program


            string fn = @"d:\Bookbase\books-generated-"+DateTime.Now.ToShortDateString()+".bkb";
            Encoding eansi = Encoding.GetEncoding(1252);
            using (StreamWriter sw = new StreamWriter(new FileStream(fn, FileMode.Create, FileAccess.Write), eansi))
            {
                sw.WriteLine("0\tBOOKS");

                int n = 1;

                foreach (BookAlbum ba in (from c in db.BookAlbum where c.Type == 0 select c))
                {
                    StringBuilder sb = new StringBuilder(n.ToString() + "\t");
                    n++;
                    sb.Append(authorclass.BookAuthorString(db, ba) + "\t");
                    sb.Append(ba.Title + "\t");
                    if (ba.Publisher != null)
                        sb.Append(ba.PublisherPublisher.Name + "\t");
                    else
                        sb.Append("\t");
                    sb.Append(dbutil.bkbdate(ba.DateBought) + "\t");
                    sb.Append(dbutil.bkbyear(ba.YearFirst) + "\t");
                    sb.Append(dbutil.bkbyear(ba.YearThis) + "\t");
                    sb.Append(ba.WhereBought + "\t");
                    sb.Append(dbutil.bkbprice(ba.Price) + "\t");
                    sb.Append("1\t");
                    sb.Append(dbutil.bkbprice(ba.Liked) + "\t");
                    sb.Append(ba.Subject + "\t");
                    sb.Append("Sverker\t");
                    sb.Append(ba.ISBN);
                    sw.WriteLine(sb.ToString());
                    foreach (ChapterSong cs in ba.ChapterSong)
                    {
                        StringBuilder sbb = new StringBuilder(n.ToString() + "\t#\t");
                        n++;
                        sbb.Append(authorclass.ChapterAuthorString(db, cs) + "\t");
                        sbb.Append(cs.Title);
                        sw.WriteLine(sbb.ToString());
                    }

                }
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            FormDelete fd = new FormDelete(db);
            fd.Show();
        }

        private void Listbutton_Click(object sender, EventArgs e)
        {
            FormListmaker fa = new FormListmaker(db,RB_music.Checked);

            fa.Show();
        }

        private string getleaf(string path)
        {
            
            string s = path.Split('\\').Last();
            return s;
        }

        private string getaufromsong(string path)
        {
            string[] ss = getleaf(path).Split('.');
            string s = ss[0];
            if (ss.Length > 1)
            {
                if (badtype.Contains(ss.Last()))
                    return null;
                s = getleaf(path).Replace("." + ss.Last(), "");

            }
            string rex = @"^(\d\d)";
            foreach (Match match in Regex.Matches(s, rex, RegexOptions.IgnoreCase))
            {
                //memo("Full match = " + match.Value);
                //memo("Found (1) "+match.Groups[1].Value);
                s = s.Replace(match.Value, "");
            }
            rex = @"^(\d)";
            foreach (Match match in Regex.Matches(s, rex, RegexOptions.IgnoreCase))
            {
                //memo("Full match = " + match.Value);
                //memo("Found (1) "+match.Groups[1].Value);
                s = s.Replace(match.Value, "");
            }

            if (s.Length > 0)
                s = s.Trim(new char[2] { ' ', '-' });
            else
                s = ss[0].Trim(new char[2] { ' ', '-' });

            if (String.IsNullOrEmpty(s))
                return null;
            if (!s.Contains('-'))
                return null;

            string[] sss = s.Split('-');
            return sss[0];
        }

        private static List<string> badtype = new List<string>() { "jpg", "db", "ini" , "zip", "rar", "m3u"}; //skip these file type

        private string getsong(string path)
        {
            string[] ss = getleaf(path).Split('.');
            string s = ss[0];
            if (ss.Length > 1)
            {
                if (badtype.Contains(ss.Last()))
                    return null;
                s = getleaf(path).Replace("." + ss.Last(),"");

            }
            string rex = @"^(\d\d)";
            foreach (Match match in Regex.Matches(s, rex, RegexOptions.IgnoreCase))
            {
                //memo("Full match = " + match.Value);
                //memo("Found (1) "+match.Groups[1].Value);
                s = s.Replace(match.Value, "");
            }
            rex = @"^(\d)";
            foreach (Match match in Regex.Matches(s, rex, RegexOptions.IgnoreCase))
            {
                //memo("Full match = " + match.Value);
                //memo("Found (1) "+match.Groups[1].Value);
                s = s.Replace(match.Value, "");
            }

            if (s.Length > 0)
                return s.Trim(new char[2] { ' ', '-' });
            else
                return ss[0].Trim(new char[2] { ' ', '-' });

        }

        private int song_file_to_db(string fn, int auidpar, int albumid, int csidpar)
        {
            int csid = csidpar;
            int auid = auidpar;

            string tit = getsong(fn);
            if (auid == nullauthor)
            {
                string auname = getaufromsong(fn);
                if (!String.IsNullOrEmpty(auname))
                {
                    auid = authorclass.NewAuthor(db, auname);
                    tit = getsong(fn.Replace(auname, ""));
                }
            }

            if (fn.Contains(".mp3"))
            {
                using (var mp3 = new Mp3(fn))
                {
                    if (mp3.HasTags && !fn.Contains(@"\Kristel\"))
                    {
                        //memo(fn);
                        var tags = mp3.GetAllTags();
                        if (tags.Count() > 0)
                        {
                            //Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);
                            foreach (Id3Tag tag in tags)
                            {
                                if (tag != null)
                                {
                                    //memo("Title: " + tag.Title);
                                    if (!String.IsNullOrEmpty(tag.Title))
                                        tit = tag.Title;
                                    //memo("Artist: " + tag.Artists);
                                    if ((auid == nullauthor) && (!String.IsNullOrEmpty(tag.Artists)) && (tag.Artists != "Various Artists"))
                                    {
                                        auid = authorclass.NewAuthor(db, tag.Artists);
                                        if (auid < 0)
                                            auid = nullauthor;
                                    }
                                    //memo("Album: " + tag.Album);
                                    //memo("Year: " + tag.Year);
                                }
                            }
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(tit))
                return csid;

            ChapterSong cs = new ChapterSong();
            //int csid = (from c in db.BookAlbum select c.Id).Max() + 1;
            csid++;
            cs.Id = csid;
            cs.Title = tit;
            cs.BookAlbum = albumid;
            db.ChapterSong.InsertOnSubmit(cs);
            db.SubmitChanges();

            AuthorChapter ac = new AuthorChapter();
            int acid = (from c in db.AuthorChapter select c.Id).Max()+1;
            ac.Id = acid;
            ac.ChapterSong = cs.Id;
            ac.Author = auid;
            db.AuthorChapter.InsertOnSubmit(ac);
            return csid;
        }

        private int album_file_to_db(string fn, int auidpar)
        {
            int auid = auidpar;
            BookAlbum ba = new BookAlbum();
            int baid = (from c in db.BookAlbum select c.Id).Max() + 1;
            ba.Id = baid;
            string tit = getsong(fn);
            if (fn.Contains(".mp3"))
            {
                using (var mp3 = new Mp3(fn))
                {
                    if (mp3.HasTags && !fn.Contains(@"\Metallica\"))
                    {
                        var tags = mp3.GetAllTags();
                        if (tags.Count() > 0)
                        {
                            //Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);
                            foreach (Id3Tag tag in tags)
                            {
                                if (tag != null)
                                {
                                    if (!String.IsNullOrEmpty(tag.Title))
                                        tit = tag.Title;
                                    //memo("Artist: " + tag.Artists);
                                    if ((auid == nullauthor) && (!String.IsNullOrEmpty(tag.Artists)) && (tag.Artists != "Various Artists"))
                                    {
                                        auid = authorclass.NewAuthor(db, tag.Artists);
                                        if (auid < 0)
                                            auid = nullauthor;
                                    }
                                    //memo("Album: " + tag.Album);
                                    //memo("Year: " + tag.Year);
                                    ba.YearThis = tag.Year;
                                }
                            }
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(tit))
                return -1;

            ba.Title = tit;
            ba.Type = 4;
            if (fn.Length < 60)
                ba.WhereBought = fn;
            else
                ba.WhereBought = fn.Substring(0, 59);
            ba.Havecopy = false;
            db.BookAlbum.InsertOnSubmit(ba);
            db.SubmitChanges();

            AuthorBook ab = new AuthorBook();
            int abid = (from c in db.AuthorBook select c.Id).Max() + 1;
            ab.Id = abid;
            ab.BookAlbum = baid;
            ab.Author = auid;
            db.AuthorBook.InsertOnSubmit(ab);
            db.SubmitChanges();

            return baid;
        }

        private void artistfolder(string folder, string artistname)
        {
            int auid = authorclass.NewAuthor(db, artistname);

            memo("Artist "+auid+" name " + artistname);


            foreach (string fn in Directory.GetFiles(folder))
            {
                //memo("Song " + getsong(fn));
                album_file_to_db(fn, auid);
            }
            foreach (string subfolder in Directory.GetDirectories(folder))
            {
                memo("Album " + getleaf(subfolder));
                int albumid = album_file_to_db(subfolder, auid);
                if (albumid < 0)
                    continue;
                int csid = (from c in db.ChapterSong select c.Id).Max() + 1;
                foreach (string file in Directory.GetFiles(subfolder))
                {
                    //memo("-- Song " + getsong(file));
                    csid = song_file_to_db(file, auid,albumid,csid);
                }
                db.SubmitChanges();
            }


        }

        private void artistfolder(string folder)
        {
            artistfolder(folder, getleaf(folder));

        }

        private void extract_from_foldertree(string folder)
        {
            foreach (string subfolder in Directory.GetDirectories(folder))
            {
                memo(subfolder);
                if (getleaf(subfolder).StartsWith("00-"))
                {
                    memo("00-");
                    if (getleaf(subfolder).Contains("lassical"))
                        extract_from_foldertree(subfolder);
                    else
                        artistfolder(subfolder, "-");
                }
                else if (getleaf(subfolder).Length == 1) //letter folders
                {
                    memo("Letter folder");
                    extract_from_foldertree(subfolder);
                }
                else
                    artistfolder(subfolder);
            }
        }

        private void Directorybutton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                util.checkpoint(db);
                string folder = folderBrowserDialog1.SelectedPath;
                memo(folder);
                extract_from_foldertree(folder);
            }
        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Modifybutton_Click(object sender, EventArgs e)
        {
            FormModify fm = new FormModify(db);
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookAlbum ba = util.bookFromISBN(textBox1.Text, db);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ISBNbutton_Click(object sender, EventArgs e)
        {
            util.checkpoint(db);
            FormNewBook fd = new FormNewBook(db, -1, null);
            fd.Show();

        }
    }
}
