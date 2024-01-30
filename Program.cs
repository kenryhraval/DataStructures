
using System.IO.Compression;
using static DataStructures.Minesweeper;

namespace DataStructures
{
    internal class Program
    {
        /************ For GraphExample.cs *******/

        static void Main()
        {
            var spore = new GraphExample();
            spore.StartGame();
            bool on = true;

            while (on)
            {
                spore.GetDestinations();

                Console.WriteLine();
                Console.WriteLine("Es vēlos braukt uz... (vai n)");

                var dest = Console.ReadLine();
                if (dest != "n")
                {
                    spore.GoTo(dest);
                }
                else
                {
                    on = false;
                }
                Console.WriteLine();

            }
        }

        
        /*************** For VectorSum.cs
        static void Main()
        {
            VectorSum vectorSum = new VectorSum();
        }
        *****************/

        /*************** For Minesweeper.cs

        static void Main()
        {
            PlayGame();
        }

        static void PlayGame()
        {
            Minesweeper minesweeper = new Minesweeper();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Vai tu gribi redzēt, kur atrodas mīnas? (j/n): ");

            var opt = Console.ReadLine();
            if (opt == "j")
            {
                Console.WriteLine();
                minesweeper.PrintGrid();
            }

            while (true)
            {
                int row, col;

                // Get user input until a valid input is provided
                while (!UserInput.TryGetCellInput(out row, out col, minesweeper.Size)) { }

                // Make a move in the game and check if it's over or won
                bool gameOverOrWon = minesweeper.Play(row, col);

                // Print the updated game board
                minesweeper.PrintGameBoard();

                // Check if the game is over or won
                if (gameOverOrWon)
                {
                    break;
                }
            }
        }

        *************/



        /******* For ReturnPaleandrome.cs

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a string (or 'exit' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break; // Exit the loop if the user enters "exit"
                }

                ReturnPalendrome.PrintPalindrome(input);
            }
        }
            *********/

    }
}


