using System;

namespace Goudkoorts.Model
{
    public class Switch : Track
    {
        private Track _ActiveTrack;
        public Track _FirstSwitchTrack;
        public Track _SecondSwitchTrack;

        public Switch(short cornerType) : base(cornerType)
        {
        }

        public bool Flip()
        {
            if(_ActiveTrack == _FirstSwitchTrack)
            {
                _ActiveTrack = _SecondSwitchTrack;
                if (cornerCode == 2)
                    cornerCode = 3;
                else
                    cornerCode = 5;
            } else
            {
                _ActiveTrack = _FirstSwitchTrack;
                if (cornerCode == 3)
                    cornerCode = 2;
                else
                    cornerCode = 4;
            }
            return true;
        }

        public override bool MoveOntoThis(Movable movable)
        {
            if (movable._Standable == _ActiveTrack || movable._Standable == _East || movable._Standable == _West || movable._Standable == _North || movable._Standable == _South) // if that path was open, try it to move to this
                return base.MoveOntoThis(movable);
            else // if the path was closed, don't try to move it, but return true, because you didn't loose.
                return true;
        }

        public void SetActiveTrack(Track activeTrack)
        {
            _ActiveTrack = activeTrack;
        }

        public override String ToString()
        {
            return "S" + base.ToString();
        }
    }
}