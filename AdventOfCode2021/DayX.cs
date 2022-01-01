using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2021D1
{
    internal class Puzz_13
    {
        private readonly List<(int X, int Y)> _points;
        private readonly List<(int X, int Y)> _foldAlongs;

        private IEnumerable<string> Entry { get; } = File.ReadAllLines("/Users/mac/Projects/AdventOfCode2021/AdventOfCode2021/day13.txt").ToList();

        public Puzz_13()
        {
            _points = Entry
                .Where(row => row.Contains(","))
                .Select(row => row.Split(','))
                .Select(e => (Convert.ToInt32(e[0]), Convert.ToInt32(e[1])))
                .Select(p => (X: p.Item1, Y: p.Item2))
                .ToList();

            _foldAlongs = Entry
                .Where(row => row.Contains("fold along"))
                .Select(row => row.Replace("fold along ", "").Split('='))
                .Select(axis => (X: axis[0] == "x" ? Convert.ToInt32(axis[1]) : 0,
                                 Y: axis[0] == "y" ? Convert.ToInt32(axis[1]) : 0))
                .ToList();
        }

        public int GiveMeTheAnswerPart10() =>
            _foldAlongs
                .Take(1)
                .SelectMany(fA => _points.Select(p => (X: Transform(fA.X, p.X),
                                                       Y: Transform(fA.Y, p.Y))))
                .Distinct()
                .Count();

        public List<string> GiveMeTheAnswerPart20()
        {
            var code = _foldAlongs
                .Aggregate(_points, (d, fA) => d.ToList()
                                                .Select(p => (X: Transform(fA.X, p.X),
                                                              Y: Transform(fA.Y, p.Y)))
                                                .ToList())
                .Distinct()
                .OrderBy(p => p.X)
                .ThenBy(p => p.Y)
                .ToList();

            var maxX = code.Max(p => p.X) + 1;
            return
                Enumerable.Range(0, code.Max(p => p.Y) + 1)
                    .Select(y =>
                        Enumerable.Range(0, maxX)
                            .Select(x => code.Contains((x, y)) ? "#" : ".")
                            .Aggregate(string.Empty, (concat, x) => $"{concat}{x}"))
                    .ToList();
        }

        private static int Transform(int fA, int axis) => fA > 0 && axis >= fA ? fA - (axis - fA) : axis;
    }
}