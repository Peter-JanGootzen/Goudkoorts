using System;

namespace Goudkoorts.Model
{
    public class Switch : Track
    {
        private Track _ActiveTrack;
        public Track _FirstSwitchTrack;
        public Track _SecondSwitchTrack;

        public Switch(short cornerCode) : base(cornerCode)
        {
            if (cornerCode == 2 || cornerCode == 3) { }
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
                    _Next = _ActiveTrack;
                    cornerCode = 5;
                    break;
                case 5:
                    cornerCode = 4;
                    _Next = _ActiveTrack;
                    break;
            }
            return true;
        }

        public override bool MoveOntoThis(Movable movable)
        {
            if (movable._Standable == _ActiveTrack || cornerCode == 4 || cornerCode == 5) // if that path was open, try it to move to this
                return base.MoveOntoThis(movable);
            else // if the path was closed, don't try to move it, but return true, because you didn't loose.
                return false;
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