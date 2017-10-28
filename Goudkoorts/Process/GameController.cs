using Goudkoorts.Model;
using Goudkoorts.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class GameController
    {
        public Game _Game;
        public ParseController _ParseController;
        public ViewController _ViewController;
        public void StartGame()
        {
            _Game = new Game();
            _ParseController = new ParseController();
            _ViewController = new ViewController(this);
            LoadLevel();
        }

        private void LoadLevel()
        {
            _Game._Level = _ParseController.LoadLevel();
        }


        private void PrintGame(Tile firstTile)
        {
            _ViewController.PrintCLI(firstTile);
        }
        private void SwitchTheSwitch(int switchInt)
        {
            _Game._Level.SwitchList[switchInt].SwitchActiveTrack();
        }

        private void CheckCartsDespawned()
        {
            _Game._Level.CartList.ForEach(x =>
            {
                if (x._Standable == null)
                {
                    x = null;
                }
            });
        }
    }
}