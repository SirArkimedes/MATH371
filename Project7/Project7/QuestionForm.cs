using System;
using System.Windows.Forms;

namespace Project7
{
    public partial class QuestionForm : Form
    {
        public QuestionForm()
        {
            InitializeComponent();
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            // Open other form.
            BargeForm form = new BargeForm();
            form.Show();
        }

        private void secondButton_Click(object sender, EventArgs e)
        {
            // Open other form.
            StochasticForm form = new StochasticForm();
            form.Show();
        }

    }
}
