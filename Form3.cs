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
    public partial class frmReplace : Form
    {
        public frmReplace()
        {
            InitializeComponent();
        }
        public static string WordtoFind;
        public static string WordtoReplace;




  

        private void frmReplace_Load(object sender, EventArgs e)
        {

        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (txtReplaceWith.Text!=""&&txtWordToFind.Text!="")
            {
                WordtoFind = txtWordToFind.Text;
                WordtoReplace = txtReplaceWith.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Check your inputs");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
