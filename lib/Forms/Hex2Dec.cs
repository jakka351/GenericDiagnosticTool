using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassThruJ2534.lib.Forms
{
    public partial class Hex2Dec : Form
    {
        public Hex2Dec()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string hexInput = "";
            string line;
            while (!string.IsNullOrEmpty(line = textBox1.Text))
            {
                hexInput += line + " ";
            }

            // Remove any whitespace and make sure the input length is even
            hexInput = hexInput.Replace(" ", "").Replace("\n", "").Replace("\r", "");
            if (hexInput.Length % 2 != 0)
            {
                textBox2.Text = "Invalid input length. Hexadecimal input should have an even number of characters.";
                return;
            }

            int byteCount = hexInput.Length / 2;
            byte[] bytes = new byte[byteCount];
            int[] decimals = new int[byteCount];
            char[] asciiChars = new char[byteCount];

            try
            {
                // Convert hex pairs to bytes
                for (int i = 0; i < byteCount; i++)
                {
                    string hexPair = hexInput.Substring(i * 2, 2);
                    bytes[i] = Convert.ToByte(hexPair, 16);
                    decimals[i] = bytes[i];

                    // Check if the byte corresponds to a printable ASCII character
                    if (decimals[i] >= 32 && decimals[i] <= 126)
                    {
                        asciiChars[i] = (char)decimals[i];
                    }
                    else
                    {
                        asciiChars[i] = '.'; // Non-printable characters are represented as '.'
                    }
                }
            }
            catch (FormatException)
            {
                textBox2.Text = "Invalid hexadecimal input.";
                return;
            }

            // Output the results
            textBox2.Text = "\nIndex\tHex\tDecimal\tASCII";
            for (int i = 0; i < byteCount; i++)
            {
                textBox2.Text += $"{i:D4}\t{bytes[i]:X2}\t{decimals[i]:D3}\t{asciiChars[i]}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Hex2Dec_Load(object sender, EventArgs e)
        {

        }
    }
}
