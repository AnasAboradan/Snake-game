
using System.Drawing;

namespace SnakeGame
{
    public class Food
    {
        public Position Position { get; private set; }
        public FoodTypes foodType;
        public int ChangeScore { get; private set; }
        public int ChangeSnakeLength { get; private set; }
        Image foodImage;

        public Food(FoodTypes foodType, float x, float y)
        {
            this.foodType = foodType;
            Position = new Position(x, y);
            FoodEffect();
        }

        private void FoodEffect()
        {
            switch (foodType)
            {
                case FoodTypes.standard:
                  foodImage = Properties.Resources.cake;
                    foodImage = new Bitmap(foodImage, 30, 30);
                    ChangeScore = 1;
                    ChangeSnakeLength = 1;
                    break;
                case FoodTypes.valuable:
                  foodImage = Properties.Resources.humburger;
                    foodImage = new Bitmap(foodImage, 30, 30);
                    ChangeScore = 5;
                    ChangeSnakeLength = 2;
                    break;
                case FoodTypes.diet:
                    foodImage = Properties.Resources.apple;
                    foodImage = new Bitmap(foodImage, 30, 30);
                    ChangeScore = 1;
                    ChangeSnakeLength = -1;
                    break;
                case FoodTypes.RandomSpeed:
                    foodImage = Properties.Resources.Ba;
                    foodImage = new Bitmap(foodImage, 30, 30);
                    ChangeScore = 1;
                    ChangeSnakeLength = 0;
                    break;
                default:
                    break;
            }
        }
        public void Draw (object sender, Graphics e)
        {
            e.DrawImage(foodImage, Position.X, Position.Y);
         
        }
        public void ChangePositsion(float x, float y)
        {
           
            Position = new Position(x, y);
        }
    }
}
