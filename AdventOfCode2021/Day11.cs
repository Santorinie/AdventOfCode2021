using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AOC2021D1
{
    internal class Day11
    { // 15:30
        public Day11()
        {
            populateMatrix();
            AddNeighbours();
            part1();
            //WriteMatrix();
        }

        private Octopus[,] Matrix = new Octopus[10, 10];
        private string[] input = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day11.txt");
        private int FlashCounter = 0;

        private void part1()
        {
            for (int i = 0; i < 100; i++)
            {
                foreach (var octopus in Matrix)
                {
                    octopus.Charge();
                }
                foreach (var octopus in Matrix)
                {
                    if (octopus.Flashed)
                    {
                        octopus.Energy = 0;
                        FlashCounter++;
                        octopus.Flashed = false;
                    }
                }
                //Console.WriteLine("\n-----------NEW ROUND-----------\n");
                //WriteMatrix();
                //Console.WriteLine("");
            }
                Console.WriteLine($"Part 1 answer: {FlashCounter}");
        }

        private void WriteMatrix()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (Matrix[x,y].Energy == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{Matrix[x,y].Energy} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{Matrix[x, y].Energy} ");
                    }
                }
                Console.WriteLine();
            }
        }

        private void populateMatrix()
        {
            for (int x = 0; x <= Matrix.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= Matrix.GetUpperBound(1); y++)
                {
                    Matrix[x, y] = new Octopus()
                    {
                        X = x,
                        Y = y,
                        Energy = char.GetNumericValue(input[x][y]),
                        Flashed = false,
                       
                    };
                }
            }
        }

        private List<Octopus> GetNeighBours(Octopus octopus)
        {
            List<Octopus> octopuses = new List<Octopus>();

            Octopus OnRight;
            Octopus OnLeft;
            Octopus OnTop;
            Octopus OnBot;
            Octopus OnTopLeft;
            Octopus OnTopRight;
            Octopus OnBotLeft;
            Octopus OnBotRight;
                try
                {
                   OnRight = Matrix[octopus.X,octopus.Y-1];
                octopuses.Add(OnRight);
                }
                catch (Exception)
                {
                    OnRight = null;
                }
                try
                {
                    OnLeft = Matrix[octopus.X, octopus.Y + 1];
                octopuses.Add(OnLeft);

            }
            catch (Exception)
                {
                    OnLeft = null;
                }
                try
                {
                    OnTop = Matrix[octopus.X -1 , octopus.Y];
                octopuses.Add(OnTop);

            }
            catch (Exception)
                {
                    OnTop = null;
                }
                try
                {
                    OnBot = Matrix[octopus.X+1, octopus.Y];
                octopuses.Add(OnBot);

            }
            catch (Exception)
                {
                    OnBot = null;
                }
                try
                {
                    OnTopLeft = Matrix[octopus.X -1, octopus.Y - 1];
                octopuses.Add(OnTopLeft);

            }
            catch (Exception)
                {
                    OnTopLeft = null;
                }
                try
                {
                    OnTopRight = Matrix[octopus.X -1, octopus.Y + 1];
                octopuses.Add(OnTopRight);

            }
            catch (Exception)
                {
                    OnTopRight = null;
                }
                try
                {
                    OnBotLeft = Matrix[octopus.X + 1, octopus.Y - 1];
                octopuses.Add(OnBotLeft);

            }
            catch (Exception)
                {
                    OnBotLeft = null;
                }
                try
                {
                    OnBotRight = Matrix[octopus.X + 1, octopus.Y + 1];
                octopuses.Add(OnBotRight);

            }
            catch (Exception)
                {
                    OnBotRight = null;
                }

            return octopuses;

        }

        private void AddNeighbours()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Matrix[x, y].Neighbours = GetNeighBours(Matrix[x, y]);
                }
            }
        }
    }

    internal class Octopus
    {
        public Octopus()
        {

        }

        public int X { get; set; }
        public int Y { get; set; }
        public double Energy { get; set; }
        public bool Flashed { get; set; }
        public List<Octopus> Neighbours { get; set; } = new List<Octopus>();

        public void Charge()
        {
            if (this.Energy < 9)
            {
                this.Energy++;
            }
            else
            {
                this.Energy = 0;
                //flash
                if (this.Flashed == false)
                {
                    Flash();
                    
                }
            }
        }

        private void OnFlashing()
        {
            foreach (var octopus in Neighbours)
            {
                if (octopus.Flashed)
                {

                }
                else
                {
                    octopus.Charge();

                }
            }
        }

        private void Flash()
        {
            // something
            Flashed = true;
            this.Energy = 0;
            OnFlashing();
        }


    }
}