using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class myObject
    {
        public int x { get; set; }
        public int y { get; set; }
        Pictures picture;

        public myObject(Pictures tpicture)
        {
            Random rand = new Random();
            x = rand.Next(Constants.cntWidth - 1);
            y = rand.Next(Constants.cntHeight - 1);
            picture = tpicture;
        }

        public virtual void Draw(Painter painter)
        {
            ImagePool.Instance.DrawPicture(painter, picture, this.x * (painter.getWidth() / Constants.cntWidth) + Constants.brushWidth, 
                                                             this.y * (painter.getHeight() / Constants.cntHeight) + Constants.brushWidth,
                                                             painter.getWidth() / Constants.cntWidth - 2 * Constants.brushWidth,
                                                             painter.getHeight() / Constants.cntHeight - 2 * Constants.brushWidth);
        }
    }
}
