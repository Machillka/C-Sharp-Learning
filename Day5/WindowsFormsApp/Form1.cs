using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Enabled = true;
            label1.Text = "Hello world!";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Enabled = false;
            label1.Text = "Label Pressed";
        }
    }
}
