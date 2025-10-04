using System.Net.Sockets;

//Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
//var tcpListner = new TcpClient(System.Net.IPAddress.Any,11000);

var udpClient = new UdpClient();

// acces sending broadcast messages
udpClient.EnableBroadcast = true;

var broadcastAddres = System.Net.IPAddress.Broadcast; 
var port = 5000;

var enpdoint = new System.Net.IPEndPoint(broadcastAddres, port);

while (true)
{
    var message = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
    var data=System.Text.Encoding.UTF8.GetBytes(message);

    await udpClient.SendAsync(data, data.Length, enpdoint);
    Console.WriteLine(message);
    await Task.Delay(5000);

}
