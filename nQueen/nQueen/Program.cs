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
            var board = new Board(10);
            var nQ = new nQueen();
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            var list = nQ.GetNQueenAnswer(board);
            watch.Stop();

            Console.WriteLine(list[0].GetResult());
            Console.WriteLine(string.Format("n：{0}, ボード数:{1}\n処理時間:{2}", board.Length, list.Count, watch.ElapsedMilliseconds));
            return;
        }
    }
}
