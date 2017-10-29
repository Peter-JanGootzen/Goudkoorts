using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Dock : Track
    {
        Water _AdjecentWater;

        public Dock()
        {
        }

        public Dock(short cornerCode) : base(cornerCode)
        {
        }

        protected override bool MoveOntoThis(Cart cart)
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