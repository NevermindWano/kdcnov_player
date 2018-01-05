using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMP.NET.RemoteAPI;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace Audio
{

    public class AIMPPlayer : IPlayer
    {
        public PlayerStateHandler handler { get; set; }

        public string name { get; set; }

        public bool run { get; set; }

        public bool beDestroyed { get; set; }

        public int volume
        {
            get
            {
                return aimp.Volume;
            }

            set
            {
                aimp.Volume = value;
            }            
        }

        private IAimpRemote aimp;

        private bool doubleEvent;
        private PlayerState playerState;

        public AIMPPlayer()
        {
            name = "aimp";
          //  Volume = 100;
        }

        public void Init(PlayerStateHandler handler)
        {
            this.handler = handler;        
        }

        public void Play(string filename)
        {
            if (aimp != null)
            {
                aimp.Dispose();
                aimp = null;
                Play(filename);
            }
            else
            {
                aimp = new AimpRemote();

                if (!startAimp(filename)) return;

                aimp.TrackInfoChanged += (s, e) =>
                {
                    if (aimp == null) return;
                    doubleEvent = (aimp.PlayerState == playerState) ? true : false;
                    playerState = aimp.PlayerState;

                    if (aimp.PlayerState == PlayerState.Stopped && !doubleEvent)
                    {
                        handler();
                    }
                };
            }            
        }


        public int GetState()
        {
            if (aimp == null)
                return 0;

            switch (aimp.PlayerState)
            {
                case PlayerState.Playing:
                    return 1;
                case PlayerState.Stopped:
                    return 0;
                default:
                    return 0;
            }            
        }

        public void Pause()
        {
            aimp.Pause();
        }

        public void Stop()
        {
            closeWaveOut();
        }

        private bool startAimp(string filename, string processName = "AIMP")
        {
            var p = new Process();
            p.StartInfo.FileName = processName;
            p.StartInfo.Arguments = filename;
            try
            {
                p.Start();
                return true;
            }
            catch (Win32Exception)
            {
                return false;
            }
        }

        private void closeWaveOut()
        {
            if (aimp != null)
            {
                aimp.Stop();
            }
            if (aimp != null)
            {
                aimp.Dispose();
                aimp = null;
            }
        }

        ~AIMPPlayer()
        {
            closeWaveOut();
        }
    }
}
