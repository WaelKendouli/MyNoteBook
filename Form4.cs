using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNoteBook
{
    public partial class frmFind : Form
    {
        public frmFind()
        {
            InitializeComponent();
        }
        public static string WordForSearch;
        private void frmFind_Load(object sender, EventArgs e)
        {

        }

        private void btnSerach_Click(object sender, EventArgs e)
        {
            if (txtWordToFind.Text!="")
            {
                WordForSearch = txtWordToFind.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("You must enter a word");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
    }
}
