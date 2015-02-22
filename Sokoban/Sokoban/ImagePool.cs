using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sokoban
{
    public class ImagePool
    {
        protected Dictionary<Pictures, Image> pictures;

        protected ImagePool()
        {
            pictures = new Dictionary<Pictures,Image>();

            pictures.Add(Pictures.Grass, Images.Grass);
            pictures.Add(Pictures.Man, Images.Man);
            pictures.Add(Pictures.Obstacle, Images.Obstacle);
            pictures.Add(Pictures.Box, Images.Box);
            pictures.Add(Pictures.Loader, Images.Loader);
            pictures.Add(Pictures.Bonus, Images.Bonus);
        }

        private sealed class SingletonCreator
        {
            private static readonly ImagePool instance = new ImagePool();

            public static ImagePool Instance
            {
                get
                {
                    return instance;
                }
            }
        }

        public static ImagePool Instance
        {
            get
            {
                return SingletonCreator.Instance;
            }
        }

        public void DrawPicture(Painter painter, Pictures picture, int x, int y, int width, int height)
        {
            if (!pictures.ContainsKey(picture)) throw new Exception("There is no such picture");
            painter.DrawImage(painter.ResizeImg(pictures[picture], width, height), x, y, width, height);
        }
    }
}
