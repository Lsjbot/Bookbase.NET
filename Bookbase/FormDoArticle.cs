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
    public partial class FormDoArticle : Form
    {
        Librarydb db;
        Article art;
        int id = -1;

        public FormDoArticle(Librarydb dbpar, int idpar)
        {
            InitializeComponent();
            db = dbpar;
            id = idpar;
            art = (from c in db.Article where c.Id == id select c).FirstOrDefault();
            if (art == null)
                TB_title.Text = "(invalid article)";
            else
            {
                TB_title.Text = art.Title;
                this.Text = art.Title;
                Yearlabel.Text = art.Year.ToString();
                var qa = (from c in db.AuthorArticle where c.Article == id select c);
                foreach (AuthorArticle aa in qa)
                {
                    string s = util.addid(aa.AuthorAuthor.Name,aa.Author,100);
                    CB_author.Items.Add(s);
                }
                if ( art.Journal != null)
                {
                    Journallabel.Text = art.JournalJournal.Name;
                    Volumelabel.Text = "Volume "+art.Volume.ToString();
                    Pageslabel.Text = "Pages "+art.Pages;
                }
                else
                {
                    Journallabel.Text = art.Refstring;
                    Volumelabel.Text = "";
                    Pageslabel.Text = "";
                }
                if (art.Summary != null)
                    AbstractBox.AppendText(art.Summary);
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CB_author_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_author.CheckedItems.Count == 0)
                return;

            string s = CB_author.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            //memo(s);
            int coauid = util.getid(s);
            //memo("coauid = " + coauid);

            CB_author.ClearSelected();

            FormDoAuthor fd = new FormDoAuthor(db, coauid);
            fd.Show();

        }

        private void Journallabel_Click(object sender, EventArgs e)
        {
            if (art.Journal != null)
            {
                FormDoJournal fj = new FormDoJournal(db, (int)art.Journal);
                fj.Show();
            }
        }

        private void Journalbutton_Click(object sender, EventArgs e)
        {
            if (art.Journal != null)
            {
                FormDoJournal fj = new FormDoJournal(db, (int)art.Journal);
                fj.Show();
            }

        }
    }
}
