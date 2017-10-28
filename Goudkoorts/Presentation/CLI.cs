using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class CLI
    {
        private GameController controller;
        public CLI(GameController controller)
        {
            this.controller = controller;
        }
        public bool CatchSwitchInput()
        {
            ConsoleKey key = Console.ReadKey().Key;
            int switchInt;
            if (int.TryParse(key.ToString(), out switchInt))
            {
                if (switchInt > 0 && switchInt < controller._Game._Level.SwitchList.Count)
                {
                    controller.SwitchTheSwitch(switchInt);
                    return true;
                }
            }
            return false;
        }

        public void PrintChar(Char line)
        {
            Console.Write(line);
        }
        public void PrintString(String line)
        {
            Console.WriteLine(line);
        }

        public void SetColorForSwitch()
        {
            Console.BackgroundColor = ConsoleColor.Red;
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }

        public void WriteEnter()
        {
            Console.WriteLine();
        }
    }
}