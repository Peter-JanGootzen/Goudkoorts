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

        private GameObject _FirstTile;

        public Level()
        {
            WarehouseList = new List<Warehouse>();
            CartList = new List<Cart>();
            ShipList = new List<Ship>();
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            if (warehouse != null)
            {
                WarehouseList.Add(warehouse);
            }
        }
        public void AddShip(Ship ship)
        {
            if (ship != null)
            {
                ShipList.Add(ship);
            }
        }

        public void SetFirstTile(Tile tile)
        {
            if(tile != null)
            {
                _FirstTile = tile;
            }
        }
    }


}