﻿using System;
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
            SpawnShip();
        }

        public List<Cart> GetCartList()
        {
            return _Level.CartList;
        }

        public void Update(int points)
        {
            Points += points;
            if (points == 10)
            {
                SpawnShip();
            }
        }

        private void SpawnShip()
        {
            Ship ship = new Ship();
            ship.Subscribe(this);
            _Level.ShipList.Add(ship);
            _Level.ShipSpawnWater._Movable = ship;
            ship._Standable = _Level.ShipSpawnWater;
        }

        public Tile GetFirstTile() => _Level.FirstTile;

        public bool MoveMovables()
        {
            bool Changed = false;
            for (int i = _Level.CartList.Count - 1; i > -1; i--)
            {
                try
                {
                    if (_Level.CartList[i].Move())
                        Changed = true;
                } catch (DespawnException)
                {
                    _Level.CartList.Remove(_Level.CartList[i]);
                }
            }
            for (int i = _Level.ShipList.Count -1; i > -1; i--)
            {
                try
                {
                    if (_Level.ShipList[i].Move())
                        Changed = true;
                } catch (DespawnException)
                {
                    _Level.ShipList.Remove(_Level.ShipList[i]);
                }
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