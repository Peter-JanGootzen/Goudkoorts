using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public abstract class Tile : GameObject
    {
        public Tile _East;
        public Tile _South;
        public Tile _West;
        public Tile _North;

        public virtual bool MoveOntoThis(Movable movable) => false;
    }
}