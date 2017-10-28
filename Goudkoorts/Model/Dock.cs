using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Dock : Track
    {
        public Dock()
        {
        }

        public Dock(short cornerCode) : base(cornerCode)
        {
        }

        Water _AdjecentWater;
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
                return _AdjecentWater.DepositGoldOntoMovable(cart);
            }
            return false;
        }

        public override String ToString() => "D";
    }
}