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
    public partial class FormDoPublisher : Form
    {
        Librarydb db;
        private Publisher a;

        public FormDoPublisher(Librarydb dbpar, int pid)
        {
            InitializeComponent();
            db = dbpar;
            var qq = from c in db.Publisher where c.Id == pid select c;
            if (qq.Count() == 0)
            {
                MessageBox.Show("Author not found, Id = " + pid);
                this.Close();
            }
            else
            {
                a = qq.First();
                this.Text = a.Name;
            }

            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            var q = from c in db.BookAlbum where c.Publisher == a.Id select c;
            Bookcountlabel.Text = q.Count().ToString() + " books";
            if (q.Count() > 0)
            {
                foreach (BookAlbum art in q)
                {
                    
                    //string s = art.AuthorBook.First().AuthorAuthor.Familyname+" (" + art.YearFirst + ") " + art.Title + ", " + a.Name;
                    CB_books.Items.Add(art.AuthorBook.First().AuthorAuthor.Familyname + "(" + art.YearFirst + ") " + util.addid(art.Title, art.Id, 100));
                }
            }
            else
                CB_books.Items.Add("(no books)");

            var qj = from c in db.Journal where c.Publisher == a.Id select c;
            Journalcountlabel.Text = qj.Count().ToString() + " journals";
            if (qj.Count() > 0)
            {
                foreach (Journal art in qj)
                {
                    string s = art.Name;
                    CB_journals.Items.Add(util.addid(art.Name, art.Id, 100));
                }
            }
            else
                CB_journals.Items.Add("(no journals)");


            // Back to normal 
            Cursor.Current = Cursors.Default;


        }

        private void FormDoPublisher_Load(object sender, EventArgs e)
        {

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CB_books_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_books.CheckedItems.Count != 1)
                return;

            string s = CB_books.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            //memo(s);
            int aid = util.getid(s);
            //memo("aid = " + aid);
            CB_books.SetItemCheckState(CB_books.CheckedIndices[0], CheckState.Unchecked);
            CB_books.ClearSelected();

            FormDoBook fd = new FormDoBook(db, aid);
            fd.Show();

        }

        private void CB_journals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_journals.CheckedItems.Count != 1)
                return;

            string s = CB_journals.CheckedItems[0].ToString();
            //SelectedItem.ToString();
            //memo(s);
            int aid = util.getid(s);
            //memo("aid = " + aid);
            CB_journals.SetItemCheckState(CB_journals.CheckedIndices[0], CheckState.Unchecked);
            CB_journals.ClearSelected();
            

            FormDoJournal fd = new FormDoJournal(db, aid);
            fd.Show();

        }
    }
}
