using System;
namespace AdventOfCode2021
{
    public class Day4Number
    {
        public Day4Number()
        {
            Marked = false;
        }

        public int value { get; set; }
        public bool Marked { get; set; }

        public void Mark()
        {
            Marked = true;
        }
    }
}
