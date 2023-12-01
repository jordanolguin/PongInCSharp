using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePongGame
{
    class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
