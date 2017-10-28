using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class program
    {
        [STAThread]

        static void Main()
        {
            ParseController pc = new ParseController();
            pc.LoadLevel();
        }
    }
}
