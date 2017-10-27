using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Switch : Track
    {
        public Switch(short cornerType) : base(cornerType)
        {

        }
        private Track _ActiveTrack;

        public bool SwitchActiveTrack()
        {
            if(_ActiveTrack == _North)
            {
                _ActiveTrack = _South as Track;
                Track north = _North as Track;
                north._Next = null;
            } else
            {
                _ActiveTrack = _North as Track;
                Track south = _South as Track;
                south._Next = null;
            }
            return true;
        }

        public override bool MoveOntoThis(Movable movable)
        {
            return base.MoveOntoThis(movable);
        }
    }
}