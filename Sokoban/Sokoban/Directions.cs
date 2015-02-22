using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Directions
    {
        public enum Direction
        {
            Down,
            Left,
            Right,
            Up,
        }

        public Dictionary<Direction, int> dx;
        public Dictionary<Direction, int> dy;

        protected Directions()
        {
            dx = new Dictionary<Direction, int>();
            dy = new Dictionary<Direction, int>();

            dx.Add(Direction.Down, 0);
            dy.Add(Direction.Down, +1);

            dx.Add(Direction.Up, 0);
            dy.Add(Direction.Up, -1);

            dx.Add(Direction.Left, -1);
            dy.Add(Direction.Left, 0);

            dx.Add(Direction.Right, +1);
            dy.Add(Direction.Right, 0);
        }
    
        private sealed class SingletonCreator
        {
            private static readonly Directions instance = new Directions();

            public static Directions Instance
            {
                get
                {
                    return instance;
                }
            }
        }

        public static Directions Instance
        {
            get
            {
                return SingletonCreator.Instance;
            }
        }
    }   
}
