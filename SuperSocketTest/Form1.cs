using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SuperSocketTest
{
    public delegate void ShowInfo(string info,bool bAdd=true);
    
    public partial class Form1 : Form
    {

        private Dictionary<string, Session> CustomDic = new Dictionary<string, Session>();
        private Server server = new Server();
        private ShowInfo MyShowInfoDelgete = null;
        private ShowInfo ShowClientRecv = null;
        private AsyncTcpSession client=null;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!server.Setup(8888))
                return;
            if (!server.Start())
                return;
            server.NewSessionConnected += Server_NewSessionConnected;
            server.SessionClosed += Server_SessionClosed;
            server.NewRequestReceived += Server_NewRequestReceived;
            MyShowInfoDelgete = new ShowInfo((str,add)=> 
            {
                if(add)
                    listBox1.Items.Add(str);
                else
                    listBox1.Items.Remove(str);
            });
            ShowClientRecv=new ShowInfo((str, add) =>
            {
               textBox_ClientRecv.Text=str;
            });

            client = new AsyncTcpSession();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888));
            client.DataReceived += Client_DataReceived;
            client.NoDelay=true;
           
        }

        private void Client_DataReceived(object sender, DataEventArgs e)
        {

            string strrecv=System.Text.Encoding.ASCII.GetString(e.Data);
           
            if (InvokeRequired)
            {
                Invoke(ShowClientRecv,new object[] { strrecv,true });
            }
            else
            {
                textBox_ClientRecv.Text = strrecv;
            }
        }

        private void Server_SessionClosed(Session session, SuperSocket.SocketBase.CloseReason value)
        {
            if (CustomDic.Keys.Contains(session.RemoteEndPoint.ToString()))
            {
                string StrCustom = session.RemoteEndPoint.ToString();
                CustomDic.Remove(StrCustom);
                if(InvokeRequired)
                    Invoke(MyShowInfoDelgete, new object[] { StrCustom ,false});
                else
                    listBox1.Items.Remove(StrCustom);
            }
        }

        private void Server_NewRequestReceived(Session session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            Console.WriteLine(requestInfo.Key);
        }
    
        private void Server_NewSessionConnected(Session session)
        {
            string strCustom=session.RemoteEndPoint.ToString();
            CustomDic.Add(strCustom,session);
            if (InvokeRequired)
            {
                Invoke(MyShowInfoDelgete,new object[] { strCustom, true });
            }
            else
            {
                listBox1.Items.Add(strCustom);
            }
        }

        private void button_ServerSend_Click(object sender, EventArgs e)
        {
            foreach (var custom in CustomDic)
                custom.Value.Send(textBox_serverSend.Text);
        }

        private void button_ClientSend_Click(object sender, EventArgs e)
        {
            string strSend = textBox_ClientSend.Text;
            client.Send(System.Text.Encoding.ASCII.GetBytes(strSend),0, strSend.Length);
        }
    }
}
