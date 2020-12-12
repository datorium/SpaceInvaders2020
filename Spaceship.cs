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
        private Game game = null;
        public Spaceship(Game gameForm)
        {
            game = gameForm;
            InitializeSpaceship();
        }

        private void InitializeSpaceship()
        {
            this.Height = 100;
            this.Width = 60;
            this.BackColor = Color.SteelBlue;
        }

        public void Fire()
        {
            Bullet bullet = new Bullet();
            bullet.Left = this.Left + 30;
            bullet.Top = this.Top - bullet.Height;
            game.Controls.Add(bullet);
        }

    }
}
