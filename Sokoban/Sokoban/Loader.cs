using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Loader : myObject
    {
        public Loader()
            : base(Pictures.Loader)
        {
        }

        public override void Draw(Painter painter)
        {
            base.Draw(painter);
        }
    }
}
