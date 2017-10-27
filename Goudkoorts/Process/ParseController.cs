using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Goudkoorts
{
    public class ParseController
    {
        public Level LoadLevel()
        {
            Level level = new Level();
            ParseLevelFile(level);
            return level;
        }

        public GameObject[,] ParseLevelFile(Level level)
        {
            GameObject[,] tiles;
            OpenFileDialog fileChooser = new OpenFileDialog();
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                if (!Path.GetFileName(fileChooser.FileName).Substring(0, 7).Equals("goudkoorts"))
                {
                    return null;
                }
                String[] horizontalText = File.ReadAllLines(fileChooser.FileName.ToString());

                int largestHeight = 0;
                int largestWidth = 0;
                for (int i = 0; i < horizontalText.Length; i++)
                {
                    if (horizontalText[i].Length > largestWidth)
                    {
                        largestWidth = horizontalText[i].Length;
                    }
                    if (horizontalText.Length > largestHeight)
                    {
                        largestHeight = horizontalText.Length;
                    }
                }
                tiles = new GameObject[largestWidth, largestHeight];
                for (int y = 0; y < largestHeight; y++)
                {
                    for (int x = 0; x < horizontalText[y].Length; x++)
                    {
                        switch (horizontalText[y][x] + "")
                        {
                            case "█":
                                tiles[x, y] = new Water();
                                break;
                            case "S":
                                tiles[x, y] = new Track(new Ship());
                                break;
                            case " ":
                                tiles[x, y] = new Spacer();
                                break;
                            case "W":
                                tiles[x, y] = new Spacer();
                                break;
                            case "o":
                                tiles[x, y] = new MarshallingYard();
                                break;
                            case "┤":
                                tiles[x, y] = new Switch();
                                break;
                            case "┴":
                                tiles[x, y] = new Switch();
                                break;
                            case "├":
                                tiles[x, y] = new Switch();
                                break;
                            case "─":
                                tiles[x, y] = new Track();
                                break;
                            case "┐":
                                tiles[x, y] = new Track();
                                break;
                            case "└":
                                tiles[x, y] = new Track();
                                break;
                            case "┘":
                                tiles[x, y] = new Track();
                                break;
                            case "┌":
                                tiles[x, y] = new Track();
                                break;

                        }
                    }
                }
                return tiles;
            }
            return null;
        }
    }
}