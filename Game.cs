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
        private Spaceship spaceship = null;
        private List<Enemy> enemies = new List<Enemy>();

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
            AddEnemyToGame(3, 8);
        }

        private void AddSpaceshipToGame()
        {
            spaceship = new Spaceship(this);
            spaceship.FireCooldown = 500;
            this.Controls.Add(spaceship);
            spaceship.Left = 150;
            spaceship.Top = ClientRectangle.Height - spaceship.Height;
        }

        private void AddEnemyToGame(int rows, int columns)
        {
            Enemy enemy = null;
            
            for(int i = 0; i < 5; i++)
            {
                enemy = new Enemy();
                enemy.Left = 60 + i * 80;
                enemy.Top = 100;
                this.Controls.Add(enemy);
                enemies.Add(enemy);
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
                spaceship.HorVelocity = -2;
            }
            else if(e.KeyCode == Keys.D)
            {
                spaceship.HorVelocity = 2;
            }
            else if(e.KeyCode == Keys.S)
            {
                spaceship.HorVelocity = 0;
            }
        }
    }
}
