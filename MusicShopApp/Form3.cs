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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusicShopApp
{
    public partial class Form3 : Form
    {
        private readonly IKeyboard _keyboard;
        private readonly Stringed _stringed;
        private readonly AppDbContext _db;

        public Form3(IKeyboard keyboard, Stringed stringed, AppDbContext db)
        {
            _keyboard = keyboard;
            _stringed = stringed;
            _db = db;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_stringed != null)
            {
                var instrument = (from r in _db.Stringeds where (r.Id == int.Parse(textBox1.Text)) select r).FirstOrDefault();
                _db.Stringeds.Remove(instrument);
                _db.SaveChanges();
                MessageBox.Show("Инструмент продан!", "Оповещение");
            }
            else {
                var instrument = (from r in _db.Keyboards where (r.Id == int.Parse(textBox1.Text)) select r).FirstOrDefault();
                _db.Keyboards.Remove(instrument);
                _db.SaveChanges();
                MessageBox.Show("Инструмент продан!", "Оповещение");
            }
        }
    }
}
