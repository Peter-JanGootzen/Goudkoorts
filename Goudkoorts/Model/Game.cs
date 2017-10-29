using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Game : IObserver
    {
        // If any of the model methods return false, the game has basicly been lost. Except for the MarshallingYard because those can stand still.

        public Level _Level;

        public int Points { get; set; }

        public void Update() => Points += 10;

        public Tile GetFirstTile() => _Level.FirstTile;

        public bool MoveMovables()
        {
            foreach (Cart c in _Level.CartList)
            {
                if (!c.Move())
                    return false;
            }
            foreach (Ship s in _Level.ShipList)
            {
                if (!s.Move())
                {
                    return false;
                }
            }
            return true; // If they all returned true
        }

        public bool SpawnCarts()
        {
            foreach (Warehouse w in _Level.WarehouseList)
            {
                if (!w.SpawnCart(CalcSpawnChance()))
                {
                    return false;
                }
            }
            return true;
        }

        public void FlipSwitch(int switchNumber)
        {
            if(switchNumber >= 0 && switchNumber < _Level.SwitchList.Count)
            _Level.SwitchList[switchNumber].Flip();
        }

        // Needs to generate a number between 1 and 100 that is deriven from the amount of points
        private int CalcSpawnChance()
        {
            return 50;
        }
    }
}