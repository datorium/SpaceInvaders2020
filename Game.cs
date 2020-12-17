﻿using System;
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
        }

        private void AddSpaceshipToGame()
        {
            spaceship = new Spaceship(this);
            spaceship.FireCooldown = 500;
            spaceship.Left = this.ClientRectangle.Width / 2 - spaceship.Width / 2;
            spaceship.Top = this.ClientRectangle.Height - spaceship.Height;
            this.Controls.Add(spaceship);
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
