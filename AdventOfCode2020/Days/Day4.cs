using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day4
    {
        //this was tough.
        //actually learning quite a bit about C# that i didn't know,
        //also learning about the debugger here in VS,
        //and finally looking into how to use regex (haha sometimes string.Split() just isn't good enough!)


        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split(new string[] { "\r", "\r" }, StringSplitOptions.None);
            string str = "";

            int count = 0;


            List<string> cleanInput = new List<string>();

            foreach (var item in input)
            {
                if (item != "")
                {
                    str = str + " " + item;
                }
                else
                {
                    cleanInput.Add(str);
                    str = "";
                }

                if (item == input[input.Length-1])
                {
                    cleanInput.Add(str);
                }
            }

            for (int i = 0; i < cleanInput.Count; i++)
            {
                if (DoesPassportHaveAllFields(cleanInput[i].Substring(1)))
                {
                    Console.WriteLine("Valid: " + cleanInput[i]);
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid: " + cleanInput[i]);
                }
            }

            return count.ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            //can pass an array into split, and have split option none. essentially splits about the combined string array(i think)
            string[] input = rawInput.Split(new string[] { "\n", "\n" }, StringSplitOptions.None);
            int count = 0;

            string str = "";

            List<string> cleanInput = new List<string>();

            foreach (var item in input)
            {
                if (item != "")
                {
                    str = str + " " + item;
                }
                else
                {
                    cleanInput.Add(str);
                    str = "";
                }

                if (item == input[input.Length - 1])
                {
                    cleanInput.Add(str);
                }
            }

            for (int i = 0; i < cleanInput.Count; i++)
            {
                if (DoesPassportHaveAllFields(cleanInput[i].Substring(1)))
                {
                    if (ArePassportFieldsValid(cleanInput[i].Substring(1)))
                    {
                        Console.WriteLine("Valid: " + cleanInput[i]);
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid: " + cleanInput[i]);
                }
            }

            return count.ToString();
        }
        #endregion

        #region Functions
        private static bool DoesPassportHaveAllFields(string passport)
        {
            List<string> fields = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            foreach (string field in fields)
            {
                if (!passport.Contains(field))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ArePassportFieldsValid(string passport)
        {
            //i learned about regex today
            //it was hard, but got through it using an example from reddit
            //i didn't even just copy, i took the time to learn what it does
            //regex is extemely usefull, and i think i will need it in the future
            //even learned about the @ string modifier (reads the string literally)
            List<string> data = new List<string>() { @"byr:(19[2-9][0-9]|200[0-2])",
                                                     @"iyr:(201[0-9]|2020)",
                                                     @"eyr:(202[0-9]|2030)",
                                                     @"hgt:((1[5-8][0-9]|19[0-3])cm)|hgt:(6[0-9]|59|7[0-6])in",
                                                     @"hcl:(#[0-9a-f]{6})",
                                                     @"ecl:(amb|blu|brn|gry|grn|hzl|oth)",
                                                     @"pid:(\d{9}\b)" };

            foreach (string regex in data)
            {
                //search the string for each regex string in the regex data list
                //matches .count will return a 1 if a match is made
                //so, if it is 0, a passport field is not valid
                MatchCollection matches = Regex.Matches(passport, regex);
                if (matches.Count == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}