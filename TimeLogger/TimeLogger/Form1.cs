using System;
using System.Windows.Forms;
using TimeLogger.Core;

namespace TimeLogger
{
    public partial class Form1 : Form
    {
        private Logger _logger;
        public Form1()
        {
            InitializeComponent();
            _logger = new Logger();            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _logger.SetCurrentTask(this.textBox1.Text);
        }
    }
}
