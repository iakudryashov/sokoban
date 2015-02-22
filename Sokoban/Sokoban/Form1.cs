using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class Form1 : Form
    {
        Game game;

        public Form1()
        {
            InitializeComponent();
            game = new Game();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            game = new Game();
            bonusLabel.Text = game.bonusesScore.ToString();
            boxLabel.Text = game.boxesScore.ToString();
            pictureBox1.Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down) game.tryMove(Directions.Direction.Down);
            if (e.KeyData == Keys.Up) game.tryMove(Directions.Direction.Up);
            if (e.KeyData == Keys.Left) game.tryMove(Directions.Direction.Left);
            if (e.KeyData == Keys.Right) game.tryMove(Directions.Direction.Right);
            bonusLabel.Text = game.bonusesScore.ToString();
            boxLabel.Text = game.boxesScore.ToString();
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(new Painter(e.Graphics));
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
