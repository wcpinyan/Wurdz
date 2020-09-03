using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wurdz.Shared.Models;

namespace Wurdz.Shared
{
    public class AppState
    {
        public List<TileModel>  shuffledTiles { get; set; }
        public List<TileModel> player1Tiles { get; set; }
        public List<TileModel> player2Tiles { get; set; }
        public TileModel selectedTile { get; set; }
        public List<Cell> boardCells{get;set;}
    }
}
