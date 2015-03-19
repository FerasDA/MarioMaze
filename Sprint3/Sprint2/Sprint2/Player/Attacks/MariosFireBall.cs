using Microsoft.Xna.Framework;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.LevelData;
using Sprint2.Objects;
using Sprint2.Objects.FireBall;
using Sprint2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.Attacks
{
    class MariosFireBall
    {
        Mario mario;
        static int fireballCount = 0;
        static int fireballCoolDown = 0;
        LevelAssets assets = new LevelAssets();
        SoundController sc = new SoundController();
        public MariosFireBall(Mario m)
        {
            mario = m;
        }

        public MariosFireBall()
        {
            
        }

        public void Attack(bool facingRight)
        {
            if (fireballCoolDown < 1 && fireballCount <2)
            {
                LevelAssets assets = new LevelAssets();
                Rectangle marioRec = mario.GetRectangle();
                if (facingRight)
                {
                    sc.Fireball();
                    FireBall f = new FireBall(assets.GetObjectTexutre(), marioRec.X + marioRec.Width - 4, marioRec.Y + 8, true, mario);
                    AddElementList ae = new AddElementList();
                    ae.Add(f);                
                }
                else
                {
                    sc.Fireball();
                    FireBall f = new FireBall(assets.GetObjectTexutre(), marioRec.X, marioRec.Y + 8, false, mario);
                    AddElementList ae = new AddElementList();
                    ae.Add(f);   
                }
                fireballCoolDown = 20;
                fireballCount++;
            }
        }
        public void Update()
        {
            fireballCoolDown--;
            int count = 0;
            foreach (IObject o in assets.GetObjectList())
            {
                FireBall f = o as FireBall;
                if (f != null)
                    count++;
            }

            fireballCount = count;
        }
    }
}
