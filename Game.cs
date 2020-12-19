using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders2020
{
    public partial class Game : Form
    {
        Spaceship spaceship = null;
        List<Enemy> enemies = new List<Enemy>();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;
            this.BackColor = Color.Black;
            AddSpaceshipToGame();
            AddEnemiesToGame();
        }

        private void AddSpaceshipToGame()
        {
            spaceship = new Spaceship(this);
            spaceship.FireCooldown = 500;
            spaceship.Left = this.ClientRectangle.Width / 2 - spaceship.Width / 2;
            spaceship.Top = this.ClientRectangle.Height - spaceship.Height;
            this.Controls.Add(spaceship);
        }

        private void AddEnemiesToGame()
        {
            Enemy enemy;
            for(int i = 0; i < 5; i++)
            {
                enemy = new Enemy();
                enemy.Top = 100;
                enemy.Left = 80 * i;
                enemies.Add(enemy);
                this.Controls.Add(enemy);
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                spaceship.Fire();
            }
            else if(e.KeyCode == Keys.A)
            {
                spaceship.MoveLeft();
            }
            else if (e.KeyCode == Keys.D)
            {
                spaceship.MoveRight();
            }
            else if (e.KeyCode == Keys.S)
            {
                spaceship.Stop();
            }
        }
    }
}
