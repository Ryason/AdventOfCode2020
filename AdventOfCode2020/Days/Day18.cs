using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day18
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            List<long> lineValue = new List<long>();

            foreach (string expression in input)
            {
                string simplified = expression.Replace(" ","");

                Regex regex = new Regex(@"[\w\*\+\s]+");

                List<string> regexMatches = new List<string>();
                List<string> values = new List<string>();

                

                foreach (var item in regex.Matches(simplified))
                {
                    Console.WriteLine(item.ToString());
                    regexMatches.Add(item.ToString());
                }

                while (regexMatches.Count() > 1)
                {
                    //before i forget my plan.
                    //regex the string, try and evaluate matches.
                    //if they evaluate, build up a new string with the value in place of the expression it is short for.
                    // 3 + 1 + (4 * 1 + (3 * 5 + 1)) + 2
                    // 3 + 1 + (4 * 1 + (16)) + 2
                    // 3 + 1 + (4 * 1 + 16) + 2
                    // 3 + 1 + (20) + 2
                    // 3 + 1 + 20 + 2

                    //making sure to remove the enclosing brackets for parts of the simplfied expression

                    for (int i = 0; i < regexMatches.Count(); i++)
                    {
                        if (char.IsNumber(regexMatches[i][0]) && char.IsNumber(regexMatches[i].Last()))
                        {
                            string toReplace = Evaluate(regexMatches[i].ToString()).ToString();
                            simplified = simplified.Replace("(" + regexMatches[i] + ")", toReplace);
                            Console.WriteLine(simplified);
                        }
                    }


                    //for (int i = 0; i < regexMatches.Count(); i++)
                    //{
                    //    if (char.IsNumber(regexMatches[i][0]) && char.IsNumber(regexMatches[i].Last()))
                    //    {
                    //        string value = Evaluate(regexMatches[i]).ToString();
                    //    }
                    //}

                    regexMatches.Clear();
                    foreach (var item in regex.Matches(simplified))
                    {
                        Console.WriteLine(item.ToString());
                        regexMatches.Add(item.ToString());
                    }
                }

                lineValue.Add(Evaluate(simplified));

            }

            long answer = 0;
            foreach (var item in lineValue)
            {
                answer += item;
            }

            return answer.ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            List<long> lineValue = new List<long>();

            foreach (string expression in input)
            {
                string simplified = expression.Replace(" ", "");
                Console.WriteLine(simplified);

                Regex regex = new Regex(@"[\w\*\+\s]+");
                Regex isolateAddition = new Regex(@"[\d\+\s]{3,}");

                List<string> regexMatches = new List<string>();
                List<string> additionMatches = new List<string>();

                foreach (var item in isolateAddition.Matches(simplified))
                {
                    additionMatches.Add(item.ToString());
                }

                foreach (var item in regex.Matches(simplified))
                {
                    regexMatches.Add(item.ToString());
                }

                while (regexMatches.Count() > 1 || additionMatches.Count() >= 1)
                {
                    while (additionMatches.Count() >= 1)
                    {
                        for (int i = 0; i < additionMatches.Count(); i++)
                        {
                            if (char.IsNumber(additionMatches[i][0]) && char.IsNumber(additionMatches[i].Last()))
                            {
                                string toReplace = Evaluate(additionMatches[i].ToString()).ToString();
                                simplified = simplified.Replace(additionMatches[i], toReplace);
                                Console.WriteLine(simplified);
                            }
                        }

                        additionMatches.Clear();
                        foreach (var item in isolateAddition.Matches(simplified))
                        {
                            if (item.ToString().Contains('+') && char.IsNumber(item.ToString().First()) && char.IsNumber(item.ToString().Last()))
                            {
                                additionMatches.Add(item.ToString());
                            }
                        }
                    }

                    for (int i = 0; i < regexMatches.Count(); i++)
                    {
                        if (char.IsNumber(regexMatches[i][0]) && char.IsNumber(regexMatches[i].Last()))
                        {
                            string toReplace = Evaluate(regexMatches[i].ToString()).ToString();
                            simplified = simplified.Replace("(" + regexMatches[i] + ")", toReplace);
                            Console.WriteLine(simplified);
                        }
                    }

                    regexMatches.Clear();

                    foreach (var item in regex.Matches(simplified))
                    {
                        Console.WriteLine(item.ToString());
                        regexMatches.Add(item.ToString());
                    }

                    additionMatches.Clear();

                    foreach (var item in isolateAddition.Matches(simplified))
                    {
                        if (item.ToString().Contains('+'))
                        {
                            additionMatches.Add(item.ToString());
                        }
                    }

                    //after one cycle, need to check again for isolating addition regex
                    //examples like 2 * 3 + (4 * 5) dont match to [\d\+\s]{3,} untill after the (4*5) is evaluated
                }

                long val = 0;
                if (long.TryParse(simplified, out val))
                {
                    lineValue.Add(val);
                }
                else
                {
                    lineValue.Add(Evaluate(simplified));
                }
            }

            long answer = 0;
            foreach (var item in lineValue)
            {
                answer += item;
            }

            return answer.ToString();
        }
        #endregion

        #region Functions
        public static long Evaluate(string expression) 
        {
            long value = 0;
            int operation = 0;
            if (long.TryParse(expression, out value))
            {
                return value;
            }
            for (int i = 0; i < expression.Count(); i++)
            {
                if (value == 0)
                {
                    int start = i;
                    int startPlus = i;
                    int count = 0;
                    while (true)
                    {
                        if (char.IsNumber(expression[startPlus]))
                        {
                            startPlus++;
                            count++;
                        }
                        else
                        {
                            i = startPlus-1;
                            value = long.Parse(expression.Substring(start, count));
                            break;
                        }
                    }
                    
                }
                else
                {
                    if (expression[i] == '+' || expression[i] == '*')
                    {
                        switch (expression[i])
                        {
                            case '+':
                                operation = 1;
                                break;
                            case '*':
                                operation = 2;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        long val = 0;

                        int start = i;
                        int startPlus = i;
                        int count = 0;

                        while (true)
                        {
                            if (startPlus >= expression.Count())
                            {
                                break;
                            }

                            if (char.IsNumber(expression[startPlus]))
                            {
                                startPlus++;
                                count++;
                            }
                            else
                            {
                                break;
                            }
                            
                        }

                        i = startPlus-1;

                        val = long.Parse(expression.Substring(start, count));

                        if (operation == 1)
                        {
                            value += val;
                            operation = 0;
                        }
                        if (operation == 2)
                        {
                            value *= val;
                            operation = 0;
                        }
                    }
                }
            }

            Console.WriteLine($"Expression: {expression} = {value}");

            return value;
        }
        #endregion
    }
}