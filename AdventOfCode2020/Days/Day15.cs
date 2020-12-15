using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day15
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split(',');

            Dictionary<long, long[]> turnTracker = new Dictionary<long, long[]>();

            List<long> turns = new List<long>();

            foreach (var number in input)
            {
                turns.Add(int.Parse(number.ToString()));
                long currentTurn = turns[turns.Count - 1];

                turnTracker.Add(currentTurn, new long[] { 9999999999, (turns.Count - 1) });
            }

            while (turns.Count < 2020)
            {
                //calculate the next turn >> add it to turns list

                //if previous number spoken has not been spoken before
                //current number spoken on this turn = 0
                if (turnTracker[turns.Last()][0] == 9999999999)
                {
                    turns.Add(0);
                    if (!turnTracker.ContainsKey(0))
                    {
                        turnTracker.Add(0, new long[] { 9999999999, turns.Count-1});
                    }
                    else
                    {
                        turnTracker[0] = new long[] { turnTracker[0][1], turns.Count - 1 };
                    } 
                }
                else
                {
                    //if number has been spoken before
                    //current turn = how many turns apart the number is from when it was previously spoken

                    //go into dictionary >> update last 2 spoken positions >> calculate difference
                    long turnAnswer = turnTracker[turns[turns.Count - 1]][1] - turnTracker[turns[turns.Count - 1]][0];
                    turns.Add(turnAnswer);

                    if (!turnTracker.ContainsKey(turnAnswer))
                    {
                        turnTracker.Add(turnAnswer, new long[] { 9999999999, turns.Count - 1 });
                    }
                    else
                    {
                        turnTracker[turnAnswer] = new long[] { turnTracker[turnAnswer][1], turns.Count - 1 };
                    }
                }
            }

            return turns.Last().ToString();
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split(',');

            Dictionary<long, long[]> turnTracker = new Dictionary<long, long[]>();

            List<long> turns = new List<long>();

            foreach (var number in input)
            {
                turns.Add(int.Parse(number.ToString()));
                long currentTurn = turns[turns.Count - 1];

                turnTracker.Add(currentTurn, new long[] { 9999999999, (turns.Count - 1) });
            }

            while (turns.Count < 30000000)
            {
                //calculate the next turn >> add it to turns list

                //if previous number spoken has not been spoken before
                //current number spoken on this turn = 0
                if (turnTracker[turns.Last()][0] == 9999999999)
                {
                    turns.Add(0);
                    if (!turnTracker.ContainsKey(0))
                    {
                        turnTracker.Add(0, new long[] { 9999999999, turns.Count - 1 });
                    }
                    else
                    {
                        turnTracker[0] = new long[] { turnTracker[0][1], turns.Count - 1 };
                    }
                }
                else
                {
                    //if number has been spoken before
                    //current turn = how many turns apart the number is from when it was previously spoken

                    //go into dictionary >> update last 2 spoken positions >> calculate difference
                    long turnAnswer = turnTracker[turns[turns.Count - 1]][1] - turnTracker[turns[turns.Count - 1]][0];
                    turns.Add(turnAnswer);

                    if (!turnTracker.ContainsKey(turnAnswer))
                    {
                        turnTracker.Add(turnAnswer, new long[] { 9999999999, turns.Count - 1 });
                    }
                    else
                    {
                        turnTracker[turnAnswer] = new long[] { turnTracker[turnAnswer][1], turns.Count - 1 };
                    }
                }
            }

            return turns.Last().ToString();
        }
        #endregion

        #region Functions

        #endregion
    }
}