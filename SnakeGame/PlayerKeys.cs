
using System.Windows.Forms;

namespace SnakeGame
{
    public class PlayerKeys
    {
        Keys up;
        Keys left;
        Keys right;
        Keys down;
        public PlayerKeys(Keys Up, Keys Down ,Keys Left, Keys Right )
        {
            up = Up;
            down = Down;
            left = Left;
            right = Right;
        }
        public Directions CheckKey(KeyEventArgs e)
        {
            if (e.KeyCode == up)
                return Directions.up;
            else if (e.KeyCode == down)
                return Directions.down;
            else if (e.KeyCode == left)
                return Directions.left;
            else if (e.KeyCode == right)
                return Directions.right;
            else 
            return Directions.non;
        }
    }
}
