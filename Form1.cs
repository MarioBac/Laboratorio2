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
                    comboBox1.Items.Add(uri);
                    Guardar("Historial.txt", uri);
                }


                else if (uri.Contains(".") == false)
                {
                    uri = "http://www.google.com/search?q=" + uri;
                    webBrowser1.Navigate(uri);
                    comboBox1.Items.Add(uri);
                    Guardar("Historial.txt", uri);
                }
            }
            else {
                webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
                string uri = comboBox1.Text.ToString();
                comboBox1.Items.Add(uri);
                Guardar("Historial.txt", uri);
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

        private void Guardar(string fileName, string texto)
        {
           
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
           
            StreamWriter writer = new StreamWriter(stream);
  
            writer.WriteLine(texto);
            
            writer.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
        }

       private void Leer (string fileName)
        {
            


            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)

            {
                comboBox1.Items.Add(reader.ReadLine());
            }

            reader.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            Leer("Historial.txt");
        }
    }
}
