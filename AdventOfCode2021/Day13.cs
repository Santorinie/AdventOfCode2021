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
        private List<Tuple<string, int>> folds = new List<Tuple<string, int>>();
        private int XLength = 0; //jobb
        private int YLength = 0; //le
        private dynamic asd;
        private List<int> counts = new List<int>();

        public Day13()
        {
            parse();
            Part1();
            
            //Write();
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
            Console.WriteLine(tuples.Min(x => x.Item1));
            YLength = tuples.Max(x => x.Item2);
            Console.WriteLine(tuples.Min(x => x.Item2));

            var zsido2 = _input.ToList()
                .Skip(_input.ToList().TakeWhile(x => x != string.Empty).Count() + 1);

            foreach (var item in zsido2)
            {
                var temp = item.Split(" ").Last().Split('=');
                folds.Add(new Tuple<string, int>(temp[0],Convert.ToInt32(temp[1])));
            }



        }

        private void Part1()
        {
            int[,] matrix = new int[YLength+1, XLength+1];
            foreach (var item in tuples)
            {
                matrix[item.Item2, item.Item1] = 1;
            }
            asd = matrix;
            //Write(matrix,folds[0].Item2,folds[0].Item1);
            Console.WriteLine();
            foreach (var item in folds)
            {
                matrix = Fold(matrix, item.Item1, item.Item2);
                Console.WriteLine();


            }
            Console.WriteLine($"1. fold: {counts[0]+1}");


        }

        private int[,] Fold(int[,] matrix, string foldAxle, int line)
        {
            int counter = 0;
            Write(matrix, line, foldAxle);
            Console.WriteLine();
            dynamic newMatrix;

            if (foldAxle == "x")
            {
                newMatrix = new int[matrix.GetLength(0), line];
                for (int i = matrix.GetLength(0)-1; i > line; i--) // oszlop, ezt keressük
                {
                    for (int y = 0; y <= line; y++) // sor
                    {
                        //Console.Write("belso, ");

                            if (i != line)
                            {
                                //fold

                                if (i != line)
                                {
                                    var fromstart = matrix[i, y];
                                    var fromend = matrix[i, (matrix.GetLength(1) - 1) - y];
                                if (fromstart == 1 && fromend == 1)
                                {
                                    newMatrix[i, y] = 1;
                                }
                                //if (fromstart == 0 && fromend == 0)
                                //{
                                //    newMatrix[i, y] = 1;
                                //}
                                else if (fromstart == 1)
                                    {
                                        newMatrix[i, y] = 1;
                                    counter++;
                                    }
                                    else if (fromend == 1)
                                    {
                                    counter++;
                                        newMatrix[i, y] = 1;
                                    }


                                }


                            }
                        else
                        {
                            //break;
                        }
                        
                    }
                    //Console.WriteLine();

                }
            }
            else
            {
                newMatrix = new int[line, matrix.GetLength(1)];
                for (int i = line; i > 0; i--) // oszlop, ezt keressük
                {
                    for (int y = 0; y < matrix.GetLength(1); y++) // sor
                    {
                        //Console.Write("belso, ");
                        
                            if (i != line)
                            {
                                //fold

                                if (i != line)
                                {
                                    var fromstart = matrix[i, y];
                                    var fromend = matrix[(matrix.GetLength(0) - 1) - i, y];
                                if (fromstart == 1 && fromend == 1)
                                {
                                    newMatrix[i, y] = 1;
                                }
                                //if (fromstart == 0)
                                //{

                                //}
                                else if (fromstart == 1)
                                    {
                                    counter++;
                                    newMatrix[i, y] = 1;
                                    }
                                    else if (fromend == 1)
                                    {
                                    counter++;
                                    newMatrix[i, y] = 1;
                                    }


                                }


                            }
                        else
                        {
                            //break;
                        }
                        
                        
                    }
                    //Console.WriteLine();

                }
            }

            Write(newMatrix);
            counts.Add(counter);
            Console.WriteLine();
            return newMatrix;

        }

        private int Write(int[,] matrixl)
        {
            int counter = 0;
            for (int i = 0; i < matrixl.GetLength(0); i++)
            {
                for (int y = 0; y < matrixl.GetLength(1); y++)
                {
                    
                    if (matrixl[i, y] == 0)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        counter++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("#");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.Write("\n");
            }
            return counter;
        }

        private int Write(int[,] matrixl, int fold,string axle)
        {
            int counter = 0;
            for (int i = 0; i < matrixl.GetLength(0); i++)
            {
                for (int y = 0; y < matrixl.GetLength(1); y++)
                {
                    if (axle == "y" && i == fold)
                    {
                        Console.Write("-");
                    }
                    else if (axle == "x" && y == fold)
                    {
                        Console.Write("|");
                    }
                    else if (matrixl[i, y] == 0)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("#");
                        counter++;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.Write("\n");
            }
            return counter;
        }

    }
}