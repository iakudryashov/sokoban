using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Box : myObject
    {
        public Box()
            : base(Pictures.Box)
        {
        }

        public override void Draw(Painter painter)
        {
            base.Draw(painter);
        }
    }
}
