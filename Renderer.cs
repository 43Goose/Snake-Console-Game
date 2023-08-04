using System.Dynamic;
namespace snake {
    public class Renderer {
        public int Width { get; private set; } = 40;
        public int Height { get; private set;} = 20;
        public List<GridTile> CurrentGrid { get; private set; } = new();

        public void InitializeGrid() {
            List<GridTile> grid = new();
            for(int i = 0; i < Height; i++) {
                for(int j = 0; j <= Width; j++) {
                    if(j == 0 || j == Width) {
                        grid.Add(new(j, i, "|"));
                    } else if(i == 0) {
                        grid.Add(new(j, i, "\u203E"));
                    } else if(i == Height - 1) {
                        grid.Add(new(j, i, "_"));
                    } else {
                        grid.Add(new(j, i, " "));
                    }
                }
                grid.Add(new(-1, -1, ""));
            }
            CurrentGrid = grid;
            DrawGrid(grid);
        }

        public void UpdateGrid(List<GridTile> changes) {
            List<GridTile> newGrid = CurrentGrid;
            foreach(GridTile tile in changes) {
                newGrid[CurrentGrid.FindIndex(i => i.x == tile.x && i.y == tile.y)] = tile;
            }
            DrawGrid(newGrid);
        }

        private void DrawGrid(List<GridTile> grid) {
            //Loop through grid and write it out
            Console.Clear();
            string display = "";

            foreach(GridTile tile in grid) {
                display += tile.content == "" ? "\n" : tile.content;
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
