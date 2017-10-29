using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class Water : Standable
    {
        public Dock _AdjecentDock;

        public Water(Ship ship)
        {
        }

        public Water() { }

        public override bool MoveOntoThis(Movable movable)
        {
            return MoveOntoThis(movable as dynamic);
        }

        private bool MoveOntoThis(Ship ship) => base.MoveOntoThis(ship);

        private bool MoveOntoThis(Cart cart) => false;

        public override bool MoveOntoNext()
        {
            if (_AdjecentDock != null && !_Movable.Filled)
                return false;
            else
                return base.MoveOntoNext();
        }

        public bool DepositGoldOntoMovable(Cart cart)
        {
            if (_Movable != null)
                return DepositGoldOntoMovable(_Movable as dynamic, cart);
            else
                return false;
        }

        private bool DepositGoldOntoMovable(Ship ship, Cart depositCart)
        {
            return ship.DepositGold(depositCart);
        }

        private bool DepositGoldOntoMovable(Cart cart, Cart depositCart)
        {
            return false;
        }

        public override String ToString()
        {
            if (_Movable != null)
                return _Movable.ToString();
            return "█";
        }
    }
}