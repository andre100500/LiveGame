using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes
{
    public enum CellType { Earth, Water };

    public class Cell
    {
        public int X, Y;

        public readonly CellType Type;

        public Cell(CellType type)
        {
            this.Type = type;
            alive = new List<LiveObject>();
        }

        public Obstacle obstacle;
        public List<LiveObject> alive;

    }
}
