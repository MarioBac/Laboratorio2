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
        List<Url> urlList = new List<Url>();
        public Form1()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            dataGridView1.Visible = false;
            DeletePagButton.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DeletePagButton.Visible = false;
            dataGridView1.Visible = false;
            readFile("Historial.txt");
            foreach (Url spark in urlList)
            {
                comboBox1.Items.Add(spark.Resource);

            }
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }


        private void GoButton_Click(object sender, EventArgs e)
        {
            string spark = "";
            if (comboBox1.Text != null)
            {
                spark = comboBox1.Text;
            }
            else if (comboBox1.SelectedItem.ToString() != null)
            {
                spark = comboBox1.SelectedItem.ToString();

            }
            if (!spark.Contains("."))
            {
                spark = "http://www.google.com/search?q=" + spark;
            }
            else
            {
                spark = "http://" + spark;
            }
            webBrowser1.Navigate(new Uri(spark));
            bool isRegisted = false;
            foreach (var auxiliar in urlList)
            {
                if (auxiliar.Resource.Contains(spark))
                {
                    auxiliar.TimesVisited++;
                    auxiliar.Date = DateTime.Now;
                    isRegisted = true;
                }

            }
            if (!isRegisted)
            {
                Url auxiliar = new Url();
                comboBox1.Items.Add(spark);
                auxiliar.Resource = spark;
                auxiliar.TimesVisited++;
                auxiliar.Date = DateTime.Now;
                urlList.Add(auxiliar);
            }

            saveFile("Historial.txt");
            comboBox1.Text = spark;
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

        
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void Leer(string fileName)
        {



            StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));


            while (reader.Peek() > -1)

            {
                comboBox1.Items.Add(reader.ReadLine());
            }

            reader.Close();
        }

        private void readFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                Url auxiliar = new Url();
                auxiliar.Resource = sr.ReadLine();
                auxiliar.TimesVisited = Convert.ToInt32(sr.ReadLine());
                auxiliar.Date = Convert.ToDateTime(sr.ReadLine());
                urlList.Add(auxiliar);
            }
            sr.Close();
            fs.Close();
        }

        private void saveFile(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);
            Console.WriteLine(urlList.Count + "<<<<");
            foreach (var spark in urlList)
            {
                foreach (string s in spark.UrlData())
                {
                    sw.WriteLine(s);
                }
            }
            sw.Close();
            stream.Close();
        }

        private void DeletePagButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Estas seguro de eliminar esta pagina?",
                                    "Confirma eliminar!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                urlList.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.DataSource = null;
                saveFile("Historial.txt");
            }

            dataGridView1.DataSource = urlList.ToList();
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vistasDescendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = urlList.OrderByDescending(url => url.Date).ToList();
        }

        private void masVisitadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = urlList.OrderBy(spark => spark.TimesVisited).ToList();
        }
    }
}
