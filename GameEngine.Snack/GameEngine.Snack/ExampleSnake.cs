using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 5;
        private Point _myHeadPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection,int foodX,int foodY)
        {
            if(currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold|| foodY == _myHeadPosition.Y)
            {
                if (foodX < _myHeadPosition.X)
                {
                    return SnakeDirection.Left;
                }
                if (foodX > _myHeadPosition.X)
                {
                    return SnakeDirection.Right;
                }
                return SnakeDirection.Left;
            }

            if(currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold|| foodX == _myHeadPosition.X)
            {
                if (foodY < _myHeadPosition.Y)
                {
                    return SnakeDirection.Up;
                }
                if (foodY > _myHeadPosition.Y)
                {
                    return SnakeDirection.Down;
                }


                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold|| foodY == _myHeadPosition.Y)
            {

                if (foodX < _myHeadPosition.X)
                {
                    return SnakeDirection.Left;
                }
                if (foodX > _myHeadPosition.X)
                {
                    return SnakeDirection.Right;
                }

                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold|| foodX == _myHeadPosition.X)
            {
                if (foodY < _myHeadPosition.Y)
                {
                    return SnakeDirection.Up;
                }
                if (foodY > _myHeadPosition.Y)
                {
                    return SnakeDirection.Down;
                }


                return SnakeDirection.Down;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }
    }
}
