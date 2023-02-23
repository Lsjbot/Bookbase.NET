using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReadCrossref;


namespace Bookbase
{
    class util
    {
        public static string addid(string s, int id, int pad)
        {
            return s.PadRight(pad) + "|" + id.ToString() + "|";
        }

        public static int getid(string s)
        {
            string rex = @"\|(\d+)\|";
            foreach (Match match in Regex.Matches(s, rex))
            {
                return tryconvert(match.Groups[1].Value);
            }

            return -1;

        }

        public static string unused_filename(string fnbase)
        {
            string fn = fnbase;
            int n = 0;
            while (File.Exists(fn))
            {
                n++;
                fn = fnbase.Replace(".", n.ToString("D3") + ".");
            }
            return fn;
        }

        public static void checkpoint(Librarydb db) //save sql script for restoring database
        {
            string fn = util.unused_filename("checkpoint.txt");

            using (StreamWriter sw = new StreamWriter(fn))
            {
                //sw.WriteLine("delete from ArticleReference where Id > "  + (from c in db.ArticleReference select c.Id).Max());
                sw.WriteLine("delete from Authoraffiliation where Id > " + (from c in db.Authoraffiliation select c.Id).Max());
                sw.WriteLine("delete from AuthorAlias where Id > "       + (from c in db.AuthorAlias select c.Id).Max());
                sw.WriteLine("delete from AuthorArticle where Id > "     + (from c in db.AuthorArticle select c.Id).Max());
                sw.WriteLine("delete from AuthorBook where Id > "        + (from c in db.AuthorBook select c.Id).Max());
                sw.WriteLine("delete from AuthorChapter where Id > "     + (from c in db.AuthorChapter select c.Id).Max());
                //sw.WriteLine("delete from AuthorSubject where Id > "     + (from c in db.AuthorSubject select c.Id).Max());
                sw.WriteLine("delete from Journal where Id > "           + (from c in db.Journal select c.Id).Max());
                sw.WriteLine("delete from Publisher where Id > "         + (from c in db.Publisher select c.Id).Max());
                //sw.WriteLine("delete from Ref where Id > "               + (from c in db.Ref select c.Id).Max());
                sw.WriteLine("delete from Article where Id > "           + (from c in db.Article select c.Id).Max());
                sw.WriteLine("delete from ChapterSong where Id > "       + (from c in db.ChapterSong select c.Id).Max());
                sw.WriteLine("delete from BookAlbum where Id > "         + (from c in db.BookAlbum select c.Id).Max());
                sw.WriteLine("delete from Author where Id > "            + (from c in db.Author select c.Id).Max());
                sw.WriteLine("delete from Affiliation where Id > "       + (from c in db.Affiliation select c.Id).Max());
            }

        }



        public static int tryconvert(string word)
        {
            int i = -1;

            try
            {
                i = Convert.ToInt32(word);
            }
            catch (OverflowException)
            {
                //memo("i Outside the range of the Int32 type: " + word);
            }
            catch (FormatException)
            {
                //if ( !String.IsNullOrEmpty(word))
                //    Console.WriteLine("i Not in a recognizable format: " + word);
            }

            return i;

        }

        public static string format_authorlist(List<string> ls)
        {
            
            if (ls.Count == 0)
                return "";
            else if (ls.Count == 1)
                return ls[0];
            else if ( ls.Count < 4)
            {
                string s = ls[0];
                for (int i = 1; i < ls.Count; i++)
                    s += " & " + ls[i];
                return s;
            }
            else
            {
                return ls[0] + " et al.";
            }
            
        }

        public static string addcentury(int? year)
        {
            if (year == null)
                return "(no year)";
            if (year <= (DateTime.Now.Year % 100))
                return "20" + year.ToString();
            else if (year < 100)
                return "19" + year.ToString();
            else
                return year.ToString();
        }

        public static string get_webpage(string url)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Lsjbot; mailto:lsjjsllsjjsl@gmail.com");

