using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Goudkoorts.Model;

namespace Goudkoorts
{
    public class ParseController
    {
        public Level LoadLevel()
        {
            Level level = new Level();
            Tile[,] levelArray = null;
            while (levelArray == null)
            {
                levelArray = ParseLevelFile(level);
            }
            GenerateReferences(levelArray);
            level.FirstTile = levelArray[0, 0];
            GenerateTrack(level.WarehouseList);
            return level;
        }

        public Tile[,] ParseLevelFile(Level level)
        {
            Tile[,] tiles;
            OpenFileDialog fileChooser = new OpenFileDialog();
            while (fileChooser.ShowDialog() == DialogResult.OK)
            {
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
                                Water water = new Water();
                                level.ShipSpawnWater = water;
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
                            case "z":
                                tiles[x, y] = new MarshallingYard(-1);
                                break;
                            case "X":
                                tiles[x, y] = new MarshallingYard(0);
                                break;
                            case "x":
                                tiles[x, y] = new MarshallingYard(true);
                                break;
                            case "┤":
                                Switch Switch5 = new Switch(5);
                                level.AddSwitch(Switch5);
                                tiles[x, y] = Switch5;
                                break;
                            case "├":
                                Switch Switch2 = new Switch(2);
                                level.AddSwitch(Switch2);
                                tiles[x, y] = Switch2;
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
                                tiles[x, y] = new Track(3);
                                break;
                            case "d":
                                tiles[x, y] = new Dock();
                                break;
                            case "|":
                                tiles[x, y] = new Track(1);
                                break;
                            case "─":
                                tiles[x, y] = new Track(0);
                                break;
                            case "+":
                                tiles[x, y] = new Track(-1);
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

        public void GenerateRoute(Tile tile, Track PreviousTrack)
        {
            Track temp = (Track)tile;
            Track previousTrack = PreviousTrack;
            while (temp.CornerCode != -1)
            {
                if (temp._Next != null)
                {
                    break;
                }
                if(previousTrack == null)
                {
                    temp._Next = (Track)temp._East;
                }
                else if (temp as dynamic is Switch Switch)
                {
                    if (Switch.CornerCode == 5)
                    {
                        GenerateRoute(temp._North, temp);
                        GenerateRoute(temp._South, temp);
                        
                        temp._Next = (Track)Switch._South;
                        Switch._FirstSwitchTrack = (Track)temp._Next;
                        Switch._SecondSwitchTrack = (Track)temp._North;
                        Switch.SetActiveTrack((Track)temp._Next);

                    }
                    if (Switch.CornerCode == 2)
                    {
                        temp._Next = (Track)Switch._East;
                        Switch.SetActiveTrack((Track)temp._Next);

                    }
                }
                else if (temp as dynamic is Track track)
                {
                    //rechte stukken
                    if (track.CornerCode == 1 || track.CornerCode == 0)
                    {
                        if (track._South is Track && previousTrack == (Track)track._South)
                        {
                            temp._Next = (Track)track._North;
                        }
                        else if (track._North is Track && previousTrack == (Track)track._North)
                        {
                            temp._Next = (Track)track._South;
                        }
                        else if (track._East is Track && previousTrack == (Track)track._East)
                        {
                            temp._Next = (Track)track._West;
                        }
                        else if (track._West is Track && previousTrack == (Track)track._West)
                        {
                            temp._Next = (Track)track._East;

                        }
                    }
                    //bochten
                    else if (track.CornerCode == 2)
                    {
                        if (track._North is Track && previousTrack == (Track)track._North)
                        {
                            temp._Next = (Track)track._East;
                        }
                        else if (track._East is Track && previousTrack == (Track)track._East)
                        {
                            temp._Next = (Track)track._North;
                        }
                    }
                    else if (track.CornerCode == 3)
                    {
                        if (track._South is Track && previousTrack == (Track)track._South)
                        {
                            temp._Next = (Track)track._East;
                        }
                        else if (track._East is Track && previousTrack == (Track)track._East)
                        {
                            temp._Next = (Track)track._South;
                        }
                    }
                    else if (track.CornerCode == 4)
                    {
                        if (track._West is Track && previousTrack == (Track)track._West)
                        {
                            temp._Next = (Track)track._North;
                        }
                        else if (track._North is Track && previousTrack == (Track)track._North)
                        {
                            temp._Next = (Track)track._West;
                        }
                    }
                    else if (track.CornerCode == 5)
                    {
                        if (track._West is Track && previousTrack == (Track)track._West)
                        {
                            temp._Next = (Track)track._South;
                        }
                        else if (track._South is Track && previousTrack == (Track)track._South)
                        {
                            temp._Next = (Track)track._West;
                        }
                    }
                }
                previousTrack = temp;
                temp = (Track)temp._Next;
            }
        }

        public void GenerateTrack(List<Warehouse> warehouses)
        {
            foreach (var w in warehouses)
            {

                Track temp = null;
                if (w._North is Track)
                {
                    temp = (Track)w._North;
                }
                else if (w._East is Track)
                {
                    temp = (Track)w._East;
                }
                else if (w._West is Track)
                {
                    temp = (Track)w._West;
                }
                else if (w._South is Track)
                {
                    temp = (Track)w._South;
                }
                w._AdjecentTrack = temp;

                GenerateRoute(temp, null);


            }
        }
    }
}
