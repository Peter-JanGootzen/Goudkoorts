using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Warehouse : Tile
    {
        public Track _AdjecentTrack;
        // chance is a number between 1 and 100
        public bool SpawnCart(Cart cart)
        {
            return _AdjecentTrack.MoveOntoThis(cart);
        }

        public override String ToString() => "W";
    }
}