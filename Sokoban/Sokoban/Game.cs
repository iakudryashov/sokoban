using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sokoban
{
    public class Game
    {
        public int boxesScore;
        public int bonusesScore;

        bool[,] field;

        List<Obstacle> obstacles;
        List<Bonus> bonuses;
        List<Box> boxes;
        List<Loader> loaders;
        Man man;

        private void GenerateMan()
        {
            while (true)
            {
                man = new Man();
                if (field[man.x, man.y]) continue;
                field[man.x, man.y] = true;
                break;
            }
        }

        bool correct(int x, int X) { return 0 <= x && x < X; }

        private void GenerateBoxes()
        {
            boxes = new List<Box>();

            while (boxes.Count < Constants.cntBoxes)
            {
                Box nbox = new Box();
                if (field[nbox.x, nbox.y]) continue;

                for (int dx = -1; dx <= 1; dx += 2)
                    for (int dy = -1; dy <= 1; dy += 2)
                        if ((!correct(nbox.x + dx, Constants.cntWidth) || field[nbox.x + dx, nbox.y]) &&
                            (!correct(nbox.y + dy, Constants.cntHeight) || field[nbox.x, nbox.y + dy]))
                            goto done;

                field[nbox.x, nbox.y] = true;
                boxes.Add(nbox);
                done: ;
            }
        }

        private void GenerateBonuses()
        {
            bonuses = new List<Bonus>();

            while (bonuses.Count < Constants.cntBonuses)
            {
                Bonus nbonus = new Bonus();
                if (field[nbonus.x, nbonus.y]) continue;
                field[nbonus.x, nbonus.y] = true;
                bonuses.Add(nbonus);
            }
        }

        private void GenerateLoaders()
        {
            loaders = new List<Loader>();

            while (loaders.Count < Constants.cntLoaders)
            {
                Loader nloader = new Loader();
                if (field[nloader.x, nloader.y]) continue;
                field[nloader.x, nloader.y] = true;
                loaders.Add(nloader);
            }
        }

        private void GenerateObstacles()
        {
            obstacles = new List<Obstacle>();

            while (obstacles.Count < Constants.cntObstacles)
            {
                Obstacle nobstacle = new Obstacle();
                if (field[nobstacle.x, nobstacle.y]) continue;
                field[nobstacle.x, nobstacle.y] = true;
                obstacles.Add(nobstacle);
            }
        }

        private void GenerateField()
        {
            field = new bool[Constants.cntWidth, Constants.cntHeight];
            for (int i = 0; i < Constants.cntWidth; i++)
                for (int j = 0; j < Constants.cntHeight; j++)
                    field[i, j] = false;

            GenerateObstacles();
            GenerateBoxes();
            GenerateBonuses();
            GenerateLoaders();
            GenerateMan();

            for (int i = 0; i < Constants.cntWidth; i++)
                for (int j = 0; j < Constants.cntHeight; j++)
                    field[i, j] = false;

            for (int i = 0; i < obstacles.Count; i++)
                field[obstacles[i].x, obstacles[i].y] = true;
        }

        public Game()
        {
            boxesScore = 0;
            bonusesScore = 0;
            GenerateField();
        }

        bool correct(int x, int y, int X, int Y) { return 0 <= x && x < X && 0 <= y && y < Y; }

        int haveBox(int x, int y)
        {
            for (int i = 0; i < boxes.Count; i++)
                if (boxes[i].x == x && boxes[i].y == y)
                    return i;
            return -1;
        }

        bool haveLoader(int x, int y)
        {
            for (int i = 0; i < loaders.Count; i++)
                if (loaders[i].x == x && loaders[i].y == y)
                    return true;
            return false;
        }

        int haveBonus(int x, int y)
        {
            for (int i = 0; i < bonuses.Count; i++)
                if (bonuses[i].x == x && bonuses[i].y == y)
                    return i;
            return -1;
        }

        public bool tryMove(Directions.Direction dir)
        {
            int nx = man.x + Directions.Instance.dx[dir];
            int ny = man.y + Directions.Instance.dy[dir];

            if (!correct(nx, ny, Constants.cntWidth, Constants.cntHeight) || field[nx, ny]) return false;

            if (haveBox(nx, ny) != -1)
            {
                int nnx = nx + Directions.Instance.dx[dir];
                int nny = ny + Directions.Instance.dy[dir];

                if (!correct(nnx, nny, Constants.cntWidth, Constants.cntHeight) || field[nnx, nny] || haveBox(nnx, nny) != -1) return false;

                int idx = haveBox(nx, ny);

                boxes[idx].x += Directions.Instance.dx[dir];
                boxes[idx].y += Directions.Instance.dy[dir];

                if (haveLoader(nnx, nny)) boxesScore++;
                if (haveLoader(nx, ny)) boxesScore--;
            }

            man.x += Directions.Instance.dx[dir];
            man.y += Directions.Instance.dy[dir];

            if (haveBonus(man.x, man.y) != -1)
            {
                bonusesScore++;
                bonuses.RemoveAt(haveBonus(man.x, man.y));
            }

            return true;
        }

        public void DrawBackground(Painter painter)
        {
            ImagePool.Instance.DrawPicture(painter, Pictures.Grass, 0, 0, painter.getWidth() , painter.getHeight());

            Pen pen = new Pen(Brushes.Black, Constants.brushWidth);

            for (int i = 0; i <= Constants.cntWidth; i++)
                painter.DrawLine(pen, painter.getWidth() / Constants.cntWidth * i, 0, painter.getWidth() / Constants.cntWidth * i, painter.getHeight());
            for (int i = 0; i <= Constants.cntHeight; i++)
                painter.DrawLine(pen, 0, painter.getHeight() / Constants.cntHeight * i, painter.getWidth(), painter.getHeight() / Constants.cntHeight * i);
        }

        public void Draw(Painter painter)
        {
            DrawBackground(painter);
            for (int i = 0; i < obstacles.Count; i++) obstacles[i].Draw(painter);
            for (int i = 0; i < bonuses.Count; i++) bonuses[i].Draw(painter);
            for (int i = 0; i < loaders.Count; i++) loaders[i].Draw(painter);
            for (int i = 0; i < boxes.Count; i++) boxes[i].Draw(painter);
            man.Draw(painter);
        }
    }
}
