using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Cart : Movable
    {
        private bool _Filled;

        public Cart()
        {
            _Filled = true;
        }

        public bool Empty()
        {
            if (_Filled)
            {
                _Filled = false;
                return true;
            }
            else
                return false;
        }

        public void SetTrack(Track track)
        {
            _Standable = track;
        }
    }
}