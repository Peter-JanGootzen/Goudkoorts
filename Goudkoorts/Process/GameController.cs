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

        public void LoadLevel()
        {
            _Game._Level = _ParseController.LoadLevel();
        }

       
        public void PrintGame(Tile firstTile)
        {
            _ViewController.PrintCLI(firstTile);
        }
        public void SwitchTheSwitch(int switchInt)
        {
            _Game._Level.SwitchList[switchInt].SwitchActiveTrack();
        }
    }
}