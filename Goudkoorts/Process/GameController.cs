using Goudkoorts.Model;
using Goudkoorts.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Goudkoorts
{
    public class GameController
    {
        public Game _Game;
        private Thread _GameLoopThread;
        public ParseController _ParseController;
        public ViewController _ViewController;

        public void StartGame()
        {
            _Game = new Game();
            _ParseController = new ParseController();
            _ViewController = new ViewController(this);
            LoadLevel();
            SendModelStringToView();
            _GameLoopThread = new Thread(ForegroundGameLoop);
            _GameLoopThread.Start();
            BackgroundGameLoop();
        }

        private void ForegroundGameLoop()
        {
            while (true)
            {
                _Game.FlipSwitch(_ViewController.GetInput());
            }
        }

        private void BackgroundGameLoop()
        {
            while (true)
            {
                if (_Game.MoveMovables() || _Game.SpawnCarts())
                {
                    break;
                }
                Thread.Sleep((int)(_Game.Points * 0.1));
            }
            _GameLoopThread.Abort();
            _ViewController.DisplayGameOver(_Game.Points);
            StartGame();
        }

        private void LoadLevel()
        {
            _Game._Level = _ParseController.LoadLevel();
        }

        private void SendModelStringToView()
        {
            _ViewController.SendModelStringToView(_Game.GetFirstTile());
        }

        private void SwitchTheSwitch(int switchInt)
        {
            _Game._Level.SwitchList[switchInt].Flip();
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