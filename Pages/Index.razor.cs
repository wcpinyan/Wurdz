using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wurdz.Shared.GameManager;
using Wurdz.Shared.Models;

namespace Wurdz.Pages
{
    public partial class Index
    {
        void ProcessState(GameManager.GameState state)
        {
             switch (state)
            {
                
                case GameManager.GameState.BoardConstructed:
                    createTilePool();
                    break;
                case GameManager.GameState.PlayersSelected:
                    break;
            
            }
        }
        async Task UpdatePlayerHand(TileModel t)
        {
            currentWord.Add(t);
            appState.player1Tiles.Remove(t);
            await OnUpdate.InvokeAsync(null);
        }
        void createTilePool()
        {
            try
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    string url = $"images/{letters[i]}.svg";
             
                    ti = new TileModel(i, url, letters[i].ToString(), tilenums[i, 1], tilenums[i, 0]);
                    tilePool = TileModel.tilePool; //tilePool is a static class variable not instance var
                                                   // Console.WriteLine(tilePool);
                    shuffled = TileModel.ShufflePool();
                    appState.shuffledTiles = shuffled;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:  ======>" + ex.Message.ToString());
            }


        }
        void ScoreWord()
        {
            Cell cell = null;
            int wordMultiplyer = 1;

            foreach (TileModel t in currentWord)
            {
                cell = t.cellDroppedOn;
                //assume 1 for all then update for anything above
                if (cell.wordMultiplyer > 1)
                {
                    wordMultiplyer = cell.wordMultiplyer;
                }
                wordScore += t.pointValue * cell.letterMultiplier;
            }
            wordScore *= wordMultiplyer;
        }
        void RecallWord()
        {
            Cell cell;

            foreach (TileModel t in currentWord)
            {

                cell = t.cellDroppedOn;
                if (cell.col == 7 && cell.row == 7)
                {
                    cell.image = "images/star.png";
                }
                else
                {
                    cell.image = "";
                }
                appState.player1Tiles.Add(t);

            }
            currentWord.Clear();
            StateHasChanged();
        }
    }
}
