using System;
using System.Collections.Generic;
using System.Text;

namespace THBAlbums
{
    public static class THBApiDef
    {
        #region 查询模式
        /// <summary>
        /// 搜索专辑
        /// </summary>
        public static readonly string SEARCH_ALBUMS = "sa";

        /// <summary>
        /// 搜索曲目
        /// </summary>
        public static readonly string SEARCH_TRACKS = "st";


        /// <summary>
        /// 获得专辑
        /// </summary>
        public static readonly string GET_ALBUM = "ga";

        /// <summary>
        /// 获得曲目
        /// </summary>
        public static readonly string GET_TRACK = "gt";
        #endregion

        #region 结果格式
        /// <summary>
        /// 一般格式
        /// </summary>
        //public static readonly string NormalA = "nm";

        /// <summary>
        /// 一般格式（SMWID放置最后）
        /// </summary>
        //public static readonly string NormalB = "nr";

        /// <summary>
        /// 键值模式
        /// </summary>
        public static readonly string KeyValue = "kv";

        /// <summary>
        /// 平行格式
        /// </summary>
        //public static readonly string ParallelA = "pa";

        /// <summary>
        /// 平行格式（SMWID放置最后）
        /// </summary>
        //public static readonly string ParallelB = "pr";
        #endregion
    }
}
