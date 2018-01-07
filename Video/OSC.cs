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
            sender = new UDPSender(ip, port);           
        }

        public static void Send(string message)
        {
            var msg = new OscMessage(message, 1);
            sender.Send(msg);
        }

        public static void Send(int trackNumber)
        {
            string message = "/track" + Convert.ToInt16(trackNumber) + "/connect";
            Send(message);
        }

        public static void Send(int numberLayer, int numberClip)
        {
            string message = "/layer" + Convert.ToInt16(numberLayer) + "/clip" + Convert.ToInt16(numberClip) + "/connect";
            Send(message);
        }
    }
}
