using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal
{

    public partial class DifficultyAsk : Form
    {
        public Difficulty difficulty = Difficulty.easy;

        public DifficultyAsk()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            difficulty = Difficulty.medium;
            Close();
        }

        private void insaneButton_Click(object sender, EventArgs e)
        {
            difficulty = Difficulty.insane;
            Close();
        }
    }
}
