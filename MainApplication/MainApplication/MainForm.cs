using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class MainForm : Form
    {
        //first lets declare our variables
        Random randomGenerator = new Random();

        //just a normal counter in our timer
        int counter = 0;

        //this will be our target number of loops on counter
        int duration = 0;

        public MainForm()
        {
            InitializeComponent();

            //lets make our timer faster
            timer1.Interval = 1;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //lets display our last generated value
            lblLastValue.Text = "Last Value: " + lblNumber.Text;

            //reset the variables
            counter = 0;

            //so that the timer will not have a constant time
            duration = randomGenerator.Next(1, 500);

            //lets start our timer
            timer1.Start();

            //lets disable the button
            btnGenerate.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lets display our random number on the label
            lblNumber.Text = randomGenerator.Next(1, 100).ToString();

            //lets stop the timer once we reached our target duration
            if (counter == duration)
            {
                timer1.Stop();
                btnGenerate.Enabled = true;

                //lets save our value
                Properties.Settings.Default.LastValue = int.Parse(lblNumber.Text);
                Properties.Settings.Default.Save();
            }

            counter++;
        }

        //Now lets reload the value, once the form is opened
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblLastValue.Text = "Last Value: " + Properties.Settings.Default.LastValue.ToString();
            lblNumber.Text = Properties.Settings.Default.LastValue.ToString();
        }
        //It works!
        
    }
}
