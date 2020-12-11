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

        int fireCooldown = 1000;
        bool canFire = true;
        
        Form game = null;
        Timer timerFireCooldown = null;

        public Spaceship(Form form)
        {
            InitializeSpaceship();
            game = form;
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
            timerFireCooldown.Interval = fireCooldown;
            timerFireCooldown.Start();
        }

        private void TimerFireCooldown_Tick(object sender, EventArgs e)
        {
            canFire = true;
            timerFireCooldown.Stop();
        }

    }
}
