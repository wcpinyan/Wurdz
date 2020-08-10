using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/* TILE images downloaded from https://suncatcherstudio.com/image-editor/ */

namespace Wurdz.Shared.Models
{

    public class Tile
    {
        public static List<Tile> tilePool { get; set; } = new List<Tile>();
        public static List<Tile> shuffled { get; set; } = new List<Tile>();

        public Tile()
        {

        }
        public Tile(
                    int id,
                    string _url,
                    string _letter,
                    int _pointValue,
                    int _numInPool
                    )
        {
            url = _url;
            letter = _letter;
            pointValue = _pointValue;
            numInPool = _numInPool;
            BuildTilePool(this);
        }
        public int id { get; set; }
        public string url { get; set; }
        public string letter { get; set; }
        public int pointValue { get; set; }
        public int numInPool { get; set; }
        public int? dropCol { get; set; }
        public int? dropRow { get; set; }

       
        public List<Tile> player1Tiles { get; set; }
        public List<Tile> player2Tiles { get; set; }
        public List<Tile> player3Tiles { get; set; }
        public List<Tile> player4Tiles { get; set; }

        void BuildTilePool(Tile t)
        {
            try
            {
                Console.WriteLine("tile: " + t.letter);
                for (int i = 0; i < t.numInPool; i++)
                {
                    tilePool.Add(t);
                   ;
                }
               
            }
            catch(Exception ex)
            {
               Console.WriteLine( ex.Message);
            }           
        }
        public static List<Tile>  ShufflePool()
        {
            try
            {
                var rnd = new Random();
                var x = tilePool.OrderBy(item => rnd.Next());
                Console.WriteLine(x.ToList().Count);
                return x.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
    }
}
