using System;
using System.Collections.Generic;
using System.Text;

namespace THBAlbums.Models
{
    /// <summary>
    /// 获取专辑结果
    /// </summary>
    public class GetAlbumResult
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
        /// 专辑名称
        /// </summary>
        public string AlName { get; set; }

        /// <summary>
        /// 制作社团
        /// </summary>
        public string Circle { get; set; }

        /// <summary>
        /// 发售时间
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 发售年份
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// 展会
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 展会词条
        /// </summary>
        public string EventPage { get; set; }

        /// <summary>
        /// 分级
        /// </summary>
        public string Rate { get; set; }

        /// <summary>
        /// 专辑编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 专辑碟数
        /// </summary>
        public int Disc { get; set; }

        /// <summary>
        /// 专辑音轨数
        /// </summary>
        public int Track { get; set; }

        /// <summary>
        /// 专辑总时长（秒）
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 专辑类型
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// 专辑风格
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 专辑特定选材
        /// </summary>
        public string Only { get; set; }

        /// <summary>
        /// 发售价格
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 会场售价
        /// </summary>
        public string EventPrice { get; set; }

        /// <summary>
        /// 通贩售价
        /// </summary>
        public string ShopPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 官网页面
        /// </summary>
        public string Official { get; set; }

        /// <summary>
        /// 封面图片链接
        /// </summary>
        public string CoverUrl { get; set; }

        /// <summary>
        /// 封面角色
        /// </summary>
        public string CoverChar { get; set; }

        /// <summary>
        /// 曲目列表
        /// </summary>
        public List<GetTrackResult> Tracks { get; set; }
    }
}
