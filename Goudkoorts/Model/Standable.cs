using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public abstract class Standable : Tile
    {
        public Movable _Movable;

        public Standable _Next { get; set; }

        public Standable(Movable movable)
        {
            _Movable = movable;
        }
        public Standable()
        {
        }

        public override bool MoveOntoThis(Movable movable)
        {
            if (_Movable == null)
            {
                _Movable = movable;
                movable._Standable = this;
                return true;
            }
            else
                throw new LostException();
        }

        public virtual bool MoveOntoNext()
        {
            if (_Next != null)
            {
                if (_Next.MoveOntoThis(_Movable))
                {
                    _Movable = null;
                    return true;
                }
                return false;
            }
            else // When a movable despawns
            {
                _Movable._Standable = null;
                _Movable = null;
                throw new DespawnException();
            }
        }

        public bool IsTaken() => _Movable == null;
    }
}