using System.Net;
using System.Net.Sockets;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Task.Run(() => Receive());
        }


        void Receive()
        {
            var port = 5000;
            var udpClient = new UdpClient(port);
            var endpoint = new IPEndPoint(IPAddress.Any, port);

            while (true)
            {
                byte[] receivedBytes = udpClient.Receive(ref endpoint);
                var message = System.Text.Encoding.UTF8.GetString(receivedBytes);

                //Console.WriteLine($"Received: {message}");

                textBox1.Invoke(() =>
                {
                    textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                });
                label1.Invoke(() =>
                {
                    label1.Text = message;
                });
            }

        }
    }
}
