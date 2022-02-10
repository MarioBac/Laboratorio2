using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex.Equals(-1))
            {
                string uri = comboBox1.Text.ToString();
                if (uri.Contains(".") == true)
                {
                    uri = "http://" + uri;
                    webBrowser1.Navigate(uri);

                }

                else if (uri.Contains(".") == false)
                {
                    uri = "http://www.google.com/search?q=" + uri;
                    webBrowser1.Navigate(uri);
                }
            }
            else {
                webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            webBrowser1.GoHome();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
   
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
        }
    }
}
