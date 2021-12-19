using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode2021;

namespace AOC2021D1
{
    class Program
    {
        static void Main(string[] args)
        {


            Day8 day8 = new Day8();
            Console.WriteLine("START");
            day8.Part2Solution();
            var fasz = day8.vegeredmenyek;

            Console.WriteLine("DONE");
            
            Console.ReadKey();
        }


        public static string[] input(string path)
        {
            var smh = File.ReadAllLines(path);
            return smh;
        }

        public static string inputstring(string path) {
            var smh = File.ReadAllText(path);
            return smh;
        }

        public static void Day1()
        {
            var inputFile = input(@"day1.txt");
            List<int> listint = new List<int>();
            foreach (var item in inputFile)
            {
                listint.Add(Convert.ToInt32(item));
            }
            int counter = 0;
            for (int i = 0; i < listint.Count - 1; i++)
            {
                if (listint[i + 1] > listint[i])
                {
                    counter++;
                }
            }

            Console.WriteLine($"Day1 Part1: {counter}");
        }

        public static void Day1Part2()
        {
            var inputFile = input(@"day1.txt");
            List<int> listint = new List<int>();
            foreach (var item in inputFile)
            {
                listint.Add(Convert.ToInt32(item));
            }
            int counter = 0;

            int lastgroup = listint[0] + listint[1] + listint[2];
            for (int i = 0; i < listint.Count - 2; i++)
            {

                var group = listint[i] + listint[i + 1] + listint[i + 2];

                if (group > lastgroup)
                {
                    counter++;
                    System.Threading.Thread.Sleep(0);
                    Console.WriteLine($"Last group sum was: {lastgroup} || Current group sum is {group} || {group} > {lastgroup} so counter is {counter} ");

                    lastgroup = group;
                }
                else
                {
                    System.Threading.Thread.Sleep(0);
                    Console.WriteLine($"Last group sum was: {lastgroup} || Current group sum is {group} || {group} < {lastgroup} so counter is {counter} ");
                    lastgroup = group;
                }
            }

            Console.WriteLine($"Day1 Part 2: {counter}");
        }

        public static void Day2Part1()
        {
            var inputfile = input(@"day1.txt");

            int forward = 0;
            int depth = 0;

            foreach (var item in inputfile)
            {
                var temp = item.Split(' ');
                if (temp[0] == "forward")
                {
                    forward = forward + int.Parse(temp[1]);
                }
                else if (temp[0] == "up")
                {
                    depth = depth - int.Parse(temp[1]);
                }
                else // down
                {
                    depth = depth + int.Parse(temp[1]);
                }
            }

            Console.WriteLine($"Day2Part1: {forward * depth}");

        }

        public static void Day2Part2()
        {
            var inputfile = input(@"day2.txt");

            int forward = 0;
            int depth = 0;
            int aim = 0;

            foreach (var item in inputfile)
            {
                var temp = item.Split(' ');
                if (temp[0] == "forward")
                {
                    forward = forward + int.Parse(temp[1]);
                    depth = depth + aim * int.Parse(temp[1]);
                }
                else if (temp[0] == "up")
                {
                    aim = aim - int.Parse(temp[1]);
                }
                else // down
                {
                    aim = aim + int.Parse(temp[1]);
                }
            }

            Console.WriteLine($"Day2Part2: {forward * depth}");
        }

        public static void Day3Part1()
        {
            var inputfile = input(@"Day3.txt");

            var bitcount = inputfile[0].Length;
            var linecount = inputfile.Count();

            int[,] matrix = new int[linecount, bitcount];


            for (int x = 0; x < linecount; x++)
            {
                for (int y = 0; y < bitcount; y++)
                {


                    matrix[x, y] = Convert.ToInt32(char.GetNumericValue(inputfile[x][y]));
                }
            }

            List<int> gammaValuesByColumn = new List<int>();
            List<int> epsilonValuesByColumn = new List<int>();
            for (int y = 0; y < bitcount; y++)
            {
                List<int> columnvalues = new List<int>();
                for (int x = 0; x < linecount; x++)
                {
                    columnvalues.Add(matrix[x, y]);


                }
                var Zeros = columnvalues.Where(x => x == 0).Count();
                var Ones = columnvalues.Where(x => x == 1).Count();


                if (Zeros > Ones)
                {
                    gammaValuesByColumn.Add(0);
                    epsilonValuesByColumn.Add(1);
                }
                else
                {
                    gammaValuesByColumn.Add(1);
                    epsilonValuesByColumn.Add(0);
                }



            }
            var gammav = string.Join("", gammaValuesByColumn.Select(x => x.ToString()).ToArray());
            var epsilonv = string.Join("", epsilonValuesByColumn.Select(x => x.ToString()).ToArray());
            var gammaDec = Convert.ToInt32(gammav, 2);
            var epsilondec = Convert.ToInt32(epsilonv, 2);
            Console.WriteLine($"Gamma: {gammav} --> {gammaDec}");

            Console.WriteLine($"Epsilon: {epsilonv} --> {epsilondec}");

            Console.WriteLine($"Day3Part1: {epsilondec * gammaDec}");


        }

