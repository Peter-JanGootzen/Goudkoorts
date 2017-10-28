using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public abstract class Tile : GameObject
    {
        protected Tile _East;
        protected Tile _South;
        protected Tile _West;
        protected Tile _North;

        public virtual bool MoveOntoThis(Movable movable) => false;
    }
}