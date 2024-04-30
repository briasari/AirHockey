using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirHockey
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(191, 0, 50, 50);
        Rectangle player2 = new Rectangle(191, 515, 50, 50);
        Rectangle ball = new Rectangle(195, 280, 42, 42);
        Rectangle topGoalBorder = new Rectangle(141, 0, 150, 75);
        Rectangle goalNet = new Rectangle(149, 0, 135, 65);
        Rectangle bottomGoalBorder = new Rectangle(141, 490, 150, 75);
        Rectangle goalNet2 = new Rectangle(149, 500, 135, 65);

        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 0;
        int player2Speed = 0;
        int ballXSpeed = 6;
        int ballYSpeed = -6;

        bool wPressed = false;
        bool aPressed = false;
        bool sPressed = false;
        bool dPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush backgroundBrush = new SolidBrush(Color.Gainsboro);

        Random randGen = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //goals and divider
            e.Graphics.FillRectangle(redBrush, topGoalBorder);
            e.Graphics.FillRectangle(backgroundBrush, goalNet);

            e.Graphics.FillRectangle(redBrush, bottomGoalBorder);
            e.Graphics.FillRectangle(backgroundBrush, goalNet2);

            e.Graphics.FillRectangle(blackBrush, 0, 300, 450, 3);

            //moving objects
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(blackBrush, ball);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    player1Speed = 5;
                    break;
                case Keys.A:
                    aPressed = true;
                    player1Speed = 5;
                    break;
                case Keys.S:
                    sPressed = true;
                    player1Speed = 5;
                    break;
                case Keys.D:
                    dPressed = true;
                    player1Speed = 5;
                    break;
                case Keys.Up:
                    upPressed = true;
                    player1Speed = 5;
                    break;
                case Keys.Down:
                    downPressed = true;
                    player1Speed = 5;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    player1Speed = 5;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    player1Speed = 5;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move ball
            ball.X = ball.X + ballXSpeed;
            ball.Y = ball.Y + ballYSpeed;

            if (ball.Y <= 0 || ball.Y >= this.Height - ball.Height)
            {
                ballYSpeed = -ballYSpeed;
            }
            if (ball.X <= 0 || ball.X >= this.Width - ball.Width)
            {
                ballXSpeed = -ballXSpeed;
            }


            //move player1
            if (wPressed == true && player1.Y >= 0)
            {
                player1.Y = player1.Y - player1Speed;
            }
            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y = player1.Y + player1Speed;
            }
            if (dPressed == true && player1.X < this.Width - player1.Width)
            {
                player1.X = player1.X + player1Speed;
            }
            if (aPressed == true && player1.X >= 0)
            {
                player1.X = player1.X - player1Speed;
            }

            //move player2
            if (upPressed == true && player2.Y > 0)
            {
                player2.Y = player2.Y - player2Speed;
            }
            if (downPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y = player2.Y + player2Speed;
            }
            if (rightPressed == true && player1.X < this.Width - player2.Width)
            {
                player2.X = player2.X + player2Speed;
            }
            if (leftPressed == true && player2.X > 0)
            {
                player2.X = player2.X - player2Speed;
            }

            //check for intersection with player
            if (player1.IntersectsWith(ball.Top))
            {
                for (int i = 0; i < 10; i++)
                {
                    ball.
                }

                if (border.IntersectsWith(ball))
                {
                    ballXSpeed = -ballXSpeed;
                    ball.X = player2.X + player2.Width;
                    round++;
                }
            }
            else
            {
                border.X = player1.X - 2;
                border.Y = player1.Y - 2;

                if (border.IntersectsWith(ball))
                {
                    ballXSpeed = -ballXSpeed;
                    ball.X = player1.X + player1.Width;
                    round++;
                }
            }





            //check for winner

            if (player1Score == 3)
            {
                winLabel.Text = "Player 1 Wins!";
                gameTimer.Stop();
            }

            if (player2Score == 3)
            {
                winLabel.Text = "Player 2 Wins!";
                gameTimer.Stop();
            }

            Refresh();

        }
    }
}
