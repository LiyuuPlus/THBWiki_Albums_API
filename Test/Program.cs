using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THBAlbums;
using THBAlbums.Models;

namespace Test
{
    class Program
    {
        static List<GetAlbumResult> albumList = new List<GetAlbumResult>();
        static Stopwatch asyncsw = new Stopwatch();
        static Stopwatch sw = new Stopwatch();
        static void Main(string[] args)
        {
            test();
            Asynctest();
            Console.ReadLine();
        }
        static void test()
        {
            sw.Start();
            var query = new THBAPIQuery();
            /*var res=query.SearchAlbum("缀");
            Console.WriteLine("专辑搜索测试：\n关键词：缀");
            Console.WriteLine("专辑名\t\t社团");
            foreach(var item in res)
            {
                Console.WriteLine($"{item.AlbumName}\t\t{item.Circle}");
            }
            Console.WriteLine("——————————————————");
            var res2 = query.SearchTrack("不思議の国のアリス");
            Console.WriteLine("曲目搜索测试：\n关键词：不思議の国のアリス");
            Console.WriteLine("曲目名\t\t\t专辑");
            foreach (var item in res2)
            {
                Console.WriteLine($"{item.TrackName}\t\t\t{item.Album}");
            }
            Console.WriteLine("——————————————————");
            var res3 = query.GetAlbum("綴");
            Console.WriteLine("专辑获取测试：\n关键词：缀");
            Console.WriteLine($"专辑名：{res3.alname}");
            Console.WriteLine($"制作社团：{res3.circle}");
            Console.WriteLine($"发售年份：{res3.year}");
            Console.WriteLine($"发售时间：{res3.date}");
            Console.WriteLine($"封面角色：{res3.coverchar}");
            Console.WriteLine("曲目碟号\t\t\t曲目音轨号\t\t曲目名\t\t\t艺术家\n原曲\t\t\t原曲来源\t\t\t时长");
            foreach (var item in res3.tracks)
            {
                Console.WriteLine($"{item.discno}\t\t\t{item.trackno}\t\t{item.name}\t\t\t{item.artist}\n{item.ogmusic}\t\t\t{item.ogwork}\t\t\t{item.time}");
            }*/
            string[] albums = { "Frozen Rainbow", "春酔い花唄", "月平線～Lunar Horizon", "东方舞夜祭", "東方怪綺談 ～ Mystic Square 全曲Win風アレンジ", "東方幻想郷 ～ Lotus Land Story 全曲Win風アレンジ", "東方夢時空 ～ Phantasmagoria of Dim.Dream 全曲Win風アレンジ", "旧巷夜谈～Acataleptic Akashic", "灵寄夜想～Mortal Leader", "少女と夢人形", "夢憶霊音", "永-TOKOSHIE", "永-TOWA", "Delusional Makai：Lotus Land Square", "ARCHIV-EAST", "蒼月の懺悔詩～Universal Nemesis", "決別の旅", "千ノ縁", "奏穹のラプソディア", "Mistera Festo", "現樂団の往古1​.​1 ～ 束方 廻怪綺談～", "東方紅輝心～Original Soundtrack～PS4改訂版", "幻想遊戯＜天＞", "詠蝶綻放Remix（白狐茶会）", "槐安心曲~Spiral of daydream", "改", "逆", "望", "綴", "天官风角秘盘", "羽衣清歌", "幻想桃源诗-七日狂想曲", "幻奏盛宴·幻想交响音乐会 ～ 流连的九河潮音 现场录音CD", "幻奏盛宴·幻想交响音乐会 ～ 七色的上海幻夜 现场录音CD", "あの日の夢のアリス DAY DREAM", "オーケストラ怪綺談", "東方夢想夏郷3 音樂全集", "東方神月譚", "Alice's Adventures in yhe Beloved Utopia", "夜桜に君を隠して", "玉響咲いた背後の永久", "綴れぬ森の少女", "墨染散華", "千秋一梦付长歌" };
            foreach (var album in albums)
            {
                var rr = query.GetAlbum(album);
                if (rr.ErrorCode == QueryError.NO_ERROR)
                {
                    Console.WriteLine($"专辑获取测试：\n关键词：{album}");
                    Console.WriteLine($"专辑名：{rr.AlName}");
                    Console.WriteLine($"制作社团：{rr.Circle}");
                    Console.WriteLine($"发售年份：{rr.Year}");
                    Console.WriteLine($"发售时间：{rr.Date}");
                    Console.WriteLine($"封面角色：{rr.CoverChar}");
                    /*Console.WriteLine("曲目音轨号\t\t曲目名\t\t\t艺术家\n原曲\t\t\t原曲来源\t\t\t时长");
                    foreach (var item in res4.Tracks)
                    {
                        Console.WriteLine($"{item.TrackNo}\t\t{item.Name}\t\t\t{item.Artist}\n{item.OGMusic}\t\t\t{item.OGWork}\t\t\t{item.Time}");
                    }*/
                    Console.WriteLine("——————————————————\n");
                }
            }
            sw.Stop();
        }
        static void Asynctest()
        {
            asyncsw.Start();
            var query = new THBAPIQuery();
            string[] albums = { "Frozen Rainbow", "春酔い花唄", "月平線～Lunar Horizon", "东方舞夜祭", "東方怪綺談 ～ Mystic Square 全曲Win風アレンジ", "東方幻想郷 ～ Lotus Land Story 全曲Win風アレンジ", "東方夢時空 ～ Phantasmagoria of Dim.Dream 全曲Win風アレンジ", "旧巷夜谈～Acataleptic Akashic", "灵寄夜想～Mortal Leader", "少女と夢人形", "夢憶霊音", "永-TOKOSHIE", "永-TOWA", "Delusional Makai：Lotus Land Square", "ARCHIV-EAST", "蒼月の懺悔詩～Universal Nemesis", "決別の旅", "千ノ縁", "奏穹のラプソディア", "Mistera Festo", "現樂団の往古1​.​1 ～ 束方 廻怪綺談～", "東方紅輝心～Original Soundtrack～PS4改訂版", "幻想遊戯＜天＞", "詠蝶綻放Remix（白狐茶会）", "槐安心曲~Spiral of daydream", "改", "逆", "望", "綴", "天官风角秘盘", "羽衣清歌", "幻想桃源诗-七日狂想曲", "幻奏盛宴·幻想交响音乐会 ～ 流连的九河潮音 现场录音CD", "幻奏盛宴·幻想交响音乐会 ～ 七色的上海幻夜 现场录音CD", "あの日の夢のアリス DAY DREAM", "オーケストラ怪綺談", "東方夢想夏郷3 音樂全集", "東方神月譚", "Alice's Adventures in yhe Beloved Utopia", "夜桜に君を隠して", "玉響咲いた背後の永久", "綴れぬ森の少女", "墨染散華", "千秋一梦付长歌" };
            var index = 0;
            foreach (var album in albums)
            {
                var res4 = query.GetAlbumAsync(album);
                _ = res4.ContinueWith(r =>
                  {
                      var rr = r.Result;
                      index++;
                      if (rr.ErrorCode == QueryError.NO_ERROR)
                      {
                          Console.WriteLine($"专辑获取测试：\n关键词：{album}");
                          Console.WriteLine($"专辑名：{rr.AlName}");
                          Console.WriteLine($"制作社团：{rr.Circle}");
                          Console.WriteLine($"发售年份：{rr.Year}");
                          Console.WriteLine($"发售时间：{rr.Date}");
                          Console.WriteLine($"封面角色：{rr.CoverChar}");
                          /*Console.WriteLine("曲目音轨号\t\t曲目名\t\t\t艺术家\n原曲\t\t\t原曲来源\t\t\t时长");
                          foreach (var item in rr.Tracks)
                          {
                              Console.WriteLine($"{item.TrackNo}\t\t{item.Name}\t\t\t{item.Artist}\n{item.OGMusic}\t\t\t{item.OGWork}\t\t\t{item.Time}");
                          }*/
                          //Console.WriteLine("——————————————————\n");
                          albumList.Add(rr);
                      }
                      Console.WriteLine(index);
                      if (index == albums.Length)
                      {
                          asyncsw.Stop();
                          Console.WriteLine($"sync:{sw.ElapsedMilliseconds}");
                          Console.WriteLine($"async:{asyncsw.ElapsedMilliseconds}");
                      }
                  });
            }
        }
    }
}
