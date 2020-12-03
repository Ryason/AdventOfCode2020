using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    static class Day3
    {
        public static string PartOneOutput(string input)
        {
            string[] map = input.Split('\n');

            int mapWidth = map[0].Length-1;
            int mapHeight = map.Length-1;
            int rowDownCount = 0;
            bool traveling = true;

            int xPos = 0;
            int yPos = 0;
            int treeCount = 0;



            while (traveling)
            {
                if (map[yPos][xPos].ToString() == "#")
                {
                    treeCount++;
                }

                xPos += 1;
                yPos += 2;
                rowDownCount += 2;
                if (xPos>mapWidth)
                {
                    xPos = xPos - mapWidth-1;
                }

                if (yPos > mapHeight)
                {
                    yPos = yPos - mapHeight-1;
                }

                if (rowDownCount>mapHeight)
                {
                    traveling = false;
                }
                


            }


            return mapWidth.ToString() + " " + mapHeight.ToString() + "TreeCount = " + treeCount.ToString();
        }

        public static string PartTwoOutput(string input)
        {
            return input;
        }
    }
}
