using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day5
    {
        #region Part One
        public static string PartOneOutput(string input)
        {
            //binary conversion of letters
            //B = 1
            //F = 0
            string[] boardingPasses = input.Split('\n');

            int highestSeatID = 0;

            foreach (var boardingPass in boardingPasses)
            {
                string row = boardingPass.Substring(0, 7);
                string col = boardingPass.Substring(7);

                row = row.Replace("F", "0").Replace("B","1");
                col = col.Replace("R", "1").Replace("L", "0");

                int rowInt = Convert.ToInt32(row, 2);
                int colInt = Convert.ToInt32(col, 2);

                int seatID = rowInt * 8 + colInt;

                if (seatID > highestSeatID)
                {
                    highestSeatID = seatID;
                }
            }

            return highestSeatID.ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string input)
        {
            //binary conversion of letters
            //B = 1
            //F = 0
            string[] boardingPasses = input.Split('\n');
            string output = "";

            List<int> seatID = new List<int>();

            foreach (var boardingPass in boardingPasses)
            {
                string row = boardingPass.Substring(0, 7);
                string col = boardingPass.Substring(7);

                row = row.Replace("F", "0").Replace("B", "1");
                col = col.Replace("R", "1").Replace("L", "0");

                int rowInt = Convert.ToInt32(row, 2);
                int colInt = Convert.ToInt32(col, 2);

                seatID.Add(rowInt * 8 + colInt);
            }

            seatID.Sort();

            for (int i = 1; i < seatID.Count(); i++)
            {
                if (seatID[i] != seatID[i-1]+1 || seatID[i] != seatID[i+1] -1)
                {
                    output = "Empty SeatID = " + seatID[i].ToString() + "\n\n" + "SeatID List:";
                    break;
                }
            }

            foreach (var ID in seatID)
            {
                output = output + "\n" + (ID + 1).ToString();
            }

            return output;
        }
        #endregion

        #region Functions

        #endregion
    }
}
