using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace HuffmanEnDeCode
{
  
    public partial class Form1 : Form
    {
        


        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.BackgroundImage = Properties.Resources.huffman_tree;
            InitializeComponent();
            var timer = new System.Windows.Forms.Timer();
            //change the background image every interv  
            timer.Interval = 100000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //add image in list from resource file.  
            List<Bitmap> lisimage = new List<Bitmap>();
            lisimage.Add(Properties.Resources.huffman_tree);
            //lisimage.Add(Properties.Resources.rite);
            var indexbackimage = DateTime.Now.Second % lisimage.Count;
            this.BackgroundImage = lisimage[indexbackimage];
        }

        private void mm_load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
        }

        private void decode_click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void encode_click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}