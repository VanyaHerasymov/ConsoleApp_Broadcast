using System.Net;
using System.Net.Sockets;

var port = 5000;

var udpClient=new UdpClient(port);

var endpoint=new IPEndPoint(IPAddress.Any, port);  

while (true)
{
    byte[] receivedBytes = udpClient.Receive(ref endpoint);

    var message = System.Text.Encoding.UTF8.GetString(receivedBytes);
    
    Console.WriteLine(message);
}