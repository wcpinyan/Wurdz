using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* TILE images downloaded from https://suncatcherstudio.com/image-editor/ */

namespace Wurdz.Shared.Models
{
    public class Tile
    {
        public int id { get; set; }
        public string tileImage { get; set; }
        public string letter { get; set; }
        public int pointValue { get; set; }
        public int dropCol { get; set; }
        public int dropRow { get; set; }

        public Tile[,] tilePool { get; set; }
        public Tile[,] player1Tiles { get; set; }
        public Tile[,] player2Tiles { get; set; }
        public Tile[,] player3Tiles { get; set; }
        public Tile[,] player4Tiles { get; set; }

        void BuildTilePool()
        {

        }
    }
}
