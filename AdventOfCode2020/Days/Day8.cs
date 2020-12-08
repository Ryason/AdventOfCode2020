using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day8
    {
        #region Part One
        public static string PartOneOutput(string input)
        {
            string[] operations = input.Split('\n');

            int acc = 0;
            int opPos = 0;

            List<int> opRan = new List<int>();

            bool looping = false;

            while (opPos < operations.Length)
            {
                string[] opArray = operations[opPos].Split(' ');
                
                string op = opArray[0];
                string val = opArray[1];

                switch (op)
                {
                    case "nop":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            opPos++;
                        }
                        break;
                    case "acc":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            acc += int.Parse(val);
                            opPos++;
                        }
                        break;
                    case "jmp":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            opPos += int.Parse(val);
                        }
                        break;
                    default:
                        break;
                }
                if (looping)
                {
                    Console.WriteLine(acc);
                    break;
                }
            }

            return acc.ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string input)
        {
            string[] operations = input.Split('\n');

            for (int i = 0; i < operations.Length; i++)
            {
                string[] operationsModified = new string[operations.Length];

                operations.CopyTo(operationsModified,0);

                if (operationsModified[i].Contains("nop"))
                {
                    Console.WriteLine($"changing nop to jump at pos {i}");
                    operationsModified[i] = operationsModified[i].Replace("nop", "jmp");
                }
                else
                {
                    if (operationsModified[i].Contains("jmp"))
                    {
                        Console.WriteLine($"changing jmp to nop at pos {i}");
                        operationsModified[i] = operationsModified[i].Replace("jmp", "nop");
                    }
                }

                if (Loops(operationsModified))
                {
                    Console.WriteLine($"changing line {i} returns a LOOP");
                    operationsModified = operations;
                }
                else
                {
                    return ReturnAcc(operationsModified).ToString();
                    
                }
            }

            return "";
        }
        #endregion

        #region Functions
        public static bool Loops(string[] input)
        {
            string[] operations = input;

            int acc = 0;

            int opPos = 0;

            List<int> opRan = new List<int>();
            bool looping = false;

            while (opPos < operations.Length)
            {
                string[] opArray = operations[opPos].Split(' ');

                string op = opArray[0];
                string val = opArray[1];

                switch (op)
                {
                    case "nop":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            opPos++;
                        }
                        break;
                    case "acc":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            acc += int.Parse(val);
                            opPos++;
                        }
                        break;
                    case "jmp":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            opPos += int.Parse(val);
                        }
                        break;
                    default:
                        break;
                }
                if (looping)
                {
                    break;
                }
            }
            return looping;
        }

        public static int ReturnAcc(string[] input)
        {
            string[] operations = input;

            int acc = 0;

            int opPos = 0;

            List<int> opRan = new List<int>();
            bool looping = false;

            while (opPos < operations.Length)
            {
                string[] opArray = operations[opPos].Split(' ');

                string op = opArray[0];
                string val = opArray[1];

                switch (op)
                {
                    case "nop":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            opPos++;
                        }
                        break;
                    case "acc":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            acc += int.Parse(val);
                            opPos++;
                        }
                        break;
                    case "jmp":
                        if (opRan.Contains(opPos))
                        {
                            looping = true;
                            break;
                        }
                        else
                        {
                            opRan.Add(opPos);
                            opPos += int.Parse(val);
                        }
                        break;
                    default:
                        break;
                }
                if (looping)
                {
                    break;
                }
            }
            return acc;
        }
        #endregion
    }
}
