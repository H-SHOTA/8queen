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
        public Cell[,] cells = null;
        public int Length = 0;

        protected Board(Board that)
        {
            cells = (Cell[,])that.cells;
            Length = that.Length;
        }

        public Board(int len)
        {
            Length = len;
            cells = new Cell[Length, Length];
            for (int yPos = 0; yPos < Length; yPos++)
            {
                for (int xPos = 0; xPos < Length; xPos++)
                {
                    cells[xPos, yPos] = new Cell();
                }
            }
        }

        public virtual Board Clone()
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

        public string GetResult()
        {
            string boardStr = "";

            for (int yPos = 0; yPos < Length; yPos++)
            {
                for (int xPos = 0; xPos < Length; xPos++)
                {
                    if (cells[xPos, yPos].status == Cell.CellStatus.ExistQueen)
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
