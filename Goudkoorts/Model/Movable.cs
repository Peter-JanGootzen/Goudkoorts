using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public abstract class Movable : GameObject
    {
        public Standable _Standable;
        private bool _Filled;
        public virtual bool Filled { get
            {
                return _Filled;
            }
        set
            {
                _Filled = value;
            }
        }

        public bool Move() => _Standable.MoveOntoNext();
    }
}