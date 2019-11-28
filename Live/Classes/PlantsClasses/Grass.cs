using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes.PlantsClasses
{
    public class Grass : Vegetable, IFrameMove
    {
        public Grass()
        {
            HitPoints = 3;
        }

        public bool CheckMoved()
        {
            throw new NotImplementedException();
        }

        public override void Graw()
        { 
            base.Graw();
            base.Graw();
        }

        public void NextFrame()
        {
            if (CheckHP())
            {
                this.Graw();



            } 

        }
    }
}
