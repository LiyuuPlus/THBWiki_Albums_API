using System;
using System.Collections.Generic;
using System.Text;

namespace THBAlbums.Models
{
    /// <summary>
    /// 搜索专辑结果
    /// </summary>
    public class SearchAlbumResult
    {
        /// <summary>
        /// 专辑SMWID
        /// </summary>
        public int SMWID { get; set; }

        /// <summary>
        /// 专辑名称
        /// </summary>

        public string AlbumName { get; set; }
        
        /// <summary>
        /// 社团名称
        /// </summary>
        public string Circle { get; set; }

    }
}
