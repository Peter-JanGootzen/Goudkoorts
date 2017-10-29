using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class MarshallingYard : Track
    {
        bool FirstMarshallingYard;

        public MarshallingYard(short cornerCode) : base(cornerCode)
        {
        }

        public MarshallingYard(bool first)
        {
            FirstMarshallingYard = first;
        }

        public override bool MoveOntoNext()
        {
            if (_Next == null)
                return false;
            else {
                if (_Next._Movable == null)
                {
                    _Next.MoveOntoThis(_Movable);
                    _Movable = null;
                    return true;
                }
                else
                    return false;
            }
                    
        }

        // If this MarshallingYard has been taken after the moving and the Tile to the East is a Track, then all the MarshallingYards are taken.
        public override bool MoveOntoThis(Movable movable)
        {
            if (base.MoveOntoThis(movable))
            {
                if (FirstMarshallingYard && _Next._Movable != null) // If the marshalling yard is now full
                {
                    throw new LostException();
                }
                else
                    return true;
            }
            else
                return false;
        }

        public override String ToString() {
            if (_Movable != null)
                return _Movable.ToString();
            else
                return "X";
        }
    }
}