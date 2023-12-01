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
    }
}