using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program(8);
            var list = obj.GetNQueenAnswer();
            Console.WriteLine(obj.GetResult(list[0]));
            Console.WriteLine("回答数：{0} 処理時間:{1}", list.Count, obj.ElapsedTime);
        }
        private bool[,] BaseBoard = null;

        private uint Length = 0;

        private ulong elapsedTime = 0;

        public ulong ElapsedTime
        {
            get
            {
                return elapsedTime;
            }
        }

        /// <summary>
        /// 正解のボードのリスト
        /// </summary>
        private List<bool[,]> CorrectAnswerList = new List<bool[,]>();

        public Program(uint len)
        {
            Length = len;
            BaseBoard = new bool[Length, Length];
        }

        /// <summary>
        /// NQueenの正解リストを取得する
        /// </summary>
        /// <param name="baseBoard">初期状態のボード</param>
        /// <returns>正解のボードリスト</returns>
        public List<bool[,]> GetNQueenAnswer()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            SearchXLine(0, BaseBoard);
            watch.Stop();

            elapsedTime = (ulong)watch.ElapsedMilliseconds;

            return CorrectAnswerList;
        }

        /// <summary>
        /// 配置可能なセルにQueenを配置する。
        /// (X軸方向に配置可能なセルを探索する)
        /// </summary>
        /// <param name="yPos">y軸の添え字</param>
        /// <param name="board">ボード</param>
        public void SearchXLine(int yPos, bool[,] board)
        {
            for (int xPos = 0; xPos < Length; xPos++)
            {
                // Queenの進路上に別Queenが存在しない場合はQueen配置可能とする
                if (IsEnablePutQueen(board, xPos, yPos))
                {
                    // Queenを配置
                    board[xPos, yPos] = true;

                    // yPosの条件で次の列の探索をするか結果を配置するか分岐する
                    if (yPos == Length - 1)
                    {
                        // 正解リストにボードを加える
                        CorrectAnswerList.Add((bool[,])board.Clone());
                    }
                    else
                    {
                        // 次の列の探索へ
                        SearchXLine(yPos + 1, board);
                    }
                }
                // 現在のxPosでの探索が終わったらボードを探索前の状態に戻す
                board[xPos, yPos] = false;
            }
        }

        /// <summary>
        /// 現在のセルにQueenが配置可能か確認する
        /// </summary>
        /// <param name="board">ボード</param>
        /// <param name="xPos">現在位置(x軸)</param>
        /// <param name="yPos">現在位置(y軸)</param>
        /// <returns>true：配置可能 false:配置不可能</returns>
        private bool IsEnablePutQueen(bool[,] board, int xPos, int yPos)
        {
            // 横ラインにQueenが存在するか確認する
            for (int x = 0; Length > x; x++)
            {
                if (board[x, yPos])
                {
                    return false;
                }
            }
            // 縦ラインにQueenが存在するか確認する
            for (int y = 0; Length > y; y++)
            {
                if (board[xPos, y])
                {
                    return false;
                }
            }
            // 右ななめ上にQueenが存在するか確認する
            for (int x = xPos + 1, y = yPos - 1; Length > x && y >= 0; x++, y--)
            {
                if (board[x, y])
                {
                    return false;
                }
            }
            // 右ななめ下にQueenが存在するか確認する
            for (int x = xPos + 1, y = yPos + 1; Length > x && Length > y; x++, y++)
            {
                if (board[x, y])
                {
                    return false;
                }
            }
            // 左ななめ上にQueenが存在するか確認する
            for (int x = xPos - 1, y = yPos - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (board[x, y])
                {
                    return false;
                }
            }
            // 左ななめ下にQueenが存在するか確認する
            for (int x = xPos - 1, y = yPos + 1; x >= 0 && Length > y; x--, y++)
            {
                if (board[x, y])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 結果を出力する
        /// </summary>
        /// <param name="board">ボード</param>
        /// <returns>結果</returns>
        public string GetResult(bool[,] board)
        {
            string boardStr = "";

            for (int yPos = 0; yPos < Length; yPos++)
            {
                for (int xPos = 0; xPos < Length; xPos++)
                {
                    if (board[xPos, yPos])
                    {
                        boardStr += "Ｑ";
                    }
                    else
                    {
                        boardStr += "・";
                    }
                }
                boardStr += "\n";
            }
            return boardStr;
        }
    }
}
