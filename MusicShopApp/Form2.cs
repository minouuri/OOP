using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static MusicShopApp.Form1;

namespace MusicShopApp
{
    public partial class Form2 : Form
    {
        private readonly IKeyboard _keyboard;
        private readonly Stringed _stringed;
        private readonly AppDbContext _db;

        public Form2(IKeyboard keyboard, Stringed stringed, AppDbContext db)
        {
            _keyboard = keyboard;
            _stringed = stringed;
            _db = db;  
            InitializeComponent();

            if (_stringed != null)
            {
                label1.Text = "Струнный инструмент";
                label1.Left = 86;
                panel2.Visible = true;
                panel3.Visible = false;
                Text = "Струнный инструмент";
            }
            if (_keyboard != null)
            {
                label1.Text = "Клавишный инструмент";
                label1.Left = 84;
                panel3.Visible = true;
                panel2.Visible = false;
                Text = "Клавишный инструмент";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_keyboard != null)
            {
                _keyboard.Sell();
                Form3 newForm = new Form3(_keyboard, null, _db);
                newForm.Show();
            }
            else
            {
                _stringed.Sell();
                Form3 newForm = new Form3(null, _stringed, _db);
                newForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_keyboard != null)
            {
                _keyboard.Order();
                MessageBox.Show(_keyboard.text_message, "Наследуемый метод");
            }
            else
            {
                _stringed.Order();
                MessageBox.Show(_stringed.text_message, "Наследуемый метод");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_keyboard != null)
            {
                _keyboard.ConfigToll();
                Form4 newForm = new Form4(_keyboard, null, _db);
                newForm.Show();
            }
            else
            {
                _stringed.ConfigToll();
                Form4 newForm = new Form4(null, _stringed, _db);
                newForm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_keyboard != null)
            {
                _keyboard.Sound();
                MessageBox.Show(_keyboard.text_message, "Переопределяемый метод");
            }
            else
            {
                _stringed.Sound();
                MessageBox.Show(_stringed.text_message, "Переопределяемый метод");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _stringed.JammingChords();
            MessageBox.Show(_stringed.text_message, "Собственнный метод");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _stringed.HittingString();
            MessageBox.Show(_stringed.text_message, "Собственнный метод");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _keyboard.PressingKeys();
            MessageBox.Show(_keyboard.text_message, "Собственнный метод");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _keyboard.PressingPedal();
            MessageBox.Show(_keyboard.text_message, "Собственнный метод");
        }
    }
}
