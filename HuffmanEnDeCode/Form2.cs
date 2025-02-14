using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanEnDeCode
{
    public partial class Form2 : Form
    {
        public Form2()

        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }

        private void brwosefiles_click(object sender, EventArgs e)
        {
            
                int size = -1;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog1.FileName;
                    try
                    {
                        string text = File.ReadAllText(file);
                        size = text.Length;
                    }
                    catch (IOException)
                    {
                    this.Close();
                    Form1 f1=new Form1();
                    f1.Show();
                    openFileDialog1.Dispose();  
                    }
                }
              //Console.WriteLine(size); 
              //Console.WriteLine(result); 
            
        }

        private void en_load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void back_click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();

        }
    }
}