        private static void Day3Part2Oxygen()
        {
            var inputFile = input(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/Day3.txt");

            //Check binaries vertically => Get most common bit => take the numbers starting with the most common bit
            //Check binaries vertically => Get most common bit => take the numbers that has this value on the 2nd
            //... recursion

            var bitcount = inputFile[0].Length;
            var linecount = inputFile.Count();

            int[,] matrix = new int[linecount, bitcount];

            // int[12, 5] x ==> 12 sor , y ==> 5 oszlop 
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {

                    matrix[x, y] = Convert.ToInt32(char.GetNumericValue(inputFile[x][y]));
                }
            }

            var matrix2 = matrix;
            for (int i = 0; i < bitcount; i++)
            {
                //bitek számán loopolunk
                // todo kinyerjük a 1 és 0 bitek számát az i pozícióból
                // todo amelyik bitből több van azokat a bináris értékeket megtartjuk és mátrixot csinálunk belőle
                // todo ismételjük a folyamatot majd az i-t inkrementáljuk
                // todo Utolsó szám a megoldás
                
                int mostCommonBit = Day3GetMostCommonBit(matrix2,i,matrix2.GetLength(0));
                int leastCommonBit = Day3GetLeastCommonBit(matrix2,i,matrix2.GetLength(0));
                List<int> newBits = new List<int>();
                for (int x = 0; x < matrix2.GetLength(0); x++)
                {
                    if (matrix2[x, i] == mostCommonBit)
                    {
                        for (int y = 0; y < matrix2.GetLength(1); y++)
                        {
                            newBits.Add(matrix2[x, y]);
                        }
                    }

                }
                int counter = 0;
                int[,] newMatrix = new int[newBits.Count/12,bitcount];
                
                for (int x = 0; x < newBits.Count/12; x++)
                {
                    for (int y = 0; y < bitcount; y++)
                    {
                        newMatrix[x, y] = newBits[counter];
                        counter++;
                    }
                }
                if (newMatrix.Length == bitcount)
                {
                    matrix2 = newMatrix;
                    break;
                }
                matrix2 = newMatrix;

            }


            Console.WriteLine("Oxygen generator rating: ");
            List<int> chars = new List<int>();
            foreach (var item in matrix2)
            {
                Console.Write(item);
                chars.Add(item);
            }
            string fasz = string.Join("", chars.Select(x => x.ToString()));
            Console.WriteLine($" Decimal: {Convert.ToInt32(fasz, 2)}");

        }

        private static void Day3Part2CO2()
        {
            var inputFile = input(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/Day3.txt");

            //Check binaries vertically => Get most common bit => take the numbers starting with the most common bit
            //Check binaries vertically => Get most common bit => take the numbers that has this value on the 2nd
            //... recursion

            var bitcount = inputFile[0].Length;
            var linecount = inputFile.Count();

            int[,] matrix = new int[linecount, bitcount];

            // int[12, 5] x ==> 12 sor , y ==> 5 oszlop 
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {

                    matrix[x, y] = Convert.ToInt32(char.GetNumericValue(inputFile[x][y]));
                }
            }

            var matrix2 = matrix;
            for (int i = 0; i < bitcount; i++)
            {
                //bitek számán loopolunk
                // todo kinyerjük a 1 és 0 bitek számát az i pozícióból
                // todo amelyik bitből több van azokat a bináris értékeket megtartjuk és mátrixot csinálunk belőle
                // todo ismételjük a folyamatot majd az i-t inkrementáljuk
                // todo Utolsó szám a megoldás

                //int mostCommonBit = Day3GetMostCommonBit(matrix2, i, matrix2.GetLength(0));
                int leastCommonBit = Day3GetLeastCommonBit(matrix2, i, matrix2.GetLength(0));
                List<int> newBits = new List<int>();
                for (int x = 0; x < matrix2.GetLength(0); x++)
                {
                    if (matrix2[x, i] == leastCommonBit)
                    {
                        for (int y = 0; y < matrix2.GetLength(1); y++)
                        {
                            newBits.Add(matrix2[x, y]);
                        }
                    }

                }
                int counter = 0;
                int[,] newMatrix = new int[newBits.Count / 12, bitcount];

                for (int x = 0; x < newBits.Count / 12; x++)
                {
                    for (int y = 0; y < bitcount; y++)
                    {
                        newMatrix[x, y] = newBits[counter];
                        counter++;
                    }
                }
                if (newMatrix.Length == bitcount)
                {
                    matrix2 = newMatrix;
                    break;
                }
                matrix2 = newMatrix;

            }


            Console.WriteLine("CO2 generator rating: ");
            List<int> chars = new List<int>();
            foreach (var item in matrix2)
            {
                Console.Write(item);
                chars.Add(item);
            }
            string fasz = string.Join("", chars.Select(x => x.ToString()));
            Console.WriteLine($" Decimal: {Convert.ToInt32(fasz,2)}");

        }

