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
using static Lab_project_oop.RegEmployees;
using System.Security.Cryptography.X509Certificates;
using MaterialSkin.Controls;
using static Lab_project_oop.Appointment;

namespace Lab_project_oop
{
    public partial class RegEmployees : MaterialForm
    {
        public RegEmployees()
        {
            InitializeComponent();
            comboBox1.Items.Add("Doctor");
            comboBox1.Items.Add("Nurse");
        }

        public class Doctor : Entity
        {
            public string Gmail { get; set; }
            public string Name_Doctor { get; set; }
            public string Birth_Doctor { get; set; }
            public string Gender_Doctor { get; set; }
            public string Number_Doctor { get; set; }
            public string Specialization_Doctor { get; set; }
            public string Password { get; set; }

            public Doctor() 
            {
                Gmail = string.Empty;
                Name_Doctor = string.Empty;
                Birth_Doctor = string.Empty;
                Gender_Doctor = string.Empty;
                Number_Doctor = string.Empty;
                Specialization_Doctor = string.Empty;
                Password = string.Empty;
            }

            public Doctor(string gmail, string name_doctor, string birth_doctor, string gender_doctor, string number_doctor)
            {
                Gmail = gmail;
                Name_Doctor = name_doctor;
                Birth_Doctor = birth_doctor;
                Gender_Doctor = gender_doctor;
                Number_Doctor = number_doctor;
                Specialization_Doctor = "Doctor";
                Password = "";

            }

            public new bool IsValid()
            {
                return !string.IsNullOrEmpty(Gmail) &&
                       !string.IsNullOrEmpty(Name_Doctor) &&
                       !string.IsNullOrEmpty(Birth_Doctor) &&
                       !string.IsNullOrEmpty(Gender_Doctor) &&
                       !string.IsNullOrEmpty(Number_Doctor) &&
                       !string.IsNullOrEmpty(Specialization_Doctor);
            }

            public override string Format()
            {
                return $"{base.Format()}[{Gmail}][{Name_Doctor}][{Birth_Doctor}][{Gender_Doctor}][{Number_Doctor}][{Specialization_Doctor}]";
            }

            public void SaveToFile(string filePath)
            {
                string DataDoctor = $"{id}, {Gmail}, {Name_Doctor}, {Birth_Doctor}, {Gender_Doctor}, {Number_Doctor}, {Password}";
                File.AppendAllText(filePath, DataDoctor + Environment.NewLine);
            }
        }
    

        sealed class Nurse : Doctor
        {

            public Nurse()
            {
                Gmail = string.Empty;
                Name_Doctor = string.Empty;
                Birth_Doctor = string.Empty;
                Gender_Doctor = string.Empty;
                Number_Doctor = string.Empty;
                Specialization_Doctor = string.Empty;
                Password = string.Empty;
            }

            public Nurse(string gmail, string name_doctor, string birth_doctor, string gender_doctor, string number_doctor)
            {
                Gmail = gmail;
                Name_Doctor = name_doctor;
                Birth_Doctor = birth_doctor;
                Gender_Doctor = gender_doctor;
                Number_Doctor = number_doctor;
                Specialization_Doctor = "Nurse";
                Password = "";
            }

            public void SaveToFile(string filePath)
            {
                string DataNurse = $"{id}, {Gmail}, {Name_Doctor}, {Birth_Doctor}, {Gender_Doctor}, {Number_Doctor}, {Password}";
                File.AppendAllText(filePath, DataNurse + Environment.NewLine);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm form1 = new MainForm();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gmail = textBox1.Text;
            string name_doctor = textBox2.Text;
            string birth_doctor = textBox3.Text;
            string gender_d = textBox4.Text;
            string number_d = textBox5.Text;

            if(comboBox1.SelectedItem.ToString() == "Doctor")
            {
              Doctor doctor = new Doctor(gmail, name_doctor, birth_doctor, gender_d, number_d);
              string filePath = @"C:\Users\User\Lab-OOP\doctors.txt";
              doctor.SaveToFile(filePath);
              MessageBox.Show("Doctor in Base");
            } 
            else if (comboBox1.SelectedItem.ToString() == "Nurse")
            {
              Nurse nurse = new Nurse(gmail, name_doctor, birth_doctor, gender_d, number_d);
              string filePath = @"C:\Users\User\Lab-OOP\nurse.txt";
              nurse.SaveToFile(filePath);
              MessageBox.Show("Nurse in Base");
            }
        }
    }
}
