using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Track : Standable
    {
        // 0 = West to East / no corner
        // 1 = North to East
        // 2 = South to East
        // 3 = West to North
        // 4 = West to South

        private short cornerType;
        public short CornerType
        {
            get { return cornerType; }
            set { }
        }

        public Track(short cornerType)
        {
            this.cornerType = cornerType;
        }
    }
}