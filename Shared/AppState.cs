using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wurdz.Shared.Models;

namespace Wurdz.Shared
{
    public class AppState
    {
        public List<Tile>  shuffledTiles { get; set; }
        public List<Tile> player1Tiles { get; set; }
        public List<Tile> player2Tiles { get; set; }
    }
}
