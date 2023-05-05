using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài1
{
    public partial class UDPServer : Form
    {
       
        public UDPServer()
        {
            InitializeComponent();
        }
        UdpClient client;
        Socket socket;
        IPEndPoint remoteEndPoint;
        private void UDPServer_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
           
        }
        
        
       
        
        public void serverThread_receive()
        {
            try
            {
                client = new UdpClient(Int32.Parse(textBox1.Text));
                while (true)
                {
                    remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    Byte[] receiveBytes = client.Receive(ref remoteEndPoint);
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    string mess = remoteEndPoint.Address.ToString() + ":" + returnData.ToString();

                    AddMessage(mess);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("There's an unknown error occurs!","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void AddMessage(string mess)
        {
            
            listView1.Items.Add(mess);
            listView1.Clear();
        }
        
        private void button2_Click(object sender, EventArgs e)//listen
        {
            //serverThread_receive(); 
            Thread listen = new Thread(serverThread_receive);
            listen.IsBackground = true;
            listen.Start();
            AddMessage("Lỗi không add được message lên trên grid view!");
        }   
     
    }
}

/*
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Task1Form : Form
    {
        public Task1Form()
        {
            InitializeComponent();
        }

        private void btnUDPClient_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                UDPClientForm frm = new UDPClientForm();
                frm.ShowDialog();
            });
            thread.Start();
        }

        private void btnUDPServer_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                UDPServerForm frm = new UDPServerForm();
                frm.ShowDialog();
            });
            thread.Start();
        }
    }
}
*/
