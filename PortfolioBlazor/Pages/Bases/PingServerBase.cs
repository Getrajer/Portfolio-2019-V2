using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class PingServerBase : ComponentBase
    {
        protected string url;
        protected string scheme;
        protected string port;
        protected string host;
        protected string path;
        protected string query;
        protected string siteReply;
        protected string pingTime;
        protected string ipAddress;
        protected int counter = 1;

        protected List<string> ipAddresses = new List<string>();

        protected string success;
        protected string error;

        public async void pingServer()
        {
            //Reset error message
            error = "";
            //Reset sucess message
            success = " ";
            var uri = new Uri(url);
            //Reset rest of the data
            scheme = " ";
            port = " ";
            host = " ";
            path = " ";
            query = " ";
            siteReply = " ";
            pingTime = " ";
            ipAddresses.Clear();
            counter = 1;


            try
            {
                var ping = new Ping();
                PingReply reply = ping.Send(uri.Host);
                siteReply = reply.Status.ToString();
                pingTime = reply.RoundtripTime.ToString();

                IPHostEntry entry = Dns.GetHostEntry(uri.Host);
                
                foreach(IPAddress address in entry.AddressList)
                {
                    ipAddresses.Add(address.ToString());
                }

                scheme = uri.Scheme;
                port = uri.Port.ToString();
                host = uri.Host;
                path = uri.AbsolutePath;
                query = uri.Query;


                await Task.Delay(500);
                success = "Success!";
                StateHasChanged();
            }
            catch
            {
                error = "Something went wrong, try again with valid website address";
            }

            
        }

    }
}
