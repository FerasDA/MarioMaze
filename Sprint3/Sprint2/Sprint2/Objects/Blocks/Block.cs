using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint2.Objects.Blocks.BlockState;
using Sprint2.Cameras;
using Sprint2.Player;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.Sound;
using Sprint2.Objects.Items;


namespace Sprint2.Objects.Blocks
{
    class Block : IObject
    {
        Texture2D blockTexture;
        IBlockState blockState;
        int xPos, yPos;
        int bumpCounter;
        bool beingBumped, movingUp;
        const int bumpDoubleMax = 10;
        SoundController sc;
        IPlayer PlayerHitBy;
        char Contains;
        int BlocksCombined;

        // Contains
        // n = nothing
        // s = star
        // p = power up
        // d = poison
        // c = coin

        public Block(Texture2D texture,int x, int y, IBlockState state, char contains)
        {
            blockTexture = texture;
            xPos = x;
            yPos = y;
            blockState = state;

            BlocksCombined = 1;
            bumpCounter = 0;
            movingUp = false;
            beingBumped = false;
            sc = new SoundController();
            Contains = contains;
        }

        public void Update()
        {
            if (beingBumped)
            {
                movingUp = bumpCounter-- > bumpDoubleMax/2;
                yPos = (movingUp) ? (yPos - 1) : (yPos + 1);
                beingBumped = bumpCounter > 0;
                if(!beingBumped)
                {
                    //add item being contained;
                    AddElementList ae = new AddElementList();
                    switch(Contains)
                    {
                        case 's':
                            ae.Add(new Star(blockTexture,xPos + 1 , yPos - GetRectangle().Height));
                            break;
                        case 'p':
                            if(PlayerHitBy.GetRectangle().Height>20)
                                ae.Add(new FireFlower(blockTexture, xPos, yPos - GetRectangle().Height));
                            else
                                ae.Add(new Mushroom(blockTexture, xPos, yPos - GetRectangle().Height));
                            break;
                        case 'd':
                            ae.Add(new PoisonMushroom(blockTexture, xPos, yPos - GetRectangle().Height));
                            break;
                        case 'c':
                            PlayerHitBy.GainedCoin();
                            ae.Add(new BlockCoins(blockTexture, xPos + 4, yPos - GetRectangle().Height));
                            break;
                        default:
                            break;

                    }
                }
            }

            blockState.Update();
        }

        public void Collision() {}
        public void Collision(IPlayer p)
        {
            PlayerHitBy = p;
            sc.Bump();
            if (blockState.IsBumpable())
            {
                bumpCounter = bumpDoubleMax;
                movingUp = true;
                beingBumped = true;
            }


            if (blockState.IsBreakable())
            {
                if(p.GetRectangle().Height> 20)
                {
                    p.AddScore(50);
                    RemoveElementList re = new RemoveElementList();
                    re.Add(this);
                }
                else
                    blockState = blockState.Collision();
            }
            else
                blockState = blockState.Collision();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle spriteRef = blockState.getReferenceRectangle();
            Camera camera = new Camera();
            for (int i = 0; i < BlocksCombined; i++ )
                spriteBatch.Draw(blockTexture, new Rectangle(xPos - camera.GetCameraOffset() + (i * spriteRef.Width), yPos - spriteRef.Height, spriteRef.Width, spriteRef.Height), spriteRef, Color.White);
        }

        public Rectangle GetRectangle()
        { 
            Rectangle spriteRef = blockState.getReferenceRectangle();
            return new Rectangle(xPos, yPos - spriteRef.Height, spriteRef.Width * BlocksCombined, spriteRef.Height);
        }

        public Rectangle GetWeakSpot()
        {
            Rectangle spriteRef = blockState.getReferenceRectangle();
            Rectangle weakRef = blockState.getWeakSpot();
            return new Rectangle(xPos + weakRef.X, yPos - weakRef.Y, weakRef.Width, weakRef.Height);
        }

        public bool Combinable(Block a)
        {
            bool output = true;
            if (blockState.IsBreakable() || blockState.IsBumpable())
                output = false;

            if (!blockState.Equals(a.blockState))
                output = false;

            if (this.yPos != a.yPos)
                output = false;

            if (this.xPos + (blockState.getReferenceRectangle().Width * BlocksCombined) != a.xPos)
                output = false;

            if (a.BlocksCombined == 0)
                output = false;

            return output;
        }

        public void Combine(Block a)
        {
            BlocksCombined+= a.BlocksCombined;
            a.BlocksCombined = 0;
        }
    }
}
