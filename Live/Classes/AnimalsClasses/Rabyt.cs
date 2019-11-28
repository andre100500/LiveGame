using Live.Classes.PlantsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes.AnimalsClasses
{
    public class Rabyt : Animal, IFrameMove, ICanMove
    {

        public Rabyt(Cell cell, SexType sex) : base(AnimalType.Vegetarian, sex, 10)
        {
            CurentCell = cell;
        }

        public void Eat()
        { 

            foreach (LiveObject liveObject in CurentCell.alive)
            {
                if (liveObject is Grass && liveObject.HitPoints > 0)
                {
                    base.Eat();
                    liveObject.HitPoints--;
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

                if (NextX > map.SizeX - 1 || NextY > map.SizeY - 1)
                {

                    NextX = CurentCell.X;
                    NextY = CurentCell.Y;

                    continue;
                }
                if (NextX < 0 || NextY < 0)
                {
                    NextX = CurentCell.X;
                    NextY = CurentCell.Y;
                    
                    continue;
                }


                if (map.grid[NextX, NextY].obstacle != null)
                {
                    NextX = CurentCell.X;
                    NextY = CurentCell.Y;
                    continue;
                } 
                 
                if(CanWalk && map.grid[NextX, NextY].Type == CellType.Earth) break;
                if(CanSweem && map.grid[NextX, NextY].Type == CellType.Water) break;
            }
            //TODO: пофиксить чтобы не выходило за массив

            NextCell = map.grid[NextX, NextY];
        }

        public void NextFrame()
        {
            if (Moved) return;

            Move();
            Eat();
            Reproduce();

            Moved = true;
        }

    }
}
