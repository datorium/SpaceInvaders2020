﻿using System;
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

        public void InitializeSpaceship()
        {
            this.Height = 100;
            this.Width = 60;
            this.BackColor = Color.SteelBlue;
        }

    }
}
