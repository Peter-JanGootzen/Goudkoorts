using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goudkoorts.Model;

namespace Goudkoorts.Model
{
    public class Ship : Movable, IObservable
    {
        List<Model.IObserver> ObserverList;
        private int _GoldCount;

        public Ship()
        {
            _GoldCount = 0;
            ObserverList = new List<Model.IObserver>();
        }

        public int GoldCount
        {
            get { return _GoldCount; }
            set { _GoldCount = value; }
        }

        public bool IsFull()
        {
            return _GoldCount == 8;
        }

        public bool DepositGold(Cart cart)
        {
            if (cart.Empty())
            {
                _GoldCount++;
                Notify(1);
                if (_GoldCount >= 8)
                    Notify(10);
                return true;
            }
            else
                return false;
        }

        public void Notify(int value) => ObserverList.ForEach(x => x.Update(value));

        public void Subscribe(IObserver observer) => ObserverList.Add(observer);

        public void Unsubscribe(IObserver observer) => ObserverList.Remove(observer);
        public override String ToString() => "" + _GoldCount;
    }
}