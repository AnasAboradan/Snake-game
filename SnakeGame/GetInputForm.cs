using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public class GetInputForm

    {
        Label Title;
        Label choicePlayerNumber;
        Button OnePlayer;
        Button twoPlayers;
        Button threePlayers;

        Button buttonC;
        public  Form form;
        public int Input { get; private set; }
        public GetInputForm()
        {
            Title = new Label();
            choicePlayerNumber = new Label();
            form = new Form();

            form.Height = 300;
            form.Width = 600;
            GetOnePlayer();
            GetTwoPlayer();
            GetThreePlayer();
            GetCancel();

           
        }
        public void Run ()
        {
            var backgroundImage = new Bitmap(Properties.Resources.startImageFunny, 600, 300);
            form.BackgroundImage = backgroundImage;

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Game Snake";
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.None;
            Title.AutoSize = true;
            Title.Location = new Point(100, 30);
            Title.TextAlign = ContentAlignment.MiddleCenter;
            Title.Text = "Snake Game";
            Title.Font = new Font("Algerian", 40F);
            Title.BackColor = Color.Transparent;

            choicePlayerNumber.Text = "HOW MANY PLAYERS?";
            choicePlayerNumber.AutoSize = true;
            choicePlayerNumber.Location = new Point(100, 150);
            choicePlayerNumber.Font = new Font("Lucida Calligraphy", 18F);
            choicePlayerNumber.BackColor = Color.Transparent;
            choicePlayerNumber.ForeColor = Color.White;



            form.Controls.Add(Title);
            form.Controls.Add(choicePlayerNumber);

            buttonC.MouseClick += ButtonC_MouseClick;
            OnePlayer.MouseClick += OnePlayer_MouseClick;
            twoPlayers.MouseClick += TwoPlayers_MouseClick;
            threePlayers.MouseClick += ThreePlayers_MouseClick;

            Application.Run(form);

        }

        private void ThreePlayers_MouseClick(object sender, MouseEventArgs e)
        {
            Input = 3;
            form.Close();
        }

        private void TwoPlayers_MouseClick(object sender, MouseEventArgs e)
        {
            Input = 2;
            form.Close();
        }

        private void OnePlayer_MouseClick(object sender, MouseEventArgs e)
        {
            Input = 1;
            form.Close();
        }

        private void ButtonC_MouseClick(object sender, MouseEventArgs e)
        {
            Input = 0;
            form.Close();
        }

      private void GetOnePlayer()
        {
            OnePlayer = new Button();
         //   OnePlayer.Text = "One Player";
            OnePlayer.Size = new Size(100, 50);
            OnePlayer.Location = new Point((int)(form.Width * 0.2), (int)(form.Height / 1.5));
            OnePlayer.BackgroundImage = new Bitmap(Properties.Resources.PanelImage, 100,50);
            form.Controls.Add(OnePlayer);

        }
        private void GetTwoPlayer()
        {
            twoPlayers = new Button();
         //  twoPlayers.Text = "Two Players";
           twoPlayers.Size = new Size(100, 50);
           twoPlayers.Location = new Point((int)(form.Width * 0.4), (int)(form.Height / 1.5));
            twoPlayers.BackgroundImage = Properties.Resources.PanelImage;
            form.Controls.Add(twoPlayers);
        }
        private void GetThreePlayer()
        {
            threePlayers = new Button();
          //  threePlayers.Text = "Three Players";
            threePlayers.Size = new Size(100, 50);
            threePlayers.BackgroundImage = new Bitmap(Properties.Resources.PanelImage, 35, 50);

            threePlayers.Location = new Point((int)(form.Width*0.6), (int)(form.Height / 1.5));
           
            form.Controls.Add(threePlayers);
        }
        private void GetCancel()
        {
            buttonC = new Button();
            buttonC.Text = "Exit";
            buttonC.Size = new Size(60, 40);
            buttonC.BackColor = Color.Red;
            buttonC.ForeColor = Color.White;
            buttonC.Font = new Font("Lucida Calligraphy", 10);
            buttonC.Location = new Point(form.Width - buttonC.Width,0);
            form.Controls.Add(buttonC);
        }

    }
}
