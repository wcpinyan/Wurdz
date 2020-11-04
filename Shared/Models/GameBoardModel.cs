using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Wurdz.Shared.Models
{
    public class GameBoardModel
    {
       
        public GameBoardModel(int _numCellsPerSide)
        {
            
            numCellsPerSide = _numCellsPerSide;
            title = "Hello Wurdz";
            cells = new Cell[numCellsPerSide, numCellsPerSide];
            // Random rand = new Random();
            for (int i = 0; i < numCellsPerSide; i++) {
                for (int j = 0; j < numCellsPerSide; j++)
                {
                    //int gen = rand.Next(1, numCellsPerSide); //gen=random generated #
                    Cell cell = new Cell();
                    cell.row = i;
                    cell.col = j;
                    SetCellValues(cell);
                    cells[i, j] = cell;
                    //Console.WriteLine(i + "," + j + cell.color);
                }


            }
            CreatePinkCrissCross();
            void CreatePinkCrissCross()
            {
                int rowCount = 0;

                foreach (var c in cells)
                {
                    if (c.row == rowCount)
                    {
                        if (c.color == "whitesmoke") //other primary color has not been placed in this square, so give it pink if appropriate
                        {
                            //if(c.col==7 && c.row == 7) //this is white center piece so skip
                            //{
                            //    c. = "images/star.png";
                            //}
                            if (c.col == rowCount || c.col == numCellsPerSide - rowCount - 1)
                            {
                                c.color = "pink";
                                c.caption = "DW";
                                c.wordMultiplyer=2;
                            }
                        }
                    }
                    else
                    {
                        rowCount++;
                    }


                }




            }
            void SetCellValues(Cell c)
            {
                // setup a criss-cross of pink squares...then override with other colors as necessary
                c.letterMultiplier = 1; //unless otherwise noted
                //set center square to pink 1st since otherwise it would be set to red
                if (c.row == 7 && c.col == 7)
                {
                    c.color = "pink";
                    c.caption = "";
                    c.wordMultiplyer = 2;
                    c.image = "images/star.png";
                    return;
                }
                if ((c.row == 0 || c.row == 7 || c.row == 14) && (c.col == 0 || c.col == 7 || c.col == 14))
                {
                    c.caption = "TW";
                    c.color = "red";
                    c.wordMultiplyer=3;
                    return;
                }
                if ((c.row == 0 && (c.col == 3 || c.col == 11)) ||
                    (c.row == 2 && (c.col == 6 || c.col == 8)) ||
                   (c.row == 3 && (c.col == 0 || c.col == 7 || c.col == 14)) ||
                   (c.row == 6 && (c.col == 2 || c.col == 6)) ||
                   (c.row == 6 && (c.col == 8 || c.col == 13)) ||
                   (c.row == 7 && (c.col == 3 || c.col == 12)) ||

                   (c.row == 8 && (c.col == 2 || c.col == 6)) ||
                   (c.row == 8 && (c.col == 8 || c.col == 13)) ||

                    (c.row == 11 && (c.col == 0 || c.col == 7 || c.col == 14)) ||

                   (c.row == 12 && (c.col == 6 || c.col == 8)) ||
                   (c.row == 14 && (c.col == 3 || c.col == 11)))
                {
                    c.caption = "DL";
                    c.color = "lightblue";
                    c.letterMultiplier=2;
                    return;
                }
              
                if (((c.row == 1 || c.row==13) && (c.col == 5 || c.col == 9)) ||
                    ((c.row == 5 || c.row == 9 ) && (c.col == 1 || c.col == 5 || c.col==9 || c.col==13)))
                
                {
                    c.caption = "TL";
                    c.color = "steelblue";
                    c.letterMultiplier=3;
                    return;
                }
                
                else { 
                    c.caption = "";
                    c.color = "whitesmoke";
                    c.letterMultiplier=1;
                    return;
                
                }
               
            }

        }
        public int id { get; set; }
        public string title { get; set; }
        public int numCellsPerSide { get; set; }
        public Cell[,] cells { get; set; }
        public int CurrentRow { get; set; }
        public int CurrentCol { get; set; }
        public bool GameOver { get; set; }
        public PlayerModel activePlayer { get; set; }


    }
    public class Cell
    {
        public int id { get; set; }
        public int width { get; set; }
        public string caption { get; set; }
        public int col { get; set; }
        public int row { get; set; }
        public string image { get; set; }
        public string color { get; set; }
        public  int wordMultiplyer { get; set; }
        public int letterMultiplier { get; set; }
    }
}
