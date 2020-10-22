using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Movsisyan_Interface
{
    public class Knight : Chessman
    {

         Dictionary<int, List<int>> ObstaclesX { get; set; }

        private Size[] Steps = new Size[] { new Size(-2, -1), new Size(-2, 1), new Size(2, -1), new Size(2, 1), new Size(-1, -2), new Size(-1, 2), new Size(1, -2), new Size(1, 2) };

        public Knight() { }

        public Knight(ChessmanType chessmanType, Size boardSize, Point startCoords, Dictionary<int, List<int>> obstaclesX)
        {
            Type = chessmanType;
            BoardSize = boardSize;
            StartCoords = startCoords;
            ObstaclesX = obstaclesX;
        }

        private int Walk(Size step)
        {
            int count = 0;

            Point point = Point.Add(StartCoords, step);

            if ((point.X > 0 && point.Y > 0) && (point.X <= BoardSize.Width && point.Y <= BoardSize.Height))
            {
                if (!ObstaclesX.ContainsKey(point.X))
                {
                    count =  1;
                }
                else
                {
                    if (!ObstaclesX[point.X].Contains(point.Y))
                        count =  1;
                    //else count = 0;
                }
            }
            //else
            //{
            //    count = 0;
            //}
            return count;
        }


        public override int CalculateCountUnderAttack()
        {
            int count = 0;

            List<Task<int>> tasks = new List<Task<int>>();

            Parallel.ForEach(Steps, i =>
            {
                tasks.Add(Task.Run(() => Walk(i)));
            });

            Task.WaitAll(tasks.ToArray());

            foreach (var it in tasks)
            {
                count += it.Result;
            }

            return count;
        }
    }
}
