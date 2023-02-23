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
    public partial class FormModifyPublisher : Form
    {
        Librarydb db;
        Publisher p;

        public FormModifyPublisher(Librarydb dbpar,Publisher ppar)
        {
            InitializeComponent();
            db = dbpar;
            p = ppar;
            TB_name.Text = p.Name;
            if (p.URL != null)
                TB_URL.Text = p.URL;
            if (p.Location != null)
                TB_location.Text = p.Location;
        }

        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TB_name.Text))
                p.Name = TB_name.Text;
            if (!String.IsNullOrEmpty(TB_location.Text))
                p.Location = TB_location.Text;
            if (!String.IsNullOrEmpty(TB_URL.Text))
                p.URL = TB_URL.Text;
            db.SubmitChanges();

            this.Close();
        }

        public static void MergePublishers(Librarydb db, Publisher pp1,Publisher pp2)
        {
            if (pp1.Id == pp2.Id)
                return;

            var qbook = from c in db.BookAlbum where c.Publisher == pp2.Id select c;
            foreach (BookAlbum ba in qbook)
                ba.Publisher = pp1.Id;

            var qjournal = from c in db.Journal where c.Publisher == pp2.Id select c;
            foreach (Journal jj in qjournal)
                jj.Publisher = pp1.Id;

            if (pp1.URL == null)
                pp1.URL = pp2.URL;
            if (pp1.Location == null)
                pp1.Location = pp2.Location;
            else if (pp2.Location != null)
                pp1.Location += ", " + pp2.Location;

            db.Publisher.DeleteOnSubmit(pp2);

            db.SubmitChanges();
        }

        private void Mergebutton_Click(object sender, EventArgs e)
        {
            FormFindPublisher fa = new FormFindPublisher(db);

            DialogResult faresult = fa.ShowDialog();
            var pid2 = fa.pubid;
            //memo("pubid = " + pid.ToString());
            //pubid = pid;
            if (faresult == DialogResult.OK)
            {
                Publisher pp2 = (from c in db.Publisher where c.Id == pid2 select c).FirstOrDefault();
                if (pp2 != null)
                {
                    if (p.Id == pp2.Id)
                        return;

                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Merge " + pp2.Name + " (" + pp2.Id + ") into " + p.Name + " (" + p.Id + ")?";
                    string caption = "Confirm merge";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        MergePublishers(db, p, pp2);
                    }

                }
            }
            

        }
    }
}
