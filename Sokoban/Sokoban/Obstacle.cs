using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Obstacle : myObject
    {
        public Obstacle()
            : base(Pictures.Obstacle)
        {
        }

        public override void Draw(Painter painter)
        {
            base.Draw(painter);
        }
    }
}
