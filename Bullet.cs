using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders2020
{
    class Bullet : PictureBox
    {
        public Bullet()
        {
            InitializeBullet();
        }

        private void InitializeBullet()
        {
            this.BackColor = Color.Orange;
            this.Height = 10;
            this.Width = 2;
        }

    }
}
