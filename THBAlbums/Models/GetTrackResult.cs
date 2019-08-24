using System;
using System.Collections.Generic;
using System.Text;

namespace THBAlbums.Models
{
    /// <summary>
    /// 获取曲目结果
    /// </summary>
    public class GetTrackResult
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 曲目SMWID
        /// </summary>
        public int SMWID { get; set; }

        /// <summary>
        /// 曲目名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 制作社团
        /// </summary>
        public string circle { get; set; }

        /// <summary>
        /// 曲目碟号
        /// </summary>
        public int discno { get; set; }

        /// <summary>
        /// 曲目音轨号
        /// </summary>
        public int trackno { get; set; }

        /// <summary>
        /// 艺术家
        /// </summary>
        public string artist { get; set; }

        /// <summary>
        /// 曲目原曲列表
        /// </summary>
        public string ogmusic { get; set; }

        /// <summary>
        /// 曲目来源
        /// </summary>
        public string ogwork { get; set; }

        /// <summary>
        /// 歌词地址
        /// </summary>
        public string lrc { get; set; }

        /// <summary>
        /// 曲目类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 曲目时长（秒）
        /// </summary>
        public int time { get; set; }
    }
}
