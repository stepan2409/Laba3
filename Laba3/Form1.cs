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
        public Form1()
        {
            InitializeComponent();
            label3.Text = Computer.GetInstance().ToString();
            Computer.GetInstance().ComputerParametersChanged += OnComputerParametersChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Computer.GetInstance().ComputerName = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value) && value >= 0)
            {
                Computer.GetInstance().ScreenBrightnessUp(value);
            } else
            {
                MessageBox.Show("Изменение яркости должно быть целым неотрицательным числом!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value) && value >= 0)
            {
                Computer.GetInstance().ScreenBrightnessDown(value);
            }
            else
            {
                MessageBox.Show("Изменение яркости должно быть целым неотрицательным числом!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Computer.GetInstance().ScreenPowerIsOn)
            {
                Computer.GetInstance().ScreenPowerDown();
                button3.Text = "ВКЛЮЧИТЬ ЭКРАН";
                textBox2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                label4.Enabled = false;
            } else
            {
                Computer.GetInstance().ScreenPowerUp();
                button3.Text = "ВЫКЛЮЧИТЬ ЭКРАН";
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                label4.Enabled = true;
            }
        }

        private void OnComputerParametersChanged (object sender, EventArgs e)
        {
            label3.Text = Computer.GetInstance().ToString();
        }
    }
}
