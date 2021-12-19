using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day8
    {

        public Day8()
        {


            
        }

        public static string input = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
        public static string[] longInput = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day8.txt");
        private static List<string> parsedAfterSeparator = new List<string>(); 
        private static List<string> parsedBeforeSeparator = new List<string>();
        private List<Tuple<int, int, string>> SegmentData = new List<Tuple<int, int, string>>();
        public List<string> vegeredmenyek = new List<string>();


        public void Part2Solution()
        {


            for (int i = 0; i < longInput.Count(); i++)
            {
                parsedAfterSeparator.Clear();
                parsedBeforeSeparator.Clear();
                SegmentData.Clear();
                Parse(longInput[i]);

                SolveALine();
            }
            int counter = 0;
            vegeredmenyek.ForEach(x => counter += Convert.ToInt32(x));
            Console.WriteLine($"Part 2 megoldas: {counter}");
        }

        public void SolveALine()
        {
            MakeMapping();
                List<int> szamok = new List<int>();
            foreach (var entity in parsedAfterSeparator) // sor
            {
                foreach (var NumberData in SegmentData)
                {

                    if (entity.ToCharArray().OrderBy(x => x).SequenceEqual(NumberData.Item3.ToCharArray().OrderBy(x => x)))
                    {
                        szamok.Add(NumberData.Item1);
                        Console.WriteLine($"entity is {NumberData.Item1}");
                        if (szamok.Count == 4)
                        {
                            string faszomanyadba = string.Join("", szamok);
                            vegeredmenyek.Add(faszomanyadba);
                            szamok.Clear();
                        }
                    }


                }



            }






        }

        public void Part1()
        {
            int[] segmentsCounts = new int[10] { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
            int appears = 0;
            foreach (var item in parsedAfterSeparator)
            {

                    if (segmentsCounts.Where(x => x == item.ToCharArray().Count()).Count() == 1)
                    {
                        appears++;
                    }
                
            }
            Console.WriteLine($"Part1: {appears}");
        }


        public void Parse(string item)
        {

                
                var parsedAfterLine = item.Split('|').Last().Split(' ').Skip(1).ToList();
                var parsedBeforeLine = item.Split('|').First().Split(' ').Take(10).ToList();

                parsedAfterSeparator =  parsedAfterSeparator.Concat(parsedAfterLine).ToList();
                parsedBeforeSeparator = parsedBeforeSeparator.Concat(parsedBeforeLine).ToList();
            
        }



        private void MakeMapping()
        {
            
            // Unique számok: 1, 4, 7, 8 -
            // Igényelt bits: 2, 4, 3, 7

  
            var egy = parsedBeforeSeparator.First(x => x.ToCharArray().Count() == 2).ToCharArray();
            var negy = parsedBeforeSeparator.First(x => x.ToCharArray().Count() == 4).ToCharArray();
            var het = parsedBeforeSeparator.First(x => x.ToCharArray().Count() == 3).ToCharArray();
            var nyolc = parsedBeforeSeparator.First(x => x.ToCharArray().Count() == 7).ToCharArray();




            string[] picsha = new string[10] {"", string.Join("", egy), "","", string.Join("", negy), "","", string.Join("", het), string.Join("",nyolc),"" };

            foreach (var szo in parsedBeforeSeparator)
            {
                var item = szo.ToCharArray();
                //0
                if (item.Intersect(nyolc).Count() == 6 && item.Intersect(negy).Count() == 3 && item.Intersect(het).Count() == 3)
                {
                    picsha[0] = szo;
                    Console.WriteLine($"A nulla az: {szo}");
                }
                //6
                else if (item.Intersect(nyolc).Count() == nyolc.Count()-1 && item.Intersect(het).Count() == 2 && item.Intersect(negy).Count() == 3)
                {
                    picsha[6] = szo;
                    Console.WriteLine($"A hat: {szo}");
                }
                //5
                else if (item.Intersect(negy).Count() == 3 && item.Intersect(het).Count() == 2 && item.Intersect(nyolc).Count() == 5)
                {
                    picsha[5] = szo;
                    Console.WriteLine($"Az öt: {szo}");
                }
                //2
                else if (item.Intersect(egy).Count() == 1 && item.Intersect(negy).Count() == 2 && item.Intersect(nyolc).Count() == 5)
                {
                    picsha[2] = szo;
                    Console.WriteLine($"A kettő: {szo}");
                }
                //3
                else if (item.Intersect(nyolc).Count() == 5 && item.Intersect(negy).Count() == 3)
                {
                    picsha[3] = szo;
                    Console.WriteLine($"A három: {szo}");
                }
                //9
                else if (item.Intersect(nyolc).Count() == 6 && item.Intersect(negy).Count() == 4)
                {
                    picsha[9] = szo;
                    Console.WriteLine($"A kilenc: {szo}");
                }
            }

                                              // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            int[] segmentsCounts = new int[10] { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 };


            for (int i = 0; i < segmentsCounts.Count(); i++)
            {
                SegmentData.Add(new Tuple<int, int, string>(i,segmentsCounts[i],picsha[i]));
            }


        }
    }
}
