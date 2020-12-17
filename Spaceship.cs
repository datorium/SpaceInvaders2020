using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders2020
{
    class Spaceship : PictureBox
    {
        public int Step { get; set; } = 2;
        public int FireCooldown { get; set; } = 1000;
       
        private int horVelocity = 0;  
        private bool canFire = true;

        private Form game = null;
        private Timer timerFireCooldown = null;
        private Timer timerMove = null;

        public Spaceship(Form form)
        {
            InitializeSpaceship();
            game = form;
            InitializeTimerMove();            
        }

        private void InitializeSpaceship()
        {
            this.BackColor = Color.Orange;
            this.Width = 20;
            this.Height = 60;
        }

        public void Fire()
        {
            if (!canFire) return;

            Bullet bullet = new Bullet();
            bullet.Left = this.Left + this.Width / 2;
            bullet.Top = this.Top - bullet.Height;
            game.Controls.Add(bullet);            
            canFire = false;
            InitializeTimerFireCooldown();
        }

        private void InitializeTimerFireCooldown()
        {
            timerFireCooldown = new Timer();
            timerFireCooldown.Tick += TimerFireCooldown_Tick;
            timerFireCooldown.Interval = this.FireCooldown;
            timerFireCooldown.Start();
        }

        private void TimerFireCooldown_Tick(object sender, EventArgs e)
        {
            canFire = true;
            timerFireCooldown.Stop();
        }

        private void InitializeTimerMove()
        {
            timerMove = new Timer();
            timerMove.Tick += TimerMove_Tick;
            timerMove.Interval = 10;
            timerMove.Start();
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            this.Left += horVelocity;
            CheckBorderCollision();
        }

        public void MoveLeft()
        {
            horVelocity = -this.Step;
        }

        public void MoveRight()
        {
            horVelocity = this.Step;
        }

        public void Stop()
        {
            horVelocity = 0;
        }

        private void CheckBorderCollision()
        {
            if(this.Left + this.Width < 0)
            {
                this.Left = game.ClientRectangle.Width;
            }
            else if(this.Left > game.ClientRectangle.Width)
            {
                this.Left = 0 - this.Width;
            }
        }

    }
}
