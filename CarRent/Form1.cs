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
    { //главное меню
        Service ser = new Service(new Repository());
        public Form1()
        {
            InitializeComponent();
                    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //при запуске программы пользователю предлагают ввести даты и имя
            richTextBox1.Text = "Сначала введите даты и имя пользователя";
            button1.Enabled = false;
            dateTimePicker2.Enabled = false;   
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { //нажатие кнопки Rent
            int ID = listBox1.SelectedIndex;
            richTextBox1.Text = ser.RentCar(ID, dateTimePicker1.Value, dateTimePicker2.Value);
            ser.MakeNoteForRepository(listBox1.SelectedItem.ToString(), textBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        { // выбор даты 2
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            { //благодаря этому участку кода, пользователь не может выбрать дату 2 раньше даты 1
                dateTimePicker1.Value = dateTimePicker2.Value;
            }
            button1.Enabled = true; //активация кнопки Rent
            List<Car> Print = new List<Car>();
            listBox1.Items.Clear();
            Print = ser.PrintAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value);            
            foreach (var item in Print)
            { //вывод списка доступных авто
                listBox1.Items.Add(item.name);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { //выбор даты 1
            if (dateTimePicker1.Value>dateTimePicker2.Value)
            { //благодаря этому участку кода, пользователь не может выбрать дату 2 раньше даты 1
                dateTimePicker2.Value = dateTimePicker1.Value;
            }
            listBox1.Items.Clear();
            dateTimePicker2.Enabled = true; //активация выбора даты 2
        }

        private void button4_Click(object sender, EventArgs e)
        { //нажатие кнопки отмены брони
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        { //нажатие кнопки "О программе"
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        { //нажатие кнопки "Справка"
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
