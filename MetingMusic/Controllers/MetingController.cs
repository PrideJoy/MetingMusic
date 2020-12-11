using MetingMusic.Models.Standard;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MetingMusic.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class MetingController : Controller
    {
        
        Meting API = new Meting();
        const bool HTTPS = false; // 如果您的网站启用了https，请将此项置为“true”，如果你的网站未启用 https，建议将此项设置为“false”
        bool NO_HTTPS = false;
    

        [HttpPost]
        public ActionResult MusicApi()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            HttpContext.Request.Params.CopyTo(dic);
            string types = getParam("types", dic);
            string netease_cookie = "";
            string source = getParam("source", dic, "Netease");
            API.Server = Enum.IsDefined(typeof(ServerProvider), source) ? (ServerProvider)Enum.Parse(typeof(ServerProvider), source) : ServerProvider.Netease;
            if (source == "kugou" || source == "baidu")
            {
                //define("NO_HTTPS", true);        // 酷狗和百度音乐源暂不支持 https
                NO_HTTPS = true;
            }
            else if ((source == "netease") && netease_cookie != "")
            {
                API.Cookie(netease_cookie);    // 解决网易云 Cookie 失效
            }
            API.TryCount = 10;
            string id = getParam("id", dic);
            string data;

            switch (types)
            {
                case "url":
                    do
                    {
                        data = API.Url(id);
                    } while (string.IsNullOrEmpty(data));
                    EchoJson(data, dic);
                    break;
                case "pic":
                    do
                    {
                        data = API.Pic(id);
                    } while (string.IsNullOrEmpty(data));
                    EchoJson(data, dic);
                    break;
                case "lyric":
                    do
                    {
                        data = API.Lyric(id);
                    } while (string.IsNullOrEmpty(data));
                    EchoJson(data, dic);
                    break;
                case "download":
                    data = "location:" + getParam("url", dic);
                    EchoJson(data, dic);
                    break;
                case "userlist":
                    string uid = getParam("uid", dic);
                    string url = "http://music.163.com/api/user/playlist/?offset=0&limit=1001&uid=" + uid;
                    data = "";
                    EchoJson(data, dic);
                    break;
                case "playlist":
                    //API.Format = false;
                    do
                    {
                        data = API.Playlist(id);
                    } while (string.IsNullOrEmpty(data));
                    EchoJson(data, dic);
                    break;
                case "search":
                    Options options = new Options();
                    string sing = getParam("name", dic);  // 歌名
                    options.limit = int.Parse(getParam("count", dic, "20"));  // 每页显示数量
                    options.page = int.Parse(getParam("pages", dic, "1"));  // 页码
                    do
                    {
                        data = API.Search(sing, options);
                    } while (string.IsNullOrEmpty(data));
                    EchoJson(data, dic);
                    break;
                default:
                    data = "错误指令！！";
                    EchoJson(data, dic);
                    break;
            }
            //data = EchoJson(data, dic);
            return Json(data, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Song(string id)
        {
            Meting API = new Meting();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            HttpContext.Request.Params.CopyTo(dic);
            var data = API.Url(id);
            //string.IsNullOrEmpty(data);
            EchoJson(data, dic);

            return Json(replacedata(data), JsonRequestBehavior.AllowGet);
        }



        public string replacedata(string  data)
        {
            data.Replace("\\", "");
            data.TrimStart('"');
            data.TrimEnd('"');

            return data;

        }


        /// <summary>
        /// 两个方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="RouteDataValues"></param>
        /// <param name="defaults"></param>
        /// <returns></returns>
        public string getParam(string key, Dictionary<string, object> RouteDataValues, string defaults = "")
        {
           
            return (key is string ? (RouteDataValues.ContainsKey(key) ? RouteDataValues[key] : defaults) : defaults).ToString().Trim();
        
        }

        public string EchoJson(string data, Dictionary<string, object> RouteDataValues) //json和jsonp通用
        {
            string callback = getParam("callback", RouteDataValues);
            if (callback!=null)
            {
                data = Server.HtmlEncode(callback) + "(" + data + ")";
            }
            if (HTTPS == true && !NO_HTTPS)// 替换链接为 https
            {
                data.Replace(@"http:\/\/", @"https:\/\/");
                data.Replace("http://", "https://");
            }
            return data;
            //return null;
            //if (callback=="true")
            //{
                
            //}
        }

        //获取歌曲的url
        public ActionResult GetTaskList(string id )
        {
            //var access = "";
            var data = API.Url(id);
           // EchoJson(data)
            return Content(data);
        }
    }
}
