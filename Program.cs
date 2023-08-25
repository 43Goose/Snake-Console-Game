using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using cstesting;

class Program {
    static void Main() {
        Console.OutputEncoding = Encoding.Unicode;
        Console.Clear();

        int gridX = 20;
        int gridY = 40;
        bool gameOver = false;
        int speed = 250;
        ConsoleKey lastKeyPress = ConsoleKey.DownArrow;

        Renderer r = new(gridY, gridX);
        Snake snake = new(r, 5, 3);

        Console.ReadKey();
        Food foodObj = new(r, 10, 6);
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
                    if (TestMove(input, snake, r, foodObj))
                    {
                        snake.Move(input);
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

    static bool TestMove(ConsoleKey key, Snake snake, Renderer r, Food foob)
    {
        string gameOver = @"^[\u250F\u2517\u2513\u251B\u2501\u2502\u25A0]$";

        int nextTileX = key == ConsoleKey.LeftArrow ? snake.SnakeList[0].x - 1 : key == ConsoleKey.RightArrow ? snake.SnakeList[0].x + 1 : snake.SnakeList[0].x;
        int nextTiley = key == ConsoleKey.UpArrow ? snake.SnakeList[0].y - 1 : key == ConsoleKey.DownArrow ? snake.SnakeList[0].y + 1 : snake.SnakeList[0].y;
        string nextTileContent = r.Grid[nextTiley, nextTileX].content;

        if(nextTileContent == foob.Graphic)
        {
            foob.Eat(snake, key);
        }

        return !Regex.IsMatch(nextTileContent, gameOver);
    }
}