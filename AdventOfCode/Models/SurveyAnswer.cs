using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Models
{
    public class SurveyAnswer
    {
        public List<string> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
            }
        }
        public bool Populating { get => populating; set => populating = value; }
        public int TotalAnswers => Answers == null ? 0 : Answers.Aggregate((i, j) => i += j).Distinct().Count();
        public int TotalSameAnswers
        {
            get
            {
                if (Answers == null)
                    return 0;
                else
                {
                    List<Tuple<char, int>> countOfCharacters = new List<Tuple<char, int>>();
                    string totalAnswers = Answers.Aggregate((i,j)=>i+=j);

                    foreach(char c in totalAnswers)
                        if(!countOfCharacters.Exists(t => t.Item1 == c))
                            countOfCharacters.Add(new Tuple<char, int>(c, totalAnswers.Where(a=>a==c).Count()));

                    return countOfCharacters.Where(cc => cc.Item2 == Answers.Count).Count();
                }
            }

        }


        private List<string> answers { get; set; }
        private bool populating { get; set; }

        public SurveyAnswer(string firstAnswer)
        {
            Answers = new List<string>();
            Answers.Add(firstAnswer);
            Populating = true;
        }

        public void AddAnswerToList(string contents)
        {
            Answers.Add(contents);
        }
    }
}
