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
using MaterialSkin.Controls;

namespace Lab_project_oop
{
    public partial class Form4 : MaterialForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            string Gmail = textBox1.Text;
            string Name_Doctor = textBox2.Text;
            string Password = textBox3.Text;

            bool userFound = false;

            string doctorsFile = @"C:\Users\User\Lab-OOP\doctors.txt";
            string nursesFile = @"C:\Users\User\Lab-OOP\nurse.txt";

            userFound = CheckUserCredentials(doctorsFile, Gmail, Name_Doctor, Password);
            if (userFound)
            {
                this.Close();
                Form5 form5 = new Form5();
                form5.Show();
            }
            else
            {
                userFound = CheckUserCredentials(nursesFile, Gmail, Name_Doctor, Password);
                if (userFound)
                {
                    this.Close();
                    Form6 form6 = new Form6();
                    form6.Show();
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
        }

        private bool CheckUserCredentials(string fileName, string gmail, string name_doctor, string password)
        {
            string[] lines = File.ReadAllLines(fileName);
            bool userFound = false;

            foreach (var line in lines)
            {
                string[] employee = line.Split(',');
                if (employee[1].Trim() == gmail && employee[2].Trim() == name_doctor && employee[6].Trim() == password)
                {
                    userFound = true;
                    break;
                }
            }
            return userFound;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm form1 = new MainForm();
            form1.Show();
        }

    }
}
