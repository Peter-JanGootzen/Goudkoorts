using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Process
{
    public class ViewController
    {
        private CLI _CLI;
        public ViewController(GameController controller)
        {
            _CLI = new CLI(controller);
        }

        public void PrintCLI(Tile firstTile)
        {
            Console.Clear();
            Tile currentxaxistile = firstTile;
            Tile currentyaxistile = firstTile;
            while (currentyaxistile != null)
            {
                if (currentxaxistile is Switch)
                {
                    _CLI.SetColorForSwitch();
                    _CLI.PrintChar(currentxaxistile.ToChar());
                    _CLI.ResetColor();
                }
                else
                {
                    _CLI.PrintChar(currentxaxistile.ToChar());
                }

                if (currentxaxistile._East != null)
                    currentxaxistile = currentxaxistile._East;
                else
                {
                    currentyaxistile = currentyaxistile._South;
                    currentxaxistile = currentyaxistile;
                    _CLI.WriteEnter();
                }
            }
        }

    }
}
