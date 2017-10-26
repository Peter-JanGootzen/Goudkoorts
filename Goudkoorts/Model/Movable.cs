using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Movable
    {
        private Track _Track;

        public void Move()
        {
            _Track.MoveOntoNext(this);
        }
    }
}