using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace nQueen
{
    [SerializableAttribute()]
    public class Board
    {
        /// <summary>
        /// n x nのボード
        /// </summary>
        public bool[,] cells;

        /// <summary>
        /// 一辺の長さ
        /// </summary>
        public int Length = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="len">一辺の長さ</param>
        public Board(int len)
        {
            Length = len;
            cells = new bool[Length, Length];
        }

        /// <summary>
        /// ボードを複製する
        /// </summary>
        /// <returns>複製したボード</returns>
        public Board Clone()
        {
            object clone;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                clone = formatter.Deserialize(stream);
            }
            return clone as Board;
        }

        /// <summary>
        /// 結果を出力する
        /// </summary>
        /// <returns>結果</returns>
        public string GetResult()
        {
            string boardStr = "";

            for (int yPos = 0; yPos < Length; yPos++)
            {
                for (int xPos = 0; xPos < Length; xPos++)
                {
                    if (cells[xPos, yPos])
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
