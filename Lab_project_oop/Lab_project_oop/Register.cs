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
    public partial class Form7 : MaterialForm
    {
        public Form7()
        {
            InitializeComponent();
        }

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

            bool userFound = false;

            string doctorsFile = @"C:\Users\User\Lab-OOP\doctors.txt";
            string nursesFile = @"C:\Users\User\Lab-OOP\nurse.txt";

            userFound = UpdatePassword(doctorsFile, Gmail, Name_Doctor, Password);
            if (!userFound)
            { 
              userFound = UpdatePassword(nursesFile, Gmail, Name_Doctor, Password);
            }
            if (userFound)
            {
                MessageBox.Show("Password was saved!");
            }
            else
            {
                MessageBox.Show("No data!");
            }
        }

        private bool UpdatePassword(string FileName, string gmail, string name_doctor, string newpassword)
        {
            string[] lines = File.ReadAllLines(FileName);
            bool userFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] employee = lines[i].Split(',');
                if (employee[1].Trim() == gmail && employee[2].Trim() == name_doctor)
                {
                    employee[6] = newpassword;
                    lines[i] = string.Join(",", employee);
                    userFound = true;
                    break;
                }
            }
            if (userFound)
            {
                File.WriteAllLines(FileName, lines);
            }
            return userFound;
        }
    }
}
