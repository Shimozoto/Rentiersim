using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentiersim
{
    public partial class Form1 : Form
    {
        int xPosR1, xPosR2, rentierNummer;
        int guthaben = 10;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        //reset
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(23, pictureBox1.Location.Y);
            pictureBox2.Location = new Point(23, pictureBox2.Location.Y);
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //start
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(guthaben);
            if (guthaben == 0)
            {
                MessageBox.Show("Kein Guthaben mehr :(", "Oh oh");
                Close();
            }
            rentierNummer = Convert.ToInt32(Interaction.InputBox("Welches Rentier wird gewinnen? 1 oder 2?", "Schliese eine Wette ab!"));
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        //stoppuhr
        private void timer1_Tick(object sender, EventArgs e)
        {
            xPosR1 = r.Next(50);
            xPosR2 = r.Next(50);
            int sieger = 0;
            pictureBox1.Location = new Point(pictureBox1.Location.X + xPosR1, pictureBox1.Location.Y);
            pictureBox2.Location = new Point(pictureBox2.Location.X + xPosR2, pictureBox2.Location.Y);
            if (pictureBox1.Location.X >= 545)
            {
                timer1.Enabled = false;
                sieger = 1;
            }
            else if (pictureBox2.Location.X >= 545)
            {
                timer1.Enabled = false;
                sieger = 2;
            }

            if (timer1.Enabled == false)
            {
                button2.Enabled = true;
                if (sieger == rentierNummer)
                {
                    MessageBox.Show("Herzlichen Glückwunsch!", "Ergebnis");
                    guthaben = guthaben + 10;
                }
                else
                {
                    MessageBox.Show("Leider Verloren!", "Ergebnis");
                    guthaben = guthaben - 10;
                }
                textBox1.Text= Convert.ToString(guthaben);
            }
        }
    }
}
