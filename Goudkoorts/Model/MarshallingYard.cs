using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Model
{
    public class MarshallingYard : Track
    {
        bool FirstMarshallingYard;

        public MarshallingYard()
        {
        }

        public MarshallingYard(short cornerCode) : base(cornerCode)
        {
        }

        public MarshallingYard(bool first)
        {
            FirstMarshallingYard = first;
        }

        public override bool MoveOntoNext(Movable movable)
        {
            if (_Next == null)
                return true;
            else
                return _Next.MoveOntoThis(movable);
        }

        // If this MarshallingYard has been taken after the moving and the Tile to the East is a Track, then all the MarshallingYards are taken.
        public override bool MoveOntoThis(Movable movable)
        {
            if (base.MoveOntoThis(movable) && FirstMarshallingYard)
            {
                return false;
            }
            else
                return true;
        }

        public override char ToChar() => 'X';
    }
}