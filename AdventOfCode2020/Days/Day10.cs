using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day10
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            List<int> joltages = new List<int>();
            joltages.Add(0);
            foreach (string jolt in input)
            {
                joltages.Add(int.Parse(jolt));
            }

            joltages.Sort();
            joltages.Add(joltages.Max() + 3);

            Dictionary<int, int> differences = new Dictionary<int, int>();
            
            differences.Add(1, 0);
            differences.Add(3, 0);

            for (int i = 1; i < joltages.Count; i++)
            {
                switch (joltages[i] - joltages[i-1])
                {
                    case 1:
                        differences[1]++;
                        break;
                    case 3:
                        differences[3]++;
                        break;
                    default:
                        break;
                }
            }

            return $"Differences of 1 = {differences[1]}\nDifferences of 3 = {differences[3]}\nMultiplied = {differences[1] * differences[3]}";
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string input)
        {
            string[] output = input.Split('\n');

            return output[0];
        }
        #endregion

        #region Functions

        #endregion
    }
}
