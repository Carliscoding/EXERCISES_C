using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bài1
{
    public partial class UDPClient : Form
    {
        public UDPClient()
        {
            InitializeComponent();
        }
        UdpClient client;
        IPEndPoint ipendp;
        Socket socket;   
        public void Send()
        {
            ipendp = new IPEndPoint(IPAddress.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            client = new UdpClient();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(textBox3.Text);
            socket.SendTo(sendBytes, ipendp);
            client.Send(sendBytes, sendBytes.Length, ipendp);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Send();
            textBox3.Clear();
        }
        private void UDPClient_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);   
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
