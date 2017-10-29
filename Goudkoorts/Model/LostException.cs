using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class LostException : Exception
    {
        public LostException(): base("You have lost")
        {
        }
    }
}
