using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Classes
{
    interface IFrameMove
    {
        void NextFrame();
        bool CheckMoved();
    }
}
