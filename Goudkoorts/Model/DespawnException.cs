using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class DespawnException : Exception
    {
        public DespawnException():base("This Object needs to be despawned")
        {
        }
    }
}
