using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TapTitansXNA_AJPenaranda
{
    public class Level
    {
        public static int windowWidth = 400;
        public static int windowHeight = 500;

        #region Properties
        ContentManager content;
        Texture2D bgd;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero;

        SpriteFont damageStringFont;
        int damageNumber = 0;

        Button playButton;
        
        #endregion

        public Level(ContentManager cont)
        {
            this.content = cont;

            hero = new Hero(cont, this);
           
        }

        public void LoadContent()
        {
            bgd = content.Load<Texture2D>("Background/background 1");
            damageStringFont = content.Load<SpriteFont>("SpriteFont1");

            playButton = new Button(content, "Sprites/push me", new Vector2(0, 350));

            hero.LoadContent();
            
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;
            

            hero.Update(gameTime);

            oldMouseState = mouseState;
            
            if(playButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                damageNumber += 1;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgd, Vector2.Zero, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            hero.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(damageStringFont, damageNumber + " Damage!", Vector2.Zero, Color.White);
            playButton.Draw(gameTime, spriteBatch);
            //spriteBatch.Draw(player, playerPosition, null, Color.White, 0.0f, Vector2.Zero, 2f, SpriteEffects.None, 0);
        }
    }
}
