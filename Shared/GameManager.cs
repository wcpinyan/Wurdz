using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wurdz.Shared.GameManager
{
    public class GameManager
    {
        public GameManager()
        {

        }
        public enum GameState
        {
            BoardConstructed,
            PlayersSelected,
            GameStarted,
            HandsDealt,
            NextPlayerSelected,
            TilePlayed,
            WordBuilt,
            WordVerified,
            WordScored,
            WordChallenged,
            WordValidated,
            WordReset,
            ReadyForNextPlayer,
            TilePoolEmpty,
            HandHasNoWord,
            NoMorePlays,
            GameOver,
            WinnerDeclared,
            WinnerAddedToBoard
        }
        public enum Action
        {
            Invite,
            Start,
            Deal,
            SelectNextPlayer,
            Draw,
            DragLetter,
            EndWordConstruction,
            ScoreWord,
            RecallWord,
            ValidateWord,
            Challenge,
            Pass,
            Stop,
            DisplayGameStats,
            DisplayWinnerBoard
        }
        public GameState ChangeState(GameState current, Action action) =>
            (current, action) switch
            {
                (GameState.BoardConstructed, Action.Invite) => GameState.PlayersSelected,
                (GameState.PlayersSelected, Action.Start) => GameState.GameStarted,
                (GameState.GameStarted, Action.Deal) => GameState.HandsDealt,
                (GameState.HandsDealt, Action.SelectNextPlayer) => GameState.PlayersSelected,
                (GameState.PlayersSelected, Action.DragLetter) => GameState.TilePlayed,
                (GameState.TilePlayed, Action.EndWordConstruction) => GameState.WordBuilt,
                (GameState.WordBuilt, Action.ScoreWord) => GameState.WordScored,
                (GameState.WordScored, Action.Challenge) => GameState.WordChallenged,
                (GameState.WordChallenged, Action.RecallWord) => GameState.WordReset,
                (GameState.WordChallenged, Action.ValidateWord) => GameState.ReadyForNextPlayer,
                (GameState.WordScored, Action.Draw) => GameState.ReadyForNextPlayer,
                (GameState.ReadyForNextPlayer, Action.SelectNextPlayer) => GameState.PlayersSelected,
                (GameState.TilePoolEmpty, Action.Draw) => GameState.ReadyForNextPlayer,
                (GameState.HandHasNoWord, Action.Pass) => GameState.ReadyForNextPlayer,
                (GameState.NoMorePlays, Action.Stop) => GameState.GameOver,
                (GameState.GameOver, Action.DisplayGameStats) => GameState.WinnerDeclared,
                (GameState.WinnerDeclared, Action.DisplayWinnerBoard) => GameState.WinnerAddedToBoard,
                _ => throw new NotSupportedException(
            $"{current} has no transition on {action}")
            };
    }
}
