using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Models
{

    public class BoardingPass
    {
        public string BoardingPassContents { get => boardingPassContents; set => boardingPassContents = value; }
        public int Row => CalculateRow();
        public int Column => CalculateColumn();
        public int SeatID => CalculateSeatID();
        private string boardingPassContents;

        public BoardingPass(string passContents)
        {
            BoardingPassContents = passContents;
        }

        private int CalculateRow()
        {
            if (!string.IsNullOrEmpty(BoardingPassContents) && BoardingPassContents.Length==10)
            {
                string row = BoardingPassContents.Substring(0,7).Replace("F", "0").Replace("B", "1");
                return Convert.ToInt32(row, 2);
            }
            else
                return 1;
        }
        private int CalculateColumn()
        {
            if (!string.IsNullOrEmpty(BoardingPassContents) && BoardingPassContents.Length == 10)
            {
                string column = BoardingPassContents.Substring(7, 3).Replace("L", "0").Replace("R", "1");
                return Convert.ToInt32(column, 2);
            }
            else
                return 1;
        }
        private int CalculateSeatID()
        {
            return (Row * 8) + Column;
        }
    }
}
