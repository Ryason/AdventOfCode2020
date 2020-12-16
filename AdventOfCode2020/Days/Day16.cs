using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day16
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split(new string[] { "\n", "\n" }, StringSplitOptions.None);

            Dictionary<string, int[]> fields = new Dictionary<string, int[]>();

            foreach (var item in input)
            {
                if (item == "")
                {
                    break;
                }
                string[] field = item.Split(':');
                string[] fieldRages = field[1].Split(new string[] { "-", "or" }, StringSplitOptions.None);
                fields.Add(field[0], new int[] {int.Parse(fieldRages[0]), 
                                                int.Parse(fieldRages[1]),
                                                int.Parse(fieldRages[2]),
                                                int.Parse(fieldRages[3])});
            }

            List<int> yourTicket = new List<int>();

            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] == "your ticket:")
                {
                    foreach (var number in input[i+1].Split(','))
                    {
                        yourTicket.Add(int.Parse(number));
                    }
                    break;
                }
            }

            List<List<int>> nearbyTickets = new List<List<int>>();

            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] == "nearby tickets:")
                {
                    for (int j = i+1; j < input.Count(); j++)
                    {
                        List<int> ticket = new List<int>();

                        foreach (var number in input[j].Split(','))
                        {
                            ticket.Add(int.Parse(number));
                        }
                        nearbyTickets.Add(ticket);
                    }
                    break;
                }
            }

            List<int> errorNumbers = new List<int>();

            foreach (var ticket in nearbyTickets)
            {
                foreach (var number in ticket)
                {
                    int validCount = 0;
                    foreach (var field in fields)
                    {
                        if ((number <= field.Value[1] && number >= field.Value[0]) || (number <= field.Value[3] && number >= field.Value[2]))
                        {
                            validCount++;
                        }
                    }
                    if (validCount == 0)
                    {
                        errorNumbers.Add(number);
                    }
                }
            }

            return errorNumbers.Sum().ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split(new string[] { "\n", "\n" }, StringSplitOptions.None);

            Dictionary<string, int[]> fields = new Dictionary<string, int[]>();

            foreach (var item in input)
            {
                if (item == "")
                {
                    break;
                }
                string[] field = item.Split(':');
                string[] fieldRages = field[1].Split(new string[] { "-", "or" }, StringSplitOptions.None);
                fields.Add(field[0], new int[] {int.Parse(fieldRages[0]),
                                                int.Parse(fieldRages[1]),
                                                int.Parse(fieldRages[2]),
                                                int.Parse(fieldRages[3])});
            }

            List<int> yourTicket = new List<int>();

            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] == "your ticket:")
                {
                    foreach (var number in input[i + 1].Split(','))
                    {
                        yourTicket.Add(int.Parse(number));
                    }
                    break;
                }
            }

            List<List<int>> nearbyTickets = new List<List<int>>();

            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] == "nearby tickets:")
                {
                    for (int j = i + 1; j < input.Count(); j++)
                    {
                        List<int> ticket = new List<int>();

                        foreach (var number in input[j].Split(','))
                        {
                            ticket.Add(int.Parse(number));
                        }
                        nearbyTickets.Add(ticket);
                    }
                    break;
                }
            }

            List<List<int>> errorTickets = new List<List<int>>();

            foreach (var ticket in nearbyTickets)
            {
                foreach (var number in ticket)
                {
                    int validCount = 0;
                    foreach (var field in fields)
                    {
                        if ((number <= field.Value[1] && number >= field.Value[0]) || (number <= field.Value[3] && number >= field.Value[2]))
                        {
                            validCount++;
                        }
                    }
                    if (validCount == 0)
                    {
                        errorTickets.Add(ticket);
                    }
                }
            }

            foreach (var ticket in errorTickets)
            {
                nearbyTickets.Remove(ticket);
            }

            List<string> fieldsFound = new List<string>();

            Dictionary<string, List<int>> matches = new Dictionary<string, List<int>>();

            foreach (var field in fields)
            {
                for (int i = 0; i < nearbyTickets[0].Count(); i++)
                {
                    int count = 0;

                    for (int j = 0; j < nearbyTickets.Count(); j++)
                    {
                        int number = nearbyTickets[j][i];

                        if ((number <= field.Value[1] && number >= field.Value[0]) || (number <= field.Value[3] && number >= field.Value[2]))
                        {
                            count++;
                        }
                    }

                    if (count == nearbyTickets.Count())
                    {
                        fieldsFound.Add($"{field.Key} can be column {i}");

                        if (!matches.ContainsKey(field.Key))
                        {
                            matches.Add(field.Key, new List<int> { i });
                        }
                        else
                        {
                            matches[field.Key].Add(i);
                        }
                    }
                }
            }

            matches = matches.OrderBy(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            for (int i = 0; i < matches.Count; i++)
            {
                for (int j = i+1; j < matches.Count; j++)
                {
                    if (j >= matches.Count)
                    {
                        break;
                    }

                    matches.ElementAt(j).Value.Remove(matches.ElementAt(i).Value[0]);
                }
            }

            long answer = 1;

            foreach (var field in matches)
            {
                if (field.Key.Contains("departure"))
                {
                    answer *= yourTicket[field.Value[0]];
                }
            }

            return answer.ToString();
        }
        #endregion

        #region Functions

        #endregion
    }
}
