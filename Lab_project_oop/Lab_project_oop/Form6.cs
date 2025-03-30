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
    public partial class Form6 : MaterialForm
    {
        public Form6()
        {
            InitializeComponent();
            Patients();
        }
        List<Appointment.Patient> patients = new List<Appointment.Patient>();
        private void Patients()
        {
            string filePath = @"C:\Users\User\Lab-OOP\patients_updating.txt";

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


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm form1 = new MainForm();
            form1.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Appointment.Patient selectedPatient = patients[listBox1.SelectedIndex];

                textBox1.Text = $"{selectedPatient.id}, {selectedPatient.Name}, {selectedPatient.Age}, {selectedPatient.Gender}, {selectedPatient.Number}, {selectedPatient.Name_Doctor}, {selectedPatient.Treatment}, {selectedPatient.Nurse}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Appointment.Patient selectedPatient = patients[listBox1.SelectedIndex];

                string patientData = $"{selectedPatient.id}, {selectedPatient.Name}, {selectedPatient.Age}, {selectedPatient.Gender}, {selectedPatient.Number}, {selectedPatient.Name_Doctor}, {selectedPatient.Treatment}, {selectedPatient.Nurse}";

                string filePath = @"C:\Users\User\Lab-OOP\patients_updating.txt";
                List<string> lines = new List<string>(File.ReadAllLines(filePath));

                lines.RemoveAll(line =>
                {
                    string[] data = line.Split(',');

                    if (data.Length >= 6)
                    { 
                        return data[0].Trim().Equals(selectedPatient.id.ToString(), StringComparison.OrdinalIgnoreCase) &&
                               data[1].Trim().Equals(selectedPatient.Name, StringComparison.OrdinalIgnoreCase) &&
                               data[2].Trim().Equals(selectedPatient.Age, StringComparison.OrdinalIgnoreCase) &&
                               data[3].Trim().Equals(selectedPatient.Gender, StringComparison.OrdinalIgnoreCase) &&
                               data[4].Trim().Equals(selectedPatient.Number, StringComparison.OrdinalIgnoreCase) &&
                               data[5].Trim().Equals(selectedPatient.Name_Doctor, StringComparison.OrdinalIgnoreCase) &&
                               (string.IsNullOrEmpty(selectedPatient.Treatment) || (data.Length > 6 && data[6].Trim().Equals(selectedPatient.Treatment, StringComparison.OrdinalIgnoreCase))) &&
                               (string.IsNullOrEmpty(selectedPatient.Nurse) || (data.Length > 7 && data[7].Trim().Equals(selectedPatient.Nurse, StringComparison.OrdinalIgnoreCase)));
                    }
                    return false;
                });

                File.WriteAllLines(filePath, lines);

                patients.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                MessageBox.Show("Patient was discharged");
            }
            else
            {
                MessageBox.Show("Select a Patient");
            }
        }

    }
}
