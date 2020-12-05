using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch ((int)dayNumber.Value)
            {
                case 1:
                    outputBox.Text = "\n- - - - DAY 1 - PART 1 - - - -\n\n" + Day1.PartOneOutput(inputBox.Text);
                    break;
                case 2:
                    outputBox.Text = "\n- - - - DAY 2 - PART 1 - - - -\n\n" + Day2.PartOneOutput(inputBox.Text);
                    break;
                case 3:
                    outputBox.Text = "\n- - - - DAY 3 - PART 1 - - - -\n\n" + Day3.PartOneOutput(inputBox.Text);
                    break;
                case 4:
                    outputBox.Text = "\n- - - - DAY 4 - PART 1 - - - -\n\n" + Day4.PartOneOutput(inputBox.Text);
                    break;
                case 5:
                    outputBox.Text = "\n- - - - DAY 5 - PART 1 - - - -\n\n" + Day5.PartOneOutput(inputBox.Text);
                    break;
                default:
                    break;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch ((int)dayNumber.Value)
            {
                case 1:
                    outputBox.Text = "\n- - - - DAY 1 - PART 2 - - - -\n\n" + Day1.PartTwoOutput(inputBox.Text);
                    break;
                case 2:
                    outputBox.Text = "\n- - - - DAY 2 - PART 2 - - - -\n\n" + Day2.PartTwoOutput(inputBox.Text);
                    break;
                case 3:
                    outputBox.Text = "\n- - - - DAY 3 - PART 2 - - - -\n\n" + Day3.PartTwoOutput(inputBox.Text);
                    break;
                case 4:
                    outputBox.Text = "\n- - - - DAY 4 - PART 2 - - - -\n\n" + Day4.PartTwoOutput(inputBox.Text);
                    break;
                case 5:
                    outputBox.Text = "\n- - - - DAY 5 - PART 2 - - - -\n\n" + Day5.PartTwoOutput(inputBox.Text);
                    break;
                default:
                    break;
            }
        }
    }
}
