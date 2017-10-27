using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Ship : Movable
    {
        private int _GoldCount;
        public int GoldCount
        {
            get { return _GoldCount; }
            set { }
        }

        public bool DepositGold(Cart cart)
        {
            if (cart.Empty())
            {
                _GoldCount++;
                return true;
            }
            else
                return false;
        }
       
        public void SetWater(Water water)
        {
            _Standable = water;
        }
    }
}