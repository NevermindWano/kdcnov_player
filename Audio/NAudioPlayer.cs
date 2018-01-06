using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace Audio
{
    public class NAudioPlayer : IPlayer
    {
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;

        private string filename;
        public bool run { get; set; }
        public string name { get; set; }

        public bool beDestroyed { get; set; }

        public int volume { get; set; }

        public PlayerStateHandler handler { get; set; }

        public NAudioPlayer()
        {
            run = false;            
        }

        public void Init(PlayerStateHandler handler)
        {
            this.handler = handler;
        }

        public void Play(string filename)
        {
            this.filename = filename;

            if (run)
            {
                closeWaveOut();
                Play(filename);
            }
            else if (filename != null)
            {
                waveOutDevice = new WaveOut();
                waveOutDevice.PlaybackStopped += (s, e) => handler();

                audioFileReader = new AudioFileReader(filename);
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
                run = true;
            }
        }



        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            closeWaveOut();            
        }

        public int GetState()
        {
            if (waveOutDevice == null)
                return 0;

            switch (waveOutDevice.PlaybackState)
            {
                case PlaybackState.Playing:
                    return 1;           
                case PlaybackState.Stopped:
                    return 0;        
                default:
                    return 0;
            }                          
        }

        public static string GetDuration(string filename)
        {
            string response;
            using (var media = new MediaFoundationReader(filename, new MediaFoundationReader.MediaFoundationReaderSettings() { SingleReaderObject = true }))
            {
                response = media.TotalTime.ToString(@"mm\:ss");
                media.Dispose();
            }
            return response;

           // return new AudioFileReader(filename).TotalTime;
        }

        private void closeWaveOut()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                run = false;
            }
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
                run = false;
            }
        }
        
    }
}
