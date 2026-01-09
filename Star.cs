using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_4___Classes_and_Space_Monogame
{
    public class Star
    {
        private Rectangle _location;
        private Vector2 _speed;
        private Texture2D _texture;
        private Color _color;
        private Random _generator;

        public Star(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _location = location;
            _speed = speed;
            _texture = texture;
            _color = Color.White;
            _generator = new Random();
        }

        public void Update(Rectangle window)
        {
            _location.Offset(_speed);
            // Check for going off the screen
            if (_location.Right < 0)
            {
                _location.X = _generator.Next(window.Width, window.Width + 10);
                _location.Y = _generator.Next(window.Height);
            }
            
        }

        public void SpeedUp()
        {
            
            _speed.X -= 1;
        }
        public void SlowDown()
        {
            if (_speed.X < -_location.Width)
                _speed.X += 1;
        }

        public float Speed
        {
            get { return _speed.X; }
            set { _speed.X = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }
    }
}
