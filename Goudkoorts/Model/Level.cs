using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Level
    {
        public List<Warehouse> WarehouseList;
        public List<Cart> CartList;
        public List<Ship> ShipList;
        public List<Switch> SwitchList;

        private GameObject _FirstTile;

        public Level()
        {
            WarehouseList = new List<Warehouse>();
            CartList = new List<Cart>();
            ShipList = new List<Ship>();
            SwitchList = new List<Switch>();
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

        public Tile GetFirstTile()
        {
            return (Tile)_FirstTile;
        }

        public void AddSwitch(Switch Switch)
        {
            if(Switch != null)
            {
                SwitchList.Add(Switch);
            }
        }
    }


}