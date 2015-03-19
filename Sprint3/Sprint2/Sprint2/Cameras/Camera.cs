using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Player;
using System.Collections;

namespace Sprint2.Cameras
{
    class Camera
    {
        int yResolution = 480;
        int xResolution = 800;
        static int cameraOffset;
        public Camera()
        {
        }

        public void Update(ArrayList pList)
        {
           int max = 0;
            foreach (IPlayer player in pList) {
                Rectangle playerRec = player.GetRectangle();
                if (playerRec.X > max)
                    max = playerRec.X;
            }
            if (max - cameraOffset > 650)
            {
                cameraOffset += (max - cameraOffset - 650);
            }
        }
        public int GetCameraOffset()
        {
            return cameraOffset;
        }
        public void Reset()
        {
            cameraOffset = 0;
        }

        public bool InsideCamraUpdateBounds(Rectangle r)
        {
            Rectangle cameraRec = new Rectangle(cameraOffset - 20, 0, xResolution + 20, yResolution+20);
            Rectangle overlap = Rectangle.Intersect(cameraRec,r);
            return !overlap.IsEmpty;
        }

    }
}
