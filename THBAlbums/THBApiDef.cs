using System;
using System.Collections.Generic;
using System.Text;

namespace THBAlbums
{
    /// <summary>
    /// THBAPI定义类，用于定义部分参数
    /// </summary>
    public static class THBApiDef
    {
        #region 查询模式
        /// <summary>
        /// 搜索专辑
        /// </summary>
        public const string SEARCH_ALBUM = "sa";

        /// <summary>
        /// 搜索曲目
        /// </summary>
        public const string SEARCH_TRACK = "st";


        /// <summary>
        /// 获得专辑
        /// </summary>
        public const string GET_ALBUM = "ga";

        /// <summary>
        /// 获得曲目
        /// </summary>
        public const string GET_TRACK = "gt";
        #endregion

        #region 结果格式
        /// <summary>
        /// 一般格式
        /// </summary>
        //public const string NormalA = "nm";

        /// <summary>
        /// 一般格式（SMWID放置最后）
        /// </summary>
        //public const string NormalB = "nr";

        /// <summary>
        /// 键值格式
        /// </summary>
        public const string KeyValue = "kv";

        /// <summary>
        /// 平行格式
        /// </summary>
        //public const string ParallelA = "pa";

        /// <summary>
        /// 平行格式（SMWID放置最后）
        /// </summary>
        //public const string ParallelB = "pr";
        #endregion

        #region 属性定义
        /// <summary>
        /// 专辑属性
        /// </summary>
        public static string[] ALBUMS_PROPERTYS = { "alname", "event", "eventpage", "circle", "date", "rate", "number", "disc", "track", "time", "property", "style", "only", "price", "eventprice", "shopprice", "note", "official", "coverurl", "coverchar","year"};

        /// <summary>
        /// 曲目属性
        /// </summary>
        public static string[] TRACKS_PROPERTYS = { "name", "discno", "trackno", "circle", "type", "time", "ogmusic", "ogwork", "artist", "lrc" };
        #endregion

    }
}
