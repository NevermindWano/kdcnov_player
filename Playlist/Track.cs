using System;
using System.ComponentModel;
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

        private ITrackOSCState oscMode;
        public ITrackOSCState OSCMode
        {
            get
            {
                if (oscMode != null)
                    return oscMode;
                else return new OSCState_track(this);
            }
            set
            {
                oscMode = value;
            }
        }

        public Track nextBg { get; set; }
        public int bpm { get; set; }
        public bool isMidiNote { get; set; }
        public int midiNote { get; set; }
        public string midiFile { get; set; }
        public int oscTrack { get; set; }
        public int oscClip { get; set; }
        public int oscLayer { get; set; }
        public string oscCustom { get; set; }
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
                oscTrack = options.Read<int>("mainTrackOsc");
                bg = true;
                isMidiNote = true;
                next = nextTrack.cycle;
            }
            options.Dispose();
        }
    }

}
