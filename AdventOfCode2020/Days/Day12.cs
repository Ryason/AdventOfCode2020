using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day12
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            int[] position = new int[] { 0, 0 };

            int[] facing = new int[] { 1, 0 };

            int shipAngle = 90;

            foreach (string move in input)
            {
                int angle = int.Parse(move.Substring(1));
                

                if (facing == new int[] { 0, 1 })
                {
                    shipAngle = 0;
                }
                if (facing == new int[] { 0, -1 })
                {
                    shipAngle = 180;
                }
                if (facing == new int[] { 1, 0 })
                {
                    shipAngle = 90;
                }
                if (facing == new int[] { -1, 0 })
                {
                    shipAngle = 270;
                }

                switch (move.Substring(0,1))
                {
                    case "N":
                        position[1] += int.Parse(move.Substring(1));
                        break;

                    case "S":
                        position[1] -= int.Parse(move.Substring(1));
                        break;

                    case "E":
                        position[0] += int.Parse(move.Substring(1));
                        break;

                    case "W":
                        position[0] -= int.Parse(move.Substring(1));
                        break;

                    case "F":
                        position[0] += facing[0] * int.Parse(move.Substring(1));
                        position[1] += facing[1] * int.Parse(move.Substring(1));
                        break;

                    case "L":
                        angle = int.Parse(move.Substring(1));

                        shipAngle -= angle;

                        if (shipAngle < 0)
                        {
                            shipAngle += 360;
                        }

                        facing = ReturnShipFacing(shipAngle);

                        break;

                    case "R":
                        angle = int.Parse(move.Substring(1));

                        shipAngle += angle;

                        if (shipAngle > 360)
                        {
                            shipAngle -= 360;
                        }

                        facing = ReturnShipFacing(shipAngle);
                        break;

                    default:
                        break;
                }
                Console.WriteLine($"Position: [X: {position[0]}] [Y: {position[1]}]");
            }

            return $"Position: [X: {position[0]}] [Y: {position[1]}] \n Distance = {Math.Abs(position[0]) + Math.Abs(position[1])}";
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            string[] input = rawInput.Split('\n');

            int[] waypoint = new int[] { 10, 1 };
            int[] position = new int[] { 0, 0 };

            foreach (string move in input)
            {

                switch (move.Substring(0, 1))
                {
                    case "N":
                        waypoint[1] += int.Parse(move.Substring(1));
                        break;
                    case "S":
                        waypoint[1] -= int.Parse(move.Substring(1));
                        break;
                    case "E":
                        waypoint[0] += int.Parse(move.Substring(1));
                        break;
                    case "W":
                        waypoint[0] -= int.Parse(move.Substring(1));
                        break;
                    case "F":
                        position[0] += waypoint[0] * int.Parse(move.Substring(1));
                        position[1] += waypoint[1] * int.Parse(move.Substring(1));
                        break;
                    case "L":
                        //rotate waypoint c-clockwise around ship
                        int numOf90LTurns = int.Parse(move.Substring(1)) / 90;
                        for (int i = 0; i < numOf90LTurns; i++)
                        {
                            waypoint = new int[] {-waypoint[1], waypoint[0]};
                        }

                        break;
                    case "R":
                        //rotate waypoint clockwise around ship
                        int numOf90RTurns = int.Parse(move.Substring(1)) / 90;
                        for (int i = 0; i < numOf90RTurns; i++)
                        {
                            waypoint = new int[] { waypoint[1], -waypoint[0] };
                        }
                        break;
                    default:
                        break;
                }
            }
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            return $"Position: [X: {position[0]}] [Y: {position[1]}] \n Distance = {Math.Abs(position[0]) + Math.Abs(position[1])}";
        }
        #endregion

        #region Functions
        public static int[] ReturnShipFacing(int angle)
        {
            int[] facing = { 0, 0 };
            if (angle == 90)
            {
                facing = new int[] { 1, 0 };
            }
            if (angle == 180)
            {
                facing = new int[] { 0, -1 };
            }
            if (angle == 270)
            {
                facing = new int[] { -1, 0 };
            }
            if (angle == 0 || angle == 360)
            {
                facing = new int[] { 0, 1 };
            }
            return facing;
        }
        #endregion
    }
}