            try
            {
                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return s;
            }
            catch (WebException e)
            {
                string message = e.Message;
                Console.Error.WriteLine(message);
            }
            return "";
        }

        public static string csvFromISBN(string isbn)
        {
            string ba = csvFromOpenlibrary(isbn);

            if (!String.IsNullOrEmpty(ba))
                return ba;

            ba = csvFromLibris(isbn);

            return ba;
        }

        public static string csvFromLibris(string isbn)
        {
            string s = "";

            string au = "";
            string tit = "";
            string pub = "";
            string yf = "";
            string yt = "";

            string librisurl = "http://libris.kb.se/xsearch?query=" + isbn + "&format=json";

            string json = get_webpage(librisurl);

            if (String.IsNullOrEmpty(json) || json.Contains("\"records\": 0,"))
                return null;

            JObject jx = JObject.Parse(json);
            JToken j = jx["xsearch"];

            Console.WriteLine("# records found (Libris) = " + j["records"].ToString());

            string yearrex = @"(.+), \d{4}";

            foreach (JObject jrecord in j["list"])
            {
                Console.WriteLine("ISBN = " + jrecord["isbn"].ToString() + ", title = " + jrecord["title"].ToString());
                if (jrecord.ContainsKey("title"))
                    tit = jrecord["title"].ToString().Replace(";", ".,");
                if (jrecord.ContainsKey("creator"))
                {
                    au = jrecord["creator"].ToString();
                    foreach (Match m in Regex.Matches(au,yearrex))
                    {
                        au = m.Groups[1].Value;
                    }
                }
                if (jrecord.ContainsKey("publisher"))
                    foreach (JValue ja in jrecord["publisher"])
                {
                    Console.WriteLine("Publisher: " + ja.ToString());
                        if (!String.IsNullOrEmpty(ja.ToString()))
                        {
                            pub = ja.ToString();
                            break;
                        }
                }
                if (jrecord.ContainsKey("date"))
                    foreach (JValue ja in jrecord["date"])
                    {
                        if (!String.IsNullOrEmpty(ja.ToString()))
                            yt = ja.ToString().Trim(new char[] { '[', ']' });
                        if (yt.Length > 2)
                            yt = yt.Substring(yt.Length - 2);
                        yf = yt;
                    }
                if (!string.IsNullOrEmpty(tit))
                    break;
            }

            s = au + ";" + tit + ";" + pub + ";;" + yf + ";" + yt + ";;;1;;;Sverker;" + isbn;

            return s;
        }

        public static string get_csvpart(string csv, int n)
        {
            if (csv == null)
                return "";
            string[] w = csv.Split(';');
            if (w.Length > n)
                return w[n];
            else
                return "";
        }

        public static string csvFromOpenlibrary(string isbn)
        {
            string s = "";

            string au = "";
            string tit = "";
            string pub = "";
            string yf = "";
            string yt = "";

            string olurl = "http://openlibrary.org/search.json?q=" + isbn;

            string json = get_webpage(olurl);

            if (String.IsNullOrEmpty(json) || json.Contains("\"numFound\": 0,"))
                return null;

            JObject j = JObject.Parse(json);

            Console.WriteLine("# records found (OL) = " + j["numFound"].ToString());

            foreach (JObject jrecord in j["docs"])
            {
                Console.WriteLine("ISBN = " + jrecord["isbn"].ToString() + ", title = " + jrecord["title"].ToString());
                tit = jrecord["title"].ToString().Replace(";",".,");
                yt = jrecord.ContainsKey("publish_year") ? jrecord["publish_year"][0].ToString() : "0";
                if (yt.Length > 2)
                    yt = yt.Substring(yt.Length - 2);
                yf = jrecord.ContainsKey("first_publish_year") ? jrecord["publish_year"][0].ToString() : yt;
                if (yf.Length > 2)
                    yf = yt.Substring(yf.Length - 2);
                foreach (JValue ja in jrecord["author_name"])
                {
                    Console.WriteLine("Author: " + ja.ToString());
                    //int iaudb = authorclass.NewAuthor(db, ja.ToString());
                    au += ja.ToString() + "&";

                }
                au = au.Trim('&');
                foreach (JValue ja in jrecord["publisher"])
                {
                    Console.WriteLine("Publisher: " + ja.ToString());
                    pub = ja.ToString();
                }

            }
            s = au + ";" + tit + ";" + pub + ";;" + yf + ";" + yt + ";;;1;;;Sverker;" + isbn;

            return s;
        }

