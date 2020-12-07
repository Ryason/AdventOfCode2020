using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace AdventOfCode2020
{
    class Day7
    {
        #region Part One
        public static string PartOneOutput(string input)
        {
            string[] cleanIn = input.Split('\n');

            Dictionary<string, string[]> bagDefinitions = new Dictionary<string, string[]>();

            foreach (var bagRule in cleanIn)
            {
                string[] temp = bagRule.Split(new string[] { " bags contain " }, StringSplitOptions.None);

                bagDefinitions.Add(temp[0], temp[1].Split(','));
            }

            Regex rx = new Regex(@"(?<=\d\s)(\w+\s){2}");

            foreach (var item in bagDefinitions)
            {
                foreach (var val in item.Value)
                {
                    MatchCollection match = rx.Matches(val);

                    Console.WriteLine(match[0].ToString().Remove(match[0].Length-1,1));
                }

                Console.WriteLine("\n");
            }

            return cleanIn[0];
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
