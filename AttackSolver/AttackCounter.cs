using Movsisyan_Interface;
using System.Drawing;

namespace Movsisyan_AttackSolver
{
    public class MyAttackCounter : IAttackCounter
    {
        public int CountUnderAttack(ChessmanType cmType, Size boardSize, Point startCoords, Point[] obstacles)
        {
            Chessman chessman = ChessmanFactory.Build(cmType, boardSize, startCoords, obstacles);
            return chessman.CalculateCountUnderAttack();
        }
    }
}
