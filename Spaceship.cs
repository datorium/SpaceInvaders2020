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
        Form game = null;

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
            Bullet bullet = new Bullet();
            bullet.Left = this.Left + this.Width / 2;
            bullet.Top = this.Top - bullet.Height;
            game.Controls.Add(bullet);            
        }

    }
}
