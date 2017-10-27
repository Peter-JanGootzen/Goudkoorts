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

        private GameObject _FirstGameObject;

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
    }


}