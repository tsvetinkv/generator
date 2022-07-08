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

namespace Generator
{
    public partial class Form1 : Form
    {
        private string filePath = "D:/randomText/generator.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Random rnd = new Random();
            int resultId = rnd.Next(1, 21);//1-20

            string luckyNote = "";
            using(StreamReader sr = File.OpenText(filePath))
            {
                string note;
                while((note = sr.ReadLine()) != null)
                {
                    if (note.StartsWith($"{resultId}/"))
                    {
                        
                        luckyNote = note.Split("/")[1];
                    }
                }
            }

            textBox1.Text = luckyNote;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (File.Exists(filePath))
            {
                int lastID = int.Parse(File.ReadAllLines(filePath).LastOrDefault().Split("/")[0]);
                
                 using (StreamWriter sw = File.AppendText(filePath))
                 {
                     sw.WriteLine($"{lastID + 1}/{textBox2.Text}");
                 }
            }
            textBox2.Clear();
        }
    }
}
