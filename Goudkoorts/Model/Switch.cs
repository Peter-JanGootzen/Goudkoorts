using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Switch : Track
    {
        public Switch(short cornerCode) : base(cornerCode)
        {
        }

        private Track _ActiveTrack;

        public bool SwitchActiveTrack()
        {
            if(_ActiveTrack == _North)
            {
                _ActiveTrack = _South as Track;
                // change cornerCode
            } else
            {
                _ActiveTrack = _North as Track;
                // change cornerCode
            }
            return true;
        }

        public override bool MoveOntoThis(Movable movable)
        {
            return base.MoveOntoThis(movable);
        }

        public void SetActiveTrack(Track activeTrack)
        {
            _ActiveTrack = activeTrack;
        }
    }
}