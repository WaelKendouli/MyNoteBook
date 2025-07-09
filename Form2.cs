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
    public partial class frmAskForSavingChanges : Form
    {

        public  short Saving; 
        public frmAskForSavingChanges()
        {
            InitializeComponent();
        }

        private void frmAskForSavingChanges_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Saving = 1;
            this.Close();
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            Saving = 0;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Saving = -1;
            this.Close();
        }

    }
}
