using System;
using Video;

namespace PlaylistLib
{

    public interface ITrackOSCState
    {
        ITrackOSCState Send();
        string ShowOSCInfo();
    }

    [Serializable]
    public class OSCState_track : ITrackOSCState
    {
        private Track track;
        public OSCState_track(Track track)
        {
            this.track = track;
        }

        public ITrackOSCState Send()
        {
            OSC.sendTrack(track.oscTrack);
            return this;
        }

        public string ShowOSCInfo()
        {
            return track.oscTrack.ToString();
        }
    }

    [Serializable]
    public class OSCState_clip : ITrackOSCState
    {
        private Track track;
        public OSCState_clip(Track track)
        {
            this.track = track;
        }

        public ITrackOSCState Send()
        {
            OSC.sendClip(track.oscLayer, track.oscClip);
            return this;
        }

        public string ShowOSCInfo()
        {
            return "L = " + track.oscLayer.ToString() + " C = " + track.oscClip.ToString();
        }
    }

    [Serializable]
    public class OSCState_custom : ITrackOSCState
    {
        private Track track;
        public OSCState_custom(Track track)
        {
            this.track = track;
        }

        public ITrackOSCState Send()
        {
            OSC.sendCustom(track.oscCustom);
            return this;
        }

        public string ShowOSCInfo()
        {
            return track.oscCustom;
        }
    }


}
