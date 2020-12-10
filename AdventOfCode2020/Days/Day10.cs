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
        public static string PartTwoOutput(string rawInput)
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

            //find what numbers in the sequence are mandatory and what can be altered.
            //TRIBONACCI SERIES!!!

            List<long> paths = new List<long>();
            List<long> pathSum = new List<long>();

            //first 0 jolt adapter has one path too it(itself).
            paths.Add(1);
            pathSum.Add(1);
            
            //determine how many previous adapters one can reach with the given restrictions
            //(a difference of joltage of no more than 3 jolts))
            for (int i = 1; i < joltages.Count(); i++)
            {
                int pathCount = 0;

                long joltage = joltages[i];

                for (int j = i-1; j > j-3; j--)
                {
                    if (j < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (joltage - joltages[j] <= 3)
                        {
                            pathCount++;
                        }
                    }
                }

                paths.Add(pathCount);
            }

            for (int i = 1; i < paths.Count(); i++)
            {
                long sum = 0;

                for (int j = i-1; j >= i-paths[i]; j--)
                {
                    sum += pathSum[j];
                }

                pathSum.Add(sum);
            }

            for (int i = 0; i < joltages.Count(); i++)
            {
                Console.WriteLine($"Adapter {i + 1}: {joltages[i]}, Paths: {paths[i]}, PathSum: {pathSum[i]}");
            }

            return $"Number of combinations: {pathSum[pathSum.Count() - 1]}";
        }
        #endregion

        #region Functions

        #endregion
    }
}
