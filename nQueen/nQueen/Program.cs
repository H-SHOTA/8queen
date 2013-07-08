using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nQueen
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(8);
            var nQ = new nQueen();
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            var list = nQ.GetNQueenAnswer(board);
            watch.Stop();

            Console.WriteLine(list[0].GetResult());
            Console.WriteLine(string.Format("n：{0}, ボード数:{1}\n処理時間:{2}", board.Length, list.Count, watch.ElapsedMilliseconds));
            return;
            //// オブジェクトコピー
            //var obj = new Program();
            //var board = new Board(8);
            //var board1 = obj.Foo(0, 0, (Board)board.Clone());
            //var board2 = obj.Foo(1, 1, (Board)board.Clone());
            //var board3 = obj.Foo(2, 2, (Board)board.Clone());

            //// 
            //var _board = new Board(8);
            //_board = obj.UpdateBoardStatus(board, 3, 3);
            //for (int yPos = 0; yPos < board.Length; yPos++)
            //{
            //    for (int xPos = 0; xPos < board.Length; xPos++)
            //    {
            //        if (board.cells[xPos, yPos].status == Cell.CellStatus.Disable)
            //        {
            //            Console.Write("×");
            //        }
            //        else
            //        {
            //            Console.Write("・");
            //        }
            //    }
            //    Console.WriteLine("");
            //}
            //return;
        }

        //public Board Foo(int x, int y, Board board)
        //{
        //    board.cells[x, y].status = Cell.CellStatus.ExistQueen;
        //    return board;
        //}

        //private Board UpdateBoardStatus(Board board, int xPos, int yPos)
        //{
        //    // Queenの位置の横ラインの状態更新
        //    for (int x = 0; board.Length > x; x++)
        //    {
        //        board.cells[x, yPos].status = Cell.CellStatus.Disable;
        //    }
        //    // Queenの位置の縦ラインの状態更新
        //    for (int y = 0; board.Length > y; y++)
        //    {
        //        board.cells[xPos, y].status = Cell.CellStatus.Disable;
        //    }
        //    // Queenの位置から右ななめ上の状態更新
        //    for (int x = xPos + 1, y = yPos - 1; board.Length > x && y >= 0; x++, y--)
        //    {
        //        board.cells[x, y].status = Cell.CellStatus.Disable;
        //    }
        //    // Queenの位置から右ななめ下の状態更新
        //    for (int x = xPos + 1, y = yPos + 1; board.Length > x && board.Length > y; x++, y++)
        //    {
        //        board.cells[x, y].status = Cell.CellStatus.Disable;
        //    }
        //    // Queenの位置から左ななめ上の状態更新
        //    for (int x = xPos - 1, y = yPos - 1; x >= 0 && y >= 0; x--, y--)
        //    {
        //        board.cells[x, y].status = Cell.CellStatus.Disable;
        //    }
        //    // Queenの位置から左ななめ下の状態更新
        //    for (int x = xPos - 1, y = yPos + 1; x >= 0 && board.Length > y; x--, y++)
        //    {
        //        board.cells[x, y].status = Cell.CellStatus.Disable;
        //    }
        //    return board;
        //}
    }
}
