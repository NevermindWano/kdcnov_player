using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpOSC;

namespace Video
{
    public static class OSC
    {
        static UDPSender sender { get; set; }

        public static void Init(string ip, int port)
        {
            if (sender == null)
                sender = new UDPSender(ip, port);           
        }

        public static void Send(string address)
        {
            var message = new OscMessage(address, 1);
            sender.Send(message);
        }

        public static void OnTrack(int trackNumber)
        {
            string address = "/track" + Convert.ToInt16(trackNumber) + "/connect";
            Send(address);
        }

        public static void OnClip(int numberLayer, int numberClip)
        {
            string address = "/layer" + Convert.ToInt16(numberLayer) + "/clip" + Convert.ToInt16(numberClip) + "/connect";
            Send(address);
        }
    }
}
