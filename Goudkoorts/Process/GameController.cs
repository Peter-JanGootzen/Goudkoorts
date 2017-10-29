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
        private Thread _ForegroundGameLoopThread;
        public ParseController _ParseController;
        public ViewController _ViewController;

        public void StartGame()
        {
            _ParseController = new ParseController();
            _ViewController = new ViewController(this);
            LoadLevel();
            SendModelStringToView();
            _ForegroundGameLoopThread = new Thread(new ThreadStart(ForegroundGameLoop));
            _ForegroundGameLoopThread.Start();
            BackgroundGameLoop();
        }

        private void ForegroundGameLoop()
        {
            while (true)
            {
                _Game.FlipSwitch(_ViewController.GetInput());
                SendModelStringToView();
            }
        }

        private void BackgroundGameLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    bool Move = _Game.MoveMovables();
                    bool Spawn = _Game.SpawnCarts();
                    if (Move || Spawn) {
                        SendModelStringToView();
                    }
                } catch (LostException)
                {
                    break;
                }
            }
            _ForegroundGameLoopThread.Abort();
            _ViewController.DisplayGameOver(_Game.Points);
            StartGame();
        }

        private void LoadLevel()
        {
            _Game = new Game(_ParseController.LoadLevel());
        }

        private void SendModelStringToView()
        {
            _ViewController.SendModelStringToView(_Game.GetFirstTile());
        }

        private void CheckCartsDespawned()
        {
            _Game.GetCartList().ForEach(x =>
            {
                if (x._Standable == null)
                {
                    x = null;
                }
            });
        }
    }
}