using Microsoft.Xna.Framework;
using Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance;
using Sprint2.LevelData;
using Sprint2.Objects;
using Sprint2.Objects.MegmanBullet;
using Sprint2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Player.Attacks
{
    class MegamansBullet
    {
        Megaman megaman;
        static int bulletCount = 0;
        static int bulletCoolDown = 0;
        LevelAssets assets = new LevelAssets();
        SoundController sc = new SoundController();

        public MegamansBullet(Megaman m)
        {
            megaman = m;
        }


        public void Attack(bool facingRight)
        {
            if (bulletCoolDown < 1 && bulletCount < 3)
            {
                LevelAssets assets = new LevelAssets();
                Rectangle megamanRec = megaman.GetRectangle();
                if (facingRight)
                {
                    //sc.MegamanBullet();
                    MegamanBullet mmb = new MegamanBullet(assets.GetMegamanTexture(), megamanRec.X + megamanRec.Width, megamanRec.Y + 14, true, megaman);
                    AddElementList ae = new AddElementList();
                     ae.Add(mmb);
                }
                else
                {
                    //sc.MegamanBullet();
                    MegamanBullet mmb = new MegamanBullet(assets.GetMegamanTexture(), megamanRec.X, megamanRec.Y + 14, false, megaman);
                    AddElementList ae = new AddElementList();
                    ae.Add(mmb);
                }
                bulletCoolDown = 15;
                bulletCount++;
            }
        }

        public void Update()
        {
            bulletCoolDown--;
            int count = 0;
            foreach (IObject o in assets.GetObjectList())
            {
                MegamanBullet b = o as MegamanBullet;
                if (b != null)
                    count++;
            }

            bulletCount = count;
        }
    }
}
