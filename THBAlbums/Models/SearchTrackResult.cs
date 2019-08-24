using System;
using System.Collections.Generic;
using System.Text;

namespace THBAlbums.Models
{
    /// <summary>
    /// 搜索曲目结果
    /// </summary>
    public class SearchTrackResult
    {
        /// <summary>
        /// 曲目SMWID
        /// </summary>
        public int SMWID { get; set; }

        /// <summary>
        /// 曲目名称
        /// </summary>

        public string TrackName { get; set; }

        /// <summary>
        /// 专辑名称
        /// </summary>
        public string Album { get; set; }
    }
}
