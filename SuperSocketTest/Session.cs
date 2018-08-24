using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
namespace SuperSocketTest
{
    public class Session : AppSession<Session>
    {
        public string CustomID { get; set; }
        public string CustomName { set; get; }
        

        protected override void OnSessionClosed(CloseReason reason)
        {
            //add you logics which will be executed after the session is closed

            base.OnSessionClosed(reason);

        }

        protected override void OnSessionStarted()
        {
            base.Send("Welecom to server");
        }
    }
}
