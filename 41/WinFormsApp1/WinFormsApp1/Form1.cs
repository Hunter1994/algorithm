using System.Drawing;
using System.Drawing.Drawing2D;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var g= Graphics.FromHwndInternal(this.Handle);
            var b =new HatchBrush(HatchStyle.BackwardDiagonal, Color.AliceBlue);
            var p = new Pen(b);
            g.DrawLine(p, 0, 0, 100, 100);
            g.Flush();
        }
    }
}