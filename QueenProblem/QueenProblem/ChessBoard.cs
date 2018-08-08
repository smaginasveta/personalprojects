using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenProblem
{
    class ChessBoard
    {
        int BoardSize;
        char[,] Board;
        int QueenPlacedCount;
        int FreePlacesForQueen;
        public ChessBoard (int boardSize)
        {
            BoardSize = boardSize;
            Board = new char[boardSize,boardSize];
            QueenPlacedCount = 0;
            FreePlacesForQueen = BoardSize * BoardSize;
            // initialize with zeros
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Board[i, j] = '0';
                }
            }

        }

        public void ShowChessBoardState()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write(Board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("QueensPlaced:" + QueenPlacedCount + ' ' + "Available Places: " + FreePlacesForQueen);
            Console.WriteLine();
        }

        public void PlaceQueen()
        {
            // method that will put a queen in the first available position on board
            bool queenPlaced = false;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (Board[i, j] == '0')
                    {
                        Board[i, j] = 'Q';
                        QueenPlacedCount++;
                        FreePlacesForQueen--;
                        queenPlaced = true;
                        FindNonEligiblePositionsForNextQueen(i, j);
                        if (queenPlaced)
                        {
                            break;
                        }
                    }
                }
                if (queenPlaced)
                {
                    break;
                }
            }


        }

        public void MarkThisPositionAsNonEligible(int horIndex, int verIndex)
        {
            if (Board[horIndex, verIndex] == '0')
            {
                Board[horIndex, verIndex] = 'X';
                FreePlacesForQueen--;
            }
        }


        public void FindNonEligiblePositionsForNextQueen(int verIndex , int horIndex)
        {
            // method that will mark all non-eligible places for next queen after the last one was placed
            // horizontally
            for (int j = 0; j < BoardSize; j++)
            {
                MarkThisPositionAsNonEligible(verIndex, j);
            }

            //vertically
            for (int i = 0; i<BoardSize; i++)
            {
                MarkThisPositionAsNonEligible(i, horIndex);
            }

            //diagonally 
            // going down
            int h = horIndex;
            int v = verIndex;
            while (h > 0 && v > 0)
            {
                // up & left
                h--;
                v--;
                MarkThisPositionAsNonEligible(v,h);
            }

            h = horIndex;
            v = verIndex;
            while (h > 0 && v < BoardSize - 1)
            {
                // down & left
                h--;
                v++;
                MarkThisPositionAsNonEligible(v, h);
            }


            h = horIndex;
            v = verIndex;
            while (h > BoardSize - 1 && v > 0)
            {
                // up & right
                h++;
                v--;
                MarkThisPositionAsNonEligible(v, h);
            }

            h = horIndex;
            v = verIndex;
            while (h < BoardSize - 1 && v < BoardSize - 1)
            {
                // up & down
                h++;
                v++;
                MarkThisPositionAsNonEligible(v, h);
            }

        }

        public int SearchQueenProblemSolution()
        {
            while (FreePlacesForQueen > 0)
            {
                PlaceQueen();
                ShowChessBoardState();
            }
            if (QueenPlacedCount < BoardSize)
                Console.WriteLine("Solution not found");
            else
                Console.WriteLine("Solution found!");
            return 0;
        }

    }
    

}
