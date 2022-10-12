using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        char[] characters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                         'J', 'K', 'L', 'M', 'N', 'O', 'P','Q', 'R',
                                         'S','T', 'U','V', 'W', 'X', 'Y', 'Z'  };

        string[] codeMorse = new string[] { "•−", "−•••", "−•−•", "−••", "•", "••−•", "−−•", "••••", "••",
                                            "•−−−−", "−•−", "•−••", "−−", "−•", "−−−", "•−−•", "•−•", "•••",
                                            "−", "••−","•••−", "•−−", "−••−", "−•−−", "−−••", "•−−−−"};

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            input = input.ToUpper();
            string output = "";
            int index;
            foreach (char c in input)
            {
                if (c != ' ')
                {
                    index = Array.IndexOf(characters, c);
                    output += codeMorse[index] + " ";
                }
            }
            output = output.Remove(output.Length - 1);
            textBox2.Text = output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Домашнее задание №3 УТС-21 Карапетов Валерий";
        }
    }
}
