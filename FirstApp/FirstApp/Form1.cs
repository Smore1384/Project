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

namespace FirstApp
{
    public partial class Form1 : Form
    {
        private string tasksFilePath = "tasks.txt";
        private string  textboxFilePath = "text.txt";
        
        public Form1()
        {
            InitializeComponent();
        }
        private bool buttonclick = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTasks();
            LoadTasks2();
           
        }

      
   

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            buttonclick = true;
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Veuillez entrer un devoir et une date.");
            }
            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    
                    string Merge = $"{textBox1.Text}, {textBox2.Text} ";

                    
                    listBox1.Items.Add(Merge);

                   
                    textBox1.Clear();
                    textBox2.Clear();
                    
                }
                else
                {
                 MessageBox.Show("Veuillez entrer une date.");
                }
            }
            else
            {
              MessageBox.Show("Veuillez entrer un devoir.");
            }
            buttonclick = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Veulliez selectioné un devoir");
            }
        }

       

        private void SaveTasks()
        {
            using (StreamWriter writer = new StreamWriter(tasksFilePath))
            {
                foreach (var item in listBox1.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        private void LoadTasks()
        {
            if (File.Exists(tasksFilePath))
            {
                using (StreamReader reader = new StreamReader(tasksFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                    }
                }
            }
        }
        private void SaveTasks2()
        {
            using (StreamWriter writer = new StreamWriter(textboxFilePath))
            {
                
                    writer.WriteLine(textBox3.Text);
              
            }
        }

        private void LoadTasks2()
        {
            if (File.Exists(textboxFilePath))
            {
                using (StreamReader reader = new StreamReader(textboxFilePath))
                {
                   textBox3.Text = reader.ReadToEnd();  
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTasks();
            SaveTasks2();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9/]"))
            {
                if (buttonclick)
                {
                    MessageBox.Show("veuillez entrez dans le format présenté");
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 10);
                    
                }
            }
            if (buttonclick)
            {
                if (textBox2.Text.Length != 9)
                {
                    
                   
                    MessageBox.Show("veuillez entrez dans le format présenté. si le cas d'une date d'un chifre comme 1 mettez 01");
                    
                }

               
            }
        }
      
        }


    }
}
