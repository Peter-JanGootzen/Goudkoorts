﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Tile : GameObject
    {
        public Tile _East;
        public Tile _South;
        public Tile _West;
        public Tile _North;

        public virtual bool MoveOntoThis(Movable movable)
        {
            return false;
        }
    }
}