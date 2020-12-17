using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day17
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            //all 26 positions around a cube at (0x,0y,0z)
            List<int[]> checkPos = new List<int[]>() 
            {
                new int[]{1,0,0},
                new int[]{1,1,0},
                new int[]{0,1,0},
                new int[]{-1,1,0},
                new int[]{-1,0,0},
                new int[]{-1,-1,0},
                new int[]{0,-1,0},
                new int[]{1,-1,0},
                new int[]{1,0,1},
                new int[]{1,1,1},
                new int[]{0,1,1},
                new int[]{-1,1,1},
                new int[]{-1,0,1},
                new int[]{-1,-1,1},
                new int[]{0,-1,1},
                new int[]{1,-1,1},
                new int[]{1,0,-1},
                new int[]{1,1,-1},
                new int[]{0,1,-1},
                new int[]{-1,1,-1},
                new int[]{-1,0,-1},
                new int[]{-1,-1,-1},
                new int[]{0,-1,-1},
                new int[]{1,-1,-1},
                new int[]{0,0,1},
                new int[]{0,0,-1}
            };

            List<int[]> onPositions = new List<int[]>();
            List<int[]> offPositions = new List<int[]>();

            for (int x = 0; x < input.Count(); x++)
            {
                int z = 0;
                for (int y = 0; y < input[0].Count(); y++)
                {
                    if (input[x][y] == '#')
                    {
                        onPositions.Add(new int[] {x,y,z});
                    }
                    else
                    {
                        offPositions.Add(new int[] {x,y,z});
                    }
                }
            }

            int count = 0;

            List<int[]> offToRemove = new List<int[]>();
            List<int[]> offToAdd = new List<int[]>();
            List<int[]> onToRemove = new List<int[]>();
            List<int[]> onToAdd = new List<int[]>();

            while (count < 6)
            {
                //add off positions around every on position
                foreach (var item in onPositions)
                {
                    foreach (var pos in checkPos)
                    {
                        if (!offPositions.Any(p => p.SequenceEqual(new int[] { item[0] + pos[0], item[1] + pos[1], item[2] + pos[2] })) && !onPositions.Any(m => m.SequenceEqual(new int[] { item[0] + pos[0], item[1] + pos[1], item[2] + pos[2] })))
                        {
                            offPositions.Add(new int[] { item[0] + pos[0], item[1] + pos[1], item[2] + pos[2] });
                        }
                    }
                }

                //for each on position, determine if it needs to turn off, or stay on.
                foreach (var pos in onPositions)
                {
                    int alive = 0;
                    foreach (var chk in checkPos)
                    {
                        int[] check = new int[] { pos[0] + chk[0], pos[1] + chk[1], pos[2] + chk[2] };
                        if (onPositions.Any(p => p.SequenceEqual(check)))
                        {
                            alive++;
                        }

                    }

                    //if neighbour count does not = 2 or 3, it turns off.
                    if (alive >= 2 && alive <= 3)
                    {

                    }
                    else
                    {
                        int[] check = new int[] { pos[0], pos[1], pos[2] };
                        if (!onToRemove.Any(p => p.SequenceEqual(check)))
                        {
                            onToRemove.Add(pos);
                        }
                        
                        if (!offToAdd.Any(p => p.SequenceEqual(check)))
                        {
                            offToAdd.Remove(pos);
                        }
                    }
                }

                foreach (var pos in offPositions)
                {
                    int alive = 0;
                    foreach (var chk in checkPos)
                    {
                        int[] check = new int[] { pos[0] + chk[0], pos[1] + chk[1], pos[2] + chk[2] };
                        if (onPositions.Any(p => p.SequenceEqual(check)))
                        {
                            alive++;
                        }
                    }
                    //if off and has 3 neighbours, it turns on.
                    if (alive == 3)
                    {
                        int[] check = new int[] { pos[0], pos[1], pos[2]};
                        if (!onToAdd.Any(p => p.SequenceEqual(check)))
                        {
                            onToAdd.Add(pos);
                        }

                        if (!offToRemove.Any(p => p.SequenceEqual(check)))
                        {
                            offToRemove.Remove(pos);
                        }
                    }
                }

                //if it turns off, remove it from the on positions list,
                //and add it to the off positions list.
                if (onToRemove.Count() > 0)
                {
                    for (int i = 0; i < onToRemove.Count; i++)
                    {
                        List<int[]> temp = new List<int[]>();
                        foreach (var onPos in onPositions)
                        {
                            if (onToRemove[i].SequenceEqual(onPos))
                            {
                                temp.Add(onPos);
                            }
                        }
                        foreach (var item in temp)
                        {
                            onPositions.Remove(item);
                        }
                    }
                }

                if (offToRemove.Count() > 0)
                {
                    for (int i = 0; i < offToRemove.Count; i++)
                    {
                        List<int[]> temp = new List<int[]>();
                        foreach (var offPos in offPositions)
                        {
                            if (offToRemove[i].SequenceEqual(offPos))
                            {
                                temp.Add(offPos);
                            }
                        }
                        foreach (var item in temp)
                        {
                            offPositions.Remove(item);
                        }
                    }
                }
                
                foreach (var item in offToAdd)
                {
                    if (!offPositions.Any(p => p.SequenceEqual(item)))
                    {
                        offPositions.Add(item);
                    }
                }
                
                foreach (var item in onToAdd)
                {
                    if (!onPositions.Any(p => p.SequenceEqual(item)))
                    {
                        onPositions.Add(item);
                    }
                    
                }

                onToAdd.Clear();
                offToAdd.Clear();
                onToRemove.Clear();
                offToRemove.Clear();

                count++;
                Console.WriteLine($"cycle {count}: {onPositions.Count()}");
            }
            
            return $"{onPositions.Count()}";
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');

            //all 26 positions around a cube at (0x,0y,0z)
            List<int[]> checkPos = new List<int[]>()
            {
                new int[]{1,0,0,0},
                new int[]{1,1,0,0},
                new int[]{0,1,0,0},
                new int[]{-1,1,0,0},
                new int[]{-1,0,0,0},
                new int[]{-1,-1,0,0},
                new int[]{0,-1,0,0},
                new int[]{1,-1,0,0},
                new int[]{1,0,1,0},
                new int[]{1,1,1,0},
                new int[]{0,1,1,0},
                new int[]{-1,1,1,0},
                new int[]{-1,0,1,0},
                new int[]{-1,-1,1,0},
                new int[]{0,-1,1,0},
                new int[]{1,-1,1,0},
                new int[]{1,0,-1,0},
                new int[]{1,1,-1,0},
                new int[]{0,1,-1,0},
                new int[]{-1,1,-1,0},
                new int[]{-1,0,-1,0},
                new int[]{-1,-1,-1,0},
                new int[]{0,-1,-1,0},
                new int[]{1,-1,-1,0},
                new int[]{0,0,1,0},
                new int[]{0,0,-1,0},
                new int[]{1,0,0,-1},
                new int[]{1,1,0,-1},
                new int[]{0,1,0,-1},
                new int[]{-1,1,0,-1},
                new int[]{-1,0,0,-1},
                new int[]{-1,-1,0,-1},
                new int[]{0,-1,0,-1},
                new int[]{1,-1,0,-1},
                new int[]{1,0,1,-1},
                new int[]{1,1,1,-1},
                new int[]{0,1,1,-1},
                new int[]{-1,1,1,-1},
                new int[]{-1,0,1,-1},
                new int[]{-1,-1,1,-1},
                new int[]{0,-1,1,-1},
                new int[]{1,-1,1,-1},
                new int[]{1,0,-1,-1},
                new int[]{1,1,-1,-1},
                new int[]{0,1,-1,-1},
                new int[]{-1,1,-1,-1},
                new int[]{-1,0,-1,-1},
                new int[]{-1,-1,-1,-1},
                new int[]{0,-1,-1,-1},
                new int[]{1,-1,-1,-1},
                new int[]{0,0,1,-1},
                new int[]{0,0,-1,-1},
                new int[]{1,0,0,1},
                new int[]{1,1,0,1},
                new int[]{0,1,0,1},
                new int[]{-1,1,0,1},
                new int[]{-1,0,0,1},
                new int[]{-1,-1,0,1},
                new int[]{0,-1,0,1},
                new int[]{1,-1,0,1},
                new int[]{1,0,1,1},
                new int[]{1,1,1,1},
                new int[]{0,1,1,1},
                new int[]{-1,1,1,1},
                new int[]{-1,0,1,1},
                new int[]{-1,-1,1,1},
                new int[]{0,-1,1,1},
                new int[]{1,-1,1,1},
                new int[]{1,0,-1,1},
                new int[]{1,1,-1,1},
                new int[]{0,1,-1,1},
                new int[]{-1,1,-1,1},
                new int[]{-1,0,-1,1},
                new int[]{-1,-1,-1,1},
                new int[]{0,-1,-1,1},
                new int[]{1,-1,-1,1},
                new int[]{0,0,1,1},
                new int[]{0,0,-1,1},
                new int[]{0,0,0,1},
                new int[]{0,0,0,-1},


            };

            List<int[]> onPositions = new List<int[]>();
            List<int[]> offPositions = new List<int[]>();

            for (int x = 0; x < input.Count(); x++)
            {
                int z = 0;
                int w = 0;
                for (int y = 0; y < input[0].Count(); y++)
                {
                    if (input[x][y] == '#')
                    {
                        onPositions.Add(new int[] { x, y, z, w });
                    }
                    else
                    {
                        offPositions.Add(new int[] { x, y, z, w });
                    }
                }
            }

            int count = 0;

            List<int[]> offToRemove = new List<int[]>();
            List<int[]> offToAdd = new List<int[]>();
            List<int[]> onToRemove = new List<int[]>();
            List<int[]> onToAdd = new List<int[]>();

            while (count < 6)
            {
                //add off positions around every on position
                foreach (var item in onPositions)
                {
                    foreach (var pos in checkPos)
                    {
                        if (!offPositions.Any(p => p.SequenceEqual(new int[] { item[0] + pos[0], item[1] + pos[1], item[2] + pos[2], item[3] + pos[3] })) && !onPositions.Any(m => m.SequenceEqual(new int[] { item[0] + pos[0], item[1] + pos[1], item[2] + pos[2], item[3] + pos[3] })))
                        {
                            offPositions.Add(new int[] { item[0] + pos[0], item[1] + pos[1], item[2] + pos[2], item[3] + pos[3] });
                        }
                    }
                }

                //for each on position, determine if it needs to turn off, or stay on.
                foreach (var pos in onPositions)
                {
                    int alive = 0;
                    foreach (var chk in checkPos)
                    {
                        int[] check = new int[] { pos[0] + chk[0], pos[1] + chk[1], pos[2] + chk[2], pos[3] + chk[3] };
                        if (onPositions.Any(p => p.SequenceEqual(check)))
                        {
                            alive++;
                        }
                        if (alive > 3)
                        {
                            break;
                        }

                    }

                    //if neighbour count does not = 2 or 3, it turns off.
                    if (alive >= 2 && alive <= 3)
                    {

                    }
                    else
                    {
                        int[] check = new int[] { pos[0], pos[1], pos[2], pos[3] };
                        if (!onToRemove.Any(p => p.SequenceEqual(check)))
                        {
                            onToRemove.Add(pos);
                        }

                        if (!offToAdd.Any(p => p.SequenceEqual(check)))
                        {
                            offToAdd.Remove(pos);
                        }
                    }
                }

                foreach (var pos in offPositions)
                {
                    int alive = 0;
                    foreach (var chk in checkPos)
                    {
                        int[] check = new int[] { pos[0] + chk[0], pos[1] + chk[1], pos[2] + chk[2], pos[3] + chk[3] };
                        if (onPositions.Any(p => p.SequenceEqual(check)))
                        {
                            alive++;
                        }
                        if (alive > 3)
                        {
                            break;
                        }
                    }
                    //if off and has 3 neighbours, it turns on.
                    if (alive == 3)
                    {
                        int[] check = new int[] { pos[0], pos[1], pos[2], pos[3] };
                        if (!onToAdd.Any(p => p.SequenceEqual(check)))
                        {
                            onToAdd.Add(pos);
                        }

                        if (!offToRemove.Any(p => p.SequenceEqual(check)))
                        {
                            offToRemove.Remove(pos);
                        }
                    }
                }

                //if it turns off, remove it from the on positions list,
                //and add it to the off positions list.
                if (onToRemove.Count() > 0)
                {
                    for (int i = 0; i < onToRemove.Count; i++)
                    {
                        List<int[]> temp = new List<int[]>();
                        foreach (var onPos in onPositions)
                        {
                            if (onToRemove[i].SequenceEqual(onPos))
                            {
                                temp.Add(onPos);
                            }
                        }
                        foreach (var item in temp)
                        {
                            onPositions.Remove(item);
                        }
                    }
                }

                if (offToRemove.Count() > 0)
                {
                    for (int i = 0; i < offToRemove.Count; i++)
                    {
                        List<int[]> temp = new List<int[]>();
                        foreach (var offPos in offPositions)
                        {
                            if (offToRemove[i].SequenceEqual(offPos))
                            {
                                temp.Add(offPos);
                            }
                        }
                        foreach (var item in temp)
                        {
                            offPositions.Remove(item);
                        }
                    }
                }

                foreach (var item in offToAdd)
                {
                    if (!offPositions.Any(p => p.SequenceEqual(item)))
                    {
                        offPositions.Add(item);
                    }
                }

                foreach (var item in onToAdd)
                {
                    if (!onPositions.Any(p => p.SequenceEqual(item)))
                    {
                        onPositions.Add(item);
                    }

                }

                onToAdd.Clear();
                offToAdd.Clear();
                onToRemove.Clear();
                offToRemove.Clear();

                count++;
                Console.WriteLine($"cycle {count}: {onPositions.Count()}");
            }

            return $"{onPositions.Count()}";
        }
        #endregion

        #region Functions

        #endregion
    }
}