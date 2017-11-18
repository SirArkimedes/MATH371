using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Barge form = new Barge();
            form.Show();
        }

        private void secondButton_Click(object sender, EventArgs e)
        {
            // Open other form.
            Probability form = new Probability();
            form.Show();
        }

    }
}
