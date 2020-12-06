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

        //IT WORKS AND I'M TOO LAZY TO ALTER WHAT LOOKED FINE WHEN IT WAS JUST 3 DAYS LONG
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
                case 6:
                    outputBox.Text = "\n- - - - DAY 6 - PART 1 - - - -\n\n" + Day6.PartOneOutput(inputBox.Text);
                    break;
                case 7:
                    outputBox.Text = "\n- - - - DAY 7 - PART 1 - - - -\n\n" + Day7.PartOneOutput(inputBox.Text);
                    break;
                case 8:
                    outputBox.Text = "\n- - - - DAY 8 - PART 1 - - - -\n\n" + Day8.PartOneOutput(inputBox.Text);
                    break;
                case 9:
                    outputBox.Text = "\n- - - - DAY 9 - PART 1 - - - -\n\n" + Day9.PartOneOutput(inputBox.Text);
                    break;
                case 10:
                    outputBox.Text = "\n- - - - DAY 10 - PART 1 - - - -\n\n" + Day10.PartOneOutput(inputBox.Text);
                    break;
                case 11:
                    outputBox.Text = "\n- - - - DAY 11 - PART 1 - - - -\n\n" + Day11.PartOneOutput(inputBox.Text);
                    break;
                case 12:
                    outputBox.Text = "\n- - - - DAY 12 - PART 1 - - - -\n\n" + Day12.PartOneOutput(inputBox.Text);
                    break;
                case 13:
                    outputBox.Text = "\n- - - - DAY 13 - PART 1 - - - -\n\n" + Day13.PartOneOutput(inputBox.Text);
                    break;
                case 14:
                    outputBox.Text = "\n- - - - DAY 14 - PART 1 - - - -\n\n" + Day14.PartOneOutput(inputBox.Text);
                    break;
                case 15:
                    outputBox.Text = "\n- - - - DAY 15 - PART 1 - - - -\n\n" + Day15.PartOneOutput(inputBox.Text);
                    break;
                case 16:
                    outputBox.Text = "\n- - - - DAY 16 - PART 1 - - - -\n\n" + Day16.PartOneOutput(inputBox.Text);
                    break;
                case 17:
                    outputBox.Text = "\n- - - - DAY 17 - PART 1 - - - -\n\n" + Day17.PartOneOutput(inputBox.Text);
                    break;
                case 18:
                    outputBox.Text = "\n- - - - DAY 18 - PART 1 - - - -\n\n" + Day18.PartOneOutput(inputBox.Text);
                    break;
                case 19:
                    outputBox.Text = "\n- - - - DAY 19 - PART 1 - - - -\n\n" + Day19.PartOneOutput(inputBox.Text);
                    break;
                case 20:
                    outputBox.Text = "\n- - - - DAY 20 - PART 1 - - - -\n\n" + Day20.PartOneOutput(inputBox.Text);
                    break;
                case 21:
                    outputBox.Text = "\n- - - - DAY 21 - PART 1 - - - -\n\n" + Day21.PartOneOutput(inputBox.Text);
                    break;
                case 22:
                    outputBox.Text = "\n- - - - DAY 22 - PART 1 - - - -\n\n" + Day22.PartOneOutput(inputBox.Text);
                    break;
                case 23:
                    outputBox.Text = "\n- - - - DAY 23 - PART 1 - - - -\n\n" + Day23.PartOneOutput(inputBox.Text);
                    break;
                case 24:
                    outputBox.Text = "\n- - - - DAY 24 - PART 1 - - - -\n\n" + Day24.PartOneOutput(inputBox.Text);
                    break;
                case 25:
                    outputBox.Text = "\n- - - - DAY 25 - PART 1 - - - -\n\n" + Day25.PartOneOutput(inputBox.Text);
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
                case 6:
                    outputBox.Text = "\n- - - - DAY 6 - PART 2 - - - -\n\n" + Day6.PartTwoOutput(inputBox.Text);
                    break;
                case 7:
                    outputBox.Text = "\n- - - - DAY 7 - PART 2 - - - -\n\n" + Day7.PartTwoOutput(inputBox.Text);
                    break;
                case 8:
                    outputBox.Text = "\n- - - - DAY 8 - PART 2 - - - -\n\n" + Day8.PartTwoOutput(inputBox.Text);
                    break;
                case 9:
                    outputBox.Text = "\n- - - - DAY 9 - PART 2 - - - -\n\n" + Day9.PartTwoOutput(inputBox.Text);
                    break;
                case 10:
                    outputBox.Text = "\n- - - - DAY 10 - PART 2 - - - -\n\n" + Day10.PartTwoOutput(inputBox.Text);
                    break;
                case 11:
                    outputBox.Text = "\n- - - - DAY 11 - PART 2 - - - -\n\n" + Day11.PartTwoOutput(inputBox.Text);
                    break;
                case 12:
                    outputBox.Text = "\n- - - - DAY 12 - PART 2 - - - -\n\n" + Day12.PartTwoOutput(inputBox.Text);
                    break;
                case 13:
                    outputBox.Text = "\n- - - - DAY 13 - PART 2 - - - -\n\n" + Day13.PartTwoOutput(inputBox.Text);
                    break;
                case 14:
                    outputBox.Text = "\n- - - - DAY 14 - PART 2 - - - -\n\n" + Day14.PartTwoOutput(inputBox.Text);
                    break;
                case 15:
                    outputBox.Text = "\n- - - - DAY 15 - PART 2 - - - -\n\n" + Day15.PartTwoOutput(inputBox.Text);
                    break;
                case 16:
                    outputBox.Text = "\n- - - - DAY 16 - PART 2 - - - -\n\n" + Day16.PartTwoOutput(inputBox.Text);
                    break;
                case 17:
                    outputBox.Text = "\n- - - - DAY 17 - PART 2 - - - -\n\n" + Day17.PartTwoOutput(inputBox.Text);
                    break;
                case 18:
                    outputBox.Text = "\n- - - - DAY 18 - PART 2 - - - -\n\n" + Day18.PartTwoOutput(inputBox.Text);
                    break;
                case 19:
                    outputBox.Text = "\n- - - - DAY 19 - PART 2 - - - -\n\n" + Day19.PartTwoOutput(inputBox.Text);
                    break;
                case 20:
                    outputBox.Text = "\n- - - - DAY 20 - PART 2 - - - -\n\n" + Day20.PartTwoOutput(inputBox.Text);
                    break;
                case 21:
                    outputBox.Text = "\n- - - - DAY 21 - PART 2 - - - -\n\n" + Day21.PartTwoOutput(inputBox.Text);
                    break;
                case 22:
                    outputBox.Text = "\n- - - - DAY 22 - PART 2 - - - -\n\n" + Day22.PartTwoOutput(inputBox.Text);
                    break;
                case 23:
                    outputBox.Text = "\n- - - - DAY 23 - PART 2 - - - -\n\n" + Day23.PartTwoOutput(inputBox.Text);
                    break;
                case 24:
                    outputBox.Text = "\n- - - - DAY 24 - PART 2 - - - -\n\n" + Day24.PartTwoOutput(inputBox.Text);
                    break;
                case 25:
                    outputBox.Text = "\n- - - - DAY 25 - PART 2 - - - -\n\n" + Day25.PartTwoOutput(inputBox.Text);
                    break;
                default:
                    break;
            }
        }
    }
}
