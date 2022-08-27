using System;
using System.Drawing;
using System.Media;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace SnakeGame
{
    public class Player
    {
        private const int PlayerSpeed = 15;
        public  static int ALivePlyersCount;
        public Snake snake;
        PlayerKeys playerKeys;
        public bool Alive { get; private set; } 
        public int Score { get; private set; }
        public int plyerNum;
        static int Id;
        Color color;


        public Color Color
        {
            get
            {
                return color;
            }
            private set
            {
                color = value;
            }
        }
        Random random;
        float GameFromWidth;
        float GameFormHeiht;

        public Player(float width, float heiht, Color color)
        {
            Id++;
            GetPlayerKeys();
            random = new Random();
            snake = new Snake(random.Next((int)width/Id), random.Next((int)(heiht - heiht * 0.1)/Id), PlayerSpeed,color);
            Score = 0;
            Alive = true;
            ALivePlyersCount++;
            plyerNum = Id;
            this.Color = color;
            GameFormHeiht = heiht;
            GameFromWidth = width;
        }
        public void CahngeDirection(KeyEventArgs e)
        {
            Directions dire = playerKeys.CheckKey(e);
            if (dire!=Directions.non)
           snake.ChangeDirection(dire);
        }
        public void  Draw(object sender, Graphics e)
        {
            snake.Draw(sender, e);
        }
        public void Move ()
        {
            if (Alive)
            {
                snake.Move(GameFromWidth, GameFormHeiht);

                Alive = !(snake.CheckIfSnakeHitItsSelf());
            }
               
            if (!Alive)
                ALivePlyersCount--;
           
        }


       public bool ISCollidedWithAnotherSnake(Player player)
        {
            bool temp = (snake.Collide(player.snake));
           Alive = ! temp;
            return temp;
        }
        private void GetPlayerKeys()
        {
            if (Id == 1)
                playerKeys = new PlayerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
           
            else if (Id==2)
                playerKeys = new PlayerKeys(Keys.W, Keys.S, Keys.A, Keys.D);
            else if (Id==3)
                playerKeys = new PlayerKeys(Keys.I, Keys.K, Keys.J, Keys.L);
        }
        public bool IsFoodEaten(Food food)
        {
            if (snake.Eat(food.Position, food.ChangeSnakeLength))
            {
                Score += food.ChangeScore;
                return true;
            }
            return false;

        }

        public void IncreasesSpeed(float speed)
        {

            snake.ChangeSpeed(speed);

        }

        public void ToNormalSpeed()
        {

            snake.NormalSpeed(PlayerSpeed);

        }


    }
}
