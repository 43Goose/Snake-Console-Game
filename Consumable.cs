using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cstesting
{
    internal class Consumable
    {
        public string Graphic { get; private set; }
        protected Renderer r;
        private int SpawnX;
        private int SpawnY;

        public Consumable(Renderer _r, string _graphic, int _x, int _y)
        {
            this.r = _r;
            this.Graphic = _graphic;
            this.SpawnX = _x;
            this.SpawnY = _y;

            r.UpdateGrid(new GridTile[] { new GridTile(SpawnX, SpawnY, Graphic) });
        }
    }
}
