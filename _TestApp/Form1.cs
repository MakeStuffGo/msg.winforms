using msg.winforms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace _TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // will be shown until disposed
            using (Cursors.WaitCursor.ShowUntilDisposed())
                Thread.Sleep(1000);

            // no need for using statement, wait cursor will be shown until action is performed
            Cursors.WaitCursor.ShowWhile(() => { Thread.Sleep(1000); });

            var i = Cursors.WaitCursor.ShowWhile(() => sleepAndReturn(1000));
        }

        private int sleepAndReturn(int sleepTime)
        {
            Thread.Sleep(sleepTime);
            return sleepTime;
        }
    }
}
