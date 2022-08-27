using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame
{
    public class Snake
    {

        float SnakeSpeed;
        public LinkedList<Position> PositionsList { get; private set; }
        Position head;
        Vector speed;
        SolidBrush brush;
        int length;
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value < 1)
                    length = 1;
                else
                    length = value;
            }
        }

        public Snake(float positionX, float positionY, float speed,Color color)
        {
            head = new Position(positionX, positionY);
            this.speed = new Vector(0, speed);
            brush = new SolidBrush(color);
            PositionsList = new LinkedList<Position>();
            PositionsList.AddFirst(head);
            Length = 1;
            SnakeSpeed = speed;
        }

        public void Draw(object sender, Graphics e)
        {
            int i = 0;
            var node = PositionsList.First;
            while(i<length)
            {
                e.FillEllipse(brush, node.Value.X, node.Value.Y, SnakeSpeed, SnakeSpeed);
                node = node.Next;
                    i++;
            }
        }
        //***************************  Fixa Siffror*************' 
        public void Move (float formWidth, float formHeiht)
        {
            if (head.X> formWidth-35)
                head.X = 7;
            else if (head.X <= 0)
                head.X = formWidth-35;
             if (head.Y > formHeiht-60)
                head.Y = (formHeiht * 0.1f)+10;
            else if (head.Y < (formHeiht * 0.1f))
                head.Y = formHeiht-60;

            PositionsList.AddFirst(head);
            head.X += speed.X;
            head.Y += speed.Y;
            CleanTheList();
        }
        public bool Eat(Position pos, int change)
        {
            float x = head.X + 8;
            float y = head.Y + 8;
            pos.X += 15;
            pos.Y += 15;
            int dis = (int)Math.Sqrt(Math.Pow(x - pos.X, 2) + Math.Pow(y - pos.Y, 2));
            if (dis<15)
            {
               Length+= change;
                return true;
            }
            return false;
        }
        public void ChangeDirection(Directions dire)
        {
            if (speed.X==0)
            {
                switch (dire)
                {
                    case Directions.left:
                        speed = new Vector(-SnakeSpeed, 0);
                        break;
                    case Directions.right:
                        speed = new Vector(SnakeSpeed, 0);
                        break;
                    default:
                        break;
                }
            }
            if (speed.Y == 0)
            {
                switch (dire)
                {
                    case Directions.down:
                        speed = new Vector(0, SnakeSpeed);
                        break;
                    case Directions.up:
                        speed = new Vector(0, -SnakeSpeed);
                        break;
                    default:
                        break;
                }
            }
        }

        private void CleanTheList()
        {
            int size = PositionsList.Count - length;
            for (int i=0; i<size-10;i++ )
            {
                PositionsList.RemoveLast();
            }
        }

       public bool CheckIfSnakeHitItsSelf()
        {
            bool hit = false;
            var headNode = PositionsList.First;
            var node = headNode.Next;
            int i = 1;
            while (i <length)
            {
                if (CheckPoints(PositionsList.First.Value ,node.Value, 5))
                {
                    hit = true;
                    break;
                }
                i++;
                node = node.Next;
            }
            return hit;
        }
        private bool CheckPoints(Position p1, Position p2,int minDistance)
        {
            int dis = (int)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            if (dis < minDistance)
                return true;
            return false;
        }

        public void RemoveList ()
        {
            PositionsList.Clear();
        }

        public bool Collide(Snake snake)
        {
            int i = 0;
            var snakeList = snake.PositionsList;
            var position= snakeList.First;
            while(i<snake.Length)
            {
                if (CheckPoints(head, position.Value,  15))
                    return true;
                position = position.Next;
                i++;
            }
            return false;
        }

        //******************************************************************************************
        private Image ImageRotate(Image image)
        {
            Bitmap temp = new Bitmap(image.Width, image.Height);
            Graphics graphicTemp = Graphics.FromImage(temp);
            graphicTemp.TranslateTransform((float)temp.Width / 2, (float)temp.Height / 2);
            graphicTemp.RotateTransform(90);
            graphicTemp.TranslateTransform(-(float)temp.Width / 2, -(float)temp.Height / 2);
            graphicTemp.DrawImage(image, new Point(0, 0));
            graphicTemp.Dispose();
            return temp;
            
        }


        public void ChangeSpeed(float Speed)
        {
           if(speed.X==0)
            {
                if (speed.Y < 0)
                    speed = new Vector(0, -Speed);
                else
                    speed = new Vector(0, Speed);
           }
            else
            {

                if (speed.X < 0)
                    speed = new Vector(-Speed, 0);
                else
                    speed = new Vector(Speed, 0);

            }
            SnakeSpeed = Speed;

        }

        public void NormalSpeed(float Speed)
        {

            ChangeSpeed(Speed);
            SnakeSpeed = Speed;

        }

    }
}
