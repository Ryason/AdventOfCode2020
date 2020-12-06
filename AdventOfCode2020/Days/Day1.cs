using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    static class Day1
    {
        #region Day One
        public static string PartOneOutput(string input)
        {
            string output = "";
            List<int> numbers = new List<int>();

            foreach (var item in input.Split('\n'))
            {
                numbers.Add(int.Parse(item));
            }
            
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (j != i)
                    {
                        if (numbers[i] + numbers[j] == 2020)
                        {
                            var num = numbers[i] * numbers[j];
                            output = "2 Numbers: " + numbers[i] + ", " + numbers[j] + "\nMultiplied = " + num;
                        }
                    }
                }
            }
            return output.ToString();
        }
        #endregion

        #region Day Two
        public static string PartTwoOutput(string input)
        {
            string output = "";
            List<int> numbers = new List<int>();

            foreach (var item in input.Split('\n'))
            {
                numbers.Add(int.Parse(item));
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    for (int k = 0; k < numbers.Count; k++)
                    {
                        if (j != i && j != k)
                        {
                            if (numbers[i] + numbers[j] + numbers[k] == 2020)
                            {
                                var num = numbers[i] * numbers[j] * numbers[k];
                                output = "2 Numbers: " + numbers[i] + ", " + numbers[j] + ", " + numbers[k] + "\nMultiplied = " + num;
                            }
                        }
                    }
                }
            }

            return output.ToString();
        }
        #endregion
    }
}
