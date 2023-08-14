using System.Security.Cryptography.X509Certificates;
using System.Text;
using cstesting;

class Program {
    static void Main() {
        Console.OutputEncoding = Encoding.Unicode;
        Console.Clear();

        bool gameOver = false;
        Renderer r = new(20, 10);
        Snake snake = new(r);

        while(!gameOver)
        {
            ConsoleKey input = Console.ReadKey().Key;
            if(input == ConsoleKey.Backspace) { 
                gameOver = true; 
                
            } else
            {
                snake.MoveHead(input);
            }
        }
    }

    static async Task SnakeMove()
    {
        await Task.Delay(1000); //delays 1 second.
    }
}