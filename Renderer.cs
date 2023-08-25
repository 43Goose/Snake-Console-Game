using System.Dynamic;
namespace cstesting {
    internal class Renderer {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public GridTile[,] Grid { get; private set; }

        public Renderer(int _width, int _height)
        {
            this.Width = _width;
            this.Height = _height;
            this.Grid = new GridTile[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == 0 || i == Height - 1)
                    {
                        if(j == 0)
                        {
                            Grid[i, j] = new GridTile(j, i, i == 0 ? "\u250F" : "\u2517");
                        }
                        else if (j == Width - 1)
                        {
                            Grid[i, j] = new GridTile(j, i, i == 0 ? "\u2513" : "\u251B");
                        }
                        else
                        {
                            Grid[i, j] = new GridTile(j, i, "\u2501");
                        }
                    }
                    else if (j == 0 || j == Width - 1)
                    {
                        Grid[i, j] = new GridTile( j, i, "\u2502");
                    }
                    else
                    {
                        Grid[i, j] = new GridTile(j, i, " ");
                    }
                }
            }

            DrawGrid(Grid);
        }

        public void UpdateGrid(GridTile[] changes) {
            GridTile[,] newGrid = Grid.Clone() as GridTile[,];
            foreach(GridTile tile in changes) {
                newGrid[tile.y, tile.x] = tile;
            }

            Grid = newGrid;
            DrawGrid(newGrid);
        }

        private void DrawGrid(GridTile[,] gridArray) {
            //Loop through grid and write it out
            Console.Clear();
            string display = "";

            foreach(GridTile tile in gridArray) {
                display += tile.x == Width - 1 ? tile.content + "\n" : tile.content;
            }
            Console.WriteLine(display);
        }
    }

    public class GridTile {
        public int x;
        public int y;
        public string content = "";

        public GridTile(int _x, int _y, string _content) {
            x = _x;
            y = _y;
            content = _content;
        }
    }
}
