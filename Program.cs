using System.Security.Cryptography.X509Certificates;
using System.Text;
using cstesting;

class Program {
    static void Main() {
        Console.OutputEncoding = Encoding.Unicode;
        Console.Clear();

        bool gameOver = false;
        int speed = 500;
        ConsoleKey lastKeyPress = ConsoleKey.DownArrow;

        Renderer r = new(20, 10);
        Snake snake = new(r, 5, 3);

        Console.ReadKey();
        DateTime timer = DateTime.Now.AddMilliseconds(speed);

        while(!gameOver)
        {

            //SNAKE MOVEMENT LOOP
            if(DateTime.Now >= timer || Console.KeyAvailable)
            {
                ConsoleKey input = lastKeyPress;
                if(Console.KeyAvailable) { input = lastKeyPress = Console.ReadKey().Key; }

                if (input == ConsoleKey.Backspace)
                {
                    gameOver = true;
                }
                else
                {
                    if (TestMove(input, snake, r))
                    {
                        snake.MoveHead(input);
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
                timer = DateTime.Now.AddMilliseconds(speed);
            }
        }
    }

    static bool TestMove(ConsoleKey key, Snake snake, Renderer r)
    {
        if (key == ConsoleKey.DownArrow)
        {
            return snake.SnakeList[0].y + 1 != r.Height - 1;
        }
        else if (key == ConsoleKey.UpArrow)
        {
            return snake.SnakeList[0].y - 1 != 0;
        }
        else if (key == ConsoleKey.RightArrow)
        {
            return snake.SnakeList[0].x + 1 != r.Width - 1;
        }
        else
        {
            return snake.SnakeList[0].x - 1 != 0;
        }
    }
}