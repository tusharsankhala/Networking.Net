using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPBroadcastSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sockBroadcaster = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sockBroadcaster.EnableBroadcast = true;

            // End Point.    
            IPEndPoint broadcastEP = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 23000);

            // Data
            byte[] broadcastBuffer = new byte[] { 0x0D, 0x0A }; // stands for /r/n.
            string inputStr;

            try
            {
                while (true)
                {
                    inputStr = Console.ReadLine();

                    if (inputStr == "<EXIT>")
                    {
                        break;
                    }

                    broadcastBuffer = Encoding.ASCII.GetBytes(inputStr);
                    sockBroadcaster.SendTo(broadcastBuffer, broadcastEP);
                }
                sockBroadcaster.Shutdown(SocketShutdown.Both);
                sockBroadcaster.Close();
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }
    }
}
