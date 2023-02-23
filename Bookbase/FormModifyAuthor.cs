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
    public partial class FormModifyAuthor : Form
    {
        private Author a;
        private Librarydb db;

        public FormModifyAuthor(Librarydb dbpar, int authorid)
        {
            db = dbpar;
            InitializeComponent();

            var q = from c in db.Author where c.Id == authorid select c;
            if (q.Count() == 0)
            {
                MessageBox.Show("Author not found, Id = " + authorid);
                this.Close();
            }
            else
            {
                a = q.First();
                this.Text = a.Name;
            }

            TB_familyname.Text = a.Familyname;
            TB_givenname.Text = a.Givenname;

        }

        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TB_familyname.Text))
                a.Familyname = TB_familyname.Text;
            if (!String.IsNullOrEmpty(TB_givenname.Text))
                a.Givenname = TB_givenname.Text;
            a.FamilynameAscii = dbutil.RemoveDiacritics(a.Familyname);
            a.GivennameAscii = dbutil.RemoveDiacritics(a.Givenname);
            a.Name = authorclass.GetFullname(a);
            db.SubmitChanges();
            this.Close();
        }

        private void Mergebutton_Click(object sender, EventArgs e)
        {
            FormFindAuthor fa = new FormFindAuthor(db);
            DialogResult faresult = fa.ShowDialog();
            var auid = fa.authorid;
            //memo("authorid = " + auid.ToString());

            if ((faresult == DialogResult.OK) && (auid >= 0))
            {
                var q = from c in db.Author where c.Id == auid select c;
                if (q.Count() == 0)
                {
                    MessageBox.Show("Author not found, Id = " + auid);
                    this.Close();
                }
                else
                {
                    Author a2 = q.First();
                    if (a2.Id == a.Id)
                        return;

                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Merge "+a2.Name+" ("+a2.Id+") into "+a.Name+" ("+a.Id+")?";
                    string caption = "Confirm merge";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        authorclass.MergeDB(db, a, a2);
                    }
                }
            }

        }
    }
}
