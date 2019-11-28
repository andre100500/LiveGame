using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes.AnimalsClasses
{
    public class Wolf : Animal, IFrameMove, ICanMove
    {
        public Wolf(Cell cell,SexType sex) : base(AnimalType.Predator, sex, 20)
        {
            CurentCell = cell;
        } 

        public void NextFrame()
        {
            if (Moved) return;

            Move();

            Moved = true; 
        }

        public void Eat()
        {

            foreach (LiveObject liveObject in CurentCell.alive)
            {
                if (liveObject is Rabyt && liveObject.HitPoints>0)
                {
                    base.Eat();
                    HitPoints++;
                    liveObject.HitPoints = 0;
                    return;
                }
            } 
        }

        public void ChoseDirection(Map map)
        {
            Random rand = new Random();
            int NextX = 0;
            int NextY = 0;

            for (int i = 0; i < 10; i++)
            {
                NextX = CurentCell.X + rand.Next(0, 2) - 1;
                NextY = CurentCell.Y + rand.Next(0, 2) - 1;

                if (NextX > map.SizeX-1 || NextY > map.SizeY-1) continue;

                if (map.grid[NextX, NextY].obstacle != null)
                {
                    NextX = CurentCell.X;
                    NextY = CurentCell.Y;
                    continue;
                }
                if (CanWalk)
                    if (map.grid[NextX, NextY].Type == CellType.Earth) break ;
                if (CanSweem)
                    if (map.grid[NextX, NextY].Type == CellType.Water) break;
            }
            NextCell = map.grid[NextX,NextY];
        }
    }
}
