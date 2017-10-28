using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Water : Standable
    {
        public override bool MoveOntoThis(Movable movable)
        {
            return MoveOntoThis(movable as dynamic);
        }

        private bool MoveOntoThis(Ship ship) => base.MoveOntoThis(ship);

        private bool MoveOntoThis(Cart cart) => false;

        public bool DepositGoldOntoMovable(Cart cart)
        {
            return DepositGoldOntoMovable(_Movable as dynamic, cart);
        }

        private bool DepositGoldOntoMovable(Ship ship, Cart depositCart)
        {
            return ship.DepositGold(depositCart);
        }

        private bool DepositGoldOntoMovable(Cart cart, Cart depositCart)
        {
            return false;
        }

        public override char ToChar() => '█';
    }
}