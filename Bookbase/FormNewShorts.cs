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
    public partial class FormNewShorts : Form
    {
        Librarydb db;
        FormNewBook parent = null;
        string mainauthor;
        int ics;
        int iac;

        public FormNewShorts(Librarydb dbpar, FormNewBook parentpar, string mainauthorpar)
        {
            InitializeComponent();
            db = dbpar;
            parent = parentpar;
            mainauthor = mainauthorpar;
            var q = from c in db.Author select c.Name;
            AutoCompleteStringCollection acs = new AutoCompleteStringCollection();
            foreach (string s in q)
                acs.Add(s);
            TB_author.AutoCompleteCustomSource = acs;
            TB_author.Text = mainauthor;
            ics = (from c in db.ChapterSong select c.Id).Max()+1;
            if (parent.shortslist.Count > 0)
            {
                int ics2 = (from c in parent.shortslist select c.Id).Max() + 1;
                ics = Math.Max(ics, ics2);
            }
            iac = (from c in db.AuthorChapter select c.Id).Max()+1;
            if ( parent.shortsauthorlist.Count > 0)
            {
                int iac2 = (from c in parent.shortsauthorlist select c.Id).Max() + 1;
                iac = Math.Max(iac, iac2);
            }
        }

        private void Donebutton_Click(object sender, EventArgs e)
        {
            register_current();
            parent.showshorts();
            parent.saveshorts();

            this.Close();
        }

        private void Coauthorbutton_Click(object sender, EventArgs e)
        {
            LB_coauthor.Items.Add(TB_author.Text);
            TB_author.Text = "";
            TB_author.Focus();
        }

        private AuthorChapter make_authorchapter(string author, int csid)
        {
            AuthorChapter ac = new AuthorChapter();
            ac.Id = iac;
            iac++;
            ac.ChapterSong = csid;
            Author au = (from c in db.Author where c.Name == author select c).FirstOrDefault();
            if (au == null)
            {
                int authorid = authorclass.NewAuthor(db, author);
                if (authorid > 0)
                {
                    ac.Author = authorid;
                    return ac;
                }
                return null;
            }
            else
            {
                ac.Author = au.Id;
                return ac;
            }
        }

        private void register_current()
        {
            if (String.IsNullOrEmpty(TB_title.Text))
                return;

            ChapterSong cs = new ChapterSong();
            cs.Id = ics;
            ics++;
            cs.Title = TB_title.Text;
            parent.shortslist.Add(cs);

            AuthorChapter ac = make_authorchapter(TB_author.Text, cs.Id);
            if (ac != null)
                parent.shortsauthorlist.Add(ac);
            foreach (string s in LB_coauthor.Items)
            {
                AuthorChapter acc = make_authorchapter(s, cs.Id);
                if (acc != null)
                    parent.shortsauthorlist.Add(acc);
            }
        }

        private void Anotherbutton_Click(object sender, EventArgs e)
        {
            register_current();
            TB_title.Text = "";
            LB_coauthor.Items.Clear();
            if (TB_author.Text != mainauthor)
            {
                TB_author.Text = "";
                TB_author.Focus();
            }
            else
                TB_title.Focus();
        }
    }
}
