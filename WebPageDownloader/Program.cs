namespace HttpClientExample
{
    class Downloader
    {
        public static string urlToDownload = "http://localhost:8000/";
        public static string fileName = "httpListener.html";

        public static async Task DownloadWebPage()
        {
            Console.WriteLine("Starting download..");
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage resp = await httpClient.GetAsync(urlToDownload);

            if (resp.IsSuccessStatusCode)
            {
                Console.WriteLine("Download successful!");
                byte[] data = await resp.Content.ReadAsByteArrayAsync();
                FileStream myFileStream = File.Create(fileName);
                myFileStream.Write(data, 0, data.Length);
                myFileStream.Close();
                Console.WriteLine("Saved in file: " + fileName);
            }

        }

        public static void Main()
        {
            Task dlTask = DownloadWebPage();
            Console.WriteLine("Wait for the web page to download..");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dlTask.GetAwaiter().GetResult();
        }
    }
    
}