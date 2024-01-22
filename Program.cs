
using static DataStructures.Minesweeper;

namespace DataStructures
{
    internal class Program
    {


        /********* For Minesweeper *********/

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





        /******* For ReturnPaleandrome
             
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


