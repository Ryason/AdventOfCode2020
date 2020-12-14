using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day14
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            char[] mask = new char[] { };

            Dictionary<long, long> memory = new Dictionary<long, long>();

            foreach (var str in input)
            {
                long memLoc;
                long memVal;

                //regex for extracting memory locations from strings like mem[8]
                Regex regex = new Regex(@"\d+");

                string[] operation = str.Split('=');

                

                operation[0] = operation[0].Replace(" ", "");
                operation[1] = operation[1].Replace(" ", "");


                Console.WriteLine($"{operation[0]} : {operation[1]}");

                if (operation[0] == "mask")
                {
                    mask = operation[1].ToCharArray();
                    
                }
                else
                {
                    memLoc = long.Parse(regex.Match(operation[0]).Value);
                    memVal = long.Parse(operation[1]);

                    if (!memory.ContainsKey(memLoc))
                    {
                        memory.Add(memLoc, 0);
                    }

                    string valBinary = Convert.ToString(memVal,2);
                    valBinary = new string('0',36 - valBinary.Length) + valBinary;
                    char[] binaryArray = valBinary.ToCharArray();
                    //apply mask to binary string >> convert back to long >> store at memLoc


                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] != 'X')
                        {
                            binaryArray[i] = mask[i];
                        }
                    }
                    Console.WriteLine(new string(binaryArray));
                    memory[memLoc] = Convert.ToInt64(new string(binaryArray), 2);

                }
            }

            long answer;

            memory.Values.Sum();

            return memory.Values.Sum().ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            char[] mask = new char[] { };

            Dictionary<long, long> memory = new Dictionary<long, long>();

            foreach (var str in input)
            {
                long memLoc;
                long memVal;

                //regex for extracting memory locations from strings like mem[8]
                Regex regex = new Regex(@"\d+");

                string[] operation = str.Split('=');



                operation[0] = operation[0].Replace(" ", "");
                operation[1] = operation[1].Replace(" ", "");


                Console.WriteLine($"{operation[0]} : {operation[1]}");

                if (operation[0] == "mask")
                {
                    mask = operation[1].ToCharArray();

                }
                else
                {
                    memLoc = long.Parse(regex.Match(operation[0]).Value);
                    memVal = long.Parse(operation[1]);

                    if (!memory.ContainsKey(memLoc))
                    {
                        memory.Add(memLoc, 0);
                    }

                    string valBinary = Convert.ToString(memVal, 2);
                    valBinary = new string('0', 36 - valBinary.Length) + valBinary;
                    char[] binaryArray = valBinary.ToCharArray();
                    //apply mask to binary string >> convert back to long >> store at memLoc


                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] != '0')
                        {
                            binaryArray[i] = mask[i];
                        }
                    }
                    Console.WriteLine(new string(binaryArray));

                    ReturnSumOfAllBinaryNumbers(new string(binaryArray));

                    //memory[memLoc] = Convert.ToInt64(new string(binaryArray), 2);

                }
            }

            

            return "a";
        }
        #endregion

        #region Functions
        public static long ReturnSumOfAllBinaryNumbers(string binaryString)
        {
            List<int> xLoc = new List<int>();

            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == 'X')
                {
                    xLoc.Add(i);
                }
            }

            List<string> allNumbers = new List<string>();

            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == 'X')
                {
                    allNumbers[0] = allNumbers[0] + "1";
                }
                else
                {
                    allNumbers[0] = allNumbers[0] + binaryString[i];
                }
            }

            
            for (int i = 0; i < xLoc.Count(); i++)
            {
                int allNumbersCount = allNumbers.Count();
                //take all previous numbers and switch current bit to a 0
                for (int j = 0; j < allNumbersCount; j++)
                {
                    char[] prevNumber = allNumbers[j].ToCharArray();

                    prevNumber[xLoc[i]] = '0';

                    allNumbers.Add(new string(prevNumber));
                }
            }

            foreach (var item in allNumbers)
            {
                Console.WriteLine(allNumbers);
            }

            return 0;
        }
        #endregion
    }
}
