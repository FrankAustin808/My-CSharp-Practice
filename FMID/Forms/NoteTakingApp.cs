using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;

namespace FMID
{
    public partial class NotesAppForm : DevExpress.XtraEditors.XtraForm
    {
        public NotesAppForm()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openTextFileButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";

            string textFile = openFileDialog1.FileName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Make sure a file was selected
                    if ((openFileDialog1.OpenFile()) != null)
                    {
                        // Open stream
                        using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                        {
                            // Read the text
                            noteBox.Text = sr.ReadToEnd();

                            infoLabel.Caption = "File: " + openFileDialog1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("An has error occured: " + ex.Message);
                }
            }
        }

        private void saveTextFileButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void saveAsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string savedtext = noteBox.Text;

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, noteBox.Text);

                infoLabel.Caption = "File saved to: " + saveFileDialog1.FileName;
            }
            else
            {
                Exception ex = new Exception();
                XtraMessageBox.Show("An has error occured: " + ex.Message);
            }
        }

        private void NotesAppForm_Load(object sender, EventArgs e)
        {

        }
    }
}
