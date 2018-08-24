using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.Common;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocketTest
{
    public class Command : CommandBase<Session, StringRequestInfo>
    {
        public override void ExecuteCommand(Session session, StringRequestInfo requestInfo)
        {
            Random r = new Random();
            int ii = r.Next(1, 99);
            session.CustomID = ii.ToString();
            session.CustomName = $"Custom_{ii.ToString()}";

            var Key = requestInfo.Key;
            var Param = requestInfo.Parameters;
            var Body = requestInfo.Body;

            session.Send(Body);
        }
    }
}
