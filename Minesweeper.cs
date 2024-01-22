using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Minesweeper
    {
        private int[][] Grid { get; set; }

        private int[][] MineGrid { get; set; }
        private int Size { get; set; } // 10

        public Minesweeper(int size = 10)
        {
            Size = size;
            Grid = new int[size][];
            MineGrid = new int[size][];
            PopulateGrids();
            GetMineGrid();
        }

        public void PopulateGrids()
        {
            for (int i = 0; i < Size; i++)
            {
                Grid[i] = new int[Size]; // Initialize each sub-array
                for (int j = 0; j < Size; j++)
                {
                    Grid[i][j] = 0;
                }
            }
        }

        public void GetMineGrid()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(Grid[i][j]);
                }
            }
        }
    }
}
