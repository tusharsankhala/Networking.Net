using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPBroadcastReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sockBreaodCastReciever = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipeLocal = new IPEndPoint(IPAddress.Any, 23000);

            byte[] recievedBuffer = new byte[512];
            StringBuilder recievedBytes = new StringBuilder(1);

            try
            {
                sockBreaodCastReciever.Bind(ipeLocal);
                while (true)
                {
                    int dataByteRecieved = sockBreaodCastReciever.Receive(recievedBuffer);
                    if (dataByteRecieved > 0)
                    {

                        recievedBytes.Append(Encoding.ASCII.GetString(recievedBuffer));
                        
                        Console.WriteLine("Number of Bytes recieved: " + dataByteRecieved);
                        Console.WriteLine("Data is: " + recievedBytes.ToString());

                        // Clear the buffer.
                        Array.Clear(recievedBuffer, 0, recievedBuffer.Length);
                        recievedBytes.Clear();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}