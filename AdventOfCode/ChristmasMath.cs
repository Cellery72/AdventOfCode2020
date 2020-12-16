using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class ChristmasMath
    {
        public static int Day1Part1(List<string> input)
        {
            for (int i = 0; i < input.Count; ++i)
            {
                int currentValue = int.Parse(input[i]);
                List<string> remainingItems = input;
                remainingItems.RemoveAt(i);

                foreach (var item in remainingItems)
                {
                    int itemValue = int.Parse(item);
                    if (itemValue + currentValue == 2020) return itemValue * currentValue;
                }
            }
            return -1;
        }
        public static int Day1Part2(List<string> input)
        {
            for (int i = 0; i < input.Count; ++i)
            {
                int firstValue = int.Parse(input[i]);
                for (int j = 0; j < input.Count; ++j)
                {
                    int secondValue = int.Parse(input[j]);
                    for (int k = 0; k < input.Count; ++k)
                    {
                        int thirdValue = int.Parse(input[k]);
                        if (firstValue + secondValue + thirdValue == 2020) return firstValue * secondValue * thirdValue;
                    }
                }
            }
            return -1;
        }

        public static int Day2Part1(List<string> input)
        {
            int validPasswordCount = 0;

            foreach (string line in input)
            {
                string passwordPolicy = line.Split(':', StringSplitOptions.None)[0].Trim();
                char requiredCharacter = passwordPolicy.Last();
                passwordPolicy = passwordPolicy.Remove(passwordPolicy.Length - 1);

                int minimum = int.Parse(passwordPolicy.Split('-', StringSplitOptions.None)[0].Trim());
                int maximum = int.Parse(passwordPolicy.Split('-', StringSplitOptions.None)[1].Trim());

                string password = line.Split(':', StringSplitOptions.None)[1].Trim();
                int characterCount = password.Count(c => c == requiredCharacter);

                if (characterCount >= minimum && characterCount <= maximum) validPasswordCount++;
            }

            return validPasswordCount;
        }
        public static int Day2Part2(List<string> input)
        {
            int validPasswordCount = 0;

            foreach (string line in input)
            {
                string passwordPolicy = line.Split(':', StringSplitOptions.None)[0].Trim();
                char requiredCharacter = passwordPolicy.Last();
                passwordPolicy = passwordPolicy.Remove(passwordPolicy.Length - 1);

                int firstLocation = int.Parse(passwordPolicy.Split('-', StringSplitOptions.None)[0].Trim()) - 1;
                int secondLocation = int.Parse(passwordPolicy.Split('-', StringSplitOptions.None)[1].Trim()) - 1;

                string password = line.Split(':', StringSplitOptions.None)[1].Trim();
                int characterCount = password.Count(c => c == requiredCharacter);

                if (password[firstLocation] == requiredCharacter && password[secondLocation] != requiredCharacter || password[secondLocation] == requiredCharacter && password[firstLocation] != requiredCharacter)
                    validPasswordCount++;
            }

            return validPasswordCount;
        }

        public static int Day3Part1(List<string> input, int down, int right)
        {
            int totalLines = input.Count;
            int currentColumnNumber = 1;
            int totalTreesHit = 0;

            for(int i=1; i<=totalLines;)
            {
                string currentLine = input[i - 1];

                if(currentColumnNumber>currentLine.Length)
                    currentColumnNumber = currentColumnNumber % currentLine.Length;

                if(currentLine[currentColumnNumber-1]=='#')
                    totalTreesHit++;


                i += down;
                currentColumnNumber += right;
            }

            return totalTreesHit;
        }
        public static long Day3Part2(List<string> input, List<Tuple<int,int>> slopes)
        {
            List<int> treesHit = new List<int>();
            long product = 0;

            foreach (var slope in slopes)
                treesHit.Add(Day3Part1(input, slope.Item1, slope.Item2));

            for(int i=0; i< treesHit.Count;++i)
            {
                if (i != 0)
                    product *= treesHit[i];
                else
                    product = treesHit[i];
            }

            return product;
        }
    }
}
