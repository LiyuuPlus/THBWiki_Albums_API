using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using THBAlbums.Utils;

namespace THBAlbums
{
    /// <summary>
    /// THB专辑API基类
    /// 来自：https://thwiki.cc/albumapi
    /// </summary>
    public class THBAPI
    {
        private const string APIUrl = "https://thwiki.cc/album.php";

        protected NameValueCollection Query { get; }

        public THBAPI()
        {
            Query = new NameValueCollection();
            //设置结果格式为键值格式
            Query["d"] = THBApiDef.KeyValue;
        }

        #region 通用
        /// <summary>
        /// 设置查询模式
        /// </summary>
        /// <param name="Mode">模式</param>
        protected void SetMode(string Mode)
        {
            switch (Mode)
            {
                case THBApiDef.SEARCH_ALBUM:
                case THBApiDef.SEARCH_TRACK:
                case THBApiDef.GET_ALBUM:
                case THBApiDef.GET_TRACK:
                    Query["m"] = Mode;
                    break;
            }
        }

        /// <summary>
        /// 设置gzip压缩等级
        /// </summary>
        /// <param name="Level">压缩等级</param>
        protected void SetGzip(int Level)
        {
            Query["g"] = Level.ToString();
        }

        /// <summary>
        /// 发起请求
        /// </summary>
        /// <returns></returns>
        protected JObject APIRequest()
        {
            var json = new JObject();
            var res = Util.HttpGet(APIUrl, Query);
            if (string.IsNullOrWhiteSpace(res))
            {
                json["status"] = false;
                json["msg"] = "request error";
            }
            else if (res.Contains("https://thwiki.cc/albumapi"))
            {
                json["status"] = false;
                json["msg"] = res;
            }
            else
            {
                json["status"] = true;
                json["result"] = res;
            }
            return json;
        }

        /// <summary>
        /// 异步发起请求
        /// </summary>
        /// <returns></returns>
        protected async Task<JObject> APIRequestAsync()
        {
            var json = new JObject();
            var res = await Util.HttpGetAsync(APIUrl, Query);
            if (string.IsNullOrWhiteSpace(res))
            {
                json["status"] = false;
                json["msg"] = "request error";
            }
            else if (res.Contains("https://thwiki.cc/albumapi"))
            {
                json["status"] = false;
                json["msg"] = res;
            }
            else
            {
                json["status"] = true;
                json["result"] = res;
            }
            return json;
        }
        #endregion

        #region 搜索
        /// <summary>
        /// 设置搜索关键字（仅搜索类方法使用）
        /// </summary>
        /// <param name="Value">搜索关键字</param>
        protected void SetSearchValue(string Value)
        {
            Query["v"] = Value;
        }

        /// <summary>
        /// 设置返回社团名/专辑名（仅搜索类方法使用）
        /// </summary>
        protected void SetReturn()
        {
            Query["o"] = "1";
        }
        #endregion

        #region 搜索专辑
        /// <summary>
        /// 设置限制条目数（仅搜索专辑使用）
        /// </summary>
        /// <param name="Limit">限制数量</param>
        protected void SetLimit(int Limit = 10)
        {
            Query["l"] = Limit.ToString();
        }
        #endregion

        #region 获取
        /// <summary>
        /// 设置曲目属性（仅获取类方法使用）
        /// </summary>
        /// <param name="Propertys">曲目属性</param>
        public void SetProperty(string[] Propertys)
        {
            Query["p"] = Propertys.ToString("+");
        }

        /// <summary>
        /// 设置多值分隔符（仅获取类方法使用）
        /// </summary>
        /// <param name="Split">分隔符</param>
        public void SetSplit(string Split)
        {
            Query["s"] = Split;
        }
        #endregion

        #region 获取专辑
        /// <summary>
        /// 设置专辑属性（仅获取专辑使用）
        /// </summary>
        /// <param name="Propertys">专辑属性</param>
        public void SetFormat(string[] Propertys)
        {
            Query["f"] = Propertys.ToString("+");
        }

        /// <summary>
        /// 设置专辑SMWID（仅获取专辑使用）
        /// </summary>
        /// <param name="ID">专辑SMWID</param>
        public void SetAlbumID(string ID)
        {
            Query["a"] = ID;
        }

        /// <summary>
        /// 设置专辑词条名（仅获取专辑使用）
        /// </summary>
        /// <param name="Title">专辑词条名</param>
        public void SetAlbumTitle(string Title)
        {
            Query["t"] = Title;
        }
        #endregion

        #region 获取曲目
        /// <summary>
        /// 设置获取曲目的SMWID列表（仅获取曲目使用）
        /// </summary>
        /// <param name="ID">曲目SMWID列表</param>
        public void SetTrackIDs(string ID)
        {
            Query["i"] = ID;
        }
        #endregion
    }
}
