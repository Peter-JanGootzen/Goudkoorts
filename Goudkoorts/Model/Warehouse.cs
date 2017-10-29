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
        public bool SpawnCart(int chance, List<Cart> Carts)
        {
            Random r = new Random();
            if (r.Next(1, 100) <= chance)
            {
                Cart cart = new Cart();
                Carts.Add(cart);
                return _AdjecentTrack.MoveOntoThis(cart);
            }
            return true;
        }

        public override String ToString() => "W";
    }
}