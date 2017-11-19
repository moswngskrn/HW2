using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace GameHW2
{
    class Enemy
    {
        //พลังชีวิต
        Texture2D tapPower;
        Rectangle destinationRect;
        Rectangle sourceRect;

        Animation enemyLeft;
        Animation enemyRight;
        public string Moving;
        public Vector2 Position;
        public int frameWidth;
        public int frameHeight;
        public bool Active;
        int Health;
        public int Damage;
        public int currentHealth;
        float Vx;

        Vector2 positionWall;
        int wallWidth;

        public Enemy(int frameWidth, int frameHeight, int frameCountCol, int frameCountRow, int delay, int Health,int Damage, int Vx)
        {
            Moving = "left";
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            bool looping = true;
            this.Health = Health;
            this.Damage = Damage;
            currentHealth = Health;
            this.Vx = Vx;
            enemyLeft = new Animation(frameWidth, frameHeight, frameCountCol, frameCountRow, delay, looping);
            enemyRight = new Animation(frameWidth, frameHeight, frameCountCol, frameCountRow, delay, looping);
        }


        public void LoadContent(ContentManager Content, string nameLeft, string nameRight,Vector2 positionWall,int wallWidth)
        {
            this.positionWall = positionWall;
            this.wallWidth = wallWidth;
            Position = new Vector2(positionWall.X+frameWidth/2,positionWall.Y-frameHeight/2);
            enemyLeft.LoadContent(Content, nameLeft);
            enemyRight.LoadContent(Content, nameRight);
            enemyLeft.Position = Position;
            enemyRight.Position = Position;

            //พลังชีวิต
            tapPower = Content.Load<Texture2D>("red");
            Active = true;
            
        }

        public void Update(GameTime gameTime)
        {
            if(Moving == "left")
            {
                Position.X -= Vx;
                if (Position.X <= positionWall.X+frameWidth/2)
                {
                    Moving = "right";
                }
            }
            if(Moving == "right")
            {
                Position.X += Vx;
                if (Position.X >= positionWall.X+wallWidth-frameWidth/2)
                {
                    Moving = "left";
                }
            }
            enemyLeft.Position = Position;
            enemyRight.Position = Position;
            enemyLeft.Update(gameTime);
            enemyRight.Update(gameTime);
            //int x = tapPower.Width-(tapPower.Width * (currentHealth / Health));


            //พลังชีวิต(currentHealth/Health)* (tapPower.Width/2)
            int x = (tapPower.Width / 2) - ((tapPower.Width / 2) * currentHealth / Health);
            destinationRect = new Rectangle((int)Position.X-frameWidth/2, (int)Position.Y-15-frameHeight/2, frameWidth, 5);
            sourceRect = new Rectangle(x, 0, tapPower.Width/2, 5);
            if (currentHealth <= 0)
            {
                Active = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tapPower, destinationRect, sourceRect, Color.White);
            if(Moving == "right")
            {
                enemyRight.Draw(spriteBatch);
            }
            if(Moving == "left")
            {
                enemyLeft.Draw(spriteBatch);
            }
        }
    }
}
