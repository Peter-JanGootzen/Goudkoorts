using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Presentation
{
    interface IView
    {
        void ReceiveModelString(String modelString);
    }
}
