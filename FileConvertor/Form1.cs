using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open a file";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.txt ,*.doc,*.csv,*.xls)|*.txt;*.doc;*.csv;*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathOpen = openFileDialog1.FileName;
                using (FileStream fs = new FileStream(pathOpen, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            lbConvertedItems.Items.Add(sr.ReadLine() + Environment.NewLine);
                        }
                    }
                }

            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string items = lbConvertedItems.Text;
            string pathOpen = openFileDialog1.FileName;
            items = pathOpen;
            if(cbFormat.SelectedItem != null)
            {
            switch (cbFormat.SelectedIndex)
            {
                case 0:
                    {
                        string extension = Path.GetExtension(pathOpen);
                        pathOpen.Replace(extension, ".txt");
                        items.Replace(items, ".txt");
                        break;
                    }
                case 1:
                    {
                        string extension = Path.GetExtension(pathOpen);
                        pathOpen.Replace(extension, ".doc");
                        items.Replace(items, ".doc");
                        break;
                    }
                case 2:
                    {
                        string extension = Path.GetExtension(pathOpen);
                        pathOpen.Replace(extension, ".csv");
                        items.Replace(items, ".csv");
                        break;
                    }
                case 3:
                    {
                        string extension = Path.GetExtension(pathOpen);
                        pathOpen.Replace(extension, ".xls");
                        items.Replace(items, ".xls");
                        break;
                    }

            }
            }
            else
            {
                MessageBox.Show("You have to choose file format first !" , "Warning" , MessageBoxButtons.OK,MessageBoxIcon.Warning );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save file";
            saveFileDialog1.FileName = "";
            switch (cbFormat.SelectedIndex)
            {
                case 0:
                    {
                        saveFileDialog1.Filter = "Text | *.txt";
                        break;
                    }
                case 1:
                    {
                        saveFileDialog1.Filter = "Doc|*.doc";
                        break;
                    }
                case 2:
                    {
                        saveFileDialog1.Filter = "Csv|*.csv";
                        break;
                    }
                case 3:
                    {
                        saveFileDialog1.Filter = "Xls|*.xls";
                        break;
                    }
            }
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog1.FileName;
                        using (FileStream fs = new FileStream(path, FileMode.Create))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                for (int i = 0; i < lbConvertedItems.Items.Count; i++)
                                {
                                    sw.WriteLine(lbConvertedItems.Items[i]);
                                }
                            }
                        }
                    }

            
        }
    }
}
    

