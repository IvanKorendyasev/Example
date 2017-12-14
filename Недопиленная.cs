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

namespace CarRent
{
    public partial class Form1 : Form
    {
        StreamWriter sw = new StreamWriter(Application.StartupPath + "\\reestr.txt", true, Encoding.Default);
        public Form1()
        {
            InitializeComponent();
            string text = System.IO.File.ReadAllText(Application.StartupPath + "\\List.txt");
            string[] list = text.Split('\n');
            foreach (var item in list)
            {
                listBox1.Items.Add(item);
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] reestr = sw.ToString().Split('\n');
            /*foreach (var item in reestr)
            {
                if (item == listBox1.SelectedItem.ToString() + " арендован")
                {
                    richTextBox1.Text = "автомобиль уже арендован";
                }
                else
                {
                    richTextBox1.Text = listBox1.SelectedItem.ToString() + " арендован" + "\n";
                    sw.WriteLine(richTextBox1.Text );
                }
            }
            if (reestr.Contains("арендован"))
            {
                richTextBox1.Text = "автомобиль уже арендован";
            }
            else
            {
                richTextBox1.Text = listBox1.SelectedItem.ToString() + " арендован" + "\n";
                sw.WriteLine(richTextBox1.Text);
            }
            sw.Close();*/
            for (int i = 0; i < reestr.Length; i++)
            {
                richTextBox1.Text = sw.ToString();
            }
        }
    }
}