        public static int Day3GetMostCommonBit(int[,] matrix, int index, int linecount)
        {
            List<int> OszlopIntek = new List<int>();
            for (int i = 0; i < linecount; i++)
            {
               OszlopIntek.Add(matrix[i,index]);
            }
            if (OszlopIntek.Count(x => x == 0) > OszlopIntek.Count(x => x == 1))
            {
                return 0;
            }
            else if (OszlopIntek.Count(x => x == 0) == OszlopIntek.Count(x => x == 1))
            {
                return 1;
            }
            else
            {
                return 1;
            }
                
            


        }

        public static int Day3GetLeastCommonBit(int[,] matrix, int index, int linecount)
        {
            List<int> OszlopIntek = new List<int>();
            for (int i = 0; i < linecount; i++)
            {
                OszlopIntek.Add(matrix[i, index]);
            }
            if (OszlopIntek.Count(x => x == 0) > OszlopIntek.Count(x => x == 1))
            {
                return 1;
            }
            else if (OszlopIntek.Count(x => x == 0) == OszlopIntek.Count(x => x == 1))
            {
                return 0;
            }
            else
            {
                return 0;
            }




        }



        public static void Day4Part1()
        {
            var inputfile = File.ReadAllLines(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/Day4.txt").ToList();
            List<int> szamok = new List<int>();
            List<int> HuzoSzamok = new List<int>();
            Day4Number[,] matrix = new Day4Number[5, 5];
            List<Day4Number[,]> matrixList = new List<Day4Number[,]>();
            //List<dynamic> matrixList = new List<dynamic>();
            
            inputfile[0].Split(',').ToList().ForEach(x => HuzoSzamok.Add(Convert.ToInt32(x)));
            inputfile.RemoveAt(0);
            inputfile.RemoveAt(0);

            Regex regex = new Regex("[0-9]{1,2}");

            for (int i = 0; i < inputfile.Count; i++)
            {
                if (inputfile[i] == "")
                {

                }
                else
                {
                  regex.Matches(inputfile[i]).ToList().ForEach(x => szamok.Add(Convert.ToInt32(x.Value)));
                }
            }
            int Szamokcounter = 0;

            for (int i = 0; i < szamok.Count/25; i++)
            {
                matrixList.Add(new Day4Number[5,5]);
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    for (int y = 0; y < matrix.GetLength(1); y++)
                    {

                        matrixList[i][x, y] = new Day4Number { value = szamok[Szamokcounter], Marked = false };
                        Szamokcounter++;
                    
                
                    }
                }
                
                

            }

            List<Day4Number> testSor = new List<Day4Number>();
            List<Day4Number> testOszlop = new List<Day4Number>();
            List<int> returns = new List<int>();
            Tuple<bool, int, int,int> winner = null;
            List<Tuple<bool, int, int, int>> winners = new List<Tuple<bool, int, int, int>>();

            for (int m = 0; m < matrixList.Count; m++)
            {
                matrix = matrixList[m];
                Console.WriteLine($"Mátrix soros: {m}.");


                // 7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

                for (int i = 0; i < HuzoSzamok.Count; i++)
                {
                    //Console.WriteLine($"{i}. kör: A nyerőszám a {HuzoSzamok[i]}");
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (matrix[x, y].value == HuzoSzamok[i])
                            {
                                matrix[x, y].Mark();

                                //Console.WriteLine($"{matrix[x, y].value} Has Been marked in round {i}");


                            }

                        }
                    }
                    
                    var result = Has5MarkedInLine(matrix, m, i);
                    if (result.Item1)
                    {

                        winners.Add(result);
                        returns.Add(result.Item2);
                        
                        break;
                    }
                }
            }


            var win = winners.Select(x => x.Item2).Min();
            
            var faszom = HuzoSzamok[win]; // x számnál nyert
            var faszom2 = winners.Where(x => x.Item2 == win).First();
;
            Console.WriteLine($"Matrix szam: {faszom2.Item4}");
            Console.WriteLine($"Nyertes szám: {faszom2.Item2}");
            Console.WriteLine($"Nem tagel szumma: {faszom2.Item3}");
            Console.WriteLine($"Day4 Part1 megoldás: {faszom2.Item3 * faszom}");


