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

        public static void init(string ip, int port)
        {
            if (sender == null)
                sender = new UDPSender(ip, port);           
        }

        public static void send(string address)
        {
            var message = new OscMessage(address, 1);
            sender.Send(message);
        }

        public static void onTrack(int trackNumber)
        {
            string address = "/track" + Convert.ToInt16(trackNumber) + "/connect";
            send(address);
        }

        public static void onClip(int numberLayer, int numberClip)
        {
            string address = "/layer" + Convert.ToInt16(numberLayer) + "/clip" + Convert.ToInt16(numberClip) + "/connect";
            send(address);
        }
    }
}
