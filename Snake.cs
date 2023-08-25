using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cstesting
{
    internal class Snake
    {
        public GridTile[] SnakeList { get; private set; }

        private string SnakeGraphic = "\u25A0";
        private Renderer r;
        private int SpawnX;
        private int SpawnY;

        public Snake(Renderer _r, int _x, int _y)
        {
            this.r = _r;
            this.SpawnX = _x;
            this.SpawnY = _y;

            GridTile[] newSnake = { new GridTile(SpawnX, SpawnY, SnakeGraphic) };
            this.SnakeList = newSnake;
            r.UpdateGrid(newSnake);
        }

        public void Move(ConsoleKey key)
        {
            GridTile[] newSnakeList = new GridTile[SnakeList.Length + 1];
            SnakeList.CopyTo(newSnakeList, 0);

            GridTile lastSnakeBody = newSnakeList[newSnakeList.Length - 2];
            newSnakeList[newSnakeList.Length - 1] = new GridTile(lastSnakeBody.x, lastSnakeBody.y, " ");

            int[] previousBodyPos = { newSnakeList[0].x, newSnakeList[0].y };
            newSnakeList[0].x += key == ConsoleKey.RightArrow ? 1 : key == ConsoleKey.LeftArrow ? -1 : 0;
            newSnakeList[0].y += key == ConsoleKey.DownArrow ? 1 : key == ConsoleKey.UpArrow ? -1 : 0;

            for (int i = 1; i < SnakeList.Length; i++)
            {
                int[] currentBodyPos = { newSnakeList[i].x, newSnakeList[i].y };
                newSnakeList[i].x = previousBodyPos[0];
                newSnakeList[i].y = previousBodyPos[1];

                previousBodyPos = currentBodyPos;
            }

            r.UpdateGrid(newSnakeList);
        }

        public void AddBody(int[] spawnPos, int amount = 1)
        {
            GridTile[] newSnake = new GridTile[SnakeList.Length + amount];
            SnakeList.CopyTo(newSnake, 0);

            for (int i = 0; i < amount; i++) 
            {
                newSnake[(newSnake.Length - 1) + i] = new GridTile(spawnPos[0], spawnPos[1], SnakeGraphic);
            }

            SnakeList = newSnake;
            r.UpdateGrid(newSnake);
        }
    }
}
