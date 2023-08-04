using System.Security.Cryptography.X509Certificates;
using System.Text;
using snake;

class Program {
    static void Main() {
        Console.OutputEncoding = Encoding.Unicode;
        Renderer r = new();
        Snake snake = new();
        Console.Clear();
        r.InitializeGrid();
        snake.SpawnSnake(r);

        ConsoleKey input = Console.ReadKey().Key;
        r.UpdateGrid(snake.MoveHead(input));
        Console.ReadKey();
    }
}

class Snake {
    public List<GridTile> SnakeList {get; private set;} = new();

    public void SpawnSnake(Renderer r) {
        SnakeList.Add(new GridTile(5, 6, "O"));
        r.UpdateGrid(SnakeList);
    }

    public List<GridTile> MoveHead(ConsoleKey key) {
        List<GridTile> newSnakeList = SnakeList;

        if(key == ConsoleKey.DownArrow) {
            newSnakeList[0].y += 1;
        } else if(key == ConsoleKey.UpArrow) {
            newSnakeList[0].y -= 1;
        } else if(key == ConsoleKey.RightArrow) {
            newSnakeList[0].x += 1;
        } else if(key == ConsoleKey.LeftArrow) {
            newSnakeList[0].x -= 1;
        }

        SnakeList = newSnakeList;
        return newSnakeList;
    }
}