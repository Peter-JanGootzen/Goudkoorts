using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Dock : Track
    {
        public Water _AdjecentWater;

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
                _AdjecentWater.DepositGoldOntoMovable(cart);
                return true;
            }
            return false;
        }

        public override String ToString() {
            if (_Movable != null)
                return _Movable.ToString();
            else
                return "D";
        }
    }
}