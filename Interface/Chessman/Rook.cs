using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Movsisyan_Interface
{
    public class Rook : Chessman
    {
         Dictionary<int, List<int>> ObstaclesX { get; set; }
         Dictionary<int, List<int>> ObstaclesY { get; set; }

   

        public Rook() { }

        public Rook(ChessmanType chessmanType, Size boardSize, Point startCoords, Dictionary<int, List<int>> obstaclesX, Dictionary<int, List<int>> obstaclesY)
        {
            Type = chessmanType;
            BoardSize = boardSize;
            StartCoords = startCoords;
            ObstaclesX = obstaclesX;
            ObstaclesY = obstaclesY;
        }

        private int Step1() //down
        {
            int count = 0;

            if (!ObstaclesX.ContainsKey(StartCoords.X))
            {
                count = StartCoords.Y - 1;
            }
            else
            {
                if (ObstaclesX[StartCoords.X].Any(p => p < StartCoords.Y))
                {
                    var near = ObstaclesX[StartCoords.X].Where(p => p < StartCoords.Y)
                         .DefaultIfEmpty(0)
                         .Max();
                    count = StartCoords.Y - near - 1;
                }
                else
                {
                    count = StartCoords.Y - 1;

                }

            }

            count = count < 0 ? 0 : count;


            return count;
        }
        private int Step2() //up
        {
            int count = 0;

            if (!ObstaclesX.ContainsKey(StartCoords.X))
            {
                count = BoardSize.Height - StartCoords.Y;
            }
            else
            {
                if (ObstaclesX[StartCoords.X].Any(p => p > StartCoords.Y))
                {
                    var near = ObstaclesX[StartCoords.X].Where(p => p > StartCoords.Y)
                         .DefaultIfEmpty(0)
                         .Min();
                    count = near - StartCoords.Y - 1;
                }
                else
                {
                    count = BoardSize.Height - StartCoords.Y;

                }

            }

            count = count < 0 ? 0 : count;


            return count;
        }
        private int Step3() //left
        {
            int count = 0;

            if (!ObstaclesY.ContainsKey(StartCoords.Y))
            {
                count = StartCoords.X - 1;
                
            }
            else
            {
                if (ObstaclesY[StartCoords.Y].Any(p => p < StartCoords.X))
                {
                    var near = ObstaclesY[StartCoords.Y].Where(p => p < StartCoords.X)
                         .DefaultIfEmpty(0)
                         .Max();
                    count = StartCoords.X - near - 1;
                 
                }
                else
                {
                    count = StartCoords.X - 1;
                    
                }

            }

            count = count < 0 ? 0 : count;


            return count;
        }
        private int Step4() //right
        {
            int count = 0;

            if (!ObstaclesY.ContainsKey(StartCoords.Y))
            {
                //count = BoardSize.Width - StartCoords.X;
                //count = 100;
            }
            //else
            {
                if (ObstaclesY.ContainsKey(StartCoords.Y) && ObstaclesY[StartCoords.Y].Any(p => p > StartCoords.X))
                {
                    var near = ObstaclesY[StartCoords.Y].Where(p => p > StartCoords.X)
                         .DefaultIfEmpty(0)
                         .Min();
                    count = near - StartCoords.X - 1;
                }
                else
                {
                    count = BoardSize.Width - StartCoords.X;
                }

            }

            count = count < 0 ? 0 : count;

            return count;
        }
        public override int CalculateCountUnderAttack()
        {
            int count = 0;

            Task<int>[] tasks = new Task<int>[4];
            tasks[0] = Task.Run(() => Step1());
            tasks[1] = Task.Run(() => Step2());
            tasks[2] = Task.Run(() => Step3());
            tasks[3] = Task.Run(() => Step4());

            Task.WaitAll(tasks);

            count += tasks[0].Result;
            count += tasks[1].Result;
            count += tasks[2].Result;
            count += tasks[3].Result;

            return count;
        }
    }
}


