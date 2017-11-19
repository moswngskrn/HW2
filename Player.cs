using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace GameHW2
{
    class Player
    {
        //start value
        Vector2 PositionS;
        string MovingS;

        Animation playerLeft;
        Animation PlayerRight;
        public string Moving= "left";
        public bool Active;
        int Health;
        public int CurrentHealth;

        public Vector2 Position;
        public int Width;
        public int Hieght;

        KeyboardState PreviousKS;
        KeyboardState CurrentKS;

        Keys Up, Down, Right, Left, Shoot;
        bool canJump;
        bool ActiveJump;
        float elapse;
        float delay;
        float PosStopY;
        float g,v;

        public bool canShootBearing;

        int H, W;

        public List<Vector2> PositionWalls;
        public List<int> WidthWalls;

        //แทบพลังชีวิต
        Texture2D tapHealth;
        Rectangle destinationRect;
        Rectangle sourceRect;
        int posTapHealthY;
        string nameTap;

        public Player(int frameWidth, int frameHeight, 
                      int frameCountCol, int frameCountRow, 
                      int delay,
                      int W,int H,
                      Keys Left,Keys Right,
                      Keys Down,Keys Up,Keys Shoot, int Health, int posTapHealthY,string nameTap)
        {
            this.nameTap = nameTap;
            this.posTapHealthY = posTapHealthY;
            this.Health = Health;
            CurrentHealth = Health;
            Active = true;

            this.W = W;
            this.H = H;
            Width = frameWidth;
            Hieght = frameHeight;
            this.Left = Left;
            this.Right = Right;
            this.Down = Down;
            this.Up = Up;
            this.Shoot = Shoot;
            bool looping = true;
            playerLeft = new Animation(frameWidth, frameHeight, frameCountCol, frameCountRow, delay, looping);
            PlayerRight = new Animation(frameWidth, frameHeight, frameCountCol, frameCountRow, delay, looping);

        }

        public List<Vector2> setPositionWalls{
            set { PositionWalls = value; }
        }

        public List<int> setWidthWalls
        {
            set { WidthWalls = value; }
        }

        public void LoadContent(ContentManager Content,string nameLeft,string nameRight, List<Vector2> PositionWalls, List<int> WidthWalls,Vector2 Pos)
        {
            
            playerLeft.LoadContent(Content, nameLeft);
            PlayerRight.LoadContent(Content, nameRight);
            
            this.WidthWalls = WidthWalls;
            this.PositionWalls = PositionWalls;

            canJump = true;
            ActiveJump = false;
            canShootBearing = false;
            delay = 20;
            elapse = 0;
            //u = 50;
            g = 5;
            v = 0;
            Position = Pos;
            playerLeft.Position = Position;
            PlayerRight.Position = Position;

            PositionS = Position;

            //แท็บพลังชีวิต
            tapHealth = Content.Load<Texture2D>(nameTap);
        }

        public void Update(GameTime gameTime)
        {
            PreviousKS = CurrentKS;
            CurrentKS = Keyboard.GetState();


            playerLeft.Update(gameTime);
            PlayerRight.Update(gameTime);
            if (CurrentKS.IsKeyDown(Shoot) && PreviousKS.IsKeyUp(Shoot))
            {
                canShootBearing = true;
            }
            if (CurrentKS.IsKeyDown(Left))
            {
                if (Position.X >= 0 + Width / 2)
                {
                    Position.X -= 5;
                    Moving = "left";
                }
                    
            }
            if (CurrentKS.IsKeyDown(Right))
            {
                if (Position.X <= W - Width / 2)
                {
                    Position.X += 5;
                    Moving = "right"; 
                }
                
            }
            if (CurrentKS.IsKeyUp(Up) &&
                PreviousKS.IsKeyDown(Up) && 
                canJump)
            {
                v = -12;
                canJump = false;
                ActiveJump = true;
                elapse = 0;
            }
            if (ActiveJump)
            {
                elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapse >= delay)
                {
                    v += g * (elapse /1000);
                    Position.Y += v;
                    if (v>=0)
                    {
                        elapse = 0;
                        ActiveJump = false;
                    }
                }
            }
            else{
                elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapse >= delay)
                {
                    if (!(isTouchWall()) && Position.Y<= H - Hieght / 2)
                    {
                        v += g * (elapse / 3000);
                        Position.Y += v;
                    }
                    if(isTouchWall())
                    {
                        elapse = 0;
                        Position.Y = PosStopY;
                        canJump = true;
                    }
                    if(Position.Y >= H-Hieght/2)
                    {
                        canJump = true;
                        Position.Y = H - Hieght / 2;
                    }
                    
                }
            }

            playerLeft.Position = Position;
            PlayerRight.Position = Position;


            //พลังชีวิต(currentHealth/Health)* (tapPower.Width/2)
            int x = (tapHealth.Width / 2) - ((tapHealth.Width / 2) * CurrentHealth / Health);
            destinationRect = new Rectangle(10,posTapHealthY,150,10);
            sourceRect = new Rectangle(x, 0, tapHealth.Width / 2, 5);
            if (CurrentHealth > Health)
            {
                CurrentHealth = Health;
            }
            if (CurrentHealth <= 0)
            {
                Active = false;
            }
        }

        public bool isTouchWall()
        {
            for(int i = 0; i < PositionWalls.Count; i++)
            {
                if(Position.Y+Hieght/2>=PositionWalls[i].Y &&
                    Position.Y + Hieght / 2 <= PositionWalls[i].Y+30 &&
                    Position.X>=PositionWalls[i].X-Width/2 &&
                    Position.X <= PositionWalls[i].X + WidthWalls[i]+Width/2)
                {
                    PosStopY = PositionWalls[i].Y-Hieght/2;
                    canJump = true;
                    return true;
                }
            }
            PosStopY = H - Hieght/2;
            return false;
        }

        public void Reset()
        {
            CurrentHealth = Health;
            playerLeft.Position = PositionS;
            PlayerRight.Position = PositionS;
        }

        public void ResetPosition()
        {
            Position.Y = H - 50;
            Position.X = 200;
            playerLeft.Position = Position;
            PlayerRight.Position = Position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tapHealth, destinationRect, sourceRect, Color.White);
            if (Moving == "left")
            {
                playerLeft.Draw(spriteBatch);
            }
            if (Moving == "right")
            {
                PlayerRight.Draw(spriteBatch);
            }

        }
    }
}
