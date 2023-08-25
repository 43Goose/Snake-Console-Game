using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cstesting
{
    internal class Food : Consumable
    {
        private int Value;

        public Food(Renderer _r, int _x, int _y, string _graphic = "X", int _value = 1) : base(_r, _graphic, _x, _y) 
        {
            this.Value = _value;
        }

        public void Eat(Snake snake, ConsoleKey dir)
        {
            GridTile lastSnake = snake.SnakeList[snake.SnakeList.Length - 1];
            int spawnX = dir == ConsoleKey.LeftArrow ? lastSnake.x + 1 : dir == ConsoleKey.RightArrow ? lastSnake.x - 1 : lastSnake.x;
            int spawnY = dir == ConsoleKey.DownArrow ? lastSnake.y + 1 : dir == ConsoleKey.UpArrow ? lastSnake.y - 1 : lastSnake.y;
            int[] spawnPos = new int[2] { spawnX, spawnY };
            
            snake.AddBody(spawnPos, Value);

            Start:
            int randX = new Random().Next(1, r.Width - 1);
            int randY = new Random().Next(1, r.Height - 1);
            foreach (GridTile body in snake.SnakeList)
            {
                if(body.x == randX && body.y == randY) { goto Start; }
            }

            r.UpdateGrid(new GridTile[] { new GridTile(randX, randY, Graphic) });
        }
    }
}
