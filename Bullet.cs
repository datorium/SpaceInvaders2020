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
        int step = 2;
        Timer timerMove = null;

        public Bullet()
        {
            InitializeBullet();
            InitializeTimerMove();
        }

        private void InitializeBullet()
        {
            this.BackColor = Color.Orange;
            this.Height = 10;
            this.Width = 2;
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
            this.Top -= step;
        }
    }
}
