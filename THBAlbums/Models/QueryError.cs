using System;
using System.Collections.Generic;
using System.Text;

namespace THBAlbums.Models
{
    /// <summary>
    /// 请求出错错误代码
    /// </summary>
    public class QueryError
    {
        /// <summary>
        /// 无错误
        /// </summary>
        public const int NO_ERROR = 0;

        /// <summary>
        /// 找不到专辑
        /// </summary>
        public const int NO_ALBUM = 1000;

        /// <summary>
        /// 找不到曲目
        /// </summary>
        public const int NO_TRACK = 1001;

        /// <summary>
        /// 未输入曲目ID
        /// </summary>
        public const int NO_TRACKID = 1002;

        /// <summary>
        /// 未输入参数
        /// </summary>
        public const int NO_KEY = 1003;
    }
}