        public static BookAlbum bookFromISBN(string isbn,Librarydb db)
        {
            BookAlbum ba = bookFromLibris(isbn,db);

            if (ba != null)
                return ba;

            ba = bookFromOpenlibrary(isbn, db);

            return ba;
        }
        public static BookAlbum bookFromLibris(string isbn, Librarydb db)
        {
            BookAlbum ba = new BookAlbum();

            //http://libris.kb.se/xsearch?query=9780674008069&format=json

            string librisurl = "http://libris.kb.se/xsearch?query=" + isbn + "&format=json";

            string json = get_webpage(librisurl);

            if (json.Contains("\"records\": 0,"))
                return null;

            JObject jx = JObject.Parse(json);
            JToken j = jx["xsearch"];

            Console.WriteLine("# records found (Libris) = " + j["records"].ToString());

            foreach (JObject jrecord in j["list"])
            {
                Console.WriteLine("ISBN = " + jrecord["isbn"].ToString()+", title = "+jrecord["title"].ToString());
            }


            return ba;
        }

        public static BookAlbum bookFromOpenlibrary(string isbn, Librarydb db)
        {
            BookAlbum ba = new BookAlbum();

            ba.Id = (from c in db.BookAlbum select c.Id).Max() + 1;
            ba.ISBN = isbn;

            //"http://openlibrary.org/search.json?q=$isbn"

            string olurl = "http://openlibrary.org/search.json?q=" + isbn;

            string json = get_webpage(olurl);

            if (json.Contains("\"numFound\": 0,"))
                return null;

            JObject j = JObject.Parse(json);

            Console.WriteLine("# records found (OL) = " + j["numFound"].ToString());

            foreach (JObject jrecord in j["docs"])
            {
                Console.WriteLine("ISBN = " + jrecord["isbn"].ToString() + ", title = " + jrecord["title"].ToString());
                ba.Title = jrecord["title"].ToString();
                ba.YearThis = jrecord.ContainsKey("publish_year") ? util.tryconvert(jrecord["publish_year"][0].ToString()): 0;
                ba.YearFirst = jrecord.ContainsKey("first_publish_year") ? util.tryconvert(jrecord["publish_year"][0].ToString()) : ba.YearThis;
                foreach (JValue ja in jrecord["author_name"])
                {
                    Console.WriteLine("Author: "+ja.ToString());
                    //int iaudb = authorclass.NewAuthor(db, ja.ToString());

                }
                foreach (JValue ja in jrecord["publisher"])
                {
                    Console.WriteLine("Publisher: " + ja.ToString());
                    var q = from c in db.Publisher where c.Name.ToLower() == ja.ToString().ToLower() select c.Id;
                    if (q.Count() > 0)
                        ba.Publisher = q.First();
                    else
                    {
                        if (!String.IsNullOrEmpty(ja.ToString()))
                        {
                            Publisher pp = new Publisher();
                            pp.Id = (from c in db.Publisher select c.Id).Max() + 1;
                            pp.Name = ja.ToString();
                            //db.Publisher.InsertOnSubmit(pp);
                            //db.SubmitChanges();
                            ba.Publisher = pp.Id;
                        }
                        else
                            ba.Publisher = null;

                    }
                }

            }
            return ba;
        }
    }
}
