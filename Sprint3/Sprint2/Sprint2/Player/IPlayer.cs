using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.Player
{
    interface IPlayer
    {
        void Idle();

        void Jump();

        void Crouch();

        void Left();

        void Right();

        void Attack();

        void Mushroom();

        void Fire();

        void Damaged();

        void Death();

        void Update();

        void Star();

        void Draw(SpriteBatch spriteBatch);

        bool IsStar();

        Rectangle GetRectangle();

        Rectangle GetSpriteRefRectangle();

        Rectangle GetWeakSpot();

        void ShiftUp();

        void ShiftDown();

        void ShiftLeft();

        void ShiftRight();

        bool IsPressingDown();

        void SetXYPos(int x, int y);

        void SetPlayerStats(PlayerStats p);

        void GainedCoin();

        void AddScore(int Score);

        void Bounce();

        void Flagpole(int score);

        void Reset();

        bool IsDead();

        Texture2D GetTexture();
    }
}
