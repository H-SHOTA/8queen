using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nQueen
{
    public class nQueen
    {
        /// <summary>
        /// 正解のボードのリスト
        /// </summary>
        private List<Board> CorrectAnswerList = new List<Board>();

        /// <summary>
        /// NQueenの正解リストを取得する
        /// </summary>
        /// <param name="baseBoard">初期状態のボード</param>
        /// <returns>正解のボードリスト</returns>
        public List<Board> GetNQueenAnswer(Board baseBoard)
        {
            SearchXLine(0, baseBoard);
            return CorrectAnswerList;
        }

        /// <summary>
        /// 配置可能なセルにQueenを配置する。
        /// (X軸方向に配置可能なセルを探索する)
        /// </summary>
        /// <param name="yPos">y軸の添え字</param>
        /// <param name="board">ボード</param>
        public void SearchXLine(int yPos, Board board)
        {
            for (int xPos = 0; xPos < board.Length; xPos++)
            {
                // Queenの進路上に別Queenが存在しない場合はQueen配置可能とする
                if ( IsEnablePutQueen(board, xPos, yPos))
                {
                    // Queenを配置
                    board.cells[xPos, yPos] = true;

                    // yPosの条件で次の列の探索をするか結果を配置するか分岐する
                    if (yPos == board.Length - 1)
                    {
                        // 正解リストにボードを加える
                        CorrectAnswerList.Add(board.Clone());
                    }
                    else
                    {
                        // 次の列の探索へ
                        SearchXLine(yPos + 1, board);
                    }
                }
                // 現在のxPosでの探索が終わったらボードを探索前の状態に戻す
                board.cells[xPos, yPos] = false;
            }
        }

        /// <summary>
        /// 現在のセルにQueenが配置可能か確認する
        /// </summary>
        /// <param name="board">ボード</param>
        /// <param name="xPos">現在位置(x軸)</param>
        /// <param name="yPos">現在位置(y軸)</param>
        /// <returns>true：配置可能 false:配置不可能</returns>
        private bool IsEnablePutQueen(Board board, int xPos, int yPos)
        {
            // 横ラインにQueenが存在するか確認する
            for (int x = 0; board.Length > x; x++)
            {
                if (board.cells[x, yPos])
                {
                    return false;
                }
            }
            // 縦ラインにQueenが存在するか確認する
            for (int y = 0; board.Length > y; y++)
            {
                if (board.cells[xPos, y])
                {
                    return false;
                }
            }
            // 右ななめ上にQueenが存在するか確認する
            for (int x = xPos + 1, y = yPos - 1; board.Length > x && y >= 0; x++, y--)
            {
                if (board.cells[x, y])
                {
                    return false;
                }
            }
            // 右ななめ下にQueenが存在するか確認する
            for (int x = xPos + 1, y = yPos + 1; board.Length > x && board.Length > y; x++, y++)
            {
                if (board.cells[x, y])
                {
                    return false;
                }
            }
            // 左ななめ上にQueenが存在するか確認する
            for (int x = xPos - 1, y = yPos - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (board.cells[x, y])
                {
                    return false;
                }
            }
            // 左ななめ下にQueenが存在するか確認する
            for (int x = xPos - 1, y = yPos + 1; x >= 0 && board.Length > y; x--, y++)
            {
                if (board.cells[x, y])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
