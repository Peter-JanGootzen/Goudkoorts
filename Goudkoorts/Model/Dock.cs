using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Dock : Track
    {
        public Dock(short cornerType) : base(cornerType)
        {

        }
        public override bool MoveOntoThis(Movable movable)
        {
            return base.MoveOntoThis(movable);
        }

        private bool MoveOnThis(Ship ship)
        {
            return false;
        }

        private bool MoveOnThis(Cart cart)
        {
            if (base.MoveOntoThis(cart))
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