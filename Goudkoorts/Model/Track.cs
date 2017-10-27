using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Track : Standable
    {
        // 0 = West to East / no corner
        // 1 = North to South / no corner
        // 2 = North to East
        // 3 = South to East
        // 4 = West to North
        // 5 = West to South

        protected short cornerCode;
        public short CornerCode
        {
            get { return cornerCode; }
            set { }
        }

        public Track(short cornerType)
        {
            this.cornerCode = cornerType;
        }

        public Track()
        {
            cornerCode = 0;
        }
    }
}