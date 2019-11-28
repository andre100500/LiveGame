using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes
{
     public class Vegetable : LiveObject
    {
        public override bool CheckHP()
        {
            return HitPoints > 0;
        }

        public virtual void Graw()
        {
            HitPoints++;
        }


        public override void Reproduce()
        {

        }

    }
}
