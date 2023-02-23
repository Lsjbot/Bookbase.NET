using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace ReadCrossref
{
    public class authorclass
    {
        public string fullname = "";
        public string familyname = "";
        public string firstname = "";
        public string initials = "";
        public string affiliation = "";
        public int affid = -1;
        public bool active = true;
        public int iaudb = -1;
        public int form2choice = -1;

        //public static Form1 parentform = null;

        public static int nextaudb = -1; // Next database id for authors
        public static Dictionary<string, int> aliaslist = new Dictionary<string, int>();

        public void NormalizeCase()
        {
            this.familyname = authorclass.NormalizeCase(this.familyname);
            this.firstname = authorclass.NormalizeCase(this.firstname);
            this.fullname = authorclass.NormalizeCase(this.fullname);
        }

        public static void MergeDB(Librarydb db, Author adbinto, Author adbfrom)//, Form1 parentform) //Merge adb2 into adb1 in database
        {
            //parentform.memo("Merging " + authorclass.GetFullname(adb2) + " into " + authorclass.GetFullname(adb1));
            //Affiliation relations

            if (adbinto == null)
                return;
            if (adbfrom == null)
                return;

            var qaff = from c in db.Authoraffiliation where c.Author == adbfrom.Id select c;
            foreach (Authoraffiliation aa in qaff)
            {
                if ((from c in db.Authoraffiliation where c.Author == adbinto.Id where c.Affiliation == aa.Affiliation select c).Count() > 0)
                    db.Authoraffiliation.DeleteOnSubmit(aa);
                else
                    aa.Author = adbinto.Id;
            }

            //Article relations
            var qart = from c in db.AuthorArticle where c.Author == adbfrom.Id select c;
            foreach (AuthorArticle aa in qart)
            {
                if ((from c in db.AuthorArticle where c.Author == adbinto.Id where c.Article == aa.Article select c).Count() > 0)
                    db.AuthorArticle.DeleteOnSubmit(aa);
                else
                    aa.Author = adbinto.Id;
            }

            //Book relations
            var qbook = from c in db.AuthorBook where c.Author == adbfrom.Id select c;
            foreach (AuthorBook aa in qbook)
            {
                if ((from c in db.AuthorBook where c.Author == adbinto.Id where c.BookAlbum == aa.BookAlbum select c).Count() > 0)
                    db.AuthorBook.DeleteOnSubmit(aa);
                else
                    aa.Author = adbinto.Id;
            }

            //Chapter relations
            var qChapter = from c in db.AuthorChapter where c.Author == adbfrom.Id select c;
            foreach (AuthorChapter aa in qChapter)
            {
                if ((from c in db.AuthorChapter where c.Author == adbinto.Id where c.ChapterSong == aa.ChapterSong select c).Count() > 0)
                    db.AuthorChapter.DeleteOnSubmit(aa);
                else
                    aa.Author = adbinto.Id;
            }

            //Redirect any old aliases
            var qaa = from c in db.AuthorAlias where c.Author == adbfrom.Id select c;
            foreach (AuthorAlias caa in qaa)
                caa.Author = adbinto.Id;

            //Create alias:
            AuthorAlias ala = new AuthorAlias();
            var q = (from c in db.AuthorAlias select c);
            int ij = 1;
            if (q.Count() > 0)
            {
                ij = (from c in db.AuthorAlias select c.Id).Max() + 1;
            }
            ala.Id = ij;
            ala.Name = adbfrom.Name;
            ala.Familyname = adbfrom.Familyname;
            ala.Givenname = adbfrom.Givenname;
            ala.Author = adbinto.Id;
            db.AuthorAlias.InsertOnSubmit(ala);


            //Merge the actual authors. Assume FamilynameAscii same
            string oldname1 = authorclass.GetFullname(adbinto);
            string oldfamily = adbinto.Familyname;
            string oldgiven = adbinto.Givenname;

            if ( adbinto.Familyname != adbfrom.Familyname)
            {
                int d1 = dbutil.LevenshteinDistance(adbinto.Familyname, adbinto.FamilynameAscii);
                int d2 = dbutil.LevenshteinDistance(adbfrom.Familyname, adbinto.FamilynameAscii);
                if (d2 > d1)
                    adbinto.Familyname = adbfrom.Familyname;
            }
            if (adbfrom.Givenname.Length > adbinto.Givenname.Length)
                adbinto.Givenname = adbfrom.Givenname;
            else if (adbfrom.Givenname.Length == adbinto.Givenname.Length)
            {
                int d1 = dbutil.LevenshteinDistance(adbinto.Givenname, adbinto.GivennameAscii);
                int d2 = dbutil.LevenshteinDistance(adbfrom.Givenname, adbinto.GivennameAscii);
                if (d2 > d1)
                    adbinto.Givenname = adbfrom.Givenname;
            }
            adbinto.Name = authorclass.GetFullname(adbinto);
            adbinto.FamilynameAscii = dbutil.RemoveDiacritics(adbinto.Familyname);
            adbinto.GivennameAscii = dbutil.RemoveDiacritics(adbinto.Givenname);
            db.Author.DeleteOnSubmit(adbfrom);

            if ( authorclass.GetFullname(adbinto) != oldname1 )
            {
                //make alias from original adb1 name
                AuthorAlias ala1 = new AuthorAlias();
                ij++;
                ala1.Id = ij;
                ala1.Name = oldname1;
                ala1.Familyname = oldfamily;
                ala1.Givenname = oldgiven;
                ala1.Author = adbinto.Id;
                db.AuthorAlias.InsertOnSubmit(ala1);
            }

            db.SubmitChanges();
        }

        public static string NormalizeCase(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            if (s.ToUpper() != s)
                return s.Replace("  "," ").Trim();
            string[] ss = s.Trim().ToLower().Split();
            string rs = "";
            foreach (string sss in ss)
            {
                if ( !String.IsNullOrEmpty(sss))
                    rs += sss.Replace(sss.Substring(0, 1), sss.Substring(0, 1).ToUpper()) + " ";
            }
            return rs.Trim();
        }

        public List<Author> GetCompatibles(Librarydb db, int mincomp)
        {
            var q = from c in db.Author
                    where c.FamilynameAscii == dbutil.RemoveDiacritics(this.familyname)
                    select c;

            List<Author> compatibles = new List<Author>();
            int icompmax = mincomp;
            //if (q.Count() > 0)
            //    parentform.memo(this.firstname + "--------");
            foreach (Author adb in q)
            {
                int icomp = this.Compatible(adb);
                //if (icomp > 0)
                //    parentform.memo(icomp + " " + adb.Givenname);

                if (icomp > icompmax)
                {
                    compatibles.Clear();
                    compatibles.Add(adb);
                    icompmax = icomp;
                }
                else if (icomp == icompmax)
                    compatibles.Add(adb);
            }
            return compatibles;
        }

        public static int NewAuthor(Librarydb db, string name)
        {
            int authorid = -1;
            authorclass ac = authorclass.Parse(name).FirstOrDefault();
            if (ac != null)
            {
                authorid = ac.AuthorToDB(db);
            }
            return authorid;
        }

        public void NewAuthorToDB(Librarydb db, int nextaudb)
        {
            Author adb = new Author();
            adb.Id = nextaudb;
            this.iaudb = nextaudb;
            adb.Familyname = this.familyname;
            adb.FamilynameAscii = dbutil.RemoveDiacritics(this.familyname);
            if (String.IsNullOrEmpty(this.firstname))
                adb.Givenname = this.initials;
            else
                adb.Givenname = this.firstname;
            adb.GivennameAscii = dbutil.RemoveDiacritics(adb.Givenname);
            adb.Name = authorclass.GetFullname(adb);

            db.Author.InsertOnSubmit(adb);

            if (this.affid > 0)
            {
                Authoraffiliation aaff = new Authoraffiliation();
                aaff.Id = 1;
                if ((from c in db.Authoraffiliation select c).Count() > 0)
                    aaff.Id = (from c in db.Authoraffiliation select c.Id).Max() + 1;
                aaff.Author = this.iaudb;
                aaff.Affiliation = this.affid;
                db.Authoraffiliation.InsertOnSubmit(aaff);
            }
            db.SubmitChanges();
            
        }

        public int AuthorToDB(Librarydb db)
        {
            if (!active)
                return -1;

            if (iaudb > 0)
                return iaudb;



            if (aliaslist.ContainsKey(this.GetFullname()))
            {
                //parentform.memo("Alias found for " + this.GetFullname());
                return aliaslist[this.GetFullname()];
            }

            if ( nextaudb < 0)
            {
                nextaudb = 1;
                var qq = (from c in db.Author select c);
                if (qq.Count() > 0)
                    nextaudb = (from c in db.Author select c.Id).Max() + 1;
            }



            List<Author> compatibles = this.GetCompatibles(db,4);

            if (compatibles.Count == 1)
            {
                iaudb = compatibles.First().Id;
                this.Merge(compatibles.First());
                aliaslist.Add(this.GetFullname(), iaudb);
            }
            else if (compatibles.Count > 1)
            {
                //find which one is right. How?
                string msg = "Multiple matches for " + this.GetFullname() + ":";

                string[] auarray = new string[compatibles.Count()];
                int i = 0;
                foreach (Author adb in compatibles)
                {
                    msg += "\n" + adb.Familyname + ", " + adb.Givenname;
                    auarray[i] = adb.Familyname + ", " + adb.Givenname;
                    i++;
                }
                //MessageBox.Show(msg);
                //Form2 f2 = new Form2(this, this.GetFullname(), auarray);

                //f2.ShowDialog();
                //f2.Dispose();

                //parentform.memo("form2choice = " + form2choice);

                if ((form2choice >= 0) && (form2choice < auarray.Length))
                {
                    iaudb = compatibles[form2choice].Id;
                    this.Merge(compatibles[form2choice]);
                    aliaslist.Add(this.GetFullname(), iaudb);
                }
            }
            if ( iaudb < 0)
            { //New post:
                this.NewAuthorToDB(db, nextaudb);
                nextaudb++;
            }
            return this.iaudb;
        }

        public void Merge (authorclass auc2)
        {
            if (this.active)
            {
                if (String.IsNullOrEmpty(this.familyname))
                    this.familyname = auc2.familyname;
                if (String.IsNullOrEmpty(this.firstname))
                {
                    this.firstname = auc2.firstname;
                    if (String.IsNullOrEmpty(this.firstname))
                        this.firstname = auc2.initials;
                }
                else if (this.firstname.Length < auc2.firstname.Length)
                {
                    this.firstname = auc2.firstname;
                }
                if (String.IsNullOrEmpty(this.initials))
                {
                    if (!String.IsNullOrEmpty(auc2.initials))
                        this.initials = auc2.initials;
                    else
                        this.initials = authorclass.MakeInitials(this.firstname);
                }
                if (String.IsNullOrEmpty(this.affiliation))
                    this.affiliation = auc2.affiliation;
                this.fullname = GetFullname();

                
                auc2.active = false;
            }
            else if (auc2.active)
            {
                auc2.Merge(this);
            }
            else
                MessageBox.Show("Bad merger in authorclass; both inactive ");
                
        }


        public void Merge(Author adb2)
        {
            if (String.IsNullOrEmpty(this.familyname))
                this.familyname = adb2.Familyname;
            if (String.IsNullOrEmpty(adb2.Givenname))
            {
                if (!String.IsNullOrEmpty(this.firstname))
                    adb2.Givenname = this.firstname;
                else if (!String.IsNullOrEmpty(this.initials))
                    adb2.Givenname = this.initials;
                adb2.GivennameAscii = dbutil.RemoveDiacritics(adb2.Givenname);
            }
            else if (this.firstname.Length > adb2.Givenname.Length)
            {
                adb2.Givenname = this.firstname;
                adb2.GivennameAscii = dbutil.RemoveDiacritics(adb2.Givenname);
            }
            adb2.Name = authorclass.GetFullname(adb2);

            //if (!String.IsNullOrEmpty(this.affiliation))
            //{
            //    var qq = (from c in parentform.db.Authoraffiliation where c.Author == adb2.Id select c);
            //    if (qq.Count() == 0)
            //    {
            //        int iaff = 1;
            //        var q = (from c in parentform.db.Affiliation select c);
            //        if (q.Count() > 0)
            //            iaff = (from c in parentform.db.Affiliation select c.Id).Max() + 1;
            //        iaff = parentform.AffiliationToDB(this.affiliation, iaff, this);
            //    }
            //}
        }

        public string GetFullname()
        {
            if (!String.IsNullOrEmpty(fullname))
                return this.fullname;
            else
                return this.familyname + ", " + this.firstname;
        }

        public static string GetFullname(Author adb)
        {
            if (!String.IsNullOrEmpty(adb.Givenname))
                return adb.Familyname + ", " + adb.Givenname;
            else
                return adb.Familyname + ".";
        }

        public static string Cleanup(string name)
        {
            return name.Replace(".", " ").Replace("  "," ").Trim();
        }

        public int Compatible(authorclass auc2)
        {
            string nf = dbutil.RemoveDiacritics(this.familyname.ToLower());
            string n1 = dbutil.RemoveDiacritics(this.firstname.ToLower());

            if (nf != auc2.familyname.ToLower())
                return 0;

            if (!String.IsNullOrEmpty(this.firstname))
            {
                if (!String.IsNullOrEmpty(auc2.firstname))
                {
                    if (n1 != auc2.firstname.ToLower())
                    {
                        if ((n1.IndexOf(auc2.firstname) == 0) || (auc2.firstname.IndexOf(n1) == 0))
                            return 3;
                        if ((authorclass.MakeInitials(this.firstname) == auc2.firstname) || (authorclass.MakeInitials(auc2.firstname) == this.firstname))
                            return 2;
                        return 0;
                    }
                    else
                        return 4;
                }
                else if (!String.IsNullOrEmpty(auc2.initials))
                {
                    if (n1 == auc2.initials.ToLower())
                        return 4;
                    else if (authorclass.MakeInitials(n1) == auc2.initials.ToLower())
                        return 2;
                    else
                        return 0;
                }
                else
                    return 1;
            }
            else if (!String.IsNullOrEmpty(this.initials))
            {
                if (this.initials.ToUpper() == auc2.firstname.ToUpper())
                    return 4;
                else if ( !String.IsNullOrEmpty(auc2.initials))
                {
                    if (this.initials.ToUpper() == auc2.initials.ToUpper())
                        return 4;
                    else
                        return 0;
                }
                if (String.IsNullOrEmpty(auc2.firstname) && String.IsNullOrEmpty(auc2.initials))
                    return 1;
                else if (authorclass.MakeInitials(auc2.firstname) != this.initials)
                    return 0;
                else
                    return 2;
            }
            else if (String.IsNullOrEmpty(auc2.firstname) && String.IsNullOrEmpty(auc2.initials))
            {
                return 4;
            }
            else
                return 1;

            //return true;
        }

        public int Compatible(Author audb)
        {
            authorclass aucs = new authorclass();
            aucs.familyname = audb.FamilynameAscii;
            aucs.firstname = audb.GivennameAscii;
            return Compatible(aucs);
        }

        public static int Compatible(Author audb1, Author audb2)
        {
            authorclass aucs1 = new authorclass();
            aucs1.familyname = audb1.FamilynameAscii;
            aucs1.firstname = audb1.GivennameAscii;
            authorclass aucs2 = new authorclass();
            aucs2.familyname = audb2.FamilynameAscii;
            aucs2.firstname = audb2.GivennameAscii;
            int ic =  aucs1.Compatible(aucs2);
            //if ( ic > 0)
            //    parentform.memo(aucs1.GetFullname() + " : " + aucs2.GetFullname() + " : " + ic);
            return ic;
        }

        public static string MakeInitials(string name)
        {
            if (String.IsNullOrEmpty(name))
                return "";
            string s = "";
            
            string nn = authorclass.Cleanup(name); 
            if (nn.Contains(" "))
            {
                foreach (string w in nn.Split())
                    if ( !String.IsNullOrEmpty(w))
                        s += w.Substring(0, 1) + " ";
            }
            else if ((nn.ToUpper() == name) && (nn.Length < 4))
            {
                foreach (char c in nn.ToCharArray())
                {
                    s = c + " ";
                }
            }
            else
                s = nn.Substring(0, 1);

            return s.Trim();
        }

        public static List<authorclass> Parse(string namepar)
        {
            List<authorclass> lc = new List<authorclass>();
            string name = namepar.Replace(".", "");
            if ( name.Contains("("))
            {
                string rex = @"\((.+?)\)";
                foreach (Match match in Regex.Matches(name, rex, RegexOptions.IgnoreCase))
                {
                    //Console.WriteLine("Full match = " + match.Value);
                    //Console.WriteLine("Found (1) {0}.",
                    //                  match.Groups[1].Value);
                    foreach (authorclass auc in authorclass.Parse("[" + match.Groups[1].Value + "]"))
                        lc.Add(auc);
                    foreach (authorclass auc in authorclass.Parse(name.Replace("(" + match.Groups[1].Value + ")", "")))
                        lc.Add(auc);
                }

            }
            else if ( name.Contains("&") || name.Contains(" and "))
            {
                foreach (string np in name.Replace(" and "," & ").Split('&'))
                {
                    foreach (authorclass auc in authorclass.Parse(np.Trim()))
                        lc.Add(auc);
                }
            }
            else if (name.Contains(" et al"))
            {
                foreach (authorclass auc in authorclass.Parse(name.Replace(" et al","")))
                    lc.Add(auc);
            }
            else if (name.Contains(","))
            {
                string[] words = name.Split(',');
                if ( words.Length == 2)
                {
                    authorclass auc = new authorclass();
                    auc.familyname = words[0].Trim();
                    auc.firstname = authorclass.Cleanup(words[1]);
                    auc.fullname = name;
                    lc.Add(auc);
                }
                else
                {
                    foreach (string w in words)
                        foreach (authorclass auc in authorclass.Parse(w.Trim()))
                            lc.Add(auc);
                }
            }
            else if (name.Trim().Contains(" "))
            {
                authorclass auc = new authorclass();
                string[] words = name.Split();
                auc.familyname = authorclass.Cleanup(words[words.Length - 1]);
                if (auc.familyname.Length > 1)
                {
                    auc.firstname = authorclass.Cleanup(words[0]);
                    if (words.Length > 2)
                        for (int i = 1; i < words.Length - 1; i++)
                            auc.firstname += " " + authorclass.Cleanup(words[i]);
                }
                else
                {
                    auc.familyname = authorclass.Cleanup(words[0]);
                    auc.firstname = authorclass.Cleanup(words[1]);
                    if (words.Length > 2)
                        for (int i = 2; i < words.Length; i++)
                            auc.firstname += " " + authorclass.Cleanup(words[i]);

                }
                auc.fullname = auc.GetFullname();
                lc.Add(auc);
            }
            else
            {
                authorclass auc = new authorclass();
                auc.familyname = name.Trim();
                auc.fullname = auc.familyname;
                lc.Add(auc);
            }


            return lc;
        }

        public static string BookAuthorString(Librarydb db, BookAlbum ba)
        {
            string s = "";
            string sep = "";

            foreach (AuthorBook ab in ba.AuthorBook)
            {
                s += sep + ab.AuthorAuthor.Name;
                sep = "&";
            }

            return s;
        }

        public static string ChapterAuthorString(Librarydb db, ChapterSong cs)
        {
            string s = "";
            string sep = "";

            foreach (AuthorChapter ab in cs.AuthorChapter)
            {
                s += sep + ab.AuthorAuthor.Name;
                sep = "&";
            }

            return s;
        }

        public static Author AuthorFromId(Librarydb db,int id)
        {
            var q = from c in db.Author
                    where c.Id == id
                    select c;
            return q.FirstOrDefault();
        }
    }

}
