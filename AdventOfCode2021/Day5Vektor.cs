using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Vektor
    {
        public Vektor(int x1, int y1, int x2, int y2)
        {
            X = new Tuple<int, int>(x1, x2);
            Y = new Tuple<int, int>(y1, y2);
            this.Line = IsLine();
            CoversPoints();
        }


        public Tuple<int, int> X { get; set; }
        public Tuple<int,int> Y { get; set; }
        public bool Line { get; set; }
        public List<Tuple<int, int>> coordinateCollection { get; set; } = new List<Tuple<int, int>>();
        private bool isXSame { get; set; }
        private bool isYSame { get; set; }

        public bool IsLine()
        {
            if (X.Item1 == X.Item2)
            {
                isXSame = true;
                isYSame = false;
                return true;
            }
            else if (Y.Item1 == Y.Item2)
            {
                isYSame = true;
                isXSame = false;
                return true;
            }
            else
            {
                isYSame = false;
                isXSame = false;
                return false;
            }
            
        }

        public void CoversPoints()
        {
            if (isXSame && Y.Item1 > Y.Item2 && isYSame == false)
            {
                for (int i = Y.Item1; i >= Y.Item2; i--)
                {
                    //Console.WriteLine($"Ciklus 1: i = {i}");
                    coordinateCollection.Add(new Tuple<int, int>(X.Item1,i));
                }
            }

            else if (isXSame && Y.Item2 > Y.Item1 && isYSame == false)
            {
                for (int i = Y.Item1; i <= Y.Item2; i++)
                {
                    //Console.WriteLine($"Ciklus 2: i = {i}");
                    coordinateCollection.Add(new Tuple<int, int>(X.Item1, i));
                }
            }

            else if (isXSame == false && X.Item1 > X.Item2 && isYSame)
            {
                for (int i = X.Item1; i >= X.Item2; i--)
                {
                    //Console.WriteLine($"Ciklus 3: i = {i}");
                    coordinateCollection.Add(new Tuple<int, int>(i, Y.Item1));
                }
            }

            else if (isXSame == false && X.Item2>X.Item1 && isYSame)
            {
                for (int i = X.Item1; i <= X.Item2; i++)
                {
                    //Console.WriteLine($"Ciklus 4: i = {i}");
                    coordinateCollection.Add(new Tuple<int, int>(i, Y.Item1));
                }
            }

            else
            {

                int minX = Math.Min(X.Item1, X.Item2);
                int maxX = Math.Max(X.Item1, X.Item2);
                int minY = Math.Max(Y.Item1, Y.Item2);
                int maxY = Math.Max(Y.Item1, Y.Item2);

                int gapX = maxX - minX;
                int gapY = maxY - minY;

                List<int> xlist = new List<int>();
                List<int> ylist = new List<int>();


                if (X.Item1 > X.Item2)
                {
                    for (int i = X.Item1; i >= X.Item2; i--)
                    {
                    xlist.Add(i);

                    }
                }
                else
                {
                    for (int i = X.Item1; i <= X.Item2; i++)
                    {
                        xlist.Add(i);

                    }
                }
                if (Y.Item1 > Y.Item2)
                {
                    for (int i = Y.Item1; i >= Y.Item2; i--)
                    {
                        ylist.Add(i);

                    }
                }
                else
                {
                    for (int i = Y.Item1; i <= Y.Item2; i++)
                    {
                        ylist.Add(i);

                    }
                }





                for (int i = 0; i < xlist.Count; i++)
                {
                    coordinateCollection.Add(new Tuple<int, int>(xlist[i],ylist[i]));
                }
            }




        }
        
    }
}
