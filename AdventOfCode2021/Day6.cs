using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2021
{
    public class Day6
    {
        public Day6()
        {
            state = StateGenerator();
        }

        private const int three = 3;
        private const int newFishStartingValue = 8;
        private const int defaultValue = 6;
        private List<double> state = new List<double>();


        private string input = "1,1,3,5,1,3,2,1,5,3,1,4,4,4,1,1,1,3,1,4,3,1,2,2,2,4,1,1,5,5,4,3,1,1,1,1,1,1,3,4,1,2,2,5,1,3,5,1,3,2,5,2,2,4,1,1,1,4,3,3,3,1,1,1,1,3,1,3,3,4,4,1,1,5,4,2,2,5,4,5,2,5,1,4,2,1,5,5,5,4,3,1,1,4,1,1,3,1,3,4,1,1,2,4,2,1,1,2,3,1,1,1,4,1,3,5,5,5,5,1,2,2,1,3,1,2,5,1,4,4,5,5,4,1,1,3,3,1,5,1,1,4,1,3,3,2,4,2,4,1,5,5,1,2,5,1,5,4,3,1,1,1,5,4,1,1,4,1,2,3,1,3,5,1,1,1,2,4,5,5,5,4,1,4,1,4,1,1,1,1,1,5,2,1,1,1,1,2,3,1,4,5,5,2,4,1,5,1,3,1,4,1,1,1,4,2,3,2,3,1,5,2,1,1,4,2,1,1,5,1,4,1,1,5,5,4,3,5,1,4,3,4,4,5,1,1,1,2,1,1,2,1,1,3,2,4,5,3,5,1,2,2,2,5,1,2,5,3,5,1,1,4,5,2,1,4,1,5,2,1,1,2,5,4,1,3,5,3,1,1,3,1,4,4,2,2,4,3,1,1";
        //private string input = "3,4,3,1,2";

        private List<double> StateGenerator()
        {
            var temp = input.Split(',');
            List<double> result = new List<double>();
            foreach (var item in temp)
            {
                result.Add(Convert.ToDouble(item));
            }
            return result;
        }
        
        public double part2()
        {
            double[] fishdata = new double[9];

            foreach (int item in state)
            {
                fishdata[item]++;
            }

            int days = 256;

            for (int i = 0; i < days; i++)
            {
                double newFish = fishdata[0];
                fishdata[0] = fishdata[1];
                fishdata[1] = fishdata[2];
                fishdata[2] = fishdata[3];
                fishdata[3] = fishdata[4];
                fishdata[4] = fishdata[5];
                fishdata[5] = fishdata[6];
                fishdata[6] = fishdata[7];
                fishdata[7] = fishdata[8];
                fishdata[8] = newFish;
                fishdata[6] += newFish;

            }

            double counter = 0;

            foreach (var item in fishdata)
            {
                counter += item;
            }
            return counter;
            
        }



        public int threeNature(int days)
        {
            // intitial: 3,4,3,1,2
            
            
            for (int i = 0; i < days; i++)
            {
                Console.WriteLine($"Nap: {i}");
                int newFishToBeAdded = 0;
                for (int szam = 0; szam < state.Count; szam++)
                {
                    if (state[szam] > 0)
                    {
                        state[szam]--;
                    }
                    else if (state[szam] == 0)
                    {
                        state[szam] = defaultValue;
                        newFishToBeAdded++;
                    }
                }
                for (int db = 0; db < newFishToBeAdded; db++)
                {
                    state.Add(newFishStartingValue);
                }
            }
            return state.Count;
        }
    }
}
