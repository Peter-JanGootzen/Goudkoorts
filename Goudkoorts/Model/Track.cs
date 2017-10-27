using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Track : Standable
    {
        private Cart cart;

        public Track(Movable moveable)
        {
            this._Movable = moveable;
        }

        public Track()
        {

        }
    }
}