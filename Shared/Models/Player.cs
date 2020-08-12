using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wurdz.Shared.Models
{
    public class Player
    {
        public int id { get; set; }
        public int number { get; set; }
        public string userName { get; set; }
        public int gamePoints { get; set; }
        public int numGamesPlayed { get; set; }
        public int numGamesWon { get; set; }
        public int rank { get; set; }

        public List<Tile> hand { get; set; }
    }
    public enum PlayerNum:int
    {
        One=1,
        Two=2,
        Three=3,
        Four=4
    }
}
