using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace THBAlbums
{
    public static class Util
    {
        public static string HttpGet(string reqUrl, NameValueCollection Query = null, Encoding encoding = null, NameValueCollection Req = null)
        {
            var result = "";
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var wc = new WebClient();
            if (Req != null)
            {
                wc.Headers["Content-Type"] = Req["Content-Type"];
                wc.Headers["Accpet"] = Req["Accpet"] ?? "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                //wc.Headers["UserAgent"] = Req["UserAgent"] ?? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36";
                wc.Headers["UserAgent"] = Req["UserAgent"] ?? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) THBAlbumsAPI/1.0";
            }
            else
            {
                wc.Headers["Accpet"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                //wc.Headers["UserAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36";
                wc.Headers["UserAgent"] = Req["UserAgent"] ?? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) THBAlbumsAPI/1.0";
            }
            wc.QueryString = Query;
            try
            {
                var res = wc.DownloadData(reqUrl);
                result = encoding.GetString(res);
            }
            catch
            {
                return "";
            }
            return result;
        }
    }
}
