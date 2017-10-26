using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class GameObject
    {
        protected GameObject _East;
        protected GameObject _South;
        protected GameObject _West;
        protected GameObject _North;
        protected GameObject _Next;

        public virtual bool MoveOnThis(Movable movable)
        {
            return false;
        }

        public void MoveOntoNext(Movable movable)
        {
            _Next.MoveOnThis(movable);
        }
    }
}