using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNoteBook
{
    public partial class frmNoteBook : Form
    {
        private bool isSaved = false;
        public short SavingResult;
        /*
         * this Variable will hold three values coming from frmAskForSavingChanges
         * 1 = save
         * 0 = don't save
         * -1 = cancel
         */
        private short DefaultZoom = 16;
        public frmNoteBook()
        {
            InitializeComponent();
        }


       
        private bool isTextEmpty()
        {
            return (rtbContent.Text == "");
        }


        private bool FindWord(string Word , string Text)
        {
            string[] Words = Text.Split(' ');

            for (int i = 0; i < Words.Length; i++)
            {
                if (Words[i]==Word)
                {
                    MessageBox.Show("Word "+ Word + " is found");
                    rtbContent.Select(rtbContent.Text.IndexOf(Word) , rtbContent.Text.IndexOf(Word)+Word.Length);
                    return true;
                }
            }
            MessageBox.Show("Word "+Word+" is not found");
            return false;
        }

        private bool SaveFile()
        {

            if (saveFileDialog1.ShowDialog()== DialogResult.OK)
            {
                string FilePath = saveFileDialog1.FileName;
                File.WriteAllText(FilePath, rtbContent.Text);
                MessageBox.Show("Saved Successfully");
                return true;
            }
            return false;
        }



        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
         isSaved = SaveFile();
        }

        private void NewText()
        {
            if (isSaved == false)
            {
                frmAskForSavingChanges FormForAsk = new frmAskForSavingChanges();
                FormForAsk.ShowDialog();
                SavingResult = FormForAsk.Saving;
                if (SavingResult == 1)//save
                {
                    isSaved = SaveFile();
                    rtbContent.Clear();
                    isSaved = false;
                }
                else if (SavingResult == 0) // Don't Save
                {
                    rtbContent.Clear();
                }
                else // Cancel
                {
                    return;
                }
            }
            else
            {
                    rtbContent.Clear();
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NewText();
            
        }
        private void ShowNewWindow()
        {
            frmNoteBook NoteBook = new frmNoteBook();
            NoteBook.Show();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewWindow();
        }
        private void ReadOpenedFile(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string FileContent = File.ReadAllText(FilePath);
                    rtbContent.Text = FileContent;

                }
                else
                {
                    MessageBox.Show("File doesn't exist");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                ReadOpenedFile(openFileDialog1.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.SelectAll();
            
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFind FormToFind = new frmFind();
            FormToFind.ShowDialog();
            FindWord(frmFind.WordForSearch, rtbContent.Text);
        }

        public string[] ReplaceWord(string WordtoFind ,string WordtoReplace )
        {
            string[] Words = rtbContent.Text.Split(' ');

            for (int i = 0; i < Words.Length; i++)
            {
                if (Words[i] == WordtoFind)
                {
                    Words[i] = WordtoReplace;
                }
            }
            return Words;
        }

        private string UpdateContent(string WordtoFind, string WordtoReplace , string Delim = " ")
        {
            string Text = "";

            string[] WordsAfterReplacement = ReplaceWord(WordtoFind, WordtoReplace);

            for (int i = 0; i < WordsAfterReplacement.Length; i++)
            {
                if (i == WordsAfterReplacement.Length -1)
                {
                    Text += WordsAfterReplacement[i];
                    return Text;
                }
                Text  += WordsAfterReplacement[i] + Delim;
            }
            return Text;
        }

        private string RemoveBackSlashN(string Text)
        {
            string NewText = Text.Replace('\n', ' ');
            return NewText;
        }

        public  void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplace FormReplace = new frmReplace();
            FormReplace.ShowDialog();

            rtbContent.Text = RemoveBackSlashN(rtbContent.Text);
            rtbContent.Text = UpdateContent(frmReplace.WordtoFind, frmReplace.WordtoReplace);

        }

        private void EditFont()
        {
            fontDialog1.ShowColor = true;
            fontDialog1.ShowApply = true;
            fontDialog1.ShowEffects = true;
            fontDialog1.ShowHelp = true;
            fontDialog1.Font = rtbContent.Font;
           

            
            if (fontDialog1.ShowDialog()==DialogResult.OK)
            {
                rtbContent.Font = fontDialog1.Font;
                rtbContent.ForeColor = fontDialog1.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditFont();
        }
        private void EditColor()
        {
            colorDialog1.Color = rtbContent.BackColor;
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                rtbContent.BackColor = colorDialog1.Color;
            }
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditColor();
        }


        
    }
}
