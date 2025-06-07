using Microsoft.EntityFrameworkCore;
using static MusicShopApp.Form2;
using static MusicShopApp.Form3;
using static MusicShopApp.Form4;

namespace MusicShopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public abstract class Instrument
        {
            public int Id { get; set; }
            public string Shop { get; set; }
            public string Seller { get; set; }
            public string text_message;

            public Instrument() { }
            public Instrument(string shop, string seller)
            {
                this.Shop = shop;
                this.Seller = seller;
            }

            public void Sell()
            {
                text_message = "Инстурмент продан!";
            }
            public void Order()
            {
                text_message = "Инстурмент заказан!";
            }
            public virtual void ConfigToll()
            {
                text_message = "Инстурмент настроен!";
            }
            public virtual void Sound()
            {
                text_message = "Инстурмент сыграл!";
            }
        }

        public class Stringed : Instrument
        {
            public int Count_of_string { get; set; }
            public string Type_of_instrument { get; set; } = "не указан";

            public Stringed()
            {

            }

            public Stringed(string shop, string seller, int count_of_string, string type_of_instrument) : base(shop, seller)
            {
                this.Count_of_string = count_of_string;
                this.Type_of_instrument = type_of_instrument;
            }

            public override void ConfigToll()
            {
                text_message = "Струнный инстурмент настроен!";
            }
            public override void Sound()
            {
                text_message = "Струнный инстурмент сыграл мелодию!";
            }
            public void JammingChords()
            {
                text_message = "-Зажатие аккордов-";
            }
            public void HittingString()
            {
                text_message = "-Удар по струнам-";
            }
        }

        public class IKeyboard : Instrument
        {
            public int Count_of_keys { get; set; }
            public string Type_of_instrument { get; set; } = "не указан";

            public IKeyboard()
            { 
            
            }

            public IKeyboard(string shop, string seller, int count_of_keys, string type_of_instrument) : base(shop, seller)
            {
                this.Count_of_keys = count_of_keys;
                this.Type_of_instrument = type_of_instrument;
            }

            public override void ConfigToll()
            {
                text_message = "Клавишный инстурмент настроен!";
            }
            public override void Sound()
            {
                text_message = "Клавишный инстурмент сыграл мелодию!";
            }
            public void PressingPedal()
            {
                text_message = "-Нажатие педали-";
            }
            public void PressingKeys()
            {
                text_message = "-Нажатие клавиш-";
            }
        }

        IKeyboard keyboard = null;
        Stringed stringed = null;
        AppDbContext db = new AppDbContext();

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == ""))
            {
                keyboard = new IKeyboard();
            }
            else
            {
                keyboard = new IKeyboard(textBox1.Text, textBox2.Text, int.Parse(textBox4.Text), textBox3.Text);
                db.Keyboards.Add(keyboard);
                db.SaveChanges();
            }
            Form2 newForm = new Form2(keyboard, null, db);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == ""))
            {
                stringed = new Stringed();
            }
            else
            {
                stringed = new Stringed(textBox1.Text, textBox2.Text, int.Parse(textBox4.Text), textBox3.Text);
                db.Stringeds.Add(stringed);
                db.SaveChanges();
            }
            Form2 newForm = new Form2(null, stringed, db);
            newForm.Show();
        }

    }
}
