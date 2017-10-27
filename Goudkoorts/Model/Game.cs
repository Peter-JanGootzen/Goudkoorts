using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Game : Model.IObserver
    {
        // If any of the model methods return false, the game has basicly been lost. Except for the MarshallingYard because those can stand still.

        public Level _Level;

        public int Points { get; set; }

        public void Update()
        {
            Points += 10;
        }
    }
}