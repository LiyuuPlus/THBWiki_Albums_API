using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;

namespace THBAlbums.Utils
{
    public static class ExtMethod
    {
        #region 转换扩展
        /// <summary>
        /// object数组转换为字符串
        /// </summary>
        /// <param name="obj">待转换数字数组</param>
        /// <param name="split">分割字符</param>
        /// <returns>转换后的字符串</returns>
        public static string ToString(this object[] obj, string split)
        {
            var str = "";
            for (var i = 0; i < obj.Length; i++)
            {
                str += string.Format("{0}{1}", obj[i], (i < obj.Length - 1) ? split : "");
            }
            return str;
        }

        /// <summary>
        /// int数组转换为字符串
        /// </summary>
        /// <param name="obj">待转换数字数组</param>
        /// <param name="split">分割字符</param>
        /// <returns>转换后的字符串</returns>
        public static string ToString(this int[] obj, string split)
        {
            var str = "";
            for (var i = 0; i < obj.Length; i++)
            {
                str += string.Format("{0}{1}", obj[i], (i < obj.Length - 1) ? split : "");
            }
            return str;
        }

        public static string ToString(this Hashtable obj, string split)
        {
            var str = "";
            var index = 0;
            foreach (DictionaryEntry v in obj)
            {
                str += string.Format("{0}={1}{2}", v.Key, v.Value, (index < obj.Count - 1) ? split : "");
                index++;
            }
            return str;
        }

        public static string ToString(this ICollection obj, string split)
        {
            var str = "";
            var index = 0;
            foreach (var v in obj)
            {
                var t = v;
                if (v is Enum)
                {
                    t = ((int)v).ToStr();
                }
                str += string.Format("{0}{1}", t, (index < obj.Count - 1) ? split : "");
                index++;
            }
            return str;
        }

        public static string ToString(this NameValueCollection obj, string split)
        {
            var str = "";
            var index = 0;
            foreach (var v in obj.Keys)
            {
                str += string.Format("{0}={1}{2}", v, obj[v.ToStr()], (index < obj.Count - 1) ? split : "");
                index++;
            }
            return str;
        }

        public static string ToString(this JArray obj, string split)
        {
            var str = "";
            var index = 0;
            foreach (var v in obj)
            {
                str += string.Format("{0}{1}", v, (index < obj.Count - 1) ? split : "");
                index++;
            }
            return str;
        }

        public static string ToString(this JArray obj, string split, string key)
        {
            var str = "";
            var index = 0;
            foreach (var v in obj)
            {
                str += string.Format("{0}{1}", v[key], (index < obj.Count - 1) ? split : "");
                index++;
            }
            return str;
        }

        public static string ToStr(this object obj, string def = "")
        {
            try
            {
                return obj.ToString();
            }
            catch
            {
                return def;
            }
        }
        /// <summary>
        /// 字符串转换int
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <param name="fail">失败后返回的数字</param>
        /// <returns>转换后的int类型的数字</returns>
        public static int ToInt(this object num, int fail = 0)
        {
            var res = 0;
            return int.TryParse(num.ToStr(), out res) ? res : fail;
        }

        /// <summary>
        /// 字符串转换float
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <param name="fail">失败后返回的数字</param>
        /// <returns>转换后的Double类型的数字</returns>
        public static float ToFloat(this object num, float fail = 0)
        {
            float res = 0;
            return float.TryParse(num.ToStr(), out res) ? res : fail;
        }

        /// <summary>
        /// 字符串转换double
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <param name="fail">失败后返回的数字</param>
        /// <returns>转换后的Double类型的数字</returns>
        public static double ToDouble(this object num, double fail = 0.0)
        {
            var res = 0.0;
            return double.TryParse(num.ToStr(), out res) ? res : fail;
        }

        /// <summary>
        /// 字符串转换long
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <param name="fail">失败后返回的数字</param>
        /// <returns>转换后的long类型的数字</returns>
        public static long ToLong(this object num, long fail = 0)
        {
            long res = 0;
            return long.TryParse(num.ToStr(), out res) ? res : fail;
        }

        /// <summary>
        /// 字符串转换decimal
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <param name="fail">失败后返回的数字</param>
        /// <returns>转换后的long类型的数字</returns>
        public static decimal ToDecimal(this object num, decimal fail = 0)
        {
            decimal res = 0;
            return decimal.TryParse(num.ToStr(), out res) ? res : fail;
        }

        /// <summary>
        /// 指定时间转换为Unix时间
        /// </summary>
        /// <param name="time">需要转换的时间</param>
        /// <returns>转换后的Unix时间</returns>
        public static string ToUnixTime(this DateTime time)
        {
            var t = (time.Ticks - TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0), TimeZoneInfo.Local).Ticks) / 10000000;
            return t.ToString();
        }

        /// <summary>
        /// 转换Json字符串
        /// </summary>
        /// <param name="obj">需要转换的对象</param>
        /// <returns></returns>
        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        #endregion

        #region 过滤扩展
        /// <summary>
        /// Json对象过滤
        /// </summary>
        /// <param name="json">Json对象</param>
        /// <param name="fkey">属性</param>
        /// <returns></returns>
        public static JObject Filter(this JObject json, string[] fkey)
        {
            foreach (var key in fkey)
            {
                json.Remove(key);
            }
            return json;
        }

        /// <summary>
        /// Json数组过滤
        /// </summary>
        /// <param name="jarray">Json数组</param>
        /// <param name="fkey">属性</param>
        /// <returns></returns>
        public static JArray Filter(this JArray jarray, string[] fkey)
        {
            foreach (JObject json in jarray)
            {
                json.Filter(fkey);
            }
            return jarray;
        }
        #endregion

        #region Json对象扩展

        /// <summary>
        /// 对当前JObject对象进行转换成目标对象
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="obj">JObject对象</param>
        /// <param name="newobj">目标对象</param>
        /// <param name="filtter">过滤属性</param>
        /// <returns></returns>
        public static T ParseTo<T>(this JObject obj, T newobj, string[] filtter = null)
        {
            foreach (var p in obj)
            {
                var name = p.Key;
                var value = p.Value;
                var np = newobj.GetType().GetProperty(name);
                if (np != null)
                {
                    var PropertyType = np.PropertyType;
                    if (filtter == null || filtter.SingleOrDefault(f => f.Contains(name)) == null)
                    {
                        np.SetValue(newobj, Convert.ChangeType(value, np.PropertyType));
                    }
                }
            }
            return newobj;
        }

        /// <summary>
        /// 将JObject对象进行转换成当前类型对象
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="obj">JObject对象</param>
        /// <param name="newobj">当前对象</param>
        /// <param name="filtter">过滤属性</param>
        public static void ParseFrom<T>(this T newobj,JObject obj,string[] filtter=null)
        {
            foreach (var p in obj)
            {
                var name = p.Key;
                var value = p.Value;
                var np = newobj.GetType().GetProperty(name);
                if (np != null)
                {
                    var PropertyType = np.PropertyType;
                    if (filtter == null || filtter.SingleOrDefault(f => f.Contains(name)) == null)
                    {
                        np.SetValue(newobj, Convert.ChangeType(value, np.PropertyType));
                    }
                }
            }
        }

        /// <summary>
        /// 判断是否缺少指定Key
        /// </summary>
        /// <param name="json"></param>
        /// <param name="fkey"></param>
        /// <returns></returns>
        public static bool IsNull(this JObject json, string[] fkey)
        {
            foreach (var key in fkey)
            {
                if (!json.ContainsKey(key))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断是否缺少指定Key
        /// </summary>
        /// <param name="json"></param>
        /// <param name="fkey"></param>
        /// <param name="misskey">缺失的key</param>
        /// <returns></returns>
        public static bool IsNull(this JObject json, string[] fkey, ref string misskey)
        {
            foreach (var key in fkey)
            {
                if (!json.ContainsKey(key))
                {
                    misskey = key;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 对象转JObject对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static JObject ToJObject(this object obj)
        {
            string t;
            if (obj is string||obj is JObject||obj is JToken)
            {
                t = obj.ToString();
            }
            else
            {
                t = obj.ToJsonString();
            }
            return JObject.Parse(t);
        }

        /// <summary>
        /// 对象转JArray对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static JArray ToJArray(this object obj)
        {
            string t;
            try
            {
                if (obj is string)
                {
                    t = obj.ToString();
                }
                else
                {
                    t = obj.ToJsonString();
                }
                return JArray.Parse(t);
            }
            catch
            {
                return new JArray();
            }
        }
        #endregion

        /// <summary>
        /// 将Unix时间转换为DateTime类型时间，失败返回1970-01-01
        /// </summary>
        /// <param name="UnixTime">Unix时间长整数</param>
        /// <returns></returns>
        public static DateTime UnixTimeToDateTime(long UnixTime)
        {
            DateTime ntime;
            try
            {
                ntime = new DateTime(1970, 1, 1, 0, 0, 0).AddTicks(UnixTime * 10000000);
            }
            catch
            {
                ntime = new DateTime(1970, 1, 1, 0, 0, 0);
            }
            return ntime;
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string BuildRandStr()
        {
            var g = Guid.NewGuid();
            var GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

        /// <summary>
        /// 比较A数组元素是否存在于B数组中
        /// </summary>
        /// <param name="arra"></param>
        /// <param name="arrb"></param>
        /// <returns></returns>
        public static bool InArray(long[] arra, long[] arrb)
        {
            return arra.Where(x => arrb.Where(y => x == y).Count() > 0).Count() > 0;
        }
    }
}
