using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeGame
{
    public enum FoodTypes { standard, valuable, diet,RandomSpeed}
    public enum Directions{ left, right, down, up, non}
    

    public class Engine
    {
        GameForm form;
        Timer timer;
        Timer TSpeed;
       
        List<Food> foodlist;
        Random random;
        List<Label> scoreLabels;
        List<Player> playrs;
        GetInputForm StartForm;
        int numberOfPlayers;
        int alivePlayers;
        GameOverPanel gameOverPanel;
        Player winner;
        Player secondWinner;
        Player thiredWinner;



        int RandomPlayerSpeed;
        List<bool> Speedlist;

        public Engine()
        {
            form = new GameForm();
            form.Height = 500;
            form.Width = 700;
            timer = new Timer();
            Speedlist = new List<bool>();
           
            foodlist = new List<Food>
            {
                 new Food(FoodTypes.standard, 300, 200),
                 new Food(FoodTypes.diet, 300, 300),
                 new Food(FoodTypes.valuable, 300, 250),
                 new Food(FoodTypes.RandomSpeed,200,200)
            };
            random = new Random();
            playrs = new List<Player>();
            scoreLabels = new List<Label>();
            TSpeed = new Timer();
            form.KeyPreview = true;
            StartForm = new GetInputForm();
            gameOverPanel = new GameOverPanel(form.Width, form.Height);
          
         
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            foreach (Player player in playrs)
                player.CahngeDirection(e);
        }
        public void Run ()
        {
            StartForm.Run();
            numberOfPlayers = StartForm.Input;
         
            if (numberOfPlayers>0)
            {
                form.Controls.Add(gameOverPanel);
                gameOverPanel.Hide();
                GetReady();
                form.Paint += Draw;
                timer.Tick += Timer_Tick;
                TSpeed.Tick += TSpeed_Tick;
                timer.Interval = 1000 / 8;
                form.KeyDown += KeyPressed;
                timer.Start();
                TSpeed.Interval = 10000;
                form.StartPosition = FormStartPosition.CenterScreen;
                gameOverPanel.playAgain.MouseClick += PlayAgain_MouseClick;
                gameOverPanel.exitButton.MouseClick += ExitButton_MouseClick;
                Application.Run(form);
            }
          
        }

        private void TSpeed_Tick(object sender, EventArgs e)
        {
            if(Speedlist[RandomPlayerSpeed])
            {
                playrs[RandomPlayerSpeed].ToNormalSpeed();
            }
         
            TSpeed.Stop();
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void PlayAgain_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Restart();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            foreach (Food food in foodlist)
                food.Draw(sender, e.Graphics);
            foreach(Player player in playrs )
            {
                if (player.Alive)
                    player.Draw(sender, e.Graphics);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
          
            alivePlayers = 0;
            CheckCollision();

            foreach (Player player in playrs)
            {
                if (player.Alive)
                {
                    player.Move();
                    alivePlayers++;
                }   
            }

            for (int i = 0; i < playrs.Count; i++)
            {
                if(!playrs[i].Alive)
                {

                    Speedlist[i] = false;
                }
            }



            foreach (var food in foodlist)
            {
                foreach(Player player in playrs)
                {
                    if (player.IsFoodEaten(food))
                    {
                        if (food.foodType == FoodTypes.RandomSpeed)
                        {
                            playrs[RandomPlayerSpeed].ToNormalSpeed();
                            do
                            {
                                RandomPlayerSpeed = random.Next(playrs.Count);

                            } while (!Speedlist[RandomPlayerSpeed]);
                            food.ChangePositsion(random.Next(20, form.Width - 50), random.Next((int)(form.Height * (0.1) + 20), (int)(form.Height - (form.Height * (0.2)))));
                            playrs[RandomPlayerSpeed].IncreasesSpeed(random.Next(20, 25));
                            TSpeed.Start();

                        }
                        else
                        {
                            food.ChangePositsion(random.Next(20, form.Width - 50), random.Next((int)(form.Height * (0.1) + 20), (int)(form.Height - (form.Height * (0.2)))));
                        }
                    }
                }
            }


            for (int i = 0; i < numberOfPlayers; i++)
            {
                scoreLabels[i].Text = $"player {i+1}: " + Convert.ToString(playrs[i].Score);
            }
            IsGameOver();
            form.Refresh();
        }

        private void GetReady()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                scoreLabels.Add(new Label());

                scoreLabels[i].ForeColor = Color.White;
                form.Controls.Add(scoreLabels[i]);
                if (i == 0)
                {
                    playrs.Add(new Player(form.Width, form.Height, Color.Red));
                    scoreLabels[i].BackColor = Color.Red;
                    scoreLabels[i].Location = new Point((form.Width - (i * form.Width)) - scoreLabels[i].Width, 10);
                    Speedlist.Add(true);
                }

                else if (i == 1)
                {
                    playrs.Add(new Player(form.Width, form.Height, Color.Blue));
                    scoreLabels[i].BackColor = Color.Blue;
                    scoreLabels[i].Location = new Point(0, 10);
                    Speedlist.Add(true);


                }
                else
                {
                    playrs.Add(new Player(form.Width, form.Height, Color.DarkMagenta));
                    scoreLabels[i].BackColor = Color.DarkMagenta;
                    scoreLabels[i].Location = new Point((form.Width / 2) - (scoreLabels[i].Width), 10);
                    Speedlist.Add(true);

                }

            }
        }

        private void CheckCollision()
        {
            if (playrs.Count == 3 && playrs[0].Alive && playrs[1].Alive&&playrs[2].Alive)
            {

                   if (!playrs[1].ISCollidedWithAnotherSnake(playrs[2]))
                     playrs[1].ISCollidedWithAnotherSnake(playrs[0]);

                        if (!playrs[2].ISCollidedWithAnotherSnake(playrs[1]))
                            playrs[2].ISCollidedWithAnotherSnake(playrs[0]);

                       if (!playrs[0].ISCollidedWithAnotherSnake(playrs[1]))
                        playrs[0].ISCollidedWithAnotherSnake(playrs[2]);

            }
            else if (playrs.Count == 3 && playrs[0].Alive && playrs[1].Alive)
            {
                playrs[0].ISCollidedWithAnotherSnake(playrs[1]);
                playrs[1].ISCollidedWithAnotherSnake(playrs[0]);
            }
            else if (playrs.Count == 3 && playrs[0].Alive && playrs[2].Alive)
            {
                playrs[0].ISCollidedWithAnotherSnake(playrs[2]);
                playrs[2].ISCollidedWithAnotherSnake(playrs[0]);
            }
            else if (playrs.Count == 3 && playrs[1].Alive && playrs[2].Alive)
            {
                playrs[1].ISCollidedWithAnotherSnake(playrs[2]);
                playrs[2].ISCollidedWithAnotherSnake(playrs[1]);
            }

           
              else   if (playrs.Count == 2 && playrs[0].Alive && playrs[1].Alive)
                {
                    playrs[0].ISCollidedWithAnotherSnake(playrs[1]);
                    playrs[1].ISCollidedWithAnotherSnake(playrs[0]);
                }
        }
        private void IsGameOver()
        {
            if (alivePlayers==0)
            {
                timer.Stop();
                TSpeed.Stop();
               if (playrs.Count==1)
                {
                    gameOverPanel.NameLabels[0].Text = "player 1";
                    gameOverPanel.ScoreLabels[0].Text = Convert.ToString(playrs[0].Score);
                    gameOverPanel.NameLabels[0].BackColor = playrs[0].Color;
                    gameOverPanel.ScoreLabels[0].BackColor= playrs[0].Color;


                }
               else if (playrs.Count==2)
                {
                    if (playrs[0].Score>playrs[1].Score)
                    {
                        gameOverPanel.NameLabels[0].Text = "player 1";
                        gameOverPanel.ScoreLabels[0].Text = Convert.ToString(playrs[0].Score);
                        gameOverPanel.NameLabels[0].BackColor = playrs[0].Color;
                        gameOverPanel.ScoreLabels[0].BackColor = playrs[0].Color;
                        gameOverPanel.NameLabels[1].Text = "player 2";
                        gameOverPanel.ScoreLabels[1].Text = Convert.ToString(playrs[1].Score);
                        gameOverPanel.NameLabels[1].BackColor = playrs[1].Color;
                        gameOverPanel.ScoreLabels[1].BackColor = playrs[1].Color;

                    }
                    else
                    {
                        gameOverPanel.NameLabels[0].Text = "player 2";
                        gameOverPanel.ScoreLabels[0].Text = Convert.ToString(playrs[1].Score);
                        gameOverPanel.NameLabels[0].BackColor = playrs[1].Color;
                        gameOverPanel.ScoreLabels[0].BackColor = playrs[1].Color;
                        gameOverPanel.NameLabels[1].Text = "player 1";
                        gameOverPanel.ScoreLabels[1].Text = Convert.ToString(playrs[0].Score);
                        gameOverPanel.NameLabels[1].BackColor = playrs[0].Color;
                        gameOverPanel.ScoreLabels[1].BackColor = playrs[0].Color;
                    }
                }

               else
                {
                    FindWinners(playrs[0], playrs[1], playrs[2]);
                    gameOverPanel.NameLabels[0].Text = $"player{winner.plyerNum} ";
                    gameOverPanel.ScoreLabels[0].Text = Convert.ToString(winner.Score);
                    gameOverPanel.NameLabels[0].BackColor = winner.Color;
                    gameOverPanel.ScoreLabels[0].BackColor = winner.Color;

                    gameOverPanel.NameLabels[1].Text = $"player{secondWinner.plyerNum} ";
                    gameOverPanel.ScoreLabels[1].Text = Convert.ToString(secondWinner.Score);
                    gameOverPanel.NameLabels[1].BackColor = secondWinner.Color;
                    gameOverPanel.ScoreLabels[1].BackColor = secondWinner.Color;

                    gameOverPanel.NameLabels[2].Text = $"player{thiredWinner.plyerNum} ";
                    gameOverPanel.ScoreLabels[2].Text = Convert.ToString(thiredWinner.Score);
                    gameOverPanel.NameLabels[2].BackColor = thiredWinner.Color;
                    gameOverPanel.ScoreLabels[2].BackColor = thiredWinner.Color;
                }
                gameOverPanel.Show();

            }
        }      
        private void FindWinners(Player p1, Player p2, Player p3)
        {
            if (p1.Score > p2.Score && p1.Score > p3.Score)
            {
                winner = p1;
                if (p2.Score > p3.Score)
                {
                    secondWinner = p2;
                    thiredWinner = p3;
                }
                else
                {
                    secondWinner = p3;
                    thiredWinner = p2;
                }
            }
                
            else if (p2.Score > p1.Score && p2.Score > p3.Score)
            {
                winner = p2;
                if (p1.Score>p3.Score)
                {
                    secondWinner = p1;
                    thiredWinner = p3;
                }
                else
                {
                    secondWinner = p3;
                    thiredWinner = p1;
                }
            }
            else
            {
                winner = p3;
                if (p1.Score>p2.Score)
                {
                    secondWinner = p1;
                    thiredWinner = p2;
                }
                else
                {
                    secondWinner = p2;
                    thiredWinner = p1;
                }
            }
        }
   
    }
}
