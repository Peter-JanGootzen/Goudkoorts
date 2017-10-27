using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Switch : Track
    {
        private Track _ActiveTrack;

        public bool SwitchActiveTrack()
        {
            if(_ActiveTrack == _North)
            {
                _ActiveTrack = _South as Track;
                if (cornerCode == 2)
                    cornerCode = 3;
                else
                    cornerCode = 5;
            } else
            {
                _ActiveTrack = _North as Track;
                if (cornerCode == 3)
                    cornerCode = 2;
                else
                    cornerCode = 4;
            }
            return true;
        }

        public override bool MoveOntoThis(Movable movable)
        {
            if (movable.Standable == _ActiveTrack || movable.Standable == _East || movable.Standable == _West || movable.Standable == _North || movable.Standable == _South) // if that path was open, try it to move to this
                return base.MoveOntoThis(movable);
            else // if the path was closed, don't try to move it, but return true, because you didn't loose.
                return true;
        }
    }
}