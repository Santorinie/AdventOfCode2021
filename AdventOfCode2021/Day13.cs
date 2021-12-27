using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOC2021D1
{
    internal class Day13
    {
        private string[] _input = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day13.txt");
        private List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
        private int XLength = 0; //jobb
        private int YLength = 0; //le
        

        public Day13()
        {
            parse();
            Part1();    
        }


        private void parse()
        {
            var zsido = _input.ToList()
     .TakeWhile(x => x != string.Empty)
     .ToList();


            foreach (var sor in zsido)
            {
                var temp = sor.Split(',');

                tuples.Add(new Tuple<int, int>(int.Parse(temp.First()), int.Parse(temp.Last())));
            }
            XLength = tuples.Max(x => x.Item1);
            YLength = tuples.Max(x => x.Item2);

        }

        private void Part1()
        {
            int[,] matrix = new int[YLength+1, XLength+1];
            foreach (var item in tuples)
            {
                matrix[item.Item2, item.Item1] = 1;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[i,y] == 0)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.Write("\n");
            }
        }

    }
}