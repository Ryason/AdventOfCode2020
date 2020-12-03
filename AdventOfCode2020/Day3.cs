using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day3
    {
        #region Part One
        public static string PartOneOutput(string input)
        {
            return CountTrees(input, 3, 1);
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string input)
        {
            List<int[]> slopes = new List<int[]>()
            {
                new int[]{ 1, 1 },
                new int[]{ 3, 1 },
                new int[]{ 5, 1 },
                new int[]{ 7, 1 },
                new int[]{ 1, 2 },
            };

            string result = "";

            //list of tree counts that will be multiplied together
            List<int> toMultiply = new List<int>();

            foreach (var item in slopes)
            {
                string tempResult = CountTrees(input, item[0], item[1]);
                int treesOnSlope = int.Parse(tempResult.Split('=')[1].ToString());
                toMultiply.Add(treesOnSlope);
                result = result + "\n" + tempResult;
            }

            //long int used to store multiplied tree count, as 64bit is needed
            long multiplyTrees = 1;

            for (int i = 0; i < toMultiply.Count(); i++)
            {
                multiplyTrees *= toMultiply[i];
            }

            return string.Format($"{result} \nTree Count Multiplied = {multiplyTrees}");
        }
        #endregion

        #region Count The Number Of Trees On A Slope
        public static string CountTrees(string input, int x, int y)
        {
            string[] map = input.Split('\n');

            int mapWidth = map[0].Length - 1;
            int mapHeight = map.Length - 1;
            int rowDownCount = 0;
            int xPos = 0;
            int yPos = 0;
            int xIncrement = x;
            int yIncrement = y;
            int treeCount = 0;

            bool traveling = true;

            while (traveling)
            {
                if (map[yPos][xPos].ToString() == "#")
                {
                    treeCount++;
                }

                xPos += xIncrement;
                yPos += yIncrement;
                rowDownCount += yIncrement;

                if (xPos > mapWidth)
                {
                    xPos = xPos - mapWidth - 1;
                }

                if (yPos > mapHeight)
                {
                    yPos = yPos - mapHeight - 1;
                }

                if (rowDownCount > mapHeight)
                {
                    traveling = false;
                }
            }

            return string.Format($"X: {x}, Y: {y} -> TreeCount = {treeCount}");
        }
        #endregion
    }
}
