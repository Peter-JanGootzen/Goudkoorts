using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Level
    {
        public List<Warehouse> WarehouseList;
        public List<Cart> CartList;
        public List<Ship> ShipList;

        private Tile _FirstTile;
    }
}