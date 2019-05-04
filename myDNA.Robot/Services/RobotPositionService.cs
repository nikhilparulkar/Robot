using myDNA.Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace myDNA.Robot.Services
{
    enum Direction
    {
        North = 0,
        East,
        South,
        West
    };

    enum TableDimensions
    {
        x_min = 0,
        x_max = 4,
        y_min = 0,
        y_max = 4
    };

    public class RobotPositionService : IRobotPosition
    {
        int x { get; set; }
        int y { get; set; }
        Direction D { get; set; }

        public RobotPositionService()
        {
        }

        public RobotPositionService(int X, int Y, String F)
        {
            x = X;
            y = Y;
            D = GetDirection(F);
        }

        private Direction leftOf(Direction t)
        {
            Direction result = Direction.North;
            switch (t)
            {
                case Direction.North:
                    result = Direction.West;
                    break;
                case Direction.East:
                    result = Direction.North;
                    break;
                case Direction.South:
                    result = Direction.East;
                    break;
                case Direction.West:
                    result = Direction.South;
                    break;
                default:
                    break;
            }
            return result;
        }

        private Direction rightOf(Direction t)
        {
            Direction result = Direction.North;
            switch (t)
            {
                case Direction.North:
                    result = Direction.East;
                    break;
                case Direction.East:
                    result = Direction.South;
                    break;
                case Direction.South:
                    result = Direction.West;
                    break;
                case Direction.West:
                    result = Direction.North;
                    break;
                default:
                    break;
            }
            return result;
        }

        public void move()
        {
            switch (D)
            {
                case Direction.North:
                    y = (y < (int)TableDimensions.y_max) ? ++y : y;
                    break;
                case Direction.East:
                    x = (x < (int)TableDimensions.x_max) ? ++x : x;
                    break;
                case Direction.South:
                    y = (y > (int)TableDimensions.y_min) ? --y : y;
                    break;
                case Direction.West:
                    x = (x > (int)TableDimensions.x_min) ? --x : x;
                    break;
                default:
                    break;
            }
        }

        public void left()
        {
            D = leftOf(D);
        }

        public void right()
        {
            D = rightOf(D);
        }

        public string report()
        {
            string result = x.ToString() + "," + y.ToString() + "," + D.ToString();
            Console.WriteLine(result);
            return result;
        }

        private Direction GetDirection(String F)
        {
            Direction result = Direction.North;

            try
            {
                switch (F.ToUpper())
                {
                    case "NORTH":
                        break;
                    case "SOUTH":
                        result = Direction.South;
                        break;
                    case "EAST":
                        result = Direction.East;
                        break;
                    case "WEST":
                        result = Direction.West;
                        break;
                    default:
                        throw new Exception("\n Invalid Direction");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public void place(int X, int Y, string F)
        {
            Direction Dir = GetDirection(F);

            if (X >= (int)TableDimensions.x_min && Y >= (int)TableDimensions.y_min &&
                X <= (int)TableDimensions.x_max && Y <= (int)TableDimensions.y_max)
            {
                x = X;
                y = Y;
                D = Dir;
            }
            else
            {
                Console.WriteLine("\n Invalid position");
            }

        }
    }
}
