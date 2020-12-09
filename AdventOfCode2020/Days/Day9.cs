using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day9
    {
        #region Part One
        public static string PartOneOutput(string input)
        {
            string[] portOutputString = input.Split('\n');

            List<long> portOut = new List<long>();

            foreach (var item in portOutputString)
            {
                portOut.Add(long.Parse(item));
            }

            string outstring = "";
            int preLength = 25;
            bool matchFound = false;
            for (int i = preLength; i < portOut.Count; i++)
            {
                matchFound = false;
                for (int j = i - preLength; j < i; j++)
                {
                    for (int k = i - preLength; k < i; k++)
                    {
                        if (portOut[i] == portOut[j]+portOut[k])
                        {
                            matchFound = true;
                            Console.WriteLine($"{portOut[i]} = {portOut[j]} + {portOut[k]}");
                            break;
                        }

                    }
                    if (matchFound)
                    {
                        break;
                    }
                    else
                    {
                        
                    }

                }
                if (!matchFound)
                {
                    Console.WriteLine($"{portOut[i]} error");
                    outstring = $"Error at position {i}: {portOut[i]}";
                }
                
            }

            return outstring;
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string input)
        {
            string[] portOutputString = input.Split('\n');

            List<long> portOut = new List<long>();

            foreach (var item in portOutputString)
            {
                portOut.Add(long.Parse(item));
            }

            string outstring = "";

            int preLength = 25;

            long error = 0;

            bool matchFound;

            for (int i = preLength; i < portOut.Count; i++)
            {
                matchFound = false;

                for (int j = i - preLength; j < i; j++)
                {
                    for (int k = i - preLength; k < i; k++)
                    {
                        if (portOut[i] == portOut[j] + portOut[k])
                        {
                            matchFound = true;

                            Console.WriteLine($"{portOut[i]} = {portOut[j]} + {portOut[k]}");
                            
                            break;
                        }
                    }

                    if (matchFound)
                    {
                        break;
                    }
                }

                if (!matchFound)
                {
                    Console.WriteLine($"{portOut[i]} error");

                    error = portOut[i];

                    outstring = $"Error at position {i}: {error}";
                }

            }

            //find consequtive

            List<long> sequence = new List<long>();

            for (int i = 0; i < portOut.Count; i++)
            {
                sequence.Clear();
                sequence.Add(portOut[i]);

                while (AddSequence(sequence) < error)
                {
                    sequence.Add(portOut[i + sequence.Count]);
                }
                if (AddSequence(sequence) == error)
                {
                    foreach (var item in sequence)
                    {
                        Console.WriteLine(item);
                    }
                    outstring = $"{sequence.Min()} + {sequence.Max()}";
                    break;
                }
            }

            return outstring;
        }
        #endregion

        #region Functions
        public static long AddSequence(List<long> sequence)
        {
            long sum = 0;

            foreach (long number in sequence)
            {
                sum += number;
            }

            return sum;
        }
        #endregion
    }
}
