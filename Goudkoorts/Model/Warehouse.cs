using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Warehouse : Tile
    {
        Track _AdjecentTrack;
        public bool SpawnCart()
        {
            if (_AdjecentTrack.IsTaken())
            {
                return _AdjecentTrack.MoveOntoThis(new Cart());
            }
            return false;
        }

        public override String ToString() => "W";
    }
}