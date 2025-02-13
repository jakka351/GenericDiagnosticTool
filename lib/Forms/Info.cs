using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace PassThruJ2534
{
	public partial class Info : Form
	{
		public Info()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
           
        }

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://testerpresent.com.au/";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void darkTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            string url = "https://testerpresent.com.au/";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
