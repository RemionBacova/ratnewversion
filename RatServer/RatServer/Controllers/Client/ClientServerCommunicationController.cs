using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using RatServer.Core.Filters;
using System.Collections;

namespace RatServer.Controllers.Client
{
    public class ClientServerCommunicationController
    {
        static protected System.Collections.ArrayList arrUsers = new ArrayList();
        static protected System.Collections.ArrayList arrMessage = new ArrayList();
        public ClientServerCommunicationController()
        {

        }


        [HttpGet(nameof(SendMessage))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public void SendMessage(string strFromUser, string strToUser, string strMess)
        {
            arrMessage.Add(strToUser + ":" + strFromUser + ":" + strMess);
        }

        [HttpGet(nameof(ReceiveMessage))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public string ReceiveMessage(string strUser)
        {
            string strMess = string.Empty;
            for (int i = 0; i < arrMessage.Count; i++)
            {
                string[] strTo = arrMessage[i].ToString().Split(':');
                if (strTo[0].ToString() == strUser)
                {
                    for (int j = 1; j < strTo.Length; j++)
                    {
                        strMess = strMess + strTo[j] + ":";
                    }
                    arrMessage.RemoveAt(i);
                    break;
                }
            }
            return strMess;
        }
  
    }
}
