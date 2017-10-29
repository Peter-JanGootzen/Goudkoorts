using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Track : Standable
    {
        // 0 = West to East / no corner
        // 1 = North to South / no corner
        // 2 = North to East
        // 3 = South to East
        // 4 = West to North
        // 5 = West to South

        public override bool MoveOntoThis(Movable movable) => MoveOntoThis(movable as dynamic);

        protected bool MoveOntoThis(Ship ship) => false;

        protected virtual bool MoveOntoThis(Cart cart) => base.MoveOntoThis(cart);

        protected short cornerCode;
        public short CornerCode
        {
            get { return cornerCode; }
            set { }
        }

        public Track(short cornerCode)
        {
            this.cornerCode = cornerCode;
        }

        public Track()
        {
            cornerCode = 0;
        }

        public override String ToString()
        {
            if (_Movable != null)
                return _Movable.ToString();
            else
            {
                switch (cornerCode)
                {
                    case -1:
                        return "─";
                    case 0:
                        return "─";
                    case 1:
                        return "|";
                    case 2:
                        return "└";
                    case 3:
                        return "┌";
                    case 4:
                        return "┘";
                    case 5:
                        return "┐";
                    default:
                        return " ";
                }
            }
        }
    }
}