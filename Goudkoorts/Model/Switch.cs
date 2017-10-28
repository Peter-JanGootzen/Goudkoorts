using System;

namespace Goudkoorts.Model
{
    public class Switch : Track
    {
        private Track _ActiveTrack;
        private Track _FirstSwitchTrack;
        private Track _SecondSwitchTrack;

        public Switch(short cornerType) : base(cornerType)
        {
        }

        public bool Flip()
        {
            if(_ActiveTrack == _FirstSwitchTrack)
            {
                _ActiveTrack = _SecondSwitchTrack;
            } else
            {
                _ActiveTrack = _FirstSwitchTrack;
            }
            switch (cornerCode)
            {
                case 2:
                    cornerCode = 3;
                    break;
                case 3:
                    cornerCode = 2;
                    break;
                case 4:
                    cornerCode = 5;
                    break;
                case 5:
                    cornerCode = 4;
                    break;
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