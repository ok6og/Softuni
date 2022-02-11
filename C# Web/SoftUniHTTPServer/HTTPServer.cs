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

        public HTTPServer(string _ipAddress, int _port)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;

            serverListener = new TcpListener(ipAddress, port);
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
                string request = this.ReadRequest(networkStream);
                Console.WriteLine(request);
                WriteResponse(networkStream, "Hello World BBY");
                connection.Close();
            }
        }

        private static void WriteResponse(NetworkStream networkStream, string content)
        {

            int contentLength = Encoding.UTF8.GetByteCount(content);
            string response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";
            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes, 0, responseBytes.Length);
        }


        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];
            StringBuilder request = new StringBuilder();
            int totalBytes = 0;
            do
            {
                int bytesRead = networkStream.Read(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes>10*24)
                {
                    throw new InvalidOperationException("Request is too large");
                }     
                request.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (networkStream.DataAvailable);

            return request.ToString();
        }
    }
}
