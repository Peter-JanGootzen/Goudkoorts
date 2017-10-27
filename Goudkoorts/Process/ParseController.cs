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

        public Tile[,] ParseLevelFile(Level level)
        {
            Tile[,] tiles;
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
                tiles = new Tile[largestWidth, largestHeight];
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
                                Ship ship = new Ship();
                                level.AddShip(ship);
                                Water water = new Water(ship);
                                tiles[x, y] = water;
                                break;
                            case " ":
                                tiles[x, y] = new Spacer();
                                break;
                            case "W":
                                Warehouse warehouse = new Warehouse();
                                level.AddWarehouse(warehouse);
                                tiles[x, y] = warehouse;
                                break;
                            case "X":
                                tiles[x, y] = new MarshallingYard();
                                break;
                            case "┤":
                                tiles[x, y] = new Switch(3);
                                break;
                            case "├":
                                tiles[x, y] = new Switch(1);
                                break;
                            case "┐":
                                tiles[x, y] = new Track(5);
                                break;
                            case "└":
                                tiles[x, y] = new Track(2);
                                break;
                            case "┘":
                                tiles[x, y] = new Track(4);
                                break;
                            case "┌":
                                tiles[x, y] = new Track(4);
                                break;
                            case "d":
                                tiles[x, y] = new Dock();
                                break;
                            case "|":
                                tiles[x, y] = new Track(0);
                                break;
                            case "─":
                                tiles[x, y] = new Track(0);
                                break;
                        }
                    }
                }
                return tiles;
            }
            return null;
        }
        public void GenerateReferences(Tile[,] tiles)
        {
            Tile north;
            Tile south;
            Tile west;
            Tile east;
            Tile temp;
            //TODO
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[x, y] == null)
                    {
                        break;
                    }
                    temp = tiles[x, y];
                    if (y - 1 > 0)
                    {
                        if (tiles[x, y - 1] != null)
                        {
                            north = tiles[x, y - 1];
                            if (temp._North == null)
                            {
                                temp._North = north;
                            }
                            if (north._South == null)
                            {
                                north._South = temp;
                            }
                        }

                    }
                    if (x - 1 > 0)
                    {
                        if (tiles[x - 1, y] != null)
                        {
                            west = tiles[x - 1, y];

                            if (temp._West == null)
                            {
                                temp._West = west;
                            }
                            if (west._East == null)
                            {
                                west._East = temp;
                            }
                        }

                    }
                    if (y + 1 < tiles.GetLength(1))
                    {
                        if (tiles[x, y + 1] != null)
                        {
                            south = tiles[x, y + 1];
                            if (temp._South == null)
                            {
                                temp._South = south;
                            }
                            if (south._North == null)
                            {
                                south._North = temp;
                            }
                        }
                    }
                    if (x + 1 < tiles.GetLength(0))
                    {
                        if (tiles[x + 1, y] != null)
                        {
                            east = tiles[x + 1, y];
                            if (temp._East == null)
                            {
                                temp._East = east;
                            }
                            if (east._West == null)
                            {
                                east._West = temp;
                            }
                        }
                    }
                }
            }

        }

        public void GenerateTrack(Warehouse[] warehouses)
        {

        }
    }
}