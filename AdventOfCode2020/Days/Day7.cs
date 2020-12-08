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

            int allowedBagCount = 0;

            Dictionary<string, string[]> bagDefinitions = new Dictionary<string, string[]>();
            
            Regex rx = new Regex(@"(?<=\d\s)(\w+\s){2}");

            foreach (var bagRule in cleanIn)
            {
                string[] temp = bagRule.Split(new string[] { " bags contain " }, StringSplitOptions.None);

                bagDefinitions.Add(temp[0], temp[1].Split(','));

                for (int i = 0; i < bagDefinitions[temp[0]].Length; i++)
                {

                    MatchCollection match = rx.Matches(bagDefinitions[temp[0]][i]);
                    if (match.Count != 0)
                    {
                        bagDefinitions[temp[0]][i] = match[0].ToString().Remove(match[0].Length - 1, 1);
                    }
                }
            }

            foreach (var item in bagDefinitions)
            {
                var list = item.Value.ToList();
                if (CheckContainingBags(list, bagDefinitions))
                {
                    allowedBagCount++;
                }
                
            }

            return allowedBagCount.ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string input)
        {
            string[] cleanIn = input.Split('\n');
            int bagTotal = 0;
            

            Dictionary<string, string[]> bagDefinitions = new Dictionary<string, string[]>();

            //regex that keeps number of bags (\d\s\w+\s\w+)

            Regex rx = new Regex(@"(\d\s\w+\s\w+)");

            foreach (var bagRule in cleanIn)
            {
                string[] temp = bagRule.Split(new string[] { " bags contain " }, StringSplitOptions.None);

                bagDefinitions.Add(temp[0], temp[1].Split(','));

                for (int i = 0; i < bagDefinitions[temp[0]].Length; i++)
                {
                    MatchCollection match = rx.Matches(bagDefinitions[temp[0]][i]);

                    if (match.Count != 0)
                    {
                        bagDefinitions[temp[0]][i] = match[0].ToString();
                    }
                }
            }

            List<string> bagsToCheck = new List<string>() { "shiny gold" };

            bagTotal += BagsInBag(bagsToCheck, bagDefinitions);
            
            

            return bagTotal.ToString();
        }
        #endregion

        #region Functions
        public static int BagsInBag(List<string> bag, Dictionary<string, string[]> bagDefinitions)
        {
            List<string> insideBag = new List<string>();
            foreach (var item in bagDefinitions[bag[0]])
            {
                for (int i = 0; i < int.Parse(item.Substring(0, 1)); i++)
                {
                    insideBag.Add(item.Substring(2));
                }
            }
            

            int listPosition = 0;

            while (listPosition < insideBag.Count)
            {
                
                foreach (var item in bagDefinitions[insideBag[listPosition]])
                {

                    if (item == "no other bags.")
                    {
                        Console.WriteLine("no other bags.");
                    }
                    else
                    {
                        Console.WriteLine($"adding {int.Parse(item.Substring(0, 1))} {item.Substring(2)}");
                        for (int i = 0; i < int.Parse(item.Substring(0, 1)); i++)
                        {
                            insideBag.Add(item.Substring(2));
                        }
                    }
                    
                    
                    
                }
                Console.WriteLine("adding 1 to listPosition");
                listPosition++;


            }

            return listPosition;
        }
        public static bool CheckContainingBags(List<string> bagCheck, Dictionary<string, string[]> bagDefinitions)
        {
            List<string> insideBag = new List<string>();
            foreach (var item in bagCheck)
            {
                insideBag.Add(item);
            }

            while (!insideBag.Contains("shiny gold"))
            {
                foreach (var bag in insideBag.ToList())
                {
                    if (bag == "no other bags.")
                    {

                    }
                    else
                    {
                        foreach (var item in ContentsOfBag(bag,bagDefinitions))
                        {
                            if (!insideBag.Contains(item))
                            {
                                insideBag.Add(item);
                            }
                        }

                        insideBag.Remove(bag);
                    }
                }

                if (insideBag.Count == 1 && insideBag[0] == "no other bags.")
                {
                    break;
                }
            }

            if (insideBag.Contains("shiny gold"))
            {
                return true;
            }

            
            

            return false;
        }

        public static List<string> ContentsOfBag(string bag, Dictionary<string, string[]> bagDefinitions)
        {
            return bagDefinitions[bag].ToList();
        }
        #endregion
    }
}
