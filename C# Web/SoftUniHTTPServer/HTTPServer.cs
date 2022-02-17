using BasicWebServer.Server.Routing;
using SoftUniHTTPServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniHTTPServer
{
    public class HTTPServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        private readonly RoutingTable routingTable;

        public HTTPServer(string _ipAddress, int _port, Action<IRoutingTable> routingTableConfiguration)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;

            serverListener = new TcpListener(ipAddress, port);
            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HTTPServer(int port, Action<IRoutingTable> routingTable)
            :this("127.0.0.1", port, routingTable)
        {

        }
        public HTTPServer(Action<IRoutingTable> routingTable)
            :this(8080, routingTable)
        {

        }
        public void Start()
        {
            serverListener.Start();
            Console.WriteLine($"Server is listening on port {port}");
            Console.WriteLine("Listening for requests");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                
                
                var networkStream = connection.GetStream();
                var requestText = this.ReadRequest(networkStream);
                Console.WriteLine(requestText);
                var request = Request.Parse(requestText);
                var response = this.routingTable.MatchRequest(request);
                if (response.PreRenderAction != null)
                {
                    response.PreRenderAction(request, response);
                }
                WriteResponse(networkStream, response);
                connection.Close();
                
                
            }
        }

        private void WriteResponse(NetworkStream networkStream, Response response)
        {

            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            networkStream.Write(responseBytes);
        }


        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];
            StringBuilder request = new StringBuilder();
            int totalBytes = 0;
            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                     
                request.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (networkStream.DataAvailable);

            return request.ToString();
        }
    }
}
