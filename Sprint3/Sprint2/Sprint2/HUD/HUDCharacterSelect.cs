using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.HUD
{
    class HUDCharacterSelect
    {
        SpriteFont font;

        public HUDCharacterSelect(SpriteFont sf)
        {
            font = sf;
        }
        public void Update(){

        }
        public void Draw(SpriteBatch spriteBatch, String currentCharSelected)
        {
            String Directions = "Use Arrow Keys to change character";
            Vector2 DirectionsPos = new Vector2((float)(400 - font.MeasureString(Directions).X / 2), 100f);
            spriteBatch.DrawString(font, Directions, DirectionsPos, Color.White);

            Directions = "Press ENTER to select character";
            DirectionsPos = new Vector2((float)(400 - font.MeasureString(Directions).X / 2), 120f);
            spriteBatch.DrawString(font, Directions, DirectionsPos, Color.White);

            String CharSelectOut = "Currently Selected Character:";
            Vector2 CharSelectOutPos = new Vector2((float)(400 - font.MeasureString(CharSelectOut).X / 2), 200f);
            spriteBatch.DrawString(font, CharSelectOut, CharSelectOutPos, Color.White);
            Vector2 CurrentCharPos = new Vector2((float)(400 - font.MeasureString(currentCharSelected).X/2), 220f);
            spriteBatch.DrawString(font, currentCharSelected, CurrentCharPos, Color.White);
        }
    }
}
