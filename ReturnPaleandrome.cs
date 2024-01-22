
namespace DataStructures
{
    internal class ReturnPalendrome
    {
        public static void PrintPalindrome(string textInput)
        {
            var text = textInput;
            var charList = text.ToList();

            Stack<char> charStack = new Stack<char>();

            var result = string.Empty;

            foreach (var character in charList)
            {
                charStack.Push(character);
                Console.Write(character);
            }

            Console.WriteLine(); // Add a newline for clarity

            while (charStack.Count > 0)
            {
                Console.Write(charStack.Pop());
            }

            Console.WriteLine(); // Add a newline for clarity
        }
    }
}


