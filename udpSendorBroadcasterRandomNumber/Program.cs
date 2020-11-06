using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace udpSendorBroadcasterRandomNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1-1 communication (uni casting communication)
            // remote IP address 
            // 0 -65,000
            // udp datagram to specific port number 
            //UdpClient udpBroadcastSender = new UdpClient(7000);
            // it is automatically detect the avaliable port on the network 
            UdpClient udpBroadcastSender = new UdpClient(0);

            // broadcast IP : 255.255.255.255
            // You must have to define port number here in IPEndPOint
            // "255.255.255.255"
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Broadcast, 7000);
            //unique Random number generate 
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            Console.WriteLine("Press Enter to start Sendor");
            try
            {
                while(true)
                {
                    // unique number is generated here
                    var number = ran.Next(1, 1000);
                    // convert your message into Bytes
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("The number is :" + number);
                    // sending my message on AIR
                    udpBroadcastSender.Send(sendBytes, sendBytes.Length, ipEndPoint);
                    Console.WriteLine(number);
                    Thread.Sleep(2000);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }
    }
}
