using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Movsisyan_Interface
{
    public class Bishop : Chessman
    {
        List<Point> PointsOfListX { get; set; }
        List<Point> PointsOfListY { get; set; }

        public Bishop() { }

        public Bishop(ChessmanType chessmanType, Size boardSize, Point startCoords, List<Point> pointsOfListX, List<Point> pointsOfListY)
        {
            Type = chessmanType;
            BoardSize = boardSize;
            StartCoords = startCoords;
            PointsOfListX = pointsOfListX;
            PointsOfListY = pointsOfListY;
        }

        private int Step1()
        {
            int count = 0;

            int min = Math.Min(StartCoords.X, StartCoords.Y) - 1;


            Point TopLeft = new Point(StartCoords.X - min, StartCoords.Y); Point TopRight = new Point(StartCoords.X, StartCoords.Y);


            Point BottomLeft = new Point(StartCoords.X - min, StartCoords.Y - min); Point BottomRight = new Point(StartCoords.X, StartCoords.Y - min);



            if (!PointsOfListX.Any(p => (p.X < TopRight.X && p.X >= BottomLeft.X && p.Y < TopRight.Y && p.Y >= BottomLeft.Y)))
            {
                count = min;
            }
            else
            {
                var absDif = Math.Abs(StartCoords.X - StartCoords.Y);

                var points = PointsOfListX.Where(p => (p.X < TopRight.X && p.X >= BottomLeft.X & p.Y < TopRight.Y && p.Y >= BottomLeft.Y)).ToList();

                if (StartCoords.X == StartCoords.Y)
                {
                    points = points.Where(p => (p.X == p.Y)).ToList();
                }

                else
                {
                    if (StartCoords.X > StartCoords.Y)
                    {
                        points = points.Where(p => (p.X - absDif == p.Y)).ToList();
                    }
                    else
                    {
                        points = points.Where(p => (p.Y - absDif == p.X)).ToList();
                    }
                }

                if (points.Count > 0)
                {
                    var near = points.Max(p => p.X);
                    count = StartCoords.X - near - 1;
                }
                else
                {
                    count = min;
                }

            }

            count = count < 0 ? 0 : count;


            return count;
        }
        private int Step2()
        {
            int count = 0;

            int min = Math.Min(BoardSize.Width - StartCoords.X, StartCoords.Y) - 1;


            Point TopLeft = new Point(StartCoords.X, StartCoords.Y); Point TopRight = new Point(StartCoords.X + min, StartCoords.Y);


            Point BottomLeft = new Point(StartCoords.X, StartCoords.Y - min); Point BottomRight = new Point(StartCoords.X + min, StartCoords.Y - min);



            if (!PointsOfListX.Any(p => (p.X <= TopRight.X && p.X > BottomLeft.X && p.Y < TopRight.Y && p.Y >= BottomLeft.Y)))
            {
                count = min;
            }
            else
            {
                var absDif = Math.Abs((BoardSize.Width - StartCoords.X) - (StartCoords.Y));

                var points = PointsOfListX.Where(p => (p.X <= TopRight.X && p.X > BottomLeft.X && p.Y < TopRight.Y && p.Y >= BottomLeft.Y)).ToList();

                if ((BoardSize.Width - StartCoords.X + 1) == (StartCoords.Y))
                {
                    points = points.Where(p => (p.X == (BoardSize.Height - p.Y + 1))).ToList();
                }

                else
                {
                    if ((BoardSize.Width - StartCoords.X + 1) > (StartCoords.Y))
                    {
                        points = points.Where(p => (p.X + absDif == (BoardSize.Height - p.Y + 1))).ToList();
                    }
                    else
                    {
                        points = points.Where(p => ((BoardSize.Height - p.Y + 1) - absDif == p.X)).ToList();
                    }
                }

                if (points.Count > 0)
                {
                    var near = points.Min(p => p.X);
                    count = StartCoords.X - near - 1;
                }
                else
                {
                    count = min;
                }

            }

            count = count < 0 ? 0 : count;


            return count;
        }
        private int Step3()
        {
            int count = 0;

            int min = Math.Min(StartCoords.X, BoardSize.Height - StartCoords.Y) - 1;


            Point TopLeft = new Point(StartCoords.X - min, StartCoords.Y + min); Point TopRight = new Point(StartCoords.X, StartCoords.Y + min);


            Point BottomLeft = new Point(StartCoords.X - min, StartCoords.Y); Point BottomRight = new Point(StartCoords.X, StartCoords.Y);



            if (!PointsOfListX.Any(p => (p.X < TopRight.X && p.X >= BottomLeft.X & p.Y <= TopRight.Y && p.Y > BottomLeft.Y)))
            {
                count = min;
            }
            else
            {
                var absDif = Math.Abs(StartCoords.X - (BoardSize.Height - StartCoords.Y));

                var points = PointsOfListX.Where(p => (p.X < TopRight.X && p.X >= BottomLeft.X && p.Y <= TopRight.Y && p.Y > BottomLeft.Y)).ToList();

                if ((BoardSize.Width - StartCoords.X + 1) == (StartCoords.Y))
                {
                    points = points.Where(p => ((BoardSize.Width - p.X + 1) == p.Y)).ToList();
                }

                else
                {
                    if (StartCoords.X > (BoardSize.Height - StartCoords.Y + 1))
                    {
                        points = points.Where(p => ((BoardSize.Width - p.X + 1) - absDif == (p.Y))).ToList();
                    }
                    else
                    {
                        points = points.Where(p => ((p.Y + absDif) == ((BoardSize.Width - p.X + 1)))).ToList();
                    }
                }

                if (points.Count > 0)
                {
                    var near = points.Max(p => p.X);
                    count = StartCoords.X - near - 1;
                }
                else
                {
                    count = min;
                }

            }

            count = count < 0 ? 0 : count;


            return count;
        }
        private int Step4()
        {
            int count = 0;

            int min = Math.Min(BoardSize.Width - StartCoords.X, BoardSize.Height - StartCoords.Y);


            Point TopLeft = new Point(StartCoords.X, StartCoords.Y + min); Point TopRight = new Point(StartCoords.X + min, StartCoords.Y + min);


            Point BottomLeft = new Point(StartCoords.X, StartCoords.Y); Point BottomRight = new Point(StartCoords.X + min, StartCoords.Y);



            if (!PointsOfListX.Any(p => (p.X <= TopRight.X && p.X > BottomLeft.X && p.Y <= TopRight.Y && p.Y > BottomLeft.Y)))
            {
                count = min;
            }
            else
            {
                var absDif = Math.Abs((BoardSize.Width - StartCoords.X) - (BoardSize.Height - StartCoords.Y));

                var points = PointsOfListX.Where(p => (p.X <= TopRight.X && p.X > BottomLeft.X && p.Y <= TopRight.Y && p.Y > BottomLeft.Y)).ToList();

                if (StartCoords.X == StartCoords.Y)
                {
                    points = points.Where(p => (p.X == p.Y)).ToList();
                }

                else
                {

                    if ((BoardSize.Width - StartCoords.X) > (BoardSize.Height - StartCoords.Y))
                    {
                        points = points.Where(p => (p.X + absDif == p.Y)).ToList();
                    }
                    else
                    {
                        points = points.Where(p => (p.Y + absDif == p.X)).ToList();
                    }
                }

                if (points.Count > 0)
                {
                    var near = points.Min(p => p.X);
                    count = StartCoords.X - near - 1;
                }
                else
                {
                    count = min;
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

