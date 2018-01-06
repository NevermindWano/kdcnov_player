using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace PlaylistLib
{
    [Serializable]
    public enum nextTrack
    {
        [Description("Следующий трек")]
        next,
        [Description("Случайный фоновый трек")]
        bgRandom,
        [Description("Фоновый трек по умолчанию")]
        bgConcrete,
        [Description("Зациклить")]
        cycle,
        [Description("Пауза")]
        pause
    }

    [Serializable]
    public class Track
    {
        public string name { get; set; }
        public string audioFilePath { get; set; }
        public string duration { get; set; }
        public nextTrack next { get; set; }
        public Track nextBg { get; set; }
        public int bpm { get; set; }
        public bool isMidiNote { get; set; }
        public int midiNote { get; set; }
        public string midiFile { get; set; }
        public int oscCommand { get; set; }
        public bool bg { get; set; }
        public bool isPlaylistTrack { get; set; }

        public Track()
        {
            isMidiNote = true;
        }

        public Track(bool bg)
        {
            this.bg = bg;
            Data options = new Data();

            string value = options.Read<string>("mainTrackPath");
            if (value != null)
            {
                audioFilePath = value;
                midiNote = options.Read<int>("mainMidiNote");
                oscCommand = options.Read<int>("mainTrackOsc");
                bg = true;
                isMidiNote = true;
                next = nextTrack.cycle;
            }
            options.Dispose();
        }
    }

}
