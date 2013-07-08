using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nQueen
{
    [SerializableAttribute()]
    public class Cell
    {
        /// <summary>
        /// セルの状態リスト
        /// </summary>
        public enum CellStatus
        {
            Empty = 0,  // Queenなし
            ExistQueen  // Queenあり
        }

        /// <summary>
        /// セルのx座標
        /// </summary>
        public int xPos = 0;
        
        /// <summary>
        /// セルのy座標
        /// </summary>
        public int yPos = 0;
        
        /// <summary>
        /// セルの状態
        /// </summary>
        public CellStatus status = CellStatus.Empty;
    }
}
