using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Man : myObject
    {
        public Man()
            : base(Pictures.Man)
        {
        }

        public override void Draw(Painter painter)
        {
            base.Draw(painter);
        }
    }
}
