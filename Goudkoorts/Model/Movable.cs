using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public abstract class Movable : GameObject
    {
        public Standable _Standable;

        public bool Move() => _Standable.MoveOntoNext();
    }
}