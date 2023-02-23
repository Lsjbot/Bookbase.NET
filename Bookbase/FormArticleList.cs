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
    public partial class FormArticleList : Form
    {
        private Librarydb db;

        public string artref(Article aa)
        {
            StringBuilder sb = new StringBuilder("");
            int nau = aa.AuthorArticle.Count;
            if (nau == 1)
                sb.Append(aa.AuthorArticle.First().AuthorAuthor.Name);
            else if ( nau == 2)
            {
                sb.Append(aa.AuthorArticle.First().AuthorAuthor.Name);
                sb.Append(" & ");
                sb.Append(aa.AuthorArticle.Last().AuthorAuthor.Name);
            }
            else
            {
                sb.Append(aa.AuthorArticle.First().AuthorAuthor.Name);
                sb.Append(" et al");
            }
            sb.Append(" (" + aa.Year.ToString() + ") ");
            sb.Append(aa.Title);

            return sb.ToString();
        }

        public string evolangref(Evolang ee)
        {
            StringBuilder sb = new StringBuilder("");
            int nau = ee.EvolangAuthor.Count;
            if (nau == 1)
                sb.Append(ee.EvolangAuthor.First().AuthorAuthor.Name);
            else if (nau == 2)
            {
                sb.Append(ee.EvolangAuthor.First().AuthorAuthor.Name);
                sb.Append(" & ");
                sb.Append(ee.EvolangAuthor.Last().AuthorAuthor.Name);
            }
            else
            {
                sb.Append(ee.EvolangAuthor.First().AuthorAuthor.Name);
                sb.Append(" et al");
            }
            sb.Append(" (" + ee.Year.ToString() + ") ");
            sb.Append(ee.Title);
            sb.Append(" [evolang]");

            return sb.ToString();
        }

        public FormArticleList(Librarydb dbpar, List<Article> la)
        {
            InitializeComponent();
            db = dbpar;

            foreach (Article aa in la )
            {
                CBart.Items.Add(artref(aa));
            }
        }

        public void AddEvolang(List<Evolang> le)
        {
            foreach (Evolang ee in le)
            {
                CBart.Items.Add(evolangref(ee));
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
