using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Models
{
    public class LuggageBag
    {
        public string BagColour { get => bagColour; set => bagColour = value; }
        public List<LuggageBag> BagsInside { get => bagsInside; set => bagsInside = value; }


        private string bagColour;
        private List<LuggageBag> bagsInside;


        public LuggageBag(string line)
        {
            BagsInside = new List<LuggageBag>();
            if(!string.IsNullOrEmpty(line))
            {
                BagColour = line.Split("bags contain")[0].Trim();
                string bagsInside = line.Split("bags contain")[1].Trim();
                if(bagsInside!="no other bags")
                {
                    string[] otherBags = bagsInside.Split(",");

                    foreach(string bag in otherBags)
                    {
                        string cleanedUpBag = bag.Trim().Replace(".",string.Empty);
                    }
                }
            }
        }

    }
}
