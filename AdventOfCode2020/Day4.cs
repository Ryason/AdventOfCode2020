using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day4
    {
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n','\n',':');

            ListDictionary passport = new ListDictionary();
            
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

                if (item == input[input.Length-1])
                {
                    cleanInput.Add(str);
                }
            }

            foreach (var field in cleanInput)
            {
                string[] fields = field.Substring(1).Split(' ');
                //if (fields.Contains("byr") &&
                //            fields.Contains("iyr") &&
                //            fields.Contains("eyr") &&
                //            fields.Contains("hgt") &&
                //            fields.Contains("hcl") &&
                //            fields.Contains("ecl") &&
                //            fields.Contains("pid") ||
                //            fields.Contains("byr") &&
                //            fields.Contains("iyr") &&
                //            fields.Contains("eyr") &&
                //            fields.Contains("hgt") &&
                //            fields.Contains("hcl") &&
                //            fields.Contains("ecl") &&
                //            fields.Contains("pid") &&
                //            fields.Contains("cid"))
                //{
                //    count++;
                //}

                str = "";
                foreach (var f in fields)
                {
                    str = str + " " + f;
                }

                if (fields.Length < 14)
                {
                    //Console.WriteLine("invalid passport detected");
                    break;
                }
                else
                {
                    count++;
                }
                //else
                //{
                    
                //    if (str.Contains("cid") && str.Contains("pid") || str.Contains("pid"))
                //    {

                //        Console.WriteLine(str);
                //        count++;
                //    }
                //    else
                //    {
                //        Console.WriteLine("inv : " + str);
                //    }
                //}
            }
            return count.ToString();
        }
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            return input[0];
        }
    }
}

