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
        public Spaceship()
        {
            InitializeSpaceship();
        }

        private void InitializeSpaceship()
        {
            this.BackColor = Color.Orange;
            this.Width = 20;
            this.Height = 60;
        }

    }
}
