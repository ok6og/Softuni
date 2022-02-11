﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniHTTPServer.HTTP
{
    public class Response
    {
        public StatusCode StatusCode { get; init; }
        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
            Headers.Add("Server", "SoftUni Server");
            Headers.Add("Date", $"{DateTime.UtcNow:R}");
        }
    }
}
