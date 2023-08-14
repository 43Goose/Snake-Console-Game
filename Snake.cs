using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cstesting
{
    internal class Snake
    {
        public GridTile[] SnakeList { get; private set; }
        public Renderer r;

        public Snake(Renderer _r)
        {
            r = _r;
            GridTile[] newSnake = { new GridTile(1, 2, "O") };
            SnakeList = newSnake;
            r.UpdateGrid(newSnake);
        }

        public void MoveHead(ConsoleKey key)
        {
            GridTile[] newSnakeList = new GridTile[SnakeList.Length + 1];
            SnakeList.CopyTo(newSnakeList, 0);

            GridTile lastSnakeBody = newSnakeList[newSnakeList.Length - 2];
            newSnakeList[newSnakeList.Length - 1] = new GridTile(lastSnakeBody.x, lastSnakeBody.y, " ");

            if (key == ConsoleKey.DownArrow)
            {
                newSnakeList[0].y += 1;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                newSnakeList[0].y -= 1;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                newSnakeList[0].x += 1;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                newSnakeList[0].x -= 1;
            }

            r.UpdateGrid(newSnakeList);
        }
    }
}
