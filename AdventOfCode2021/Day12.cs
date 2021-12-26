using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Data;

namespace AOC2021D1
{
    internal class Day12
    {
        public Day12()
        {
            parse();

            Console.WriteLine(part1());
        }




        private string[] input = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day12.txt");
        //private HashSet<string> csatornak = new HashSet<string>();
        //private List<(string from, HashSet<string> to, bool visited)> tunnels = new List<(string from, HashSet<string> to, bool visited)>();
        private Dictionary<string,List<string>> tunnels = new();
        private List<string> paths = new List<string>();
        //private List<string> visited2 = new List<string>();
        //private HashSet<string> visitedBig = new HashSet<string>();

        private int part1()
        {
            Traversen("start", new(),false);

            return paths.Distinct().ToList().Count;

        }

        private void Traversen(string current, List<string> visited, bool isPartTwo)
        {
            visited.Add(current);
            if (!tunnels.ContainsKey(current))
            {
                paths.Add(string.Join(",", visited));
                visited = new();
                return;
            }

            var multipleSmallVisits = visited.Any(x => x.ToLower() == x && visited.Count(y => y == x) == 2);

            var next = multipleSmallVisits || isPartTwo ? tunnels[current].Where(x => x.ToUpper() == x || x == "end" || !visited.Contains(x) && x != "start").ToList()
                : tunnels[current].Where(x => x != "start");


            foreach (var x in next)
            {
                Traversen(x, visited.ToList(), isPartTwo);

            }
        }
    

        private void parse()
        {
            foreach (var sor in input)
            {
                var temp = sor.Split('-');
                var temp2 = sor.Split('-').Reverse().ToList();

                if (tunnels.ContainsKey(temp[0]))
                {
                    tunnels.Where(x => x.Key == temp[0]).ToList().ForEach(y => y.Value.Add(temp[1]));
                }
                else
                {
                    List<string> templist = new List<string>();
                    //if (temp[1] != "start")
                    //{

                    //templist.Add(temp[1]);
                    //}
                    templist.Add(temp[1]);
                    tunnels.Add(temp[0],templist);
                }
                if (tunnels.ContainsKey(temp2[0]))
                {
                    tunnels.Where(x => x.Key == temp2[0]).ToList().ForEach(y => y.Value.Add(temp2[1]));
                }
                else
                {
                    List<string> templist = new List<string>();
                    templist.Add(temp2[1]);
                    tunnels.Add(temp2[0], templist);
                }
            }

            tunnels.Remove("end");


        }

        private void Populate()
        {

        }
        public bool IsCapital(char name)
        {
            if (name.ToString() == name.ToString().ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}