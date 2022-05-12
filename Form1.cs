using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mophongb1
{
    public partial class Form1 : Form

    {
        double a, b, c, d, Ts;
        double uk, yk, uk1, yk1, uk2, yk2;
        int Tsm;

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string rev_d = serialPort1.ReadLine();
            textBox5.Text = rev_d;
            uk = double.Parse(rev_d);
          
        }

        bool tmpstart =false;

        private void Start_Click(object sender, EventArgs e)
        {

            try
            {
                if (tmpstart)
                {
                    timer1.Enabled = true;
                }
                else { MessageBox.Show("Please insert a b or Ts !"); }

            }
            catch
            {
                //MessageBox.Show("Please insert uk !");x
            }
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            yk = a * yk1 - b * yk2 + c * uk1 + d * uk2;
            yk2 = yk1;
            uk2 = uk1;
            yk1 = yk;
            uk1 = uk;

            textBox3.Text = yk.ToString();
            serialPort1.WriteLine(yk.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            Control.CheckForIllegalCrossThreadCalls = false;
            textBox1.Text = "1.998994252960587";
            textBox6.Text = "0.999000499833375";
            textBox2.Text = "0.001249582786698";
            textBox7.Text = "0.001249166328432";
            textBox4.Text = "0.01";

        }

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox6.Text);
                c = double.Parse(textBox2.Text);
                d = double.Parse(textBox7.Text);

                Ts=double.Parse(textBox4.Text);
                Tsm=(int) (Ts *1000);
                timer1.Interval = Tsm;
                tmpstart=true;
            }
            catch
            {
                MessageBox.Show("Invalid number !");
            }
        }
    }
}
