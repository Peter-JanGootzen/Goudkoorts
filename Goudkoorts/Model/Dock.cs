using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Dock : Standable
    {
        public override bool MoveOnThis(Movable movable)
        {
            return base.MoveOnThis(movable);
        }

        private bool MoveOnThis(Ship ship)
        {
            return false;
        }

        private bool MoveOnThis(Cart cart)
        {
            bool baseOutput = base.MoveOnThis(cart);
            if (base.MoveOnThis(cart))
            {
                if (_North is Water)
                {
                    Water north = (Water)_North;
                    return north.DepositGoldOntoMovable(cart);
                }
                return false;
            }
            return false;
        }
    }
}