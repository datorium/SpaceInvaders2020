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
        private Timer timerMain = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimerMain();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;
            this.BackColor = Color.Black;
            AddSpaceshipToGame();
            AddEnemiesToGame(6, 15);
        }

        private void AddSpaceshipToGame()
        {
            spaceship = new Spaceship(this);
            spaceship.FireCooldown = 500;
            spaceship.Left = this.ClientRectangle.Width / 2 - spaceship.Width / 2;
            spaceship.Top = this.ClientRectangle.Height - spaceship.Height;
            this.Controls.Add(spaceship);
        }

        private void AddEnemiesToGame(int rows, int cols)
        {
            Enemy enemy;
            for(int rowCounter = 0; rowCounter < rows; rowCounter++)
            {
                for (int colCounter = 0; colCounter < cols; colCounter++)
                {
                    enemy = new Enemy();
                    enemy.Top = 100 + 40 * rowCounter;
                    enemy.Left = 100 + 40 * colCounter;
                    enemies.Add(enemy);
                    this.Controls.Add(enemy);
                }
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

        private void BulletEnemyCollisionDetection()
        {
            //for(int b = 0; b < spaceship.bullets.Count; b++)
            //{
            //    for(int e = 0; e < enemies.Count; e++)
            //    {
            //        if (spaceship.bullets[b].Bounds.IntersectsWith(enemies[e].Bounds))
            //        {
            //            //collision detected
            //            //bullet.Dispose();
            //            //enemy.Dispose();
            //        }
            //    }
            //}            
            
            foreach(var bullet in spaceship.bullets)
            {
                foreach(var enemy in enemies)
                {
                    if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        //collision detected
                        bullet.Dispose();
                        enemy.Dispose();
                    }
                }
            }

        }

        private void InitializeTimerMain()
        {
            timerMain = new Timer();
            timerMain.Interval = 10;
            timerMain.Tick += TimerMain_Tick;
            timerMain.Start();
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            BulletEnemyCollisionDetection();
        }
    }
}
