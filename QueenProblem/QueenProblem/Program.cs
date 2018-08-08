using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*The N Queen is the problem of placing N chess queens on an N×N chessboard so that no two queens attack each other.*/

namespace QueenProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = 4;

            var board = new ChessBoard(boardSize);
            board.SearchQueenProblemSolution();
            Console.ReadLine();
        }
        
    }
}
