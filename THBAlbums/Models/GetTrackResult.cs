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
        public string Name { get; set; }

        /// <summary>
        /// 制作社团
        /// </summary>
        public string Circle { get; set; }

        /// <summary>
        /// 曲目碟号
        /// </summary>
        public int DiscNo { get; set; }

        /// <summary>
        /// 曲目音轨号
        /// </summary>
        public int TrackNo { get; set; }

        /// <summary>
        /// 艺术家
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// 曲目原曲列表
        /// </summary>
        public string OGMusic { get; set; }

        /// <summary>
        /// 曲目来源
        /// </summary>
        public string OGWork { get; set; }

        /// <summary>
        /// 歌词地址（原文）
        /// </summary>
        public string Lrc { get; set; }

        /// <summary>
        /// 歌词地址（译文）
        /// </summary>
        public string TranLrc { get; set; }

        /// <summary>
        /// 歌词地址（双语对照）
        /// </summary>
        public string AllLrc { get; set; }

        /// <summary>
        /// 曲目类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 曲目时长（秒）
        /// </summary>
        public int Time { get; set; }
    }
}
