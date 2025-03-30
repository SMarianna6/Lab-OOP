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
    public partial class Appointment : MaterialForm
    {
        public Appointment()
        {
            InitializeComponent();
        }
        public class Entity
        {
            public Guid id { get; set; } //Id 

            public Entity()
            {
                id = Guid.NewGuid();
            }

            public Entity(Guid id)
            {
                this.id = id;
            }

            public bool IsValid()
            {
                return id != Guid.Empty;
            }

            public virtual string Format()
            {
                return "[" + id.ToString() + "]";
            }
        }

        public class Patient : Entity
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string Number { get; set; }
            public string Name_Doctor { get; set; }
            public string Treatment { get; set; }
            public string Nurse { get; set; }

            public Patient()
            {
                Name = string.Empty;
                Age = string.Empty;
                Gender = string.Empty;
                Number = string.Empty;
                Name_Doctor = string.Empty;
                Treatment = string.Empty;
                Nurse = string.Empty;
            }

            public Patient(Guid id, string name, string age, string gender, string number, string name_doctor)
            {
                this.id = id;
                Name = name;
                Age = age;
                Gender = gender;
                Number = number;
                Name_Doctor = name_doctor;
                Treatment = "";
                Nurse = "";
            }

            public new bool IsValid()
            {
                return
                       base.IsValid() &&
                       !string.IsNullOrEmpty(Name) &&
                       !string.IsNullOrEmpty(Age) &&
                       !string.IsNullOrEmpty(Gender) &&
                       !string.IsNullOrEmpty(Number) &&
                       !string.IsNullOrEmpty(Name_Doctor);
            }

            public override string Format()
            {
                return $"{base.Format()}[{Name}][{Age}][{Gender}][{Number}][{Name_Doctor}]";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm form1 = new MainForm();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string age = textBoxAge.Text;
            string gender = textBoxGender.Text;
            string number = textBoxNumber.Text;
            string name_doctor = textBoxDoctorName.Text;

            Patient patient = new Patient(Guid.NewGuid(), name, age, gender, number, name_doctor);
            string filePath = @"C:\Users\User\Lab-OOP\patients.txt";
            string DataPatient = $"{patient.id}, {patient.Name}, {patient.Age}, {patient.Gender}, {patient.Number}, {patient.Name_Doctor}, {patient.Treatment}, {patient.Nurse}";
            File.AppendAllText(filePath, DataPatient + Environment.NewLine);

            MessageBox.Show("RECORD IS MADE");
        }
    }
}
