using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


/* TILE images downloaded from https://suncatcherstudio.com/image-editor/ */

namespace Wurdz.Shared.Models
{

    public class TileModel
    {
        public static List<TileModel> tilePool { get; set; } = new List<TileModel>();
        public static List<TileModel> shuffled { get; set; } = new List<TileModel>();

        private static int count=0;
        private static int countDealt = 0;
        public TileModel()
        {

        }
        public TileModel(
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
        public string url { get; set; } //path to the given tile image(the image is the tile gui)
        public string borderColor { get; set; }="black";
        public string letter { get; set; }
        public int pointValue { get; set; }
        public int numInPool { get; set; }
        public int? dropCol { get; set; }
        public int? dropRow { get; set; }
        public int assignedTo { get; set; } //Player number this tile is dealt to.
        public Cell cellDroppedOn{get;set;}


        public static List<TileModel> player1Tiles { get; set; } = new List<TileModel>();
        public static List<TileModel> player2Tiles { get; set; } = new List<TileModel>();
        public static List<TileModel> player3Tiles { get; set; } = new List<TileModel>();
        public static List<TileModel> player4Tiles { get; set; } = new List<TileModel>();

        void BuildTilePool(TileModel t)
        {
            try
            {


                for (int i = 0; i < t.numInPool; i++)
                {
                    count++;
                    t.id = count;
                    // Console.WriteLine("tile: " + t.id);
                    tilePool.Add(t);
                    ;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                count = 0;
            }
        }
        public static List<TileModel> ShufflePool()
        {
            try
            {
                var rnd = new Random();
                var x = tilePool.OrderBy(item => rnd.Next());
                Console.WriteLine(x.ToList().Count);
                return x.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                countDealt = 0;
            }

        }

        public void DrawInitialHands(List<TileModel> shuffledtiles,PlayerModel player)
        {
            try
            {
                Console.WriteLine("player num: " + player.number);
                Console.WriteLine("player name: "+player.userName);
                // Console.WriteLine("shuffled count: " + shuffledtiles.Count);

                switch (player.number)
                {
                    case (int)PlayerNum.One:
                        player1Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        { 
                            // Console.WriteLine("shuffled[i]: "+ shuffledtiles[i]);
                            shuffledtiles[i].assignedTo=(int)PlayerNum.One;
                            player1Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                        
                            countDealt++;
                        }
                        break;
                    case (int)PlayerNum.Two:
                        player2Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        {
                          
                            player2Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                            player2Tiles[i].assignedTo=(int)PlayerNum.Two;
                            countDealt++;
                        }
                        break;
                    case (int)PlayerNum.Three:
                        player3Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        {
                            
                            player3Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                            player3Tiles[i].assignedTo=(int)PlayerNum.Three;
                            countDealt++;
                        }
                        break;
                    case (int)PlayerNum.Four:
                        player4Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        {
                           
                            player4Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                           player4Tiles[i].assignedTo=(int)PlayerNum.Four;
                            countDealt++;
                        }
                        break;
                    default:
                        //something went wrong
                        break;


                }
           
                // Console.WriteLine("shuffled count: " + shuffledtiles.Count);
                //in the "for" loop above...we can't take out any untill the add op is complete.               
                shuffledtiles.RemoveRange(0, 7);
                // Console.WriteLine("shuffled count: " + shuffledtiles.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: "+ex.Message);
            }


        }
    }
}
