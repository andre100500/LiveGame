using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes.AnimalsClasses
{
    class Mushroom : Vegetable , IFrameMove
    {
        public Mushroom()
        {
            HitPoints = 1;
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

        public bool CheckMoved()
        {
            throw new NotImplementedException();
        }

       
        
    }
}
