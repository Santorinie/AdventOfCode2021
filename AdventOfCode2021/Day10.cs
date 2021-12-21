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
        }

        private string[] input = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day10.txt");
        private int[] karakterek = new int[8];
        private List<string> incompleteLines = new List<string>();
        //private List<string> completeLines = new List<string>();
        private List<char> openingTags = new List<char>() { '(','[','{','<' };
        private List<char> closingTags = new List<char>() {')',']','}','>' };
        private List<Tag> tags = new List<Tag>();


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