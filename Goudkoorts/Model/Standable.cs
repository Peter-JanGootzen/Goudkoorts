using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Standable : GameObject
    {
        protected Movable _Movable;

        public override bool MoveOnThis(Movable movable)
        {
            if (_Movable == null)
            {
                _Movable = movable;
                return true;
            }
            else
                return false;
        }
    }
}