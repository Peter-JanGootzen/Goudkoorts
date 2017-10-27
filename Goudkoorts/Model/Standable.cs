using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Standable : Tile
    {
        protected Movable _Movable;

        public Standable _Next { get; set; }

        public override bool MoveOntoThis(Movable movable)
        {
            if (_Movable == null)
            {
                _Movable = movable;
                return true;
            }
            else
                return false;
        }

        public virtual bool MoveOntoNext(Movable movable)
        {
            if (_Next != null)
                return _Next.MoveOntoThis(movable);
            else
                return false;
        }

        public bool IsTaken()
        {
            return _Movable == null;
        }
    }
}