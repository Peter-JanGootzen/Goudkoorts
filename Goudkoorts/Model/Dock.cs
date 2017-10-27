using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Dock : Track
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
            if (base.MoveOnThis(cart))
            {
                if (_North is Water north)
                {
                    return north.DepositGoldOntoMovable(cart);
                }
                return false;
            }
            return false;
        }
    }
}