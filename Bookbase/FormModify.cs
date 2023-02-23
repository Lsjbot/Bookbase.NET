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
    public partial class FormModify : Form
    {
        private Librarydb db;

        public FormModify(Librarydb dbpar)
        {
            InitializeComponent();
            db = dbpar;
        }



        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Authorbutton_Click(object sender, EventArgs e)
        {
            FormFindAuthor fa = new FormFindAuthor(db);
            DialogResult faresult = fa.ShowDialog();
            var auid = fa.authorid;
            //memo("authorid = " + auid.ToString());

            if ((faresult == DialogResult.OK) && (auid >= 0))
            {
                FormModifyAuthor fd = new FormModifyAuthor(db, auid);
                fd.Show();
            }
        }

        private void Publisherbutton_Click(object sender, EventArgs e)
        {
            FormFindPublisher fa = new FormFindPublisher(db);

            DialogResult faresult = fa.ShowDialog();
            var pid = fa.pubid;
            //memo("pubid = " + pid.ToString());
            //pubid = pid;
            if (faresult == DialogResult.OK)
            {
                Publisher pp = (from c in db.Publisher where c.Id == pid select c).FirstOrDefault();
                if (pp != null)
                {
                    FormModifyPublisher fmp = new FormModifyPublisher(db,pp);
                    fmp.Show();
                }
            }

        }

        private void misparsebutton_Click(object sender, EventArgs e)
        {
            FormMisparse fm = new FormMisparse(db);
            fm.Show();
        }
    }
}
