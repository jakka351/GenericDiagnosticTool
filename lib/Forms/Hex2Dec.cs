using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Globalization;

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
            try
            {

                string hexString = textBox1.Text;

                // Convert the large hex string to a BigInteger
                // NumberStyles.HexNumber lets Parse know that we're dealing with hex.
                BigInteger bigIntValue = BigInteger.Parse(hexString, NumberStyles.HexNumber);

                // Convert the BigInteger to its decimal representation
                string decimalString = bigIntValue.ToString();

                // Convert hex string to byte array
                // Ensure the length is even. If not, you may need to prepend a '0'
                // This step is only meaningful if you actually have bytes representing ASCII.
                // If the hex is just a large number (e.g. not representing ASCII),
                // decoding it as ASCII might not produce readable text.
                if (hexString.Length % 2 != 0)
                {
                    // If odd length, prepend '0' to make it even.
                    hexString = "0" + hexString;
                }

                byte[] bytes = new byte[hexString.Length / 2];
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
                }

                // Convert byte array to ASCII string
                string asciiString = Encoding.ASCII.GetString(bytes);

                textBox2.Text = decimalString;
                textBox3.Text = asciiString;
            }
            catch(Exception ex)
            {
                this.Close();
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Hex2Dec_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
