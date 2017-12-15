using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace signalrtest
{
    [HubName("myChatHub")]
    public class LetsChat : Hub
    {

        public void send(string message)
        {
            Clients.All.sendMessage(message);
        }

    }
}