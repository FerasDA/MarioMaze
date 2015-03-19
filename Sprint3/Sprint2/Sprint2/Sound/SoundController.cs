using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Sound
{
    class SoundController
    {
        static Song song;
        static SoundEffect jump;
        static SoundEffect pause;
        static SoundEffect playerDeath;
        static SoundEffect coin;
        static SoundEffect bump;
        static SoundEffect fireball;

        public SoundController(){}

        public void SetSong(Song s)
        {
            song = s;
        }

        public void PlaySong()
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.7f;
        }

        private void PauseSong()
        {
            if(MediaPlayer.State.Equals(MediaState.Playing))
                MediaPlayer.Pause();
            else if(MediaPlayer.State.Equals(MediaState.Paused))
                MediaPlayer.Resume();
        }

        public void Pause()
        {
            PauseSong();
            pause.Play();
        }

        public void SetPause(SoundEffect p)
        {
            pause = p;
        }

        public void SetPlayerDeath(SoundEffect d)
        {
            playerDeath = d;
        }

        public void PlayerDeath()
        {
            playerDeath.Play();
        }

        public void SetJump(SoundEffect j)
        {
            jump = j;
        }

        public void Jump()
        {
            jump.Play();
        }

        public void SetCoin(SoundEffect c)
        {
            coin = c;
        }

        public void Coin()
        {
            coin.Play();
        }

        public void SetBump(SoundEffect b)
        {
            bump = b; 
        }
        public void Bump()
        {
            bump.Play();
        }

        public void SetFireBall(SoundEffect f)
        {
            fireball = f;
        }

        public void Fireball()
        {
            fireball.Play();
        }
    }
}
