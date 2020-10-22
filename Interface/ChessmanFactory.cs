using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Movsisyan_Interface
{
    public static class ChessmanFactory
    {

        public static Chessman Build(ChessmanType chessmanType, Size boardSize, Point startCoords, Point[] obstacles)
        {

            List<Point> pointsOfList = obstacles.ToList();


            List<Point> pointsOfListX = pointsOfList.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();

            Dictionary<int, List<int>> obstaclesX = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> obstaclesY = new Dictionary<int, List<int>>();

            foreach (var it in pointsOfListX)
            {
                if (!obstaclesX.ContainsKey(it.X))
                    obstaclesX.Add(it.X, new List<int>());

                obstaclesX[it.X].Add(it.Y);
            }

            List<Point> pointsOfListY = pointsOfList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();

            foreach (var it in pointsOfListY)
            {
                if (!obstaclesY.ContainsKey(it.Y))
                    obstaclesY.Add(it.Y, new List<int>());

                obstaclesY[it.Y].Add(it.X);
            }

            switch (chessmanType)
            {
                case ChessmanType.Rook:
                    return new Rook(chessmanType, boardSize, startCoords, obstaclesX, obstaclesY);
                case ChessmanType.Bishop:
                    return new Bishop(chessmanType, boardSize, startCoords, pointsOfListX, pointsOfListY);
                case ChessmanType.Knight:
                    return new Knight(chessmanType, boardSize, startCoords, obstaclesX);

                default:
                    throw new Exception("The current chessman type is not supported.");

            }
        }
    }
}
