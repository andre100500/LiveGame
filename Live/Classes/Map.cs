using Live.Classes.AnimalsClasses;
using Live.Classes.PlantsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes
{
    public class Map
    { 
        public int SizeX = 5;
        public int SizeY = 6;
        public Cell[,] grid;

        public Map(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;

            InitMap();
            InitObstacles(5);
            InitVegetables(10);
            InitAnimals(6);
             

        }
         
        //TODO: Переделать функцию под всех животных на всех клетках
        public void NextFrame()
        {

            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    foreach(LiveObject liveObj in grid[i, j].alive)
                    {
                        if (liveObj is ICanMove)
                        {
                           ((ICanMove)liveObj).ChoseDirection(this);
                        }
                    } 
                }
            }
             

            Rabyt diranimal = new Rabyt(grid[0, 0], SexType.Male);
            if (diranimal is ICanMove)
                Console.WriteLine("Yes he can move");

            diranimal.ChoseDirection(this);
            IFrameMove animal = (Rabyt)diranimal;

            if (animal.CheckMoved() == false)
            {
                animal.NextFrame();
            }

            CleanDeadAnimas();
        }

        private void CleanDeadAnimas()
        {

        }

        private void InitMap()
        { 
            grid = new Cell[SizeX, SizeY];
            Random rnd = new Random();
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    grid[i, j] = new Cell((CellType)rnd.Next(2));
                    grid[i, j].X = i;
                    grid[i, j].Y = j;
                }
            } 
        }
         
        private void InitObstacles(int count)
        { 
            while (count != 0)
            {
                Random rnd = new Random();
                foreach (Cell cell in grid)
                {
                    if (rnd.Next(100) > 2 && cell.obstacle == null)
                    {
                        cell.obstacle = new Obstacle();
                        Console.WriteLine("Препятствие на координате {0}:{1} оставшиеся препятствия {2}", cell.X, cell.Y, count);
                        count--;
                        if (count <= 0) return;
                    }
                }
            }
        }
         
        public void ShowMap()
        { 
            Console.WriteLine(ShowMapLog());
        }

        public string ShowMapLog()
        {
            string str="";
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    if (grid[i, j].Type == CellType.Earth && grid[i, j].obstacle == null)
                    {
                        str += "_";
                    }
                    else if (grid[i, j].Type == CellType.Earth && grid[i, j].obstacle != null)
                    {
                        str += "!";
                    }
                    else if (grid[i, j].Type == CellType.Water && grid[i, j].obstacle == null)
                    {
                        str += "~";
                    }
                    else if (grid[i, j].Type == CellType.Water && grid[i, j].obstacle != null)
                    {
                        str += "^";
                    }
                }
                str += "\n";
            }

            return str;
        }






        public void ShowVegetables()
        { 

            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    if (grid[i, j].alive.Count > 0 && grid[i, j].alive[0] is Vegetable)
                    {
                        Console.Write(grid[i, j].alive[0].HitPoints);
                    }
                    else
                    {
                        Console.Write('_');
                    }
                }
                Console.WriteLine("\n");
            }
        }




         

        private void InitVegetables(int count)
        { 
            while (count != 0)
            {
                Random rnd = new Random();
                foreach (Cell cell in grid)
                {
                    if (rnd.Next(100) < 2 && cell.obstacle == null)
                    {
                        if (cell.alive.Count == 0)
                        {
                            Grass tempGras = new Grass();
                            cell.alive.Add(tempGras);
                            Console.WriteLine("Трава на координате {0}:{1}", cell.X, cell.Y, count);
                            count--;
                            if (count <= 0) return;
                        }
                    }

                }
            }

        }


        private void InitAnimals(int count)
        { 
            while (count != 0)
            {
                Random rnd = new Random();
                foreach (Cell cell in grid)
                {
                    if (rnd.Next(100) < 2 && cell.obstacle == null)
                    {
                        if (cell.alive.Count == 0)
                        {
                            Random rand = new Random();
                            Rabyt tempAnimal = new Rabyt(cell, (SexType)rand.Next(1));
                            cell.alive.Add(tempAnimal);
                            Console.WriteLine("Кролик на координате {0}:{1}", cell.X, cell.Y, count);
                            count--;
                            if (count <= 0) return;
                        }
                    }

                }
            }
        }

    }
}
