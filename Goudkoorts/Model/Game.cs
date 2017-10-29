using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Game : IObserver
    {
        // If any of the model methods return false, the game has basicly been lost. Except for the MarshallingYard because those can stand still.

        private Level _Level;
        private Random _Random;
        public int Points { get; set; }

        public Game(Level level)
        {
            _Level = level;
            _Random = new Random();
        }

        public List<Cart> GetCartList()
        {
            return _Level.CartList;
        }

        public void Update(int points) => Points += points;

        public Tile GetFirstTile() => _Level.FirstTile;

        public bool MoveMovables()
        {
            bool Changed = false;
            foreach (Cart c in _Level.CartList)
            {
                if (c.Move())
                    Changed = true;
            }
            foreach (Ship s in _Level.ShipList)
            {
                if (s.Move())
                    Changed = true;
            }
            return Changed; // If they all returned true
        }

        public bool SpawnCarts()
        {
            bool Changed = false;
            foreach (Warehouse w in _Level.WarehouseList)
            {
                if (_Random.Next(1, 100) <= CalcSpawnChance())
                {
                    Cart cart = new Cart();
                    _Level.CartList.Add(cart);
                    if (w.SpawnCart(cart))
                    {
                        Changed = true;
                    }
                }
            }
            return Changed;
        }

        public void FlipSwitch(int switchNumber)
        {
            if(switchNumber >= 0 && switchNumber < _Level.SwitchList.Count)
            _Level.SwitchList[switchNumber].Flip();
        }

        // Needs to generate a number between 1 and 100 that is deriven from the amount of points
        private int CalcSpawnChance()
        {
            return 3;
        }
    }
}