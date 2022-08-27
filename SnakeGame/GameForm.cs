using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class GameForm : Form
    {
        FlowLayoutPanel score;
        TextBox textBox;
        private Image backgroundImage;

        public GameForm()
        {
       
            InitializeComponent();
            score = new FlowLayoutPanel();
            textBox = new TextBox();
            backgroundImage = Properties.Resources.BackgroundImage;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            
            
        }
      

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            //var rc = new Rectangle(this.ClientSize.Width - backgroundImage.Width,
            //    (this.ClientSize.Height ) - backgroundImage.Height,
            //    backgroundImage.Width, backgroundImage.Height);
            var rc = new Rectangle(-7, 35, this.ClientSize.Width + 15, this.ClientSize.Height - 10);
            e.Graphics.DrawImage(backgroundImage, rc);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 700;
            Height = 500;

            MaximizeBox = false;
            MinimizeBox = false;
            score.BackgroundImage = Properties.Resources.PanelImage;
            Controls.Add(score);
            Layout += GameForm_Layout;
        }

        private void GameForm_Layout(object sender, LayoutEventArgs e)
        {
            score.Width = Width;
            score.Height =(int)( 0.1* Height);
        }
    }
}
