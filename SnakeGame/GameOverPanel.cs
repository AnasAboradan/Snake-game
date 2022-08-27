using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
   public class GameOverPanel : Panel
    {
        Label theGameIsOver;
        //public Label WinnerName;
        //public Label secondePlayer;
        //public Label LastPlayer;
       List<Label> labelsList;
       public List<Label> NameLabels;
       public  List<Label> ScoreLabels;
       public Button exitButton;
       public Button playAgain;
        public GameOverPanel(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            labelsList = new List<Label>();
            NameLabels = new List<Label>();
            ScoreLabels = new List<Label>();

            InitializeTheList();

            InitializeComponent();
            InitializeNameList();
            InitializeScoreList();
            InitializeButtons();
        }
        private void InitializeComponent()
        {
            this.theGameIsOver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // theGameIsOver
            // 
            this.theGameIsOver.AutoSize = true;
            this.theGameIsOver.BackColor = System.Drawing.Color.LightGreen;
            this.theGameIsOver.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.theGameIsOver.Font = new System.Drawing.Font("Algerian", 50F);
            this.theGameIsOver.ForeColor = System.Drawing.Color.Red;
            this.theGameIsOver.Location = new System.Drawing.Point(140, 10);
            this.theGameIsOver.Name = "theGameIsOver";
            this.theGameIsOver.Size = new System.Drawing.Size(527, 96);
            this.theGameIsOver.TabIndex = 0;
            this.theGameIsOver.Text = "Game Over ";
            this.theGameIsOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.theGameIsOver.Click += new System.EventHandler(this.theGameIsOver_Click);
            // 
            // GameOverPanel
            // 
            this.BackgroundImage = global::SnakeGame.Properties.Resources.PanelImageVer01;
            this.Controls.Add(this.theGameIsOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitializeTheList()
        {
            for (int i =0; i<6; i++)
            {
                labelsList.Add(new Label());
                labelsList[i].Font = Font = new Font("Lucida Calligraphy", 15F);
                labelsList[i].AutoSize = true;
                labelsList[i].TextAlign = ContentAlignment.MiddleCenter;
                labelsList[i].ForeColor = Color.Red;
                labelsList[i].BackColor = Color.LightGray;




            }
            labelsList[0].Location = new Point(100, 125);
            labelsList[0].Text = "The Winner:";
            labelsList[1].Location = new Point(450, 125);
            labelsList[1].Text="Score:";
            labelsList[2].Location = new Point(100, 200);
            labelsList[2].Text = "The second: ";
            labelsList[3].Location = new Point(450, 200);
            labelsList[3].Text = "Score:";
            labelsList[4].Location = new Point(100, 275);
            labelsList[4].Text = "  The third: ";
            labelsList[5].Location = new Point(450, 275);
            labelsList[5].Text = "Score:";
            for (int i = 0; i < 6; i++)
            {
                labelsList[i].BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(labelsList[i]);
            }

        }
        private void InitializeNameList()
        {
            for (int i = 0; i<3; i++)
            {
                NameLabels.Add(new Label());
                NameLabels[i].Font = Font = new Font("Lucida Calligraphy", 15F);
                NameLabels[i].AutoSize = true;
                NameLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                NameLabels[i].ForeColor = Color.White;
                NameLabels[i].Text = "Player 0";

            }
            NameLabels[0].Location = new Point(300, 125);
            NameLabels[1].Location = new Point(300, 200);
            NameLabels[2].Location = new Point(300, 275);
            for (int i = 0; i < 3; i++)
            {
                NameLabels[i].BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(NameLabels[i]);
            }

        }
        private void InitializeScoreList()
        {
            for (int i = 0; i < 3; i++)
            {
                ScoreLabels.Add(new Label());
                ScoreLabels[i].Font = Font = new Font("Lucida Calligraphy", 15F);
                NameLabels[i].AutoSize = true;
                ScoreLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                ScoreLabels[i].ForeColor = Color.White;
                ScoreLabels[i].Text = "0000";
                ScoreLabels[i].Width = 75;
                ScoreLabels[i].Height = labelsList[0].Height;



            }
            ScoreLabels[0].Location = new Point(550, 125);
            ScoreLabels[1].Location = new Point(550, 200);
            ScoreLabels[2].Location = new Point(550, 275);
            for (int i = 0; i < 3; i++)
            {
                ScoreLabels[i].BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(ScoreLabels[i]);
            }

        }
        private void InitializeButtons()
        {
            playAgain = new Button();
            playAgain.Location = new Point(150, 350);
            playAgain.Text = "New Game";
            playAgain.Width = 150;
            playAgain.Height = 75;
            playAgain.BackColor = Color.LightGreen;
            this.Controls.Add(playAgain);


            exitButton = new Button();
            exitButton.Location = new Point(400, 350);
            exitButton.Text = "Exit";
            exitButton.Width = 150;
            exitButton.Height = 75;
            exitButton.BackColor = Color.LightGreen;

            this.Controls.Add(exitButton);

        }

        private void theGameIsOver_Click(object sender, EventArgs e)
        {

        }
    }
}
