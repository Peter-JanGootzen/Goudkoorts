using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public abstract class Movable : GameObject
    {
        protected Standable _Standable;
        public Standable Standable { get { return _Standable; } set { } }

        public bool Move() => _Standable.MoveOntoNext(this);
    }
}