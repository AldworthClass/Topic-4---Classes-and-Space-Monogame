using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace Topic_4___Classes_and_Space_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D shipTexture;
        Texture2D starTexture;

        Rectangle shipRect;
        Rectangle window;

        List<Star> stars;

        Star star1;

        Random generator;

        KeyboardState keyboardState, previousKeyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            shipRect = new Rectangle(50, 250, 150, 40);
            generator = new Random();

            base.Initialize();

            stars = new List<Star>();
            for (int i = 0; i < 150; i++)
            {
                int x, y, size;
                Vector2 speed = new Vector2();
                
                x = generator.Next(window.Width);
                y = generator.Next(window.Height);

                size = generator.Next(1, 4);
                speed.X = -size;
                Rectangle star = new Rectangle(x, y, size, size);
                stars.Add(new Star(starTexture, star, speed));



            }

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            shipTexture = Content.Load<Texture2D>("Images/enterprise");
            starTexture = Content.Load<Texture2D>("Images/circle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            // TODO: Add your update logic here
            foreach (Star star in stars)
            {
                star.Update(window);                    
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var star in stars)
                star.Draw(_spriteBatch);

            _spriteBatch.Draw(shipTexture, shipRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
