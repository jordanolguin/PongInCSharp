using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePongGame
{
    public partial class Form1 : Form
    {
        private const int PaddleWidth = 20;
        private const int PaddleHeight = 100;
        private const int BallSize = 20;

        private int paddleSpeed = 5;
        private int ballSpeed = 5;
        private int ballXSpeed = 1;
        private int ballYSpeed = 1;

        private PictureBox paddle1;
        private PictureBox paddle2;
        private PictureBox ball;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Create paddles and ball (PictureBoxes)
            paddle1 = new PictureBox
            {
                Size = new Size(PaddleWidth, PaddleHeight),
                BackColor = Color.White,
                Location = new Point(0, ClientSize.Height / 2 - PaddleHeight / 2)
            };

            paddle2 = new PictureBox
            {
                Size = new Size(PaddleWidth, PaddleHeight),
                BackColor = Color.White,
                Location = new Point(ClientSize.Width - PaddleWidth, ClientSize.Height / 2 - PaddleHeight / 2)
            };

            ball = new PictureBox
            {
                Size = new Size(BallSize, BallSize),
                BackColor = Color.White,
                Location = new Point(ClientSize.Width / 2 - BallSize / 2, ClientSize.Height / 2 - BallSize / 2)
            };

            // Add controls to the form
            Controls.Add(paddle1);
            Controls.Add(paddle2);
            Controls.Add(ball);

            // Set up the game loop using a Timer
            var gameTimer = new Timer { Interval = 16 };
            gameTimer.Tick += GameTick;
            gameTimer.Start();

            // Handle key events for moving the paddles
            KeyDown += Form1_KeyDown;
        }

        private void GameTick(object sender, EventArgs e)
        {
            // Move the ball
            ball.Left += ballSpeed * ballXSpeed;
            ball.Top += ballSpeed * ballYSpeed;

            // Check the collisions with the paddles
            if (ball.Bounds.IntersectsWith(paddle1.Bounds) || ball.Bounds.IntersectsWith(paddle2.Bounds))
                ballXSpeed = -ballXSpeed;

            // Check for collisions with top and bottom
            if (ball.Top <= 0 || ball.Bottom >= ClientSize.Height)
                ballYSpeed = -ballYSpeed;

            // Check for scoring
            if (ball.Left <= 0 || ball.Right >= ClientSize.Width)
            {
                // Reset the ball position for the next round
                ball.Location = new Point(ClientSize.Width / 2 - BallSize / 2, ClientSize.Height / 2 - BallSize / 2);
                ballXSpeed = -ballXSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Move the paddles with W/S and Up/Down keys
            if (e.KeyCode == Keys.W && paddle1.Top > 0)
                paddle1.Top -= paddleSpeed;
            if (e.KeyCode == Keys.S && paddle1.Bottom < ClientSize.Height)
                paddle1.Top += paddleSpeed;
            if (e.KeyCode == Keys.Up && paddle2.Top > 0)
                paddle2.Top -= paddleSpeed;
            if (e.KeyCode == Keys.Down && paddle2.Bottom < ClientSize.Height)
                paddle2.Top += paddleSpeed;
        }
    }
}
