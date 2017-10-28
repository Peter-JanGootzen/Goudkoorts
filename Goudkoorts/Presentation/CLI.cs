﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Presentation
{
    public class CLI : IView
    {
        private String _LastModelString;

        private void RefreshCLI(String modelString)
        {
            modelString.ToList().ForEach(x =>
            {
                if (x.Equals('S'))
                    Console.BackgroundColor = ConsoleColor.Red;
                else if (x.Equals('\n')) // For a new line, idk what the new line is in the modelString
                {
                    Console.WriteLine();
                } else
                {
                    Console.WriteLine(x);
                    Console.ResetColor();
                }

            });
            _LastModelString = modelString;
        }

        public int CatchSwitchInput()
        {
            int.TryParse(Console.ReadKey().Key.ToString(), out int input);
            return input;
            /* if (int.TryParse(key.ToString(), out switchInt))
            {
                if (switchInt > 0 && switchInt < controller._Game._Level.SwitchList.Count)
                {
                    controller.SwitchTheSwitch(switchInt);
                    return true;
                }
            }
            return false;
            */
        }

        public void ReceiveModelString(string modelString)
        {
            if (_LastModelString.Equals(modelString))
                return;
            else
            {
                RefreshCLI(modelString);
            }
        }
    }
}