using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        SoundPlayer correct = new SoundPlayer(@"C:\Windows\Media\chimes.wav");
        int paddend1;
        int paddend2;
        int saddend1;
        int saddend2;
        int maddend1;
        int maddend2;
        int daddend1;
        int daddend2;
        int timeLeft;
        public void StartTheQuiz()
        {
            
            paddend1 = randomizer.Next(51);
            paddend2 = randomizer.Next(51);
            plusLeftLabel.Text = paddend1.ToString();
            plusRightLabel.Text = paddend2.ToString();
            saddend1 = randomizer.Next(1, 101);
            saddend2 = randomizer.Next(1, saddend1);
            minusLeftLabel.Text = saddend1.ToString();
            minusRightLabel.Text = saddend2.ToString();
            maddend1 = randomizer.Next(2,11);
            maddend2 = randomizer.Next(2,11);
            timesLeftLabel.Text = maddend1.ToString();
            timesRightLabel.Text = maddend2.ToString();
            daddend1 = randomizer.Next(2,11);
            daddend2 = randomizer.Next(2,11);
            dividedLeftLabel.Text = daddend1.ToString();
            dividedRightLabel.Text = daddend2.ToString();
            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((paddend1 + paddend2 == sum.Value)
                && (saddend1 - saddend2 == difference.Value)
                && (maddend1 * maddend2 == product.Value)
                && (daddend1 / daddend2 == quotient.Value))
                return true;
            else
                return false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                timeLabel.BackColor = Color.White;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = paddend1 + paddend2;
                difference.Value = saddend1 - saddend2;
                product.Value = maddend1 * maddend2;
                quotient.Value = daddend1 / daddend2;
                startButton.Enabled = true;
                timeLabel.BackColor = Color.White;

            }
        }

        private void sum_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (paddend1 + paddend2 == sum.Value)
            {
                correct.Play();
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if (saddend1 - saddend2 == difference.Value)
            {
                correct.Play();
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            if (maddend1 * maddend2 == product.Value)
            {
                correct.Play();
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if (daddend1 / daddend2 == quotient.Value)
            {
                correct.Play();
            }
        }
    }
}
