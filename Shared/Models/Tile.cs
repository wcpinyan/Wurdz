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

        private static int count=0;
        private static int countDealt = 0;
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


        public static List<Tile> player1Tiles { get; set; } = new List<Tile>();
        public static List<Tile> player2Tiles { get; set; } = new List<Tile>();
        public static List<Tile> player3Tiles { get; set; } = new List<Tile>();
        public static List<Tile> player4Tiles { get; set; } = new List<Tile>();

        void BuildTilePool(Tile t)
        {
            try
            {


                for (int i = 0; i < t.numInPool; i++)
                {
                    count++;
                    t.id = count;
                    Console.WriteLine("tile: " + t.id);
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
        public static List<Tile> ShufflePool()
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

        public void DrawInitialHands(List<Tile> shuffledtiles,Player player)
        {
            try
            {
                Console.WriteLine("player1 num: " + player.number);
                Console.WriteLine("shuffled count: " + shuffledtiles.Count);

                switch (player.number)
                {
                    case (int)PlayerNum.One:
                        player1Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        {
                           
                            Console.WriteLine("shuffled[i]: "+ shuffledtiles[i]);
                            player1Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                            Console.WriteLine(player1Tiles.Count);
                            countDealt++;
                        }
                        break;
                    case (int)PlayerNum.Two:
                        player2Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        {
                          
                            player2Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                            countDealt++;
                        }
                        break;
                    case (int)PlayerNum.Three:
                        player3Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        {
                            
                            player3Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                            countDealt++;
                        }
                        break;
                    case (int)PlayerNum.Four:
                        player4Tiles.Clear();
                        for (int i = 0; i < 7; i++)
                        {
                           
                            player4Tiles.Add(shuffledtiles[i]); //get each tile starting with the 1st 7 tiles left in shuffled   
                            countDealt++;
                        }
                        break;
                    default:
                        //something went wrong
                        break;


                }
           
                Console.WriteLine("shuffled count: " + shuffledtiles.Count);
                //in the "for" loop above...we can't take out any untill the add op is complete.               
                shuffledtiles.RemoveRange(0, 7);
                Console.WriteLine("shuffled count: " + shuffledtiles.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: "+ex.Message);
            }


        }
    }
}
