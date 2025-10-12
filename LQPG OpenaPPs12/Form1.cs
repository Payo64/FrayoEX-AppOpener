using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace LPQG_OpenaPPs12
{

    public partial class Form1 : Form
    {
        private string selectedExePath = string.Empty;
        private string selectedapp = string.Empty;
        private string Argumentation = string.Empty;

        public Form1()
        {
            InitializeComponent();
            label4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Argumentation = textBox1.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog() { Filter = "Windows EXE|*.exe" })
            {
                
                

                if (op.ShowDialog() == DialogResult.OK)
                {
                    selectedExePath = op.FileName;
                    selectedapp = Path.GetFileName(op.FileName);  // store the file path
                    string exe;
                    exe = op.FileName;
                    
                    label4.Show();
                    { label4.Text = selectedapp; label4.Refresh(); }
                    MessageBox.Show(" App Selected!",
                                    "Open", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    

                }
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedExePath) && File.Exists(selectedExePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = selectedExePath;
                startInfo.Arguments = Argumentation; // 👈 Use the textbox input
                startInfo.WorkingDirectory = Path.GetDirectoryName(selectedExePath);
                startInfo.UseShellExecute = false;



                Process.Start(startInfo);

                MessageBox.Show("Application started with arguments: " + Argumentation,
                                "LQPG App Opener", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            else
            {
                MessageBox.Show("Application is not selected", "LQPG App Opener", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
