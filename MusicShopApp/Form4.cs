using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MusicShopApp.Form1;
using static MusicShopApp.Form2;
using static MusicShopApp.Form3;

namespace MusicShopApp
{
    public partial class Form4 : Form
    {
        private readonly IKeyboard _keyboard;
        private readonly Stringed _stringed;
        private readonly AppDbContext _db;

        public Form4(IKeyboard keyboard, Stringed stringed, AppDbContext db)
        {
            _keyboard = keyboard;
            _stringed = stringed;
            _db = db;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count_of = 0;
            string text_seller = textBox2.Text;
            string text_shop = textBox3.Text;
            if (textBox4.Text != "") { count_of = int.Parse(textBox4.Text); }
            string text_type = textBox5.Text;

            if (_stringed != null)
            {
                var instrument = (from r in _db.Stringeds where (r.Id == int.Parse(textBox1.Text)) select r).FirstOrDefault();

                if (text_seller != "") { instrument.Seller = text_seller; } else { instrument.Seller = instrument.Seller; }
                if (text_shop != "") { instrument.Shop = text_shop; } else { instrument.Shop = instrument.Shop; }
                if (count_of != 0) { instrument.Count_of_string = count_of; } else { instrument.Count_of_string = instrument.Count_of_string; }
                if (text_type != "") { instrument.Type_of_instrument = text_type; } else { instrument.Type_of_instrument = instrument.Type_of_instrument; }

                _db.Update(instrument);
                _db.SaveChanges();
                MessageBox.Show("Инструмент обновлен!", "Оповещение");
            }
            else
            {
                var instrument = (from r in _db.Keyboards where (r.Id == int.Parse(textBox1.Text)) select r).FirstOrDefault();

                if (text_seller != null) { instrument.Seller = text_seller; } else { instrument.Seller = instrument.Seller; }
                if (text_shop != null) { instrument.Shop = text_shop; } else { instrument.Shop = instrument.Shop; }
                if (count_of != 0) { instrument.Count_of_keys = count_of; } else { instrument.Count_of_keys = instrument.Count_of_keys; }
                if (text_type != null) { instrument.Type_of_instrument = text_type; } else { instrument.Type_of_instrument = instrument.Type_of_instrument; }

                _db.Update(instrument);
                _db.SaveChanges();
                MessageBox.Show("Инструмент обновлен!", "Оповещение");
            }
        }
    }
}
