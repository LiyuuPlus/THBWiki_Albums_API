using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using THBAlbums.Models;
using THBAlbums.Utils;

namespace THBAlbums
{
    /// <summary>
    /// THB专辑API查询类
    /// 来自：https://thwiki.cc/albumapi
    /// </summary>
    public class THBAPIQuery : THBAPI
    {
        /// <summary>
        /// 搜索专辑
        /// </summary>
        /// <param name="AlbumName">专辑名</param>
        /// <param name="limit">限制条目数</param>
        public List<SearchAlbumResult> SearchAlbum(string AlbumName, int limit = 10)
        {
            SetMode(THBApiDef.SEARCH_ALBUM);
            SetLimit(limit);
            SetReturn();
            SetSearchValue(AlbumName);
            var res = APIRequest();
            var json = res.ToJObject();
            var sarlist = new List<SearchAlbumResult>();
            if ((bool)json["status"])
            {
                var result = json["result"].ToJObject();
                foreach (var item in result)
                {
                    var value = item.Value;
                    var ja = value.ToJArray();
                    var sar = new SearchAlbumResult
                    {
                        SMWID = item.Key.ToInt(),
                        AlbumName = ja[0].ToStr(),
                        Circle = ja[1].ToStr()
                    };
                    sarlist.Add(sar);
                }
            }
            return sarlist;
        }

        /// <summary>
        /// 搜索曲目
        /// </summary>
        /// <param name="TrackName">曲目名称</param>
        public List<SearchTrackResult> SearchTrack(string TrackName)
        {
            SetMode(THBApiDef.SEARCH_TRACK);
            SetReturn();
            SetSearchValue(TrackName);
            var res = APIRequest();
            var json = res.ToJObject();
            var strlist = new List<SearchTrackResult>();
            if ((bool)json["status"])
            {
                var result = json["result"].ToJObject();
                foreach (var item in result)
                {
                    var value = item.Value;
                    var ja = value.ToJArray();
                    var str = new SearchTrackResult
                    {
                        SMWID = item.Key.ToInt(),
                        TrackName = ja[0].ToStr(),
                        Album = ja[1].ToStr()
                    };
                    strlist.Add(str);
                }
            }
            return strlist;
        }

        /// <summary>
        /// 获取专辑（名称、ID二选一）
        /// </summary>
        /// <param name="AlbumName">专辑名称</param>
        /// <param name="ID">专辑SMWID</param>
        /// <returns></returns>
        public GetAlbumResult GetAlbum(string AlbumName = "", string ID = "")
        {
            var gar = new GetAlbumResult();
            gar.ErrorCode = QueryError.NO_ERROR;
            gar.tracks = new List<GetTrackResult>();
            if (string.IsNullOrWhiteSpace(AlbumName) && string.IsNullOrWhiteSpace(ID))
            {
                gar.ErrorCode = QueryError.NO_KEY;
                gar.ErrorMsg = "未填写必要参数";
                return gar;
            }
            SetFormat(THBApiDef.ALBUMS_PROPERTYS);
            SetProperty(THBApiDef.TRACKS_PROPERTYS);
            SetMode(THBApiDef.GET_ALBUM);
            SetSplit("，");
            if (!string.IsNullOrWhiteSpace(ID))
            {
                SetAlbumID(ID);
            }
            else
            {
                SetAlbumTitle(AlbumName);
            }
            var res = APIRequest();
            var json = res.ToJObject();
            if ((bool)json["status"])
            {
                var result = json["result"].ToString().ToJArray();
                var album = result[0].ToJObject();
                gar.ParseFrom(album);
                var tracks = result[1].ToJObject();
                foreach (var item in tracks)
                {
                    var value = item.Value;
                    var jo = value.ToJObject();
                    var gtr = new GetTrackResult
                    {
                        SMWID = item.Key.ToInt()
                    };
                    gtr.ParseFrom(jo);
                    gar.tracks.Add(gtr);
                }
            }
            return gar;
        }

        /// <summary>
        /// 获取曲目
        /// </summary>
        /// <param name="ID">曲目SMWID列表</param>
        public void GetTrack(string ID)
        {
            SetMode(THBApiDef.GET_TRACK);
        }
    }
}
