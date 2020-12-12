using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day11
    {
        //I now have a dislike of lists
        //Why is it so hard to not have a copy of a list reference the original!!!

        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string[] input = rawInput.Split('\n');
            List<string[]> seatPlan = new List<string[]>();
            List<string> row = new List<string>();

            foreach (var str in input)
            {
                foreach (var character in str)
                {
                    row.Add(character.ToString());
                }
                seatPlan.Add(row.ToArray());
                row.Clear();
            }

            List<string[]> nextSeatPlan = new List<string[]>();
            int count = 0;
            bool simulate = true;

            while (simulate)
            {
                nextSeatPlan = NextStep(seatPlan);
                count++;
                bool match = false;

                for (int i = 0; i < seatPlan.Count; i++)
                {
                    for (int j = 0; j < seatPlan[0].Length; j++)
                    {
                        if (seatPlan[i][j].ToString() != nextSeatPlan[i][j].ToString())
                        {
                            match = false;
                            break;
                        }
                        else
                        {
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        break;
                    }
                    else
                    {
                        match = true;
                    }
                }
                if (match)
                {
                    simulate = false;
                    Console.WriteLine($"{count} steps until balanced state");
                    break;
                }
                else
                {
                    seatPlan.Clear();
                    seatPlan = nextSeatPlan;
                }
            }

            int steps = count;
            count = 0;

            foreach (var line in nextSeatPlan)
            {
                foreach (var str in line)
                {
                    if (str == "#")
                    {
                        count++;
                    }
                }
            }
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            return $"{steps} steps until balanced state\n{count} seats occupied";
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string[] input = rawInput.Split('\n');
            List<string[]> seatPlan = new List<string[]>();
            List<string> row = new List<string>();

            foreach (var str in input)
            {
                foreach (var character in str)
                {
                    row.Add(character.ToString());
                }
                seatPlan.Add(row.ToArray());
                row.Clear();
            }

            List<string[]> nextSeatPlan = new List<string[]>();
            int count = 0;
            bool simulate = true;

            while (simulate)
            {
                nextSeatPlan = NextStepPartTwo(seatPlan);
                count++;
                bool match = false;

                for (int i = 0; i < seatPlan.Count; i++)
                {
                    for (int j = 0; j < seatPlan[0].Length; j++)
                    {
                        if (seatPlan[i][j].ToString() != nextSeatPlan[i][j].ToString())
                        {
                            match = false;
                            break;
                        }
                        else
                        {
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        break;
                    }
                    else
                    {
                        match = true;
                    }
                }
                if (match)
                {
                    simulate = false;
                    Console.WriteLine($"{count} steps until balanced state");
                    break;
                }
                else
                {
                    seatPlan.Clear();
                    seatPlan = nextSeatPlan;
                }
            }

            int steps = count;
            count = 0;

            foreach (var line in nextSeatPlan)
            {
                foreach (var str in line)
                {
                    if (str == "#")
                    {
                        count++;
                    }
                }
            }
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            return $"{steps} steps until balanced state\n{count} seats occupied";
        }
        #endregion

        #region Functions
        public static List<string[]> NextStep(List<string[]> seatPlan)
        {
            List<string[]> nextSeatPlan = new List<string[]>();

            for (int i = 0; i < seatPlan.Count; i++)
            {
                List<string> str = new List<string>();

                for (int j = 0; j < seatPlan[0].Length; j++)
                {
                    str.Add("");
                }

                nextSeatPlan.Add(str.ToArray());
                str.Clear();
            }
            
            for (int i = 0; i < seatPlan.Count; i++)
            {
                for (int j = 0; j < seatPlan[0].Length; j++)
                {
                    List<int[]> indxChk = new List<int[]>()
                            {
                                new int[]{i-1,j-1},
                                new int[]{i-1,j},
                                new int[]{i-1,j+1},
                                new int[]{i,j-1},
                                new int[]{i,j+1},
                                new int[]{i+1,j-1},
                                new int[]{i+1,j},
                                new int[]{i+1,j+1}
                            };

                    int count = 0;

                    switch (seatPlan[i][j])
                    {
                        case ".":
                            nextSeatPlan[i][j] = (".");
                            break;
                        case "L":
                            foreach (var indx in indxChk)
                            {
                                if (indx[0] > -1 && indx[0] < seatPlan.Count)
                                {
                                    if (indx[1] > -1 && indx[1] < seatPlan[0].Length)
                                    {
                                        if (seatPlan[indx[0]][indx[1]] == "#")
                                        {
                                            count++;
                                        }
                                    }
                                }
                            }
                            if (count == 0)
                            {
                                nextSeatPlan[i][j] = ("#");
                            }
                            else
                            {
                                nextSeatPlan[i][j] = ("L");
                            }
                            break;
                        case "#":
                            foreach (var indx in indxChk)
                            {
                                if (indx[0] > -1 && indx[0] < seatPlan.Count)
                                {
                                    if (indx[1] > -1 && indx[1] < seatPlan[0].Length)
                                    {
                                        if (seatPlan[indx[0]][indx[1]] == "#")
                                        {
                                            count++;
                                        }
                                    }
                                }
                            }
                            if (count < 4)
                            {
                                nextSeatPlan[i][j] = ("#");
                            }
                            else
                            {
                                nextSeatPlan[i][j] = ("L");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return nextSeatPlan.ToList();
        }

        public static List<string[]> NextStepPartTwo(List<string[]> seatPlan)
        {
            List<string[]> nextSeatPlan = new List<string[]>();

            for (int i = 0; i < seatPlan.Count; i++)
            {
                List<string> str = new List<string>();

                for (int j = 0; j < seatPlan[0].Length; j++)
                {
                    str.Add("");
                }

                nextSeatPlan.Add(str.ToArray());
                str.Clear();
            }

            for (int i = 0; i < seatPlan.Count; i++)
            {
                for (int j = 0; j < seatPlan[0].Length; j++)
                {
                    List<int[]> indxChk = new List<int[]>()
                            {
                                new int[]{-1,-1},
                                new int[]{-1,0},
                                new int[]{-1,+1},
                                new int[]{0,-1},
                                new int[]{0,1},
                                new int[]{1,-1},
                                new int[]{1,0},
                                new int[]{1,1}
                            };

                    int count = 0;

                    switch (seatPlan[i][j])
                    {
                        case ".":
                            nextSeatPlan[i][j] = (".");
                            break;
                        case "L":
                            foreach (var indx in indxChk)
                            {
                                int m = 1;
                                bool looking = true;
                                while (looking)
                                {
                                    if ((i + indx[0] * m) > -1 && (i + indx[0] * m) < seatPlan.Count)
                                    {
                                        if (((j + indx[1] * m) > -1 && (j + indx[1] * m) < seatPlan[0].Length))
                                        {
                                            if (seatPlan[(i + indx[0] * m)][(j + indx[1] * m)] == "#")
                                            {
                                                count++;
                                                looking = false;
                                            }
                                            if (seatPlan[(i + indx[0] * m)][(j + indx[1] * m)] == "L")
                                            {
                                                looking = false;

                                            }
                                            else
                                            {
                                                m++;
                                            }
                                        }
                                        else
                                        {
                                            looking = false;
                                        }
                                    }
                                    else
                                    {
                                        looking = false;
                                    }
                                }
                            }
                            if (count == 0)
                            {
                                nextSeatPlan[i][j] = ("#");
                            }
                            else
                            {
                                nextSeatPlan[i][j] = ("L");
                            }
                            break;
                        case "#":
                            foreach (var indx in indxChk)
                            {
                                int m = 1;
                                bool looking = true;
                                while (looking)
                                {
                                    if ((i + indx[0] * m) > -1 && (i + indx[0] * m) < seatPlan.Count)
                                    {
                                        if (((j + indx[1] * m) > -1 && (j + indx[1] * m) < seatPlan[0].Length))
                                        {
                                            if (seatPlan[(i + indx[0] * m)][(j + indx[1] * m)] == "#")
                                            {
                                                count++;
                                                looking = false;
                                            }
                                            if (seatPlan[(i + indx[0] * m)][(j + indx[1] * m)] == "L")
                                            {
                                                looking = false;

                                            }
                                            else
                                            {
                                                m++;
                                            }
                                        }
                                        else
                                        {
                                            looking = false;
                                        }
                                    }
                                    else
                                    {
                                        looking = false;
                                    }
                                }

                            }
                            if (count < 5)
                            {
                                nextSeatPlan[i][j] = ("#");
                            }
                            else
                            {
                                nextSeatPlan[i][j] = ("L");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return nextSeatPlan.ToList();
        }
        #endregion
    }
}