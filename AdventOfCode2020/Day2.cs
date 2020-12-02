using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    static class Day2
    {
        #region Part One
        public static string PartOneOutput(string input)
        {
            int passwordCount = 0;
            //3-6 s: ssdsssss
            string[] passwordString = input.Split('\n');

            foreach (var passW in passwordString)
            {
                int lowerLimit = int.Parse(passW.Split(' ')[0].ToString().Split('-')[0]);
                int upperLimit = int.Parse(passW.Split(' ')[0].ToString().Split('-')[1]);

                string letterToCount = passW.Split(' ')[1][0].ToString();

                string password = passW.Split(' ')[2].ToString();

                int count = 0;

                foreach (var item in password)
                {
                    if (item.ToString() == letterToCount)
                    {
                        count++;
                    }
                }
                if (count <= upperLimit && count >= lowerLimit)
                {
                    passwordCount += 1;
                }
            }

            return passwordCount.ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string input)
        {
            int passwordCount = 0;

            //3-6 s: ssdsssss
            string[] passwordString = input.Split('\n');

            foreach (var passW in passwordString)
            {
                int pos1 = int.Parse(passW.Split(' ')[0].ToString().Split('-')[0]);
                int pos2 = int.Parse(passW.Split(' ')[0].ToString().Split('-')[1]);

                string letterToTrack = passW.Split(' ')[1][0].ToString();

                string password = passW.Split(' ')[2].ToString();

                if (password[pos1-1].ToString() == letterToTrack ^ password[pos2-1].ToString() == letterToTrack)
                {
                    passwordCount++;
                }
            }

            return passwordCount.ToString();
        }
        #endregion
    }
}
