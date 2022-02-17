﻿using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SoftUniHTTPServer.HTTP
{
    public class Request
    {
        public Method Method { get;private set; }

        public string Url { get;private set; }

        public HeaderCollection Headers { get;private set; }

        public string Body { get; set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");
            var firstLine = lines
                .First()
                .Split(" ");
            
            var url = firstLine[1];
            Method method = ParseMethod(firstLine[0]);
            var headers = ParseHeaders(lines.Skip(1));
            var bodyLines = lines.Skip(headers.Count+2).ToArray();
            var body = string.Join("\r\n", bodyLines);
            var form = ParseForm(headers, body);

            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body,
                Form = form
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> lines)
        {
            var headers = new HeaderCollection();  
            foreach (var line in lines)
            {
                if (line == String.Empty)
                {
                    break;
                }
                var parts = line.Split(':', 2);

                if(parts.Length != 2)
                {
                    throw new InvalidOperationException("Request header's invalid");
                    
                }
                headers.Add(parts[0], parts[1].Trim());
            }
            return headers;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method),method,true);
            }
            catch (Exception)
            {

                throw new InvalidOperationException($"Method {method} is not supported");
            }
        }

        private static Dictionary<string,string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string,string>();
            if (headers.Contains(Header.ContentType)&&headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }
            return formCollection;
        }

        private static Dictionary<string,string> ParseFormData(string bodyLines)
            => HttpUtility.UrlDecode(bodyLines)
            .Split('&')
            .Select(part => part.Split('='))
            .Where(part=>part.Length == 2)
            .ToDictionary(
                part=> part[0],
                part=> part[1],
                StringComparer.InvariantCultureIgnoreCase);
    }
}
