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
    public partial class FormFindAuthor : Form
    {
        public int authorid = -1;

        private Button[] Letterbuttons = new Button[35];
        private Dictionary<int, string> buttondict = new Dictionary<int, string>();

        private Librarydb db;

        private DataTable dta = new DataTable();


        public FormFindAuthor(Librarydb dbpar)
        {
            db = dbpar;

            InitializeComponent();

            textBox1.Text = "";

            Init_Letterbuttons();
            foreach (int i in buttondict.Keys)
            {
                this.Controls.Add(Letterbuttons[i]);
                Letterbuttons[i].Click += new System.EventHandler(Letterbutton_Click);
            }

            //dta.Columns.Add("Id", typeof(int));
            //dta.Columns.Add("Name", typeof(string));
            ////bind to combobox

            //this.comboBox1.DataSource = dta.DefaultView;

            //this.comboBox1.DisplayMember = "Name";

            //this.comboBox1.ValueMember = "Id";

            //suppose default ID is 4 then code as follow

        }

        private void Init_Letterbuttons()
        {
            int sizex = 66;
            int sizey = 23;
            int basex = 15;
            int basey = 200;
            int perrow = 5;


            if (buttondict.Count == 0)
            {
                for (int i = 0; i < Letterbuttons.Length; i++)
                {
                    Letterbuttons[i] = new Button();
                }

                for (int i = 0; i < 26; i++)
                {
                    buttondict.Add(i, ((char)('A' + i)).ToString());
                }
                buttondict.Add(26, "Å");
                buttondict.Add(27, "Ä");
                buttondict.Add(28, "Ö");
                buttondict.Add(29, "[");
                buttondict.Add(30, " ");
            }

            foreach (int i in buttondict.Keys)
            {
                int row = i / perrow;
                int col = i % perrow;
                Letterbuttons[i].Location = new Point(basex + col * sizex, basey + row * sizey);
                Letterbuttons[i].Text = buttondict[i];
                Letterbuttons[i].Size = new System.Drawing.Size(sizex, sizey);
                //Letterbuttons[i].TabIndex = 0;
                Letterbuttons[i].UseVisualStyleBackColor = true;
                Letterbuttons[i].Enabled = true;
                //this.Controls.Add(Letterbuttons[i]);
            }
            BackButton.Enabled = false;

        }

        private void Letterbutton_handler(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                Init_Letterbuttons();
                return;
            }

            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;

            var q = from c in db.Author where (c.FamilynameAscii + " " + c.GivennameAscii).StartsWith(s) select c;
            int nq = q.Count();

            if (textBox1.Text.Length > s.Length)
                return;

            label1.Text = nq.ToString() + " authors selected.";
            if (nq == 0)
            {
                label1.Text = "No authors found";
                Newauthorbutton.Visible = true;
                Newauthorbutton.Enabled = true;

                //comboBox1.Items.Clear();
            }
            else
            {
                if (nq < 100)
                {
                    comboBox1.Items.Clear();
                    //dta.Clear();
                    List<Author> ql = q.ToList();
                    //ql.Sort();
                    foreach (Author c in ql)
                    {
                        comboBox1.Items.Add(c.Name);
                        //DataRow row = dta.NewRow();
                        //row["Id"] = c.Id;
                        //row["Name"] = c.Name;
                        //dta.Rows.Add(row);
                    }

                    comboBox1.DroppedDown = true;
                }

                if (textBox1.Text.Length > s.Length)
                    return;

                foreach (int i in buttondict.Keys)
                {
                    if (buttondict[i] == " ")
                    {
                        Letterbuttons[i].Text = s + buttondict[i].ToLower();
                        int nqq = (from c in db.Author where c.FamilynameAscii == s select c).Count();
                        Letterbuttons[i].Enabled = (nqq > 0);
                    }
                    else if ( s.Contains(" "))
                    {
                        Letterbuttons[i].Text = s + buttondict[i].ToLower();
                        int nqq = (from c in db.Author where (c.FamilynameAscii+" "+c.GivennameAscii).StartsWith(Letterbuttons[i].Text) select c).Count();
                        Letterbuttons[i].Enabled = (nqq > 0);
                    }
                    else
                    {
                        Letterbuttons[i].Text = s + buttondict[i].ToLower();
                        int nqq = (from c in db.Author where c.FamilynameAscii.StartsWith(Letterbuttons[i].Text) select c).Count();
                        Letterbuttons[i].Enabled = (nqq > 0);
                    }
                }
            }
            // Back to normal 
            Cursor.Current = Cursors.Default;

        }

        private void Letterbutton_Click(object sender, EventArgs e)
        {
            string s = ((Button)sender).Text.ToLower();
            Letterbutton_handler(s);
            BackButton.Enabled = true;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            authorid = -1;
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            string s = Letterbuttons[0].Text;
            label2.Text = "Backbutton " + s + "|";
            if (s.Length > 2)
                Letterbutton_handler(s.Substring(0, s.Length - 2));
            else
                Letterbutton_handler("");
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            string s = comboBox1.SelectedItem.ToString();
            label2.Text = s;
            var q = from c in db.Author where c.Name == s select c;
            if (q.Count() == 1)
            {
                authorid = q.First().Id;
                label1.Text = q.First().Name + " selected";
            }
            else
                label1.Text = q.Count().ToString() + " authors selected in combobox";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 2)
            {
                Letterbutton_handler(textBox1.Text);
                if (comboBox1.Items.Count == 1)
                {
                    //comboBox1.Items[0]
                    comboBox1.SelectedIndex = 0;
                }
            }

        }

        private void Newauthorbutton_Click(object sender, EventArgs e)
        {
            authorid = authorclass.NewAuthor(db,textBox1.Text);
            if (authorid > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
