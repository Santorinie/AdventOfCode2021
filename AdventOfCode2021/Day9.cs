using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2021D1
{
    internal class Day9
    {
        public Day9()
        {
            parse();
            part2();
        }

        public static string[] input = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day9.txt");
        private static int inputLen = input.Length;
        public static int LineLen = input.First().ToCharArray().Count();
        private static int Sorok = inputLen - 1;
        private static int Oszlopok = LineLen - 1;
        private List<Point> basins = new List<Point>();
        private List<string> szamok = new List<string>();
        public List<string> values = new List<string>();
        private List<Point> pontok = new List<Point>();
        //private Point[,] pontmatrix = new Point[Sorok+1,Oszlopok+1];
        private List<Tuple<int, int>> LowPoinLoc = new List<Tuple<int, int>>();
        private List<Point> lowpointloc = new List<Point>();
        public int lowpointcounter = 0;
        private double? OnRight = null;
        private double? OnLeft = null;
        private double? OnTop = null;
        private double? OnBot = null;

        private List<Point> neighbours = new List<Point>();
        private List<int> basincounts = new List<int>();

        public void part1()
        {


            for (int sorszam = 0; sorszam < inputLen; sorszam++) // 5
            {
                for (int oszlopszam = 0; oszlopszam < LineLen; oszlopszam++) // 10
                {
                    var currentLocation = char.GetNumericValue(szamok[sorszam][oszlopszam]);

                    if (sorszam == 0 && oszlopszam == 0)
                    {
                        OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        //OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        //OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnRight && currentLocation < OnBot)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam,oszlopszam));
                            lowpointloc.Add(new Point() {X = sorszam,Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]),Checked = false });
                        }
                    }
                    else if (sorszam == inputLen-1 && oszlopszam == LineLen-1)
                    {
                        //OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        //OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnLeft && currentLocation < OnTop)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }
                    else if (sorszam == 0 && oszlopszam == LineLen-1)
                    {
                        //OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        //OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnLeft && currentLocation < OnBot)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }
                    else if (sorszam == inputLen-1 && oszlopszam == 0)
                    {
                        OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        //OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        //OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnRight && currentLocation < OnTop)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }
                    else if (sorszam == 0)
                    {
                         OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                         OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                         //OnTop = null;
                         OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnRight && currentLocation < OnLeft && currentLocation < OnBot)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }
                    else if (sorszam == inputLen-1)
                    {
                        OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        //OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnRight && currentLocation < OnLeft && currentLocation < OnTop)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }
                    else if (oszlopszam == 0)
                    {
                        OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        //OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnRight && currentLocation < OnTop && currentLocation < OnBot)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }
                    else if (oszlopszam == LineLen-1)
                    {
                        //OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnLeft && currentLocation < OnTop && currentLocation < OnBot)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }
                    else
                    {
                        OnRight = char.GetNumericValue(szamok[sorszam][oszlopszam + 1]);
                        OnLeft = char.GetNumericValue(szamok[sorszam][oszlopszam - 1]);
                        OnTop = char.GetNumericValue(szamok[sorszam - 1][oszlopszam]);
                        OnBot = char.GetNumericValue(szamok[sorszam + 1][oszlopszam]);
                        if (currentLocation < OnRight && currentLocation < OnLeft && currentLocation < OnTop && currentLocation < OnBot)
                        {
                            values.Add(currentLocation.ToString());
                            LowPoinLoc.Add(new Tuple<int, int>(sorszam, oszlopszam));
                            lowpointloc.Add(new Point() { X = sorszam, Y = oszlopszam, Value = char.GetNumericValue(szamok[sorszam][oszlopszam]), Checked = false });

                        }
                    }

                }
            }
            int vegeredmeny = 0;

            foreach (var item in values)
            {
                vegeredmeny += Convert.ToInt32(item) + 1;
            }

            Console.WriteLine($"Part1: {vegeredmeny}");
        }

        public void part2()
        {
            part1();
            for (int x = 0; x <= Sorok; x++)
            {
                for (int y = 0; y <= Oszlopok; y++)
                {
                    pontok.Add(new Point() { X = x, Y = y, Value = char.GetNumericValue(szamok[x][y])});
                }
            }
            foreach (var item in lowpointloc)
            {
                basins.Clear();
                lowpointcounter = CheckNeighbours(item,lowpointcounter);

                var pina = basins.Distinct();
                basincounts.Add(pina.Count());
                Console.WriteLine($"Das ist basins: {pina.Count()}db");
            }

            Console.WriteLine($"Part2 solution: {basincounts.OrderByDescending(x => x).Take(3).Aggregate(1, (x, y) => x * y)}");

        }

        private int CheckNeighbours(Point pont,int counter)
        {
            List<Point> children = new List<Point>();
            try
            {
                OnLeft = pontok.First(x => x.Y == pont.Y-1 && x.X == pont.X).Value;
                Point child = pontok.First(x => x.Y == pont.Y - 1 && x.X == pont.X);
                children.Add(child);
            }
            catch (Exception)
            {
                OnLeft = -1;
            }
            try
            {
                OnRight = pontok.First(x => x.Y == pont.Y + 1 && x.X == pont.X).Value;
                Point child = pontok.First(x => x.Y == pont.Y + 1 && x.X == pont.X);
                children.Add(child);

            }
            catch (Exception)
            {
                OnRight = -1;
            }
            try
            {
                OnTop = pontok.First(x => x.X == pont.X - 1 && x.Y == pont.Y).Value;
                Point child = pontok.First(x => x.X == pont.X - 1 && x.Y == pont.Y);
                children.Add(child);

            }
            catch (Exception)
            {
                OnTop = -1;
            }
            try
            {
                OnBot = pontok.First(x => x.X == pont.X + 1 && x.Y == pont.Y).Value;
                Point child = pontok.First(x => x.X == pont.X + 1 && x.Y == pont.Y);
                children.Add(child);
            }
            catch (Exception)
            {
                OnBot = -1;
            }

            //Ha a szomszéd nagyobb mint az alap pozíció és nem 9 akkor Ellenőrizzük
            // Minden tag saját magát számolja meg
            // pont az +1-et ad a maxhoz, a childrenek ha trueval térnek vissza +1-et adnak vissza
            // A vizsgált tagok mindig az alaptagok
            counter++;
            basins.Add(pont);
            var index = pontok.FindIndex(x => x.X == pont.X && x.Y == pont.Y && x.Value == pont.Value);
            pontok.RemoveAt(index);
            pontok.Add(new Point() { X = pont.X, Y = pont.Y, Checked = true, Value = pont.Value });
            

            foreach (var item in children)
            {
                if (item.Value > pont.Value && item.Value != 9 && item.Checked == false)
                {
                    //basins.Add(item);
                    counter = CheckNeighbours(item,counter);
                }

            }
            return counter;

        }


        private void parse()
        {
            foreach (var item in input)
            {
                szamok.Add(item);
            }
        }

    }

    internal class Point
    {

        public Point()
        {
            //this.Checked = false;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public double Value { get; set; }
        public bool Checked { get; set; }
    }
}