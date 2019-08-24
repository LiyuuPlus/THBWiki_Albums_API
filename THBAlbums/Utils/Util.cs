using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace THBAlbums.Utils
{
    public static class Util
    {
        /// <summary>
        /// 请求一个地址，并获得结果
        /// </summary>
        /// <param name="reqUrl">请求地址</param>
        /// <param name="Query">请求参数</param>
        /// <param name="encoding">编码</param>
        /// <param name="Req">附加请求</param>
        /// <returns></returns>
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
                Req = new NameValueCollection();
                wc.Headers["Accpet"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                //wc.Headers["UserAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36";
                wc.Headers["UserAgent"] = Req["UserAgent"] ?? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) THBAlbumsAPI/1.0";
            }
            wc.QueryString = Query;
            try
            {
                var res = wc.DownloadData(reqUrl);
                result = DeUnicode(encoding.GetString(res));
            }
            catch
            {
                return "";
            }
            return result;
        }

        /// <summary>
        /// 异步请求一个地址，并获得结果
        /// </summary>
        /// <param name="reqUrl">请求地址</param>
        /// <param name="Query">请求参数</param>
        /// <param name="encoding">编码</param>
        /// <param name="Req">附加请求</param>
        /// <returns></returns>

        public static async Task<string> HttpGetAsync(string reqUrl, NameValueCollection Query = null, Encoding encoding = null, NameValueCollection Req = null)
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
                var res = await wc.DownloadDataTaskAsync(reqUrl);
                result = DeUnicode(encoding.GetString(res));
            }
            catch
            {
                return "";
            }
            return result;
        }

        /// <summary>
        /// Unicode解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DeUnicode(string str)
        {
            var reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
            return reg.Replace(str, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        }
    }
}
