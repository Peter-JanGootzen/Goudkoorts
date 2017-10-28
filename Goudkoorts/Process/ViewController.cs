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
            String parseLine = "";
            Console.Clear();
            Tile currentxaxistile = firstTile;
            Tile currentyaxistile = firstTile;
            while (currentyaxistile != null)
            {
                parseLine = parseLine + currentxaxistile.ToChar();

                if (currentxaxistile._East != null)
                    currentxaxistile = currentxaxistile._East;
                else
                {
                    _CLI.PrintLine(parseLine);
                    parseLine = "";
                    currentyaxistile = currentyaxistile._South;
                    currentxaxistile = currentyaxistile;
                }
            }
        }

    }
}
