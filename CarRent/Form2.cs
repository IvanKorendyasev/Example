using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent
{
    public partial class Form2 : Form
    {
        Service ser = new Service(new Repository());
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { //кнопка удаления брони
            ser.DeleteRent(textBox1.Text, listBox1.SelectedItem.ToString());
            List<Car> Print = new List<Car>();
            listBox1.Items.Clear();
            Print = ser.PrintMyRents(textBox1.Text);
            foreach (var item in Print)
            { //вывод нового списка текущих броней
                listBox1.Items.Add(item.name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //кнопка подтверждения ввода имени пользователя
            List<Car> Print = new List<Car>();
            listBox1.Items.Clear();
            Print = ser.PrintMyRents(textBox1.Text);
            foreach (var item in Print)
            { //вывод броней пользователя
                listBox1.Items.Add(item.name);
            }            
            if (listBox1.Items.Count != 0)
            { //проверка на наличие аренд у пользователя
                listBox1.SetSelected(0, true);
                button1.Enabled = true;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
