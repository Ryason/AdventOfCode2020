using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day13
    {
        #region Part One
        public static string PartOneOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');
            int arrivalTime = int.Parse(input[0]);
            string[] busString = input[1].Split(',');
            List<int> busList = new List<int>();

            foreach (var str in busString)
            {
                if (str != "x")
                {
                    busList.Add(int.Parse(str));
                }
            }

            Dictionary<int, int> nextBusTimes= new Dictionary<int, int>();

            foreach (int bus in busList)
            {
                int time = arrivalTime;
                nextBusTimes.Add(bus, 0);

                while (time % bus != 0)
                {
                    time++;
                }

                nextBusTimes[bus] = time;
            }

            int departureTime = nextBusTimes.Values.Min();
            int departureBus = nextBusTimes.FirstOrDefault(x => x.Value == departureTime).Key;
            int answer = departureBus * (departureTime - arrivalTime);

            return $"Take the number {departureBus} bus at {departureTime}\nBusID * WaitTime = {answer}";
        }
        #endregion

        #region Part Two
        public static string PartTwoOutput(string rawInput)
        {
            string[] input = rawInput.Split('\n');
            string[] busString = input[1].Split(',');
            List<int> busList = new List<int>();
            List<int> busOffset = new List<int>();

            for (int i = 0; i < busString.Count(); i++)
            {
                if (busString[i] != "x")
                {
                    busList.Add(int.Parse(busString[i]));
                    busOffset.Add(i);
                }
            }
            
            long startTime = busList[0];
            long increment = busList[0];
            bool searching = true;

            while (searching)
            {
                long time = startTime;
                int count = 0;

                for (int i = 1; i < busList.Count; i++)
                {
                    if ((time + busOffset[i]) % busList[i] == 0)
                    { 
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count == busList.Count - 1)
                {
                    searching = false;
                }
                else
                {
                    searching = true;

                    //increment always equals the multiple of the values that have been found to line up
                    increment = 1;

                    for (int i = 0; i < count+1; i++)
                    {
                        increment *= busList[i];
                    }

                    startTime += increment;
                }
            }

            return $"{startTime}";
        }
        #endregion

        #region Functions

        #endregion
    }
}
