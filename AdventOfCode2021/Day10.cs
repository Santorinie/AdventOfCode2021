using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2021D1
{
    internal class Day10
    {
        public Day10()
        {
            //SortLines();
            PopulateTags();
            Part1();
            Part2();
        }

        private string[] input = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day10.txt");
        private int[] karakterek = new int[8];
        private List<string> incompleteLines = new List<string>();
        //private List<string> completeLines = new List<string>();
        private List<char> openingTags = new List<char>() { '(','[','{','<' };
        private List<char> closingTags = new List<char>() {')',']','}','>' };
        private List<Tag> tags = new List<Tag>();
        private List<string> Part2Solutions = new List<string>();
        private List<double> Part2Ints = new List<double>();


        private void Part1()
        {
            // Karaktertáblázat: ( ; ) ; [ ; ] ; { ; } ; < ; >
            // ( = 0 | ) = 1 | [ = 2 | ] = 3 | { = 4 | } = 5 | < = 6 | > = 7 

            List<char> Invalidchars = new List<char>();
            foreach (var sor in input)
            {
                bool isCorrupted = false;
                var line = sor.ToCharArray().ToList();
                SortLines(line);
                List<char> openingSequence = new List<char>();
                List<char> canExpect = new List<char>();
                //List<char> closingSequence = new List<char>();
                char openingChar = sor[0];
                foreach (var karakter in line)
                {
                    if (openingTags.Contains(karakter)) // Ha nyitó tag
                    {
                        if (openingSequence.Count() == 0)
                        {
                            openingChar = karakter;
                        }
                        openingSequence.Add(karakter);
                    }
                    else // Ha záró tag
                    {
                        try
                        {
                            char opposingTag = tags.First(x => x.ClosingTag == karakter).OpeningTag;
                            var index = openingSequence.LastIndexOf(opposingTag);

                
                            if (index == -1 || openingSequence[0] != openingChar && openingSequence.Count() > 0 || openingSequence.Last() != tags.First(x => x.ClosingTag == karakter).OpeningTag)
                            {
                                //Console.WriteLine("Hiba van a mátrixban");
                                //Console.WriteLine($"Expected {tags.First(x => x.OpeningTag == openingSequence.Last()).ClosingTag}, but found {karakter} instead.");
                                Invalidchars.Add(karakter);
                                isCorrupted = true;
                                break;
                            }
                            else
                            {
                                openingSequence.RemoveAt(index);

                            }



                        }
                        catch (Exception)
                        {
                            Console.WriteLine(karakter);
                        }
                    }



                }
                if (isCorrupted)
                {

                }
                else
                {

                    //Console.WriteLine("Line isnt corrupted");
                    incompleteLines.Add(sor);
                }

            }

            var korScore = Invalidchars.Count(x => x == ')')*3;
            var szogletesScore = Invalidchars.Count(x => x == ']')*57;
            var kapcsosScore = Invalidchars.Count(x => x == '}')*1197;
            var kacsaScore = Invalidchars.Count(x => x == '>')*25137;

            Console.WriteLine($"Part1: {korScore+szogletesScore+kapcsosScore+kacsaScore}");
            
        }

        private void Part2()
        {
            foreach (var sor in incompleteLines)
            {
                var line = sor.ToCharArray().ToList();
                List<int> karakterLanc = new List<int>();
                // Karaktertáblázat: ( ; ) ; [ ; ] ; { ; } ; < ; >
                // ( = 0 | ) = 1 | [ = 2 | ] = 3 | { = 4 | } = 5 | < = 6 | > = 7 
                List<char> sequence = new List<char>();

                while (line.Contains(']') || line.Contains(')') || line.Contains('}') || line.Contains('>'))
                {
                    for (int i = 0; i < line.Count-1; i++)
                    {
                        //char currentChar = line[i];
                        //char nextChar = line[i+1];
                        bool isOpeningChar = false;
                        char opposingChar = 'a';
                        if (openingTags.Contains(line[i]))
                        {
                            isOpeningChar = true; 
                            opposingChar = tags.First(x => x.OpeningTag == line[i]).ClosingTag;

                        }
                        else
                        {
                            opposingChar = tags.First(x => x.ClosingTag == line[i]).OpeningTag;
                        }
                        if (isOpeningChar && line[i+1] == opposingChar)
                        {
                            line.RemoveAt(i);
                            line.RemoveAt(i);
                        }
                        else
                        {
                            //sequence.Add(line[i]);
                        }
                    }

                }
                line.Reverse();
                //Console.WriteLine($"Solution: ");
                List<char> solutionList = new List<char>();
                foreach (var item in line)
                {
                    var opposing = tags.First(x => x.OpeningTag == item).ClosingTag;
                    solutionList.Add(opposing);
                }
                string solution = string.Join("", solutionList);
                Part2Solutions.Add(solution);

                

            }
            try
            {

                foreach (var item2 in Part2Solutions)
                {
                    double total_score = 0;
                    foreach (var item in item2)
                    {

                        if (item == ')')
                        {
                            total_score = total_score * 5 + 1;
                        }
                        else if (item == ']')
                        {
                            total_score = total_score * 5 + 2;
                        }
                        else if (item == '}')
                        {
                            total_score = total_score * 5 + 3;
                        }
                        else if (item == '>')
                        {
                            total_score = total_score * 5 + 4;
                        }
                    }
                    Part2Ints.Add(total_score);
                    Console.WriteLine(total_score);
                }

                int numbercount = Part2Ints.Count();
                int halfindex = numbercount / 2;
                var sorted = Part2Ints.OrderBy(x => x);
                double median;
                if (numbercount%2 == 0)
                {
                    median = (sorted.ElementAt(halfindex) + sorted.ElementAt(halfindex - 1)) / 2;
                }
                else
                {
                    median = sorted.ElementAt(halfindex);
                }
                Console.WriteLine($"Part2: {median}");


            }
            catch (Exception)
            {

            }
        }

        private void PopulateTags()
        {
            tags.Add(new Tag() { OpeningTag = '(', ClosingTag = ')' });
            tags.Add(new Tag() { OpeningTag = '[', ClosingTag = ']' });
            tags.Add(new Tag() { OpeningTag = '{', ClosingTag = '}' });
            tags.Add(new Tag() { OpeningTag = '<', ClosingTag = '>' });

        }

        private void SortLines(List<char> line)
        {
            //int[] karakterek = new int[8];

                karakterek[0] = line.Count(x => x == '(');
                karakterek[1] = line.Count(x => x == ')');
                karakterek[2] = line.Count(x => x == '[');
                karakterek[3] = line.Count(x => x == ']');
                karakterek[4] = line.Count(x => x == '{');
                karakterek[5] = line.Count(x => x == '}');
                karakterek[6] = line.Count(x => x == '<');
                karakterek[7] = line.Count(x => x == '>');

                //int incomplete = 0;
                //for (int i = 0; i < localkarakterek.Count() - 1; i += 2)
                //{
                //    if (localkarakterek[i] != localkarakterek[i + 1])
                //    {
                //        incomplete++;
                //    }
                //}

                //if (incomplete > 1)
                //{
                //    incompleteLines.Add(line);
                //}
                //else if (incomplete < 1)
                //{
                //    completeLines.Add(line);
                //}
            
        }
        
    }

    internal class Tag
    {
        public char OpeningTag { get; set; }
        public char ClosingTag { get; set; }
    }
}