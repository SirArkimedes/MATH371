using System.Collections.Generic;
using System.Windows.Forms;

namespace Project8
{
    class Dot
    {
        private RadioButton button = new RadioButton();

        public Dot(RadioButton button)
        {
            this.button = button;
        }
    }

    class Path
    {
        
    }

    class Box
    {

    }

    // Class that manages the Game's state.
    class Game
    {
        public Dot[,] dots;

        private uint width = 0;
        private uint height = 0;

        public Game(uint width, uint height)
        {
            dots = new Dot[width, height];

            this.width = width;
            this.height = height;
        }
    }
}
