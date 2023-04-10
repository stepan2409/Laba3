using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private Computer computer;
        
        public Form1()
        {
            InitializeComponent();
            computer = Computer.GetInstance();
            label3.Text = computer.ToString();
            computer.ComputerParametersChanged += OnComputerParametersChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            computer.ComputerName = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            computer.ScreenBrightnessUp((int)numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            computer.ScreenBrightnessDown((int)numericUpDown1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (computer.ScreenPowerIsOn)
            {
                computer.ScreenPowerDown();
                button3.Text = "ВКЛЮЧИТЬ ЭКРАН";
            } else
            {
                computer.ScreenPowerUp();
                button3.Text = "ВЫКЛЮЧИТЬ ЭКРАН";
            }
        }

        private void OnComputerParametersChanged (object sender, EventArgs e)
        {
            label3.Text = computer.ToString();
        }
    }
}
