using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Water : Standable
    {
        public override bool MoveOnThis(Movable movable)
        {
            return MoveOnThis(movable as dynamic);
        }

        private bool MoveOnThis(Ship ship)
        {
            // Check if it's empty and stuff
            return true;
        }

        private bool MoveOnThis(Cart cart)
        {
            return false;
        }

        public bool DepositGoldOntoMovable(Cart cart)
        {
            return DepositGoldOntoMovableDynamic(_Movable as dynamic, cart);
        }

        private bool DepositGoldOntoMovableDynamic(Ship ship, Cart cart)
        {
            return ship.DepositGold(cart);
        }

        private bool DepositGoldOntoMovableDynamic(Cart cart)
        {
            return false;
        }
    }
}