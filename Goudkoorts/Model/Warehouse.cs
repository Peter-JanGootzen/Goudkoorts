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
        public bool SpawnCart(int chance)
        {
            Random r = new Random();
            if (!_AdjecentTrack.IsTaken() && r.Next(1, 100) < chance)
            {
                return _AdjecentTrack.MoveOntoThis(new Cart());
            }
            return false;
        }

        public override String ToString() => "W";
    }
}