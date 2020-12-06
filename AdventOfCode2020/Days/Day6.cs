using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Day6
    {
        //My variable names are so ambiguous for a lot of this, shjould really make them more readable

        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split(new string[] { "\n", "\n" }, StringSplitOptions.None);
            int answerCount = 0;
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

            List<string> outputList = new List<string>();

            for (int i = 0; i < cleanInput.Count(); i++)
            {
                cleanInput[i] = cleanInput[i].Replace(" ", String.Empty);
                outputList.Add("");
                foreach (var letter in cleanInput[i])
                {
                    if (!outputList[outputList.Count-1].Contains(letter))
                    {
                        outputList[outputList.Count-1] = outputList[outputList.Count-1] + letter;
                    }
                }

            }

            foreach (var item in outputList)
            {
                answerCount += item.Length;
            }

            return answerCount.ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split(new string[] { "\n", "\n" }, StringSplitOptions.None);
            int answerCount = 0;
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

            List<string[]> part2List = new List<string[]>();

            for (int i = 0; i < cleanInput.Count(); i++)
            {
                part2List.Add(cleanInput[i].Substring(1).Split(' '));
            }

            List<string> outputList = new List<string>();

            for (int i = 0; i < cleanInput.Count(); i++)
            {
                cleanInput[i] = cleanInput[i].Replace(" ", String.Empty);

                outputList.Add("");

                foreach (var letter in cleanInput[i])
                {
                    if (!outputList[outputList.Count - 1].Contains(letter))
                    {
                        outputList[outputList.Count - 1] = outputList[outputList.Count - 1] + letter;
                    }
                }

            }

            for (int i = 0; i < outputList.Count(); i++)
            {
                string questionsAnswered = outputList[i];

                foreach (var letter in questionsAnswered)
                {
                    int same = 0;

                    foreach (var item in part2List[i])
                    {
                        if (item.Contains(letter))
                        {
                            same++;
                        }
                    }

                    if (same == part2List[i].Length)
                    {
                        answerCount++;
                    }
                }
            }

            return answerCount.ToString();
        }
        #endregion

        #region Functions

        #endregion
    }
}
