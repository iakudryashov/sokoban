using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Bonus : myObject
    {
        public Bonus()
            : base(Pictures.Bonus)
        {
        }

        public override void Draw(Painter painter)
        {
            base.Draw(painter);
        }
    }
}
