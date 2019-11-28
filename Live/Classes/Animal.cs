using Live.Classes.AnimalsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes
{
    public enum AnimalType { Vegetarian, Predator, Omnivorous }
    public enum SexType { Male, Female } 

    public class Animal : LiveObject
    {

        protected Cell CurentCell;
        protected Cell NextCell;

        public readonly AnimalType FoodType;
        public readonly SexType Sex;
        public readonly int DeadAge; 

        public bool CanSweem;
        public bool CanWalk;
        public bool CanFly;

        
        public Animal(AnimalType foodType, SexType sex, int deadAge,bool isCanWalk=true, bool IsCanSweem = false,bool isCanFly=false)
        { 

            FoodType = foodType;
            Sex = sex;
            DeadAge = deadAge; 
            CanSweem = IsCanSweem;
            CanWalk = isCanWalk;
            CanFly = isCanFly;
        }

        public virtual void Eat()
        {
            HitPoints++;
        }
         

        public virtual void Move()
        {
            CurentCell.alive.Remove(this);
            CurentCell = NextCell;
            NextCell.alive.Add(this);
            
            NextCell = null;
        }
         
        public override void Reproduce()
        {

        }

        public override bool CheckHP()
        {
            return HitPoints >= 0;
        }


        public bool CheckMoved()
        {
            return NextCell == null;
        }
    }
}
