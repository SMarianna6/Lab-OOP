using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MaterialSkin.Controls;

namespace Lab_project_oop
{
    public partial class Form4 : MaterialForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        delegate void ShowText(string text);

        ShowText TextS = (string text) =>
        {
            MessageBox.Show(text);
        };

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm form1 = new MainForm();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Gmail = textBox1.Text;
            string Name_Doctor = textBox2.Text;
            string Password = textBox3.Text;

            string doctorsFile = @"C:\Users\User\Lab-OOP\doctors.txt";
            string nursesFile = @"C:\Users\User\Lab-OOP\nurse.txt";

            if (CheckUser(doctorsFile, Gmail, Name_Doctor, Password))
            {
                Form5 form5 = new Form5();
                form5.Show();
                this.Close();
            } 
            else if(CheckUser(nursesFile, Gmail, Name_Doctor, Password)) 
            {
                Form6 form6 = new Form6();
                form6.Show();
                this.Close();
            }
            else
            {
                TextS("Error. Check if you entered your data correctly.");
            }
        }
        private bool CheckUser(string FileName, string Gmail, string Name_Doctor, string Password)
        {
            string[] lines = File.ReadAllLines(FileName);
 
            for (int i = 0; i < lines.Length; i++)
            {
                string[] inputData = lines[i].Split(',');
                if (inputData[1].Trim() == Gmail && inputData[2].Trim() == Name_Doctor && inputData[6].Trim() == Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
