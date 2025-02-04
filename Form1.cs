using System; // Provides basic types and values
using System.Collections.Generic; // Provides generic collection types (not used in this code, but included)
using System.ComponentModel; // Contains types for component-based programming (not used here)
using System.Data; // Provides types for working with data (not used here)
using System.Diagnostics; // Provides classes for working with diagnostics (not used here)
using System.Drawing; // Provides types for graphics, drawing (not used here)
using System.Linq; // Provides LINQ (Language Integrated Query) capabilities (not used here)
using System.Security.Cryptography; // Provides cryptographic services (used here for hashing)
using System.Text; // Contains classes for manipulating strings (used here for encoding and building hashed result)
using System.Threading.Tasks; // Used for asynchronous programming (not used here)
using System.Windows.Forms; // Provides types for creating Windows Forms applications

/*
 @ Documentation has been provided by ChatGPT.
*/

namespace FlyffPasswordHasher
{
    public partial class Form1 : Form
    {
        // Constructor to initialize the form components
        public Form1()
        {
            InitializeComponent();
        }

        // Method that takes a string input and returns its MD5 hash as a hexadecimal string
        private string FlyffHasher(string str)
        {
            // Create an MD5 hash algorithm object
            using (MD5 md5 = MD5.Create())
            {
                // Compute the hash of the byte array of the input string
                byte[] hashed = md5.ComputeHash(Encoding.Default.GetBytes(str));

                // StringBuilder to construct the resulting hex string
                StringBuilder sb = new StringBuilder();

                // Loop through the hashed byte array and append each byte as a 2-character hexadecimal string
                foreach (byte b in hashed)
                {
                    sb.AppendFormat("{0:x2}", b); // Format each byte to hex (lowercase)
                }

                // Return the final hexadecimal string representation of the hash
                return sb.ToString();
            }
        }

        // Event handler for the button click event
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if both textboxes are filled (password and salt)
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                // Clear any previous text in the result box
                textBox3.Clear();

                // Concatenate the salt (textBox2) and password (textBox1) then hash the combined string
                textBox3.Text = FlyffHasher(textBox2.Text + textBox1.Text);
            }
            else
            {
                // If either textbox is empty, show an error message
                MessageBox.Show("Please fill in both password and salt.");
            }
        }
    }
}