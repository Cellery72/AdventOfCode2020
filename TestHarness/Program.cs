using AdventOfCode2020;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code 2020!");
            //Console.WriteLine("Day 1: Enter location of source text file");
            //var userPath = Console.ReadLine();
            string userPath = @"C:\Users\Justin Ellery\Documents\Github\AdventOfCode2020\Input\Day7.txt";
            //string userPath = @"C:\Users\Justin Ellery\Documents\Github\AdventOfCode2020\Input\Day5.txt";
            if(!string.IsNullOrEmpty(userPath))
            {
                try
                {
                    List<string> lines = File.ReadAllLines(userPath).ToList();
                    //List<Tuple<int, int>> slope = new List<Tuple<int, int>>()
                    //{
                    //    new Tuple<int, int>(1,1),
                    //    new Tuple<int, int>(1,3),
                    //    new Tuple<int, int>(1,5),
                    //    new Tuple<int, int>(1,7),
                    //    new Tuple<int, int>(2,1)
                    //};
                    var output = ChristmasMath.Day7Part1(lines);
                    Console.WriteLine("And the answer is... " + output);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Your file path is broken you dumby.");
                    Console.WriteLine("Here's your stupid error message: " + e.ToString());
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
}