            var lose = winners.Select(x => x.Item2).Max();
            var valamicske = HuzoSzamok[lose];
            var valamicske2 = winners.Where(x => x.Item2 == lose).First();

            Console.WriteLine($"Matrix szam: {valamicske2.Item4}");
            Console.WriteLine($"Nyertes szám: {valamicske2.Item2}");
            Console.WriteLine($"Nem tagel szumma: {valamicske2.Item3}");
            Console.WriteLine($"Day4 Part2 megoldás: {valamicske2.Item3 * valamicske}");

            
           

   
 




            






        }

        //    x1 x2 x3 x4 x5
        // x1 01 02 03 04 05
        // x2 06 07 08 09 10
        // x3 11 12 13 14 15
        // x4 16 17 18 19 20
        // x5 21 22 23 24 25
        //

        public static Tuple<bool, int,int,int> Has5MarkedInLine(Day4Number[,] matrix, int matrixnum, int huzoszam)
        {
            for (int x = 0; x < 5; x++)
            {
                if (matrix[x,0].Marked == true && matrix[x, 1].Marked == true && matrix[x, 2].Marked == true && matrix[x, 3].Marked == true && matrix[x, 4].Marked == true)
                {
                    //Console.WriteLine($"A(z) {x}. sorban 5db marke van");
                    Console.WriteLine($"---------A {matrixnum}. matrix a {huzoszam}-nal lett true---------");
                    int summer = 0;
                    for (int x2 = 0; x2 < 5; x2++)
                    {
                        for (int y2 = 0; y2 < 5; y2++)
                        {
                            if (matrix[x2,y2].Marked == false)
                            {
                                summer = summer + matrix[x2, y2].value;
                            }
                        }
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine();
                    return new Tuple<bool, int,int,int>(true,huzoszam,summer,matrixnum);
   
                }
            }

            for (int y = 0; y < 5; y++)
            {
                if (matrix[0, y].Marked == true && matrix[1, y].Marked == true && matrix[2, y].Marked == true && matrix[3, y].Marked == true && matrix[4, y].Marked == true)
                {
                    //Console.WriteLine($"A(z) {y}. oszlopban 5db mark van");
                    Console.WriteLine($"--------A {matrixnum}. matrix a {huzoszam}-nal lett true--------");
                    int summer = 0;
                    for (int x2 = 0; x2 < 5; x2++)
                    {
                        for (int y2 = 0; y2 < 5; y2++)
                        {
                            if (matrix[x2, y2].Marked == false)
                            {
                                summer = summer + matrix[x2, y2].value;
                            }
                        }
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine();
                    return new Tuple<bool, int,int,int>(true, huzoszam,summer,matrixnum);

                }
            }

            return new Tuple<bool, int,int,int>(false, 99,0,0);
        
            

        }

        public static void Day5Part1()
        {
            var inputfile = input(@"/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/Day5.txt");
            Regex regex = new Regex("[0-9]{1,3}");
            List<Vektor> vektorok = new List<Vektor>();
            int part1 = 7142;
            List<Tuple<int, int>> koordinataLista = new List<Tuple<int, int>>();
            List<Tuple<int, int>> koordinata = new List<Tuple<int, int>>();
            List<int> countTracker = new List<int>();
            foreach (var vektor in inputfile)
            {
                var matches = regex.Matches(vektor);
                vektorok.Add(new Vektor(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[2].Value), Convert.ToInt32(matches[3].Value)));
            }


            //var EgySorosVektorok = vektorok.Where(x => x.Line).ToList();
            Console.WriteLine("PART 1 PASS");


            //vektorok[0].CoversPoints();


            foreach (var item in vektorok)
            {
                foreach (var tuple in item.coordinateCollection)
                {
                    koordinataLista.Add(tuple);
                }
            }
            Console.WriteLine("PART 2 PASS");
            koordinata = koordinataLista.Distinct().ToList();
            Console.WriteLine("PART 3 PASS");
            Console.WriteLine($"koordinata count: {koordinata.Count}");
            for (int i = 0; i < koordinata.Count; i++)
            {
                Console.WriteLine($"I = {i}");

                if (koordinataLista.Count(x => x.Item1 == koordinata[i].Item1 && x.Item2 == koordinata[i].Item2) > 1)
                {
                    countTracker.Add(1);
                    
                }
                else
                {
                    countTracker.Add(0);
                }
                
            }
            Console.WriteLine("PART 4 PASS");
            Console.WriteLine(countTracker.Count(x => x == 1));
            Console.WriteLine("PART 5 PASS");

        }

    }
}
