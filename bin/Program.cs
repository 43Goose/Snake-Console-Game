using System.Security.Cryptography.X509Certificates;
using System.Text;
using cstesting;

class Program {
    static void Main() {
        Console.OutputEncoding = Encoding.Unicode;
        Console.Clear();
        Renderer r = new(10, 5);
        Snake snake = new(r);

        ConsoleKey input = Console.ReadKey().Key;
        snake.MoveHead(input);
        Console.ReadKey();
    }
}