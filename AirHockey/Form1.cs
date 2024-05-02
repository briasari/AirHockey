using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace AirHockey
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(191, 0, 50, 50);
        Rectangle player1Top = new Rectangle(191, 0, 50, 1);
        Rectangle player1Bottom = new Rectangle(191, 50, 50, 1);
        Rectangle player1Left = new Rectangle(191, 0, 1, 50);
        Rectangle player1Right = new Rectangle(241, 0, 1, 50);

        Rectangle player2 = new Rectangle(191, 505, 50, 50);
        Rectangle player2Top = new Rectangle(191, 515, 50, 1);
        Rectangle player2Bottom = new Rectangle(191, 565, 50, 1);
        Rectangle player2Left = new Rectangle(191, 515, 1, 50);
        Rectangle player2Right = new Rectangle(241, 515, 1, 50);

        Rectangle ball = new Rectangle(195, 280, 30, 30);
        Rectangle topGoalBorder = new Rectangle(141, 0, 150, 75);
        Rectangle goalNet = new Rectangle(149, 0, 135, 65);
        Rectangle bottomGoalBorder = new Rectangle(141, 490, 150, 75);
        Rectangle goalNet2 = new Rectangle(149, 500, 135, 65);

        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 5;
        int player2Speed = 5;
        int ballXSpeed = 2;
        int ballYSpeed = -2;

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

        Stopwatch stopwatch = new Stopwatch();

        int increaseVar = 40;
        int decreaseVar = 5;

        Random randGen = new Random();


        public Form1()
        {
            InitializeComponent();

            stopwatch.Start();
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
            e.Graphics.FillRectangle(blackBrush, player1Top);
            e.Graphics.FillRectangle(blackBrush, player1Bottom);
            e.Graphics.FillRectangle(blackBrush, player1Left);
            e.Graphics.FillRectangle(blackBrush, player1Right);

            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(blackBrush, player2Top);
            e.Graphics.FillRectangle(blackBrush, player2Bottom);
            e.Graphics.FillRectangle(blackBrush, player2Left);
            e.Graphics.FillRectangle(blackBrush, player2Right);

            e.Graphics.FillRectangle(blackBrush, ball);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;

                    break;
                case Keys.A:
                    aPressed = true;

                    break;
                case Keys.S:
                    sPressed = true;

                    break;
                case Keys.D:
                    dPressed = true;

                    break;
                case Keys.Up:
                    upPressed = true;

                    break;
                case Keys.Down:
                    downPressed = true;

                    break;
                case Keys.Left:
                    leftPressed = true;

                    break;
                case Keys.Right:
                    rightPressed = true;
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
            //sides, player1
            player1Top.X = player1.X;
            player1Top.Y = player1.Y;

            player1Bottom.X = player1.X;
            player1Bottom.Y = player1.Y + 50;

            player1Left.X = player1.X;
            player1Left.Y = player1.Y;

            player1Right.X = player1.X + 50;
            player1Right.Y = player1.Y;

            //sides, player2
            player2Top.X = player2.X;
            player2Top.Y = player2.Y;

            player2Bottom.X = player2.X;
            player2Bottom.Y = player2.Y + 50;

            player2Left.X = player2.X;
            player2Left.Y = player2.Y;

            player2Right.X = player2.X + 50;
            player2Right.Y = player2.Y;


            ball.X = ball.X + ballXSpeed;
            ball.Y = ball.Y + ballYSpeed;


            //check for intersection with player1
            if (player1Top.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ball.Y = player1.Y - ball.Height;
            }
            else if (player1Bottom.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ball.Y = player1.Y + player1.Height;
            }
            else if (player1Left.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ball.X = player1.X - ball.Width;
            }
            else if (player1Right.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ball.X = player1.X + player1.Width;
            }

            //check for intersection with player2
            if (player2Top.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ball.Y = player2.Y - ball.Height;
            }
            else if (player2Bottom.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ball.Y = player2.Y + player2.Height;
            }
            else if (player2Left.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ball.X = player2.X - ball.Width;
            }
            else if (player2Right.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ball.X = player2.X + player2.Width;
            }


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
            if (sPressed == true && player1.Y < 300 - player1.Height)
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
            if (upPressed == true && player2.Y >= 300)
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



            //(149, 0, 135, 65);

            //if (65 > ball.X > 

            //check for score
            if (ball.X <= 65 - ball.Width && ball.X <= 149 + 135 - ball.Height && ball.Y <=135)
            {
                player1Score++;
                ball.X = 195;
                ball.Y = 280;
                ballXSpeed = 0;
                ballYSpeed = 0;
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
