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
    public partial class Form5 : MaterialForm
    {
        public Form5()
        {
            InitializeComponent();
            Patients();
        }

        List<Appointment.Patient> patients = new List<Appointment.Patient>(); 
        private void Patients()
        {
            string filePath = @"C:\Users\User\Lab-OOP\patients.txt"; 

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] data = line.Split(',');

                    if (data.Length >= 6) 
                    {
                        var patient = new Appointment.Patient(Guid.Parse(data[0].Trim()), data[1].Trim(), data[2].Trim(), data[3].Trim(), data[4].Trim(), data[5].Trim());
                        
                           if (data.Length > 6) patient.Treatment = data[6].Trim();
                           if (data.Length > 7) patient.Nurse = data[7].Trim();
                           patients.Add(patient); 
                    }
                }
            }

            for (int i = 0; i < patients.Count; i++)
            {
                listBox1.Items.Add(patients[i].Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                
                Appointment.Patient selectedPatient = patients[listBox1.SelectedIndex];

                textBox1.Text = $"{selectedPatient.id}, {selectedPatient.Name}, {selectedPatient.Age}, {selectedPatient.Gender}, {selectedPatient.Number}, {selectedPatient.Name_Doctor}";
                textBox2.Text = selectedPatient.Treatment;
                textBox3.Text = selectedPatient.Nurse;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Appointment.Patient selectedPatient = patients[listBox1.SelectedIndex];

                selectedPatient.Treatment = textBox2.Text;
                selectedPatient.Nurse = textBox3.Text;

                listBox1.Items[listBox1.SelectedIndex] = $"{selectedPatient.id} - {selectedPatient.Treatment}";

                SavePatientsToFile();

                MessageBox.Show("Data was saved!");
            }
        }

        private void SavePatientsToFile()
        {
            string newFilePath = @"C:\Users\User\Lab-OOP\patients_updating.txt";

            using (StreamWriter writer = new StreamWriter(newFilePath, false))
            {
                for (int i = 0; i < patients.Count; i++)
                {
                    Appointment.Patient patient = patients[i];
                    string dataPatient = $"{patient.id}, {patient.Name}, {patient.Age}, {patient.Gender}, {patient.Number}, {patient.Name_Doctor}, {patient.Treatment}, {patient.Nurse}";
                    writer.WriteLine(dataPatient);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm form1 = new MainForm();
            form1.Show();
        }
    }
}
