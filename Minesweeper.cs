using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace DataStructures
{
    public class Minesweeper
    {
        private int[][] Grid { get; set; }
        private int[][] MineGrid { get; set; }
        private bool[][] Revealed { get; set; }
        public int Size { get; set; }

        public Minesweeper(int size = 4)
        {
            Size = size;
            Grid = new int[size][];
            MineGrid = new int[size][];
            Revealed = new bool[size][];

            PopulateLevel();
            PrintGameBoard();
        }


        private void PopulateLevel()
        {
            var random = new Random();
            for (int i = 0; i < Size; i++)
            {
                Grid[i] = new int[Size];
                MineGrid[i] = new int[Size];
                Revealed[i] = new bool[Size];

                for (int j = 0; j < Size; j++)
                {
                    Grid[i][j] = 0;
                    Revealed[i][j] = false;

                    var chance = random.Next(10);
                    if (chance == 0)
                    {
                        MineGrid[i][j] = 1;
                    }
                    else
                    {
                        MineGrid[i][j] = 0;
                    }
                }
            }

            // Detektorus pēc tam 
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (MineGrid[i][j] == 1)
                    {
                        PopulateDetectors(i, j);
                    }
                }
            }

            // Add debug information
            Console.WriteLine("Līmenis izveidots, spēle sākas.");
            PrintGrid();

        }


        private void PopulateDetectors(int i, int j)
        {
            // V
            if (i - 1 >= 0)
            {
                Grid[i - 1][j]++;
                if (j - 1 >= 0)
                    Grid[i - 1][j - 1]++;
                if (j + 1 < Size)
                    Grid[i - 1][j + 1]++;
            }

            if (i + 1 < Size)
            {
                Grid[i + 1][j]++;
                if (j - 1 >= 0)
                    Grid[i + 1][j - 1]++;
                if (j + 1 < Size)
                    Grid[i + 1][j + 1]++;
            }

            // H
            if (j - 1 >= 0)
                Grid[i][j - 1]++;
            if (j + 1 < Size)
                Grid[i][j + 1]++;
        }

        // Atblusošanai (for debug)
        private void PrintGrid()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (MineGrid[i][j]==1)
                    { 
                        Console.Write("X "); 
                    }
                    else
                    {
                        Console.Write(Grid[i][j] + " ");
                    }
                    
                    
                }
                Console.WriteLine();
            }
        }
        //

        public void PrintGameBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    if (Revealed[i][j])
                    {
                        if (MineGrid[i][j] == 1)
                            Console.Write("X ");
                        else
                            Console.Write(Grid[i][j] + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
            }
        }

        public bool Play(int row, int col)
        {
            if (MineGrid[row][col] == 1)
            {
                Console.WriteLine("Spēles beigas! Tu uzdūries mīnai!");
                Revealed[row][col] = true;
                return true;
            }
            else
            {
                RevealCell(row, col);

                if (AllNonMineCellsRevealed())
                {
                    Console.WriteLine("Tu uzvarēji!");
                    return true;
                }

                return false; // Spēle turpinās
            }
        }

        private bool AllNonMineCellsRevealed()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (MineGrid[i][j] == 0 && !Revealed[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void RevealCell(int row, int col)
        {
            Revealed[row][col] = true;

            
        }
    }

    public class UserInput
    {
        public static bool TryGetCellInput(out int row, out int col, int size)
        {
            Console.WriteLine();
            Console.Write("Ievadi rindu (0 līdz {0}): ", size - 1);
            if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < size)
            {
                Console.Write("Ievadi kolonnu (0 līdz {0}): ", size - 1);
                if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < size)
                {
                    return true;
                }
            }

            Console.WriteLine("Lūdzu ievadīt derīgus skaitļus.");
            row = col = -1;
            return false;
        }
    }
}


