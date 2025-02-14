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
    public partial class Form3 : Form
    {
        public Form3()
        {

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
            browse.BackColor = Color.FromArgb(100, 51, 90, 241);
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void brwosefiles_click(object sender, EventArgs e)
        {


        }

        bool read = false;
        String name = "";
        private void upload_file_Click(object sender, EventArgs e)
        {

            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Select .txt file to Decode...";
            OFD.Filter = "TXT Files|* .txt";

            DialogResult result = OFD.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {

                textBox1.Text = OFD.FileName;
                read = true;
                name = OFD.FileName;
                //MessageBox.Show(read.ToString());



            }
            //Console.WriteLine(size); 
            //Console.WriteLine(result); 

        }


        private void backcklick(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void encode_click(object sender, EventArgs e)
        {
            MessageBox.Show(name);
            try
            {
                if (String.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Invalid File");
                    Form1 f1 = new Form1();
                    this.Close();
                    f1.Show();
                }
                else
                {
                    string text = File.ReadAllText(name);
                    //int size = text.Length;
                    HuffmanTree HT = new HuffmanTree();

                    HT.build(text);
                    Node root = HT.root;
                    HT.printPaths();
                    //String p = HT.printDictreserve();
                    textBox2.AppendText(" __________________" + Environment.NewLine);
                    textBox2.AppendText("| " + "Symbol  |   Code|" + Environment.NewLine);
                    textBox2.AppendText("-------------------" + Environment.NewLine);
                   
                    //Dictionary<char, String> dictionary =HT.dictToString(HT.getDict());

                    //Dictionary<char, String> symchar = new Dictionary<char, String>();
                    // symchar = HT.CharCodesTable();
                    //textBox2.Text = Char.ToString(root.s)+size.ToString();
                    //DataGridView DGV = new DataGridView();
                    //this.DGV.Columns.Add("Index", "Symbol");
                    //this.DGV.Columns.Add("Value", "Code");

                    /*string res = "";
                    foreach(KeyValuePair<char, String> pair in dictionary)
                    {
                      res = res + "Symbol: " + pair.Key +  "        Code:    " + pair.Value + Environment.NewLine;

                               //res = res+"Symbol: "+node.s.ToString()+"         Frequency:  " + node.f.ToString()+"        Code:    "+ node.c +"         Parent Frequency:  " + node.parent.f.ToString() + "       Parent Code:    " + node.parent.c+ "         GrandParent Frequency:  " + node.parent.parent.f.ToString() + "       GrandParent Code:    " + node.parent.parent.c + Environment.NewLine;    
                   }

                    //res = "Root: " + root.f + "    Root Left: " + root.left.f + "     Root Right: " + root.right.f + "      Root Left Left: " + root.left.left.f; "         Frequency:  " + node.f.ToString() +
                    //res = HT.printPreorder(root);
                    */
                    textBox2.AppendText(HT.printPreorder(root));
                }


                //textBox2.Text = res;
            }



            catch (IOException)
            {
                //this.Close();
                // Form1 f1 = new Form1();
                //f1.Show();
                //OFD.Dispose();
                MessageBox.Show("OOOpsss error 404");

            }
        }

       

       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Pen blackpan = new Pen(Color.Black);
        Graphics g = null;

        private void canvas(object sender, PaintEventArgs e)
        {
            //TextBox.Location
        }
        public void drawLine()
        {
            //Point[] points //when we create new node add a new point to the point list x will be Textbox.Location.x  y ->    and populate textbox with text of nodes ffreq
                //start with first 2 nodes : 1st  - x=startx y = starty, 2nd - x=startx+5, y+starty (does not change);     then their parent x coordinate  = will be 2nd x - 1st x /2  and parent y -coordinate will be y =starty+5
                //when root is in min set then ith x = startx + i*5  y = starty+(i-1)*5; then new root x = 
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
