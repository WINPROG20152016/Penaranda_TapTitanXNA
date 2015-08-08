using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TapTitansXNA_AJPenaranda
{
    public class Hero
    {
        #region Properties
        Vector2 TrunksPosition;
        Vector2 GotenPosition;
        Vector2 OwlPosition;
        Vector2 GotenExplosionPosition;
        Texture2D TrunksIdle;
        Texture2D TrunksAttack;
        Texture2D GotenIdle;
        Texture2D GotenAttack;
        Texture2D OwlHit;
        Texture2D OwlFlying;
        Texture2D GotenExplosion;
        ContentManager content;
        Level level;
        
        int positionX;
        int positionY;
        int trunks = 1;
        int trunksSwitch = 1;
        int goten = 1;
        int gotenSwitch = 1;
        int owl = 1;
        int owlSwitch = 1;
       

        Animation idleAnimationTrunks;
        Animation attackAnimationTrunks;
        Animation idleAnimationGoten;
        Animation attackAnimationGoten;
        Animation animationOwlFlying;
        Animation animationOwlHit;
        Animation animationGotenExplosion;
        AnimationPlayer spritePlayerOwl;
        AnimationPlayer spritePlayerTrunks;
        AnimationPlayer spritePlayerGoten;
        AnimationPlayer spritePlayerGotenExplosion;
        #endregion

        public Hero(ContentManager cont, Level level)
        {
            this.content = cont;
            this.level = level;
        }

        public void LoadContent()
        {
            TrunksIdle = content.Load<Texture2D>("Sprites/trunks");
            TrunksAttack = content.Load<Texture2D>("Sprites/trunks attack"); 
            idleAnimationTrunks = new Animation(TrunksIdle, 0.1f, true, 6);
            attackAnimationTrunks = new Animation(TrunksAttack, 0.1f, true, 5);
            spritePlayerTrunks.PlayAnimation(idleAnimationTrunks);

            GotenIdle = content.Load<Texture2D>("Sprites/Goten idle");
            GotenAttack = content.Load<Texture2D>("Sprites/Goten attack");
            idleAnimationGoten = new Animation(GotenIdle, 0.1f, true, 5);
            attackAnimationGoten = new Animation(GotenAttack, 0.1f, true, 6);
            spritePlayerGoten.PlayAnimation(idleAnimationGoten);

            OwlFlying = content.Load<Texture2D>("Sprites/Owl flying");
            OwlHit = content.Load<Texture2D>("Sprites/Owl hit");
            animationOwlFlying = new Animation(OwlFlying, 0.1f, true, 6);
            animationOwlHit = new Animation(OwlHit, 0.1f, true, 6);
            spritePlayerOwl.PlayAnimation(animationOwlFlying);

            GotenExplosion = content.Load<Texture2D>("Sprites/Goten explosion");
            animationGotenExplosion = new Animation(GotenExplosion, 0.1f, true, 6);
            spritePlayerGotenExplosion.PlayAnimation(animationGotenExplosion);
            

            if (trunks == 1)
            {
                positionX = (Level.windowWidth / 2) - (TrunksIdle.Width / 4) + 280;
                positionY = (Level.windowHeight / 2) - (TrunksIdle.Height / 4) + 60;
                TrunksPosition = new Vector2((float)positionX, (float)positionY);
                trunks = 0;
            }

            if (goten == 1)
            {
                positionX = (Level.windowWidth / 2) - (GotenIdle.Width / 4) + 55;
                positionY = (Level.windowHeight / 2) - (GotenIdle.Height / 4) + 60;
                GotenPosition = new Vector2((float)positionX, (float)positionY);
                goten = 0;
            }

            if (owl == 1)
            {
                positionX = (Level.windowWidth / 2) + 10;
                positionY = (Level.windowHeight / 2) - 20;
                OwlPosition = new Vector2((float)positionX, (float)positionY);
                owl = 0;
            }
           
        }
        public void Update(GameTime gameTime)
        {
            //if (trunks == 0)
            //{

            if (level.HitButton == 1)
            {
                positionX = (Level.windowWidth / 2) - (TrunksAttack.Width / 4) + 337;
                positionY = (Level.windowHeight / 2) - (TrunksAttack.Height / 4) + 55;
                TrunksPosition = new Vector2((float)positionX, (float)positionY);
                spritePlayerTrunks.PlayAnimation(attackAnimationTrunks);

                positionX = (Level.windowWidth / 2);
                positionY = (Level.windowHeight / 2) - 15;
                OwlPosition = new Vector2((float)positionX, (float)positionY);
                spritePlayerOwl.PlayAnimation(animationOwlHit);

                level.HitButton = 0;
            }

            /*else if (level.HitButton == 0)
            {
                positionX = (Level.windowWidth / 2) - (TrunksIdle.Width / 4) + 280;
                positionY = (Level.windowHeight / 2) - (TrunksIdle.Height / 4) + 60;
                TrunksPosition = new Vector2((float)positionX, (float)positionY);
                spritePlayerTrunks.PlayAnimation(idleAnimationTrunks);

                //level.HitButton = 1;
            }*/

            //if (level.mouseState.LeftButton == ButtonState.Pressed && level.oldMouseState.LeftButton == ButtonState.Released /* &&level.HitButton == 1 && trunks == 0*/)
                //{
                    
                    /*if (trunks == 0)
                    {
                        positionX = (Level.windowWidth / 2) - (TrunksAttack.Width / 4) + 337;
                        positionY = (Level.windowHeight / 2) - (TrunksAttack.Height / 4) + 55;
                        TrunksPosition = new Vector2((float)positionX, (float)positionY);
                        spritePlayerTrunks.PlayAnimation(attackAnimationTrunks);
                        trunks = 1;
                    }*/
                    //positionX = (Level.windowWidth / 2) - (TrunksAttack.Width / 4) + 337;
                    //positionY = (Level.windowHeight / 2) - (TrunksAttack.Height / 4) + 55;
                   // TrunksPosition = new Vector2((float)positionX, (float)positionY);
                    //spritePlayerTrunks.PlayAnimation(attackAnimationTrunks);
                    //level.HitButton = 0;
                    //trunks = 1;
                //}
        

               else if (level.mouseState.LeftButton == ButtonState.Pressed && level.oldMouseState.LeftButton == ButtonState.Released)
                {
                    
                    /*if (trunks == 1)
                    {
                        positionX = (Level.windowWidth / 2) - (TrunksIdle.Width / 4) + 280;
                        positionY = (Level.windowHeight / 2) - (TrunksIdle.Height / 4) + 60;
                        TrunksPosition = new Vector2((float)positionX, (float)positionY);
                        trunks = 0;
                    }
                    spritePlayerTrunks.PlayAnimation(idleAnimationTrunks);*/

                   
                    positionX = (Level.windowWidth / 2) - (TrunksIdle.Width / 4) + 280;
                    positionY = (Level.windowHeight / 2) - (TrunksIdle.Height / 4) + 60;
                    TrunksPosition = new Vector2((float)positionX, (float)positionY);
                    spritePlayerTrunks.PlayAnimation(idleAnimationTrunks);

                    positionX = (Level.windowWidth / 2);
                    positionY = (Level.windowHeight / 2) - 30;
                    OwlPosition = new Vector2((float)positionX, (float)positionY);
                    spritePlayerOwl.PlayAnimation(animationOwlFlying);
                }
            //}

            if (gotenSwitch == 1)
            {
                if (level.mouseState.LeftButton == ButtonState.Pressed && level.oldMouseState.LeftButton == ButtonState.Released)// && level.HitButton == 0)
                {
                    /*if (goten == 0)
                    {  
                        positionX = (Level.windowWidth / 2) - (GotenAttack.Width / 4) + 110;
                        positionY = (Level.windowHeight / 2) - (GotenAttack.Height / 4) + 60;
                        GotenPosition = new Vector2((float)positionX, (float)positionY);
                        GotenExplosionPosition = new Vector2((float)positionX + 40, (float)positionY + 10);
                        spritePlayerGoten.PlayAnimation(attackAnimationGoten);
                        goten = 1;
                    }*/
                    /*positionX = (Level.windowWidth / 2) - (GotenAttack.Width / 4) + 110;
                    positionY = (Level.windowHeight / 2) - (GotenAttack.Height / 4) + 60;
                    GotenPosition = new Vector2((float)positionX, (float)positionY);
                    GotenExplosionPosition = new Vector2((float)positionX + 40, (float)positionY + 10);
                    spritePlayerGoten.PlayAnimation(attackAnimationGoten);*/



                }
                /*else if (level.mouseState.RightButton == ButtonState.Pressed && level.oldMouseState.RightButton == ButtonState.Released)
                {
                    
                    if (goten == 1)
                    {
                        positionX = (Level.windowWidth / 2) - (GotenIdle.Width / 4) + 55;
                        positionY = (Level.windowHeight / 2) - (GotenIdle.Height / 4) + 60;
                        GotenPosition = new Vector2((float)positionX, (float)positionY);
                        goten = 0;
                    }
                    spritePlayerGoten.PlayAnimation(idleAnimationGoten);

                }*/
            }

           /* if (owl == 1)
            {
                if (trunks == 0)
                {
                    positionX = (Level.windowWidth / 2);
                    positionY = (Level.windowHeight / 2) - 30;
                    OwlPosition = new Vector2((float)positionX, (float)positionY);
                    spritePlayerOwl.PlayAnimation(animationOwlFlying);
                }
                else if (level.HitButton == 1)
                {
                    positionX = (Level.windowWidth / 2);
                    positionY = (Level.windowHeight / 2) - 15;
                    OwlPosition = new Vector2((float)positionX, (float)positionY);
                    spritePlayerOwl.PlayAnimation(animationOwlHit);
                }
            }*/
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spritePlayerTrunks.Draw(gameTime, spriteBatch, TrunksPosition, SpriteEffects.None);
            spritePlayerGoten.Draw(gameTime, spriteBatch, GotenPosition, SpriteEffects.None);
            spritePlayerOwl.Draw(gameTime, spriteBatch, OwlPosition, SpriteEffects.None);

            if (goten == 1)
            {
                spritePlayerGotenExplosion.Draw(gameTime, spriteBatch, GotenExplosionPosition, SpriteEffects.None);
            }
        }
    }
}
