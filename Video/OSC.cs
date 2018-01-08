using System;
using SharpOSC;

namespace Video
{
    public delegate void SendCustom(string message);
    public delegate void SendTrack(int trackNumber);
    public delegate void SendClip(int numberLayer, int numberClip);

    public static class OSC
    {
        static UDPSender sender { get; set; }

        public static SendCustom sendCustom;
        public static SendTrack sendTrack;
        public static SendClip sendClip;

        public static void Init(string ip, int port)
        {           
            sender = new UDPSender(ip, port);

            sendCustom = new SendCustom(send);
            sendTrack = new SendTrack(send);
            sendClip = new SendClip(send);
        }

        private static void send(string message)
        {
            var msg = new OscMessage(message, 1);
            sender.Send(msg);
        }

        private static void send(int trackNumber)
        {
            string message = "/track" + Convert.ToInt16(trackNumber) + "/connect";
            send(message);
        }

        private static void send(int numberLayer, int numberClip)
        {
            string message = "/layer" + Convert.ToInt16(numberLayer) + "/clip" + Convert.ToInt16(numberClip) + "/connect";
            send(message);
        }
    }
}
