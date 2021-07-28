using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day19
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            List<string> messages = new List<string>();

            Dictionary<string, string> rules = new Dictionary<string, string>();

            Dictionary<string, string> knowRules = new Dictionary<string, string>();

            Dictionary<string, string> rulesToUpdate = new Dictionary<string, string>();


            List<string> regexToCheckFor = new List<string>();

            string ruleA;
            string ruleB;

            foreach (var item in input)
            {
                if (item.Contains(':')) //If so, it is a rule
                {
                    string[] line = item.Split(new string[] { ": " }, StringSplitOptions.None);

                    if (line[1] == "\"a\"")
                    {
                        rules.Add(line[0], "a");
                        knowRules.Add(line[0], "a");
                        ruleA = line[0];
                    }
                    else
                    {
                        if (line[1] == "\"b\"")
                        {
                            rules.Add(line[0], "b");
                            knowRules.Add(line[0], "b");
                            ruleB = line[0];
                        }
                        else
                        {
                            rules.Add(line[0], line[1]);
                        }
                    }
                }
                else
                {
                    messages.Add(item);
                }
            }

            //find the rule numbers where they are the values a and b
            //search each rule and where there are numbers that match the rule for a and b, replace with a and b.
            //after replaceing values with letters, if a rule is all letters, store the rule number and its rule

            Regex matchNumbers = new Regex(@"\d+");
            while (true)
            {
                foreach (var rule in rules)
                {
                    string currentRule = rule.Value;
                    //find numbers in a rule
                    var numbers = matchNumbers.Matches(rule.Value);

                    //search matches for a known rule
                    foreach (var num in numbers)
                    {
                        if (knowRules.ContainsKey(num.ToString()))
                        {
                            //replace the number with rule that is only letters
                            Regex replaceRuleNumber = new Regex(@"(?<!\d)" + $"{int.Parse(num.ToString())}" + @"(?!\d)");

                            currentRule = replaceRuleNumber.Replace(currentRule, knowRules[num.ToString()]);
                        }
                    }

                    if (!matchNumbers.IsMatch(currentRule))
                    {
                        if (knowRules.ContainsKey(rule.Key))
                        {
                            knowRules[rule.Key] = "(" + currentRule + ")";
                        }
                        else
                        {
                            knowRules.Add(rule.Key, "(" + currentRule + ")");
                        }
                    }
                    else
                    {
                        if (rulesToUpdate.ContainsKey(rule.Key))
                        {
                            rulesToUpdate[rule.Key] = currentRule;
                        }
                        else
                        {
                            rulesToUpdate.Add(rule.Key, currentRule);
                        }
                    }

                }

                foreach (var item in rulesToUpdate)
                {
                    rules[item.Key] = item.Value;
                }

                if (knowRules.Count == rules.Count)
                {
                    break;
                }
            }



            int count = -1;
            Regex mainRule = new Regex(knowRules["0"].Replace(" ", ""));

            foreach (var msg in messages)
            {
                if (mainRule.Match(msg).Length == msg.Length)
                {
                    count++;
                }
            }


            //8: (42 | 42 (42 | 42 ))+



            return $"matches = {count} \n\n Rule 42 = {knowRules["42"]} \nRule 31 = {knowRules["31"]} \n";
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            List<string> messages = new List<string>();

            Dictionary<string, string> rules = new Dictionary<string, string>();

            Dictionary<string, string> knowRules = new Dictionary<string, string>();

            Dictionary<string, string> rulesToUpdate = new Dictionary<string, string>();


            List<string> regexToCheckFor = new List<string>();

            string ruleA;
            string ruleB;

            foreach (var item in input)
            {
                if (item.Contains(':')) //If so, it is a rule
                {
                    string[] line = item.Split(new string[] { ": " }, StringSplitOptions.None);

                    if (line[1] == "\"a\"")
                    {
                        rules.Add(line[0], "a");
                        knowRules.Add(line[0], "a");
                        ruleA = line[0];
                    }
                    else
                    {
                        if (line[1] == "\"b\"")
                        {
                            rules.Add(line[0], "b");
                            knowRules.Add(line[0], "b");
                            ruleB = line[0];
                        }
                        else
                        {
                            rules.Add(line[0], line[1]);
                        }
                    }
                }
                else
                {
                    messages.Add(item);
                }
            }

            //find the rule numbers where they are the values a and b
            //search each rule and where there are numbers that match the rule for a and b, replace with a and b.
            //after replaceing values with letters, if a rule is all letters, store the rule number and its rule

            Regex matchNumbers = new Regex(@"\d+");

            for (int i = 0; i < 10; i++)
            {
                rules["8"] = rules["8"].Replace("8", "(" + rules["8"] + ")");
                rules["11"] = rules["11"].Replace("11", "(" + rules["11"] + ")");
            }

            rules["8"] = rules["8"].Replace("8", "");
            rules["11"] = rules["11"].Replace("11", "");

            while (true)
            {
                foreach (var rule in rules)
                {
                    string currentRule = rule.Value;
                    //find numbers in a rule
                    var numbers = matchNumbers.Matches(rule.Value);

                    //search matches for a known rule
                    foreach (var num in numbers)
                    {
                        if (knowRules.ContainsKey(num.ToString()))
                        {
                            //replace the number with rule that is only letters
                            Regex replaceRuleNumber = new Regex(@"(?<!\d)" + $"{int.Parse(num.ToString())}" + @"(?!\d)");

                            currentRule = replaceRuleNumber.Replace(currentRule, knowRules[num.ToString()]);
                        }
                    }

                    if (!matchNumbers.IsMatch(currentRule))
                    {
                        if (knowRules.ContainsKey(rule.Key))
                        {
                            knowRules[rule.Key] = "(" + currentRule + ")";
                        }
                        else
                        {
                            knowRules.Add(rule.Key, "(" + currentRule + ")");
                        }
                    }
                    else
                    {
                        if (rulesToUpdate.ContainsKey(rule.Key))
                        {
                            rulesToUpdate[rule.Key] = currentRule;
                        }
                        else
                        {
                            rulesToUpdate.Add(rule.Key, currentRule);
                        }
                    }

                }

                foreach (var item in rulesToUpdate)
                {
                    rules[item.Key] = item.Value;
                }

                if (knowRules.Count == rules.Count)
                {
                    break;
                }
            }



            int count = -1;
            Regex mainRule = new Regex(knowRules["0"].Replace(" ", ""));

            foreach (var msg in messages)
            {
                if (mainRule.Match(msg).Length == msg.Length)
                {
                    count++;
                }
            }


            //8: (42 | 42 (42 | 42 ))+



            return $"matches = {count} \n\n Rule 8 = {knowRules["8"]} \nRule 11 = {knowRules["11"]} \n";
            #endregion

            #region Functions

            #endregion
        }
    }
}