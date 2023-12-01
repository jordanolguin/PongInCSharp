using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePongGame
{
    public partial class Form1 : Form1
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

        publicForm1()
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
        }
    }
}