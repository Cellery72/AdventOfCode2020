using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Models
{
    public class Passport
    {
        public bool Populating { get => populating; set => populating = value; }
        public bool IsValid
        {
            get
            {
                return (!string.IsNullOrEmpty(Byr) && !string.IsNullOrEmpty(Iyr) && !string.IsNullOrEmpty(Eyr)
                         && !string.IsNullOrEmpty(Hgt) && !string.IsNullOrEmpty(Hcl) && !string.IsNullOrEmpty(Ecl)
                         && !string.IsNullOrEmpty(Pid));
            }
        }
        public bool IsValidForAutoValidation
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(Byr) || string.IsNullOrEmpty(Eyr) || string.IsNullOrEmpty(Iyr))
                        return false;

                    int bYear = int.Parse(Byr);
                    if (bYear < 1920 || bYear > 2002)
                        return false;

                    int iYear = int.Parse(Iyr);
                    if (iYear < 2010 || iYear > 2020)
                        return false;

                    int eYear = int.Parse(Eyr);
                    if (eYear < 2020 || eYear > 2030)
                        return false;

                    if (string.IsNullOrEmpty(Hgt) || (!Hgt.ToLower().EndsWith("in") && !Hgt.ToLower().EndsWith("cm")))
                        return false;
                    else if (Hgt.ToLower().EndsWith("in")) 
                    {
                        string tempHeight = Hgt.Replace("in", string.Empty);
                        if (!tempHeight.All(c => char.IsDigit(c)))
                            return false;

                        int heightValue = int.Parse(Hgt.Where(Char.IsDigit).ToArray());
                        if (heightValue < 59 || heightValue > 76)
                            return false;
                    }
                    else if (Hgt.ToLower().EndsWith("cm"))
                    {
                        string tempHeight = Hgt.Replace("cm", string.Empty);
                        if (!tempHeight.All(c => char.IsDigit(c)))
                            return false;

                        int heightValue = int.Parse(Hgt.Where(Char.IsDigit).ToArray());
                        if (heightValue < 150 || heightValue > 193)
                            return false;
                    }

                    if(string.IsNullOrEmpty(Hcl) || !Hcl.StartsWith("#"))
                    {
                        return false;
                    }
                    else
                    {
                        Regex hairPattern = new Regex(@"^[a-f0-9]{6}$");

                        string hairValue = Hcl.Substring(1, Hcl.Length-1);
                        if (hairValue.Any(c => !Char.IsLetterOrDigit(c)))
                            return false;
                        else if (hairValue.Length != 6)
                            return false;
                        else
                        {
                            var hexValue = Int32.Parse(hairValue, System.Globalization.NumberStyles.HexNumber);
                        }
                    }

                    if (string.IsNullOrEmpty(Ecl))
                        return false;
                    else
                    {
                        List<string> validColours = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        if (!validColours.Contains(Ecl.ToLower()))
                            return false;
                    }

                    if (string.IsNullOrEmpty(Pid))
                        return false;
                    else if(Pid.Length!=9 || !Pid.All(c=>Char.IsDigit(c)))
                    {
                        return false;
                    }

                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }        
        }


        public string Byr { get => byr; set => byr = value; }
        public string Iyr { get => iyr; set => iyr = value; }
        public string Eyr { get => eyr; set => eyr = value; }
        public string Hgt { get => hgt; set => hgt = value; }
        public string Hcl { get => hcl; set => hcl = value; }
        public string Ecl { get => ecl; set => ecl = value; }
        public string Pid { get => pid; set => pid = value; }
        public string Cid { get => cid; set => cid = value; }

        private string byr;
        private string iyr;
        private string eyr;
        private string hgt;
        private string hcl;
        private string ecl;
        private string pid;
        private string cid;
        private bool populating;
    }
    enum Requirements
    {
        [Description("Birth Year")]
        byr = 0,
        [Description("Issue Year")]
        iyr,
        [Description("Expiration Year")]
        eyr,
        [Description("Height")]
        hgt,
        [Description("Hair Colour")]
        hcl,
        [Description("Eye Colour")]
        ecl,
        [Description("Passport ID")]
        pid,
        [Description("CountryId")]
        cid
    }
}
