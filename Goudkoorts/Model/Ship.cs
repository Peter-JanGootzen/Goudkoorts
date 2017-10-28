using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goudkoorts.Model;

namespace Goudkoorts.Model
{
    public class Ship : Movable, Model.IObservable
    {
        List<Model.IObserver> ObserverList;
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
                if (_GoldCount >= 8)
                    Notify();
                return true;
            }
            else
                return false;
        }

        public void Notify()
        {
            ObserverList.ForEach(x => x.Update());
        }

        public void SetWater(Water water)
        {
            _Standable = water;
        }

        public void Subscribe(IObserver observer)
        {
            ObserverList.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            ObserverList.Remove(observer);
        }
        public override char ToChar() => (char)GoldCount;
    }
}