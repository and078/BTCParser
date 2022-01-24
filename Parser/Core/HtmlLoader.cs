using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parser.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}";
            url = DeleteDoubleSlash(url);
        }

        private string DeleteDoubleSlash(string url)
        {
            if (url.Length < 8) return url;
            const int urlFirstPart = 8; // "https://"
            string firstPart = url.Remove(urlFirstPart);
            string lastPart = url.Substring(urlFirstPart);
            return firstPart + lastPart.Replace("//", "/");
        }

        public async Task<string> GetSourseByPageId(int id)
        { 
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
