using System;
using System.Windows.Forms;

namespace Morse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnToMorse.Enabled = textBox1.Text.Length != 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnToMorse.Enabled = textBox1.Text.Length != 0;
        }

        private void btnToMorse_Click(object sender, EventArgs e)
        {
            Morse morse = new Morse(textBox1.Text);
            morse.ConvertToMorse();
            textBox2.Text = morse.MorseText;
            morse = null;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Text = "Домашняя работа №3 УТС-21 Карапетов Валерий";
        }
    }
    public class Morse
    {
        private string[] LiteralsRus = new string[] {   "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И",
                                                        "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", 
                                                        "Т", "У", "Ф", "Х", "Ц", "Щ", "Ы", "Ь", "Ч", 
                                                        "Ш", "Э", "Ю", "Я", "Ё" };
        private string[] LiteralsLat = new string[] {   "A", "B", "W", "G", "D", "E", "V", 
                                                        "Z", "I", "J", "K", "L", "M", "N",
                                                        "O", "P", "R", "S", "T", "U", "F",
                                                        "H", "C", "Q", "Y", "X" };
        private string[] LiteralCodes = new string[] {  "· –", "– · · ·", "· – –", "– – ·", 
                                                        "– · ·", "·", "· · · –", "– – · ·",
                                                        "· ·", "· – – –", "– · –", "· – · ·",
                                                        "– –", "– ·", "– – –", "· – – ·", 
                                                        "· – ·", "· · ·", "–", "· · –", 
                                                        "· · – ·", "· · · ·", "– · – ·",
                                                        "– – · –", "– · – –", "– · · –",
                                                        "– – – ·", "– – – – ", "· · – · ·",
                                                        "· · – –", "· – · –","·"};
        private string[] Signs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", 
                                                ",", "·", ";", ":", "?", "№", "\"", "'", "(", "!", "–", ")"};
        private string[] SignCodes = new string[] { "· – – – –", "· · – – –", "· · · – –", "· · · · –",
                                                    "· · · · ·", "– · · · ·", "– – · · ·", "– – – · ·",
                                                    "– – – – ·", "– – – – –", "· – · – · –", "· · · · · ·",
                                                    "– · – · –", "– – – · · ·", "· · – – · ·", "– · · – ·", 
                                                    "· – · · – ·", "· – – – – ·", "– · – – · –", "– – · · – –",
                                                    "– · · · · –", "– · – – · –" };
        private string plainText;
        /// <summary>
        /// Обычный текст
        /// </summary>
        public string PlainText
        {
            get { return plainText; }
        }
        private string morseText;
        /// <summary>
        /// Текст, записанный азбукой Морзе
        /// </summary>
        public string MorseText
        {
            get { return morseText; }
        }

        public Morse(string Text)
        {
            this.plainText = Text;
        }
        /// <summary>
        /// Преобразование в азбуку Морзе
        /// </summary>
        public void ConvertToMorse()
        {
            int index;
            morseText = string.Empty;
            foreach (char letter in plainText)
            {
                index = -1;
                if (letter == ' ') continue;
                //поиск символа в массиве знаков и цифр
                index = Array.IndexOf<string>(Signs, letter.ToString().ToUpper());
                //Поиск символа в массиве латинских литералов
                if (index != -1)
                {
                    morseText += SignCodes[index];
                    continue;
                }
                else index = Array.IndexOf<string>(LiteralsLat, letter.ToString().ToUpper());

                //Поиск символа в массиве русских литералов
                if (index != -1)
                {
                    morseText += LiteralCodes[index];
                    continue;
                }                    
                else index = Array.IndexOf<string>(LiteralsRus, letter.ToString().ToUpper());

                if (index == -1) continue;
                morseText += LiteralCodes[index];
            }
        }
    }
}
