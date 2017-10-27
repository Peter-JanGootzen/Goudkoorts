using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Warehouse : Tile
    {
        public bool SpawnCart()
        {
            if (_East is Standable east && east.IsTaken())
            {
                return east.MoveOntoThis(new Cart());
            }
            return false;
        }

        public override char ToChar()
        {
            return 'W';
        }
    }
}