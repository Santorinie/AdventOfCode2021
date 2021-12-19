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
        }

        public static string[] input = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day9.txt");
        private static int inputLen = input.Length;
        public static int LineLen = input.First().ToCharArray().Count();

        private List<string> szamok = new List<string>();
        public List<string> values = new List<string>();
        private List<Tuple<int, int>> LowPoinLoc = new List<Tuple<int, int>>();
        public double lowpointcounter = 0;
        private double? OnRight = null;
        private double? OnLeft = null;
        private double? OnTop = null;
        private double? OnBot = null;




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
            foreach (var item in LowPoinLoc)
            {
                lowpointcounter += IsLowPoint(item.Item1, item.Item2, lowpointcounter);
            }

            //lowpointcounter += IsLowPoint(LowPoinLoc[0].Item1,LowPoinLoc[0].Item2 , lowpointcounter);

        }

        private double IsLowPoint(int x, int y,double counter) //5 input, 10 line
        {
            List<double?> boundaries = new List<double?>();
            var currentpos = char.GetNumericValue(szamok[x][y]);
            if (x == 0 && y > 0 && y < LineLen-1)
            {
                OnRight = char.GetNumericValue(szamok[x][y + 1]);
                OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                //OnTop = char.GetNumericValue(szamok[x - 1][y]);
                OnBot = char.GetNumericValue(szamok[x + 1][y]);

                boundaries.Add(OnRight);
                boundaries.Add(OnLeft);
                //boundaries.Add(OnTop);
                boundaries.Add(OnBot);
                if (currentpos < OnRight && currentpos < OnLeft && currentpos < OnBot)
                {
                    counter += boundaries.Where(x => x != 9).Count();
                    counter += IsLowPoint(x,y+1,counter);
                    counter += IsLowPoint(x,y-1,counter);
                    //counter += IsLowPoint(x - 1, y, counter);
                    counter += IsLowPoint(x + 1, y, counter);
                    return counter;
                }
            }
            else if (x == inputLen-1 && y > 0 && y < LineLen-1)
            {
                OnRight = char.GetNumericValue(szamok[x][y + 1]);
                OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                OnTop = char.GetNumericValue(szamok[x - 1][y]);
                //OnBot = char.GetNumericValue(szamok[x + 1][y]);
                boundaries.Add(OnRight);
                boundaries.Add(OnLeft);
                boundaries.Add(OnTop);
                //boundaries.Add(OnBot);
                if (currentpos < OnRight && currentpos < OnLeft && currentpos < OnTop)
                {
                    counter += boundaries.Where(x => x != 9).Count();

                    if (OnRight != 9)
                    {

                    counter += IsLowPoint(x, y + 1, counter);
                    }
                    if (OnLeft != 9)
                    {

                    counter += IsLowPoint(x, y - 1, counter);
                    }
                    if (OnTop != 9)
                    {
                    counter += IsLowPoint(x - 1, y, counter);

                    }
                    //if (OnBot != 9)
                    //{
                    //counter += IsLowPoint(x + 1, y, counter);

                    //}
                    return counter;
                }
            }
            else if (y == 0 && x > 0 && x < inputLen-1)
            {
                OnRight = char.GetNumericValue(szamok[x][y + 1]);
                //OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                OnTop = char.GetNumericValue(szamok[x - 1][y]);
                OnBot = char.GetNumericValue(szamok[x + 1][y]);
                boundaries.Add(OnRight);
                //boundaries.Add(OnLeft);
                boundaries.Add(OnTop);
                boundaries.Add(OnBot);
                if (currentpos < OnRight && currentpos < OnTop && currentpos < OnBot)
                {
                    counter += boundaries.Where(x => x != 9).Count();

                    if (OnRight != 9)
                    {

                        counter += IsLowPoint(x, y + 1, counter);
                    }
                    //if (OnLeft != 9)
                    //{

                    //    counter += IsLowPoint(x, y - 1, counter);
                    //}
                    if (OnTop != 9)
                    {
                        counter += IsLowPoint(x - 1, y, counter);

                    }
                    if (OnBot != 9)
                    {
                        counter += IsLowPoint(x + 1, y, counter);

                    }
                    return counter;
                }
            }
            else if (y == LineLen-1 && x > 0 && x < inputLen-1)
            {
                //OnRight = char.GetNumericValue(szamok[x][y + 1]);
                OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                OnTop = char.GetNumericValue(szamok[x - 1][y]);
                OnBot = char.GetNumericValue(szamok[x + 1][y]);
                //boundaries.Add(OnRight);
                boundaries.Add(OnLeft);
                boundaries.Add(OnTop);
                boundaries.Add(OnBot);
                if (currentpos < OnTop && currentpos < OnLeft && currentpos < OnBot)
                {
                    counter += boundaries.Where(x => x != 9).Count();

                    //if (OnRight != 9)
                    //{

                    //    counter += IsLowPoint(x, y + 1, counter);
                    //}
                    if (OnLeft != 9)
                    {

                        counter += IsLowPoint(x, y - 1, counter);
                    }
                    if (OnTop != 9)
                    {
                        counter += IsLowPoint(x - 1, y, counter);

                    }
                    if (OnBot != 9)
                    {
                        counter += IsLowPoint(x + 1, y, counter);

                    }
                    return counter;
                }
            }
            else if (x == 0 && y == 0)
            {
                OnRight = char.GetNumericValue(szamok[x][y + 1]);
                //OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                //OnTop = char.GetNumericValue(szamok[x - 1][y]);
                OnBot = char.GetNumericValue(szamok[x + 1][y]);
                boundaries.Add(OnRight);
                //boundaries.Add(OnLeft);
                //boundaries.Add(OnTop);
                boundaries.Add(OnBot);
                if (currentpos < OnRight && currentpos < OnBot)
                {
                    counter += boundaries.Where(x => x != 9).Count();

                    if (OnRight != 9)
                    {

                        counter += IsLowPoint(x, y + 1, counter);
                    }
                    //if (OnLeft != 9)
                    //{

                    //    counter += IsLowPoint(x, y - 1, counter);
                    //}
                    //if (OnTop != 9)
                    //{
                    //    counter += IsLowPoint(x - 1, y, counter);

                    //}
                    if (OnBot != 9)
                    {
                        counter += IsLowPoint(x + 1, y, counter);

                    }
                    return counter;
                }
            }
            else if (x == inputLen-1 && y == LineLen -1)
            {
                //OnRight = char.GetNumericValue(szamok[x][y + 1]);
                OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                OnTop = char.GetNumericValue(szamok[x - 1][y]);
                //OnBot = char.GetNumericValue(szamok[x + 1][y]);
                //boundaries.Add(OnRight);
                boundaries.Add(OnLeft);
                boundaries.Add(OnTop);
                //boundaries.Add(OnBot);
                if (currentpos < OnTop && currentpos < OnLeft)
                {
                    counter += boundaries.Where(x => x != 9).Count();

                    //if (OnRight != 9)
                    //{

                    //    counter += IsLowPoint(x, y + 1, counter);
                    //}
                    if (OnLeft != 9)
                    {

                        counter += IsLowPoint(x, y - 1, counter);
                    }
                    if (OnTop != 9)
                    {
                        counter += IsLowPoint(x - 1, y, counter);

                    }
                    //if (OnBot != 9)
                    //{
                    //    counter += IsLowPoint(x + 1, y, counter);

                    //}
                    return counter;
                }
            }
            else if (x == 0 && y == LineLen-1)
            {
                //OnRight = char.GetNumericValue(szamok[x][y + 1]);
                OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                //OnTop = char.GetNumericValue(szamok[x - 1][y]);
                OnBot = char.GetNumericValue(szamok[x + 1][y]);
                //boundaries.Add(OnRight);
                boundaries.Add(OnLeft);
                //boundaries.Add(OnTop);
                boundaries.Add(OnBot);
                if (currentpos < OnLeft && currentpos < OnBot)
                {
                    counter += boundaries.Where(x => x != 9).Count();
                    //if (OnRight != 9)
                    //{

                    //    counter += IsLowPoint(x, y + 1, counter);
                    //}
                    if (OnLeft != 9)
                    {

                        counter += IsLowPoint(x, y - 1, counter);
                    }
                    //if (OnTop != 9)
                    //{
                    //    counter += IsLowPoint(x - 1, y, counter);

                    //}
                    if (OnBot != 9)
                    {
                        counter += IsLowPoint(x + 1, y, counter);

                    }
                    return counter;
                }
            }
            else if (x == inputLen-1 && y == 0)
            {
                OnRight = char.GetNumericValue(szamok[x][y + 1]);
                //OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                OnTop = char.GetNumericValue(szamok[x - 1][y]);
                //OnBot = char.GetNumericValue(szamok[x + 1][y]);
                boundaries.Add(OnRight);
                //boundaries.Add(OnLeft);
                boundaries.Add(OnTop);
                //boundaries.Add(OnBot);
                if (currentpos < OnRight && currentpos < OnTop)
                {
                    counter += boundaries.Where(x => x != 9).Count();

                    if (OnRight != 9)
                    {

                        counter += IsLowPoint(x, y + 1, counter);
                    }
                    //if (OnLeft != 9)
                    //{

                    //    counter += IsLowPoint(x, y - 1, counter);
                    //}
                    if (OnTop != 9)
                    {
                        counter += IsLowPoint(x - 1, y, counter);

                    }
                    //if (OnBot != 9)
                    //{
                    //    counter += IsLowPoint(x + 1, y, counter);

                    //}
                    return counter;
                }
            }
            else
            {
                OnRight = char.GetNumericValue(szamok[x][y + 1]);
                OnLeft = char.GetNumericValue(szamok[x][y - 1]);
                OnTop = char.GetNumericValue(szamok[x - 1][y]);
                OnBot = char.GetNumericValue(szamok[x + 1][y]);
                boundaries.Add(OnRight);
                boundaries.Add(OnLeft);
                boundaries.Add(OnTop);
                boundaries.Add(OnBot);
                if (currentpos < OnRight && currentpos < OnLeft && currentpos < OnBot && currentpos < OnTop)
                {
                    counter += boundaries.Where(x => x != 9).Count();

                    if (OnRight != 9)
                    {

                        counter += IsLowPoint(x, y + 1, counter);
                    }
                    if (OnLeft != 9)
                    {

                        counter += IsLowPoint(x, y - 1, counter);
                    }
                    if (OnTop != 9)
                    {
                        counter += IsLowPoint(x - 1, y, counter);

                    }
                    if (OnBot != 9)
                    {
                        counter += IsLowPoint(x + 1, y, counter);

                    }
                    return counter;
                }
            }
            return 0;
        }


        private void parse()
        {
            foreach (var item in input)
            {
                szamok.Add(item);
            }
        }

    }
}