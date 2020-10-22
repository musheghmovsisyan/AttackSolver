using System.Collections.Generic;
using System.Drawing;

namespace Movsisyan_Interface
{
    public abstract class Chessman
    {
        public int Count { get; set; }

        private ChessmanType chessmanType;
        public ChessmanType Type { get; set; }
        public Size BoardSize { get; set; }
        public Point StartCoords { get; set; }      

        public abstract int CalculateCountUnderAttack();
    }
}
