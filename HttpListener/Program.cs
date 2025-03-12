using System.Net;
using System.Text;

namespace HttpListenerExample
{
    class HttpServer
    {
        public static HttpListener listener;
        public static string url = "http://localhost:8000/";
        public static int viewCount = 0;
        public static int requestCount = 0;
        public static string pageData = 
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>HttpListener Example</title>" +
            "  </head>" +
            "  <body>" +
            "    <p>Page Views: {0}</p>" +
            "    <form method=\"post\" action=\"shutdown\">" +
            "      <input type=\"submit\" value=\"Shutdown\" {1}>" +
            "    </form>" +
            "  </body>" +
            "</html>";

        public static async Task HandleIncomingCalls()
        {
            bool runServer = true;
            while (runServer)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                
                Console.WriteLine("Request #: "+ ++requestCount);
                Console.WriteLine("Method: "+ request.HttpMethod);
                Console.WriteLine("Url: "+ request.Url.ToString());
                Console.WriteLine("userHostName: "+ request.UserHostName);
                Console.WriteLine("UserAgent: "+ request.UserAgent);
                Console.WriteLine("ProtocolVersion: "+ request.ProtocolVersion);
                Console.WriteLine("IsLocal: "+ request.IsLocal);
                
                if(request.Url.AbsolutePath == "/shutdown" && request.HttpMethod == "POST")
                {
                    Console.WriteLine("Shutdown requested");
                    runServer = false;
                }

                if (request.Url.AbsolutePath != "/favicon.ico" && request.Url.AbsolutePath != "/shutdown")
                {
                    viewCount++;
                }
                string disableSubmit = runServer ? "" : "disabled";
                byte[] data = Encoding.UTF8.GetBytes(string.Format(pageData, viewCount, disableSubmit));
                response.ContentType = "text/html";
                response.ContentLength64 = data.Length;
                
                await response.OutputStream.WriteAsync(data, 0, data.Length);
                response.Close();
            }
        }

        public static void Main()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Listening for connections on {0}", url);
            Task listenTask = HandleIncomingCalls();
            listenTask.GetAwaiter().GetResult();
            listener.Close();
        }
    }
}