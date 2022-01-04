using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using MoreLinq;
using System.Text;
using System.Numerics;

namespace AOC2021D1
{
    internal class Day14
    {
//        private string[] input = @"BNSOSBBKPCSCPKPOPNNK

//HH -> N
//CO -> F
//BC -> O
//HN -> V
//SV -> S
//FS -> F
//CV -> F
//KN -> F
//OP -> H
//VN -> P
//PF -> P
//HP -> H
//FK -> K
//BS -> F
//FP -> H
//FN -> V
//VV -> O
//PS -> S
//SK -> N
//FF -> K
//PK -> V
//OF -> N
//VP -> K
//KB -> H
//OV -> B
//CH -> F
//SF -> F
//NH -> O
//NC -> N
//SP -> N
//NN -> F
//OK -> S
//BB -> S
//NK -> S
//FH -> P
//FC -> S
//OB -> P
//VS -> P
//BF -> S
//HC -> V
//CK -> O
//NP -> K
//KV -> S
//OS -> V
//CF -> V
//FB -> C
//HO -> S
//BV -> V
//KS -> C
//HB -> S
//SO -> N
//PH -> C
//PN -> F
//OC -> F
//KO -> F
//VF -> V
//CS -> O
//VK -> O
//FV -> N
//OO -> K
//NS -> S
//KK -> C
//FO -> S
//PV -> S
//CN -> O
//VC -> P
//SS -> C
//PO -> P
//BN -> N
//PB -> N
//PC -> H
//SH -> K
//BH -> F
//HK -> O
//VB -> P
//NV -> O
//NB -> C
//CP -> H
//NO -> K
//PP -> N
//CC -> S
//CB -> K
//VH -> H
//SC -> C
//KC -> N
//SB -> B
//BP -> P
//KP -> K
//SN -> H
//KF -> K
//KH -> B
//HV -> V
//HS -> K
//NF -> B
//ON -> H
//BO -> P
//VO -> K
//OH -> C
//HF -> O
//BK -> H".Split("\n");
        private string[] input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C".Split("\n");
        private List<char> baseText;
        private Dictionary<string, long> map = new();
        private Dictionary<string, long> Patterncounters = new();
        private Dictionary<string, string> rules = new Dictionary<string, string>();
        public Day14()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            baseText = input[0].ToCharArray().ToList();
            foreach (var sor in input.Skip(2))
            {
               var temp = sor.Split(" -> ");
                rules.Add(temp[0],temp[1]);
                map.Add(temp[0], 0);
                
                

            }
            
            map = Converter(input[0]);

            Part2();
            watch.Stop();
            Console.WriteLine($"Runtime: {watch.ElapsedMilliseconds} ms");
        }

        private void Part1()
        {

            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine(i+1);
                Loop();
                //Console.WriteLine($"After step {i+1}: {string.Join("",baseText)}");
            }
            var mostCommon = baseText.Max(x => baseText.Count(y => y == x));
            var leastcommon = baseText.Min(x => baseText.Count(y => y == x));

            //HashSet<char> set = new HashSet<char>(baseText);
            //set.ForEach(x => appearance.Add(x, baseText.Count(y => y == x)));

            Console.WriteLine($"Part 1: {mostCommon-leastcommon}");
        }

        private void Part2()
        {
            Dictionary<string, long> status = map;
            Dictionary<char, long> charcounter = new();


            for (int i = 0; i < input[0].Length; i++)
            {
                charcounter[input[0][i]] = charcounter.ContainsKey(input[0][i]) ? charcounter[input[0][i]] + 1 : 1;
            }

            for (int i = 0; i < 40; i++)
            {
                status = DoWork(status, charcounter);

            }


            long max = charcounter.Max(x => x.Value);
            long min = charcounter.Min(x => x.Value);

            Console.WriteLine($"Part 2 solution: {max-min}");

        }

        private void Loop()
        {
            Dictionary<int, char> changes = new();
            for (int i = 0; i < baseText.Count; i++)
            {
                string Pattern;

                if (i + 1 < baseText.Count)
                {
                    Pattern = baseText[i].ToString() + baseText[i + 1].ToString();


                }
                else
                {
                    break;
                }




                if (rules.ContainsKey(Pattern))
                {
                    changes.Add(i + 1, Convert.ToChar(rules.First(x => x.Key == Pattern).Value));


                }
            }
            int counter = 0; // shift value
            foreach (var updates in changes)
            {
                baseText.Insert(updates.Key + counter, updates.Value);
                counter++;
            }
        }

        private Dictionary<string,long> Converter(string text)
        {
            Dictionary<string,long> patterns = new();
            for (int i = 0; i < text.Length; i++)
            {
                string Pattern;

                if (i + 1 < text.Length)
                {
                    Pattern = text[i].ToString() + text[i + 1].ToString();
                    patterns[Pattern] = patterns.ContainsKey(Pattern) ? patterns[Pattern] + 1 : 1;


                }
                else
                {
                    break;
                }

            }
            return patterns;
        }

        private Dictionary<string,long> DoWork(Dictionary<string,long> patterns, Dictionary<char,long> chCounts)
        {
            Dictionary<string, long> updates = new Dictionary<string, long>();

            foreach (var path in patterns)
            {
                char newChar = Convert.ToChar(rules[path.Key]);

                chCounts[newChar] = chCounts.ContainsKey(newChar) ? chCounts[newChar] + path.Value : path.Value;

                string newString1 = "" + path.Key[0] + rules[path.Key];
                string newString2 = "" + rules[path.Key] + path.Key[1];

                updates[newString1] = updates.ContainsKey(newString1) ? path.Value + updates[newString1] : path.Value; 
                updates[newString2] = updates.ContainsKey(newString2) ? path.Value + updates[newString2] : path.Value; 
            }

            return updates;

        }






    }
}