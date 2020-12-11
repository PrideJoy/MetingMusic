using MetingMusic.Models.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetingMusic.Controllers
{
    public class MusicController : Controller
    {
        //
        // GET: /Music/

        public ActionResult Index()
        {
            return View();
        }

       


        #region 搜索歌曲
        /// <summary>
        /// 搜索歌曲
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="options"></param>
        /// <returns>返回json字符串</returns>
        //public  ActionResult Search(string keyword, Options options = null)
        //{


        //    return Json(data, JsonRequestBehavior.AllowGet); ;
        //}

        #endregion

        #region 根据歌曲ID获取
        /// <summary>
        /// 根据歌曲ID获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回json字符串</returns>
        public ActionResult  Song(string id)
        {
            Meting API = new Meting();

            var  data = API.Url(id);
            //string.IsNullOrEmpty(data);
            //             EchoJson(data, dic);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //#region 根据专辑ID获取
        ///// <summary>
        ///// 根据专辑ID获取
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>返回json字符串</returns>
        //public virtual string Album(string id)
        //{
        //    Music_api api = null;
        //    switch (this.Server)
        //    {
        //        case ServerProvider.Netease:
        //            api = new Music_api
        //            {
        //                method = "POST",
        //                url = "http://music.163.com/api/v1/album/" + id,
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    total = "true",
        //                    offset = "0",
        //                    id = id,
        //                    limit = "1000",
        //                    ext = "true",
        //                    private_cloud = "true"
        //                }),
        //                encode = Netease_AESCBC,
        //                format = "songs"
        //            };
        //            break;
        //        case ServerProvider.Tencent:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://c.y.qq.com/v8/fcg-bin/fcg_v8_album_detail_cp.fcg",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    albummid = id,
        //                    platform = "mac",
        //                    format = "json",
        //                    newsong = 1
        //                }),
        //                format = "data.getSongInfo"
        //            };
        //            break;
        //        case ServerProvider.Kugou:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://mobilecdn.kugou.com/api/v3/album/song",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    albumid = id,
        //                    area_code = 1,
        //                    plat = 2,
        //                    page = 1,
        //                    pagesize = -1,
        //                    version = 8990
        //                }),
        //                format = "data.info"
        //            };
        //            break;
        //        case ServerProvider.Xiami:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://acs.m.xiami.com/h5/mtop.alimusic.music.albumservice.getalbumdetail/1.0/",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    data = new JObject
        //                    {
        //                        { "albumId", id }
        //                    },
        //                    r = "mtop.alimusic.music.albumservice.getalbumdetail"
        //                }),
        //                encode = Xiami_sign,
        //                format = "data.data.albumDetail.songs"
        //            };
        //            break;
        //        case ServerProvider.Baidu:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://musicapi.taihe.com/v1/restserver/ting",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    from = "qianqianmini",
        //                    method = "baidu.ting.album.getAlbumInfo",
        //                    album_id = id,
        //                    platform = "darwin",
        //                    version = "11.2.1"
        //                }),
        //                format = "songlist"
        //            };
        //            break;
        //    }

        //    return this.Exec(api);
        //}

        ///// <summary>
        ///// 根据专辑ID获取
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>返回实体对象</returns>
        //public Music_search_item[] AlbumObj(string id)
        //{
        //    bool tempFormat = this.Format;
        //    this.Format = true;
        //    string jsonStr = Album(id);
        //    Music_search_item[] rtn = MetingTool.MusicJson2Obj(jsonStr);
        //    this.Format = tempFormat;

        //    return rtn;
        //}
        //#endregion

        //#region 根据作家ID获取
        ///// <summary>
        ///// 根据作家ID获取
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="limit"></param>
        ///// <returns>返回json字符串</returns>
        //public virtual string Artist(string id, int limit = 50)
        //{
        //    Music_api api = null;
        //    switch (this.Server)
        //    {
        //        case ServerProvider.Netease:
        //            api = new Music_api
        //            {
        //                method = "POST",
        //                url = "http://music.163.com/api/v1/artist/" + id,
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    ext = "true",
        //                    private_cloud = "true",
        //                    top = limit,
        //                    id = id
        //                }),
        //                encode = Netease_AESCBC,
        //                format = "hotSongs"
        //            };
        //            break;
        //        case ServerProvider.Tencent:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://c.y.qq.com/v8/fcg-bin/fcg_v8_singer_track_cp.fcg",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    singermid = id,
        //                    begin = 0,
        //                    num = limit,
        //                    order = "listen",
        //                    platform = "mac",
        //                    newsong = 1
        //                }),
        //                format = "data.list"
        //            };
        //            break;
        //        case ServerProvider.Kugou:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://mobilecdn.kugou.com/api/v3/singer/song",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    singerid = id,
        //                    area_code = 1,
        //                    page = 1,
        //                    plat = 0,
        //                    pagesize = limit,
        //                    version = 8990
        //                }),
        //                format = "data.info"
        //            };
        //            break;
        //        case ServerProvider.Xiami:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://acs.m.xiami.com/h5/mtop.alimusic.music.songservice.getartistsongs/1.0/",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    data = new JObject
        //                    {
        //                        { "artistId", id },
        //                        { "pagingVO", new JObject
        //                        {
        //                            { "page", 1 },
        //                            { "pageSize", limit }
        //                        } }
        //                    },
        //                    r = "mtop.alimusic.music.songservice.getartistsongs"
        //                }),
        //                encode = Xiami_sign,
        //                format = "data.data.songs"
        //            };
        //            break;
        //        case ServerProvider.Baidu:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://musicapi.taihe.com/v1/restserver/ting",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    from = "qianqianmini",
        //                    method = "baidu.ting.artist.getSongList",
        //                    artistid = id,
        //                    limits = limit,
        //                    platform = "darwin",
        //                    offset = 0,
        //                    tinguid = 0,
        //                    version = "11.2.1"
        //                }),
        //                format = "songlist"
        //            };
        //            break;
        //    }

        //    return this.Exec(api);
        //}

        ///// <summary>
        ///// 根据作家ID获取
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="limit"></param>
        ///// <returns>返回实体对象</returns>
        //public Music_search_item[] ArtistObj(string id, int limit = 50)
        //{
        //    bool tempFormat = this.Format;
        //    this.Format = true;
        //    string jsonStr = Artist(id, limit);
        //    Music_search_item[] rtn = MetingTool.MusicJson2Obj(jsonStr);
        //    this.Format = tempFormat;

        //    return rtn;
        //}
        //#endregion

        //#region 根据歌单ID获取
        ///// <summary>
        ///// 根据歌单ID获取
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>返回json字符串</returns>
        //public virtual string Playlist(string id)
        //{
        //    Music_api api = null;
        //    switch (this.Server)
        //    {
        //        case ServerProvider.Netease:
        //            api = new Music_api
        //            {
        //                method = "POST",
        //                url = "http://music.163.com/api/v3/playlist/detail",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    s = "0",
        //                    id = id,
        //                    n = "1000",
        //                    t = "0"
        //                }),
        //                encode = Netease_AESCBC,
        //                format = "playlist.tracks"
        //            };
        //            break;
        //        case ServerProvider.Tencent:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://c.y.qq.com/v8/fcg-bin/fcg_v8_playlist_cp.fcg",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    id = id,
        //                    format = "json",
        //                    newsong = 1,
        //                    platform = "jqspaframe.json"
        //                }),
        //                format = "data.cdlist.0.songlist"
        //            };
        //            break;
        //        case ServerProvider.Kugou:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://mobilecdn.kugou.com/api/v3/special/song",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    specialid = id,
        //                    area_code = 1,
        //                    page = 1,
        //                    plat = 2,
        //                    pagesize = -1,
        //                    version = 8990
        //                }),
        //                format = "data.info"
        //            };
        //            break;
        //        case ServerProvider.Xiami:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://h5api.m.xiami.com/h5/mtop.alimusic.music.list.collectservice.getcollectdetail/1.0/",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    data = new JObject
        //                    {
        //                        { "listId", id },
        //                        { "isFullTags", false },
        //                        { "pagingVO", new JObject
        //                        {
        //                            { "page", 1 },
        //                            { "pageSize", 1000 }
        //                        } }
        //                    },
        //                    r = "mtop.alimusic.music.list.collectservice.getcollectdetail"
        //                }),
        //                encode = Xiami_sign,
        //                format = "data.data.collectDetail.songs"
        //            };
        //            break;
        //        case ServerProvider.Baidu:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://musicapi.taihe.com/v1/restserver/ting",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    from = "qianqianmini",
        //                    method = "baidu.ting.diy.gedanInfo",
        //                    listid = id,
        //                    platform = "darwin",
        //                    version = "11.2.1"
        //                }),
        //                format = "content"
        //            };
        //            break;
        //    }

        //    return this.Exec(api);
        //}

        ///// <summary>
        ///// 根据歌单ID获取
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>返回实体对象</returns>
        //public Music_search_item[] PlaylistObj(string id)
        //{
        //    bool tempFormat = this.Format;
        //    this.Format = true;
        //    string jsonStr = Playlist(id);
        //    Music_search_item[] rtn = MetingTool.MusicJson2Obj(jsonStr);
        //    this.Format = tempFormat;

        //    return rtn;
        //}
        //#endregion

        //#region 根据音乐ID获取音乐链接
        ///// <summary>
        ///// 根据音乐ID获取音乐链接
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="br"></param>
        ///// <returns>返回json字符串</returns>
        //public virtual string Url(string id, int br = 320)
        //{
        //    Music_api api = null;
        //    switch (this.Server)
        //    {
        //        case ServerProvider.Netease:
        //            api = new Music_api
        //            {
        //                method = "POST",
        //                url = "http://music.163.com/api/song/enhance/player/url",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    ids = "[" + id + "]",
        //                    br = br * 1000
        //                }),
        //                encode = Netease_AESCBC,
        //                decode = Netease_url
        //            };
        //            break;
        //        case ServerProvider.Tencent:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://c.y.qq.com/v8/fcg-bin/fcg_play_single_song.fcg",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    songmid = id,
        //                    platform = "yqq",
        //                    format = "json"
        //                }),
        //                decode = Tencent_url
        //            };
        //            break;
        //        case ServerProvider.Kugou:
        //            api = new Music_api
        //            {
        //                method = "POST",
        //                url = "http://media.store.kugou.com/v1/get_res_privilege",
        //                sendDataType = SendDataType.Json,
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    relate = 1,
        //                    userid = "0",
        //                    vip = 0,
        //                    appid = 1000,
        //                    token = "",
        //                    behavior = "download",
        //                    area_code = "1",
        //                    clientver = "8990",
        //                    resource = new JArray
        //                    {
        //                        Common.Dynamic2JObject(new
        //                        {
        //                            id = 0,
        //                            type = "audio",
        //                            hash = id
        //                        })
        //                    },
        //                }),
        //                decode = Kugou_url
        //            };
        //            break;
        //        case ServerProvider.Xiami:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://acs.m.xiami.com/h5/mtop.alimusic.music.songservice.getsongs/1.0/",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    data = new JObject
        //                    {
        //                        { "songIds", new JArray
        //                        {
        //                            id
        //                        } }
        //                    },
        //                    r = "mtop.alimusic.music.songservice.getsongs"
        //                }),
        //                encode = Xiami_sign,
        //                decode = Xiami_url
        //            };
        //            break;
        //        case ServerProvider.Baidu:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://musicapi.taihe.com/v1/restserver/ting",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    from = "qianqianmini",
        //                    method = "baidu.ting.song.getInfos",
        //                    songid = id,
        //                    res = 1,
        //                    platform = "darwin",
        //                    version = "1.0.0"
        //                }),
        //                encode = Baidu_AESCBC,
        //                decode = Baidu_url
        //            };
        //            break;
        //    }
        //    this.Br = br;

        //    return this.Exec(api);
        //}

        ///// <summary>
        ///// 根据音乐ID获取音乐链接
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="br"></param>
        ///// <returns>返回实体对象</returns>
        //public Music_url UrlObj(string id, int br = 320)
        //{
        //    bool tempFormat = this.Format;
        //    this.Format = true;
        //    string jsonStr = Url(id, br);
        //    Music_url rtn = MetingTool.UrlJson2Obj(jsonStr);
        //    this.Format = tempFormat;

        //    return rtn;
        //}
        //#endregion

        //#region 根据歌曲ID查歌词
        ///// <summary>
        ///// 根据歌曲ID查歌词
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>返回json字符串</returns>
        //public virtual string Lyric(string id)
        //{
        //    Music_api api = null;
        //    switch (this.Server)
        //    {
        //        case ServerProvider.Netease:
        //            api = new Music_api
        //            {
        //                method = "POST",
        //                url = "http://music.163.com/api/song/lyric",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    id = id,
        //                    os = "linux",
        //                    lv = -1,
        //                    kv = -1,
        //                    tv = -1
        //                }),
        //                encode = Netease_AESCBC,
        //                decode = Netease_lyric
        //            };
        //            break;
        //        case ServerProvider.Tencent:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://c.y.qq.com/lyric/fcgi-bin/fcg_query_lyric_new.fcg",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    songmid = id,
        //                    g_tk = "5381"
        //                }),
        //                decode = Tencent_lyric
        //            };
        //            break;
        //        case ServerProvider.Kugou:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://krcs.kugou.com/search",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    keyword = "%20-%20",
        //                    ver = 1,
        //                    hash = id,
        //                    client = "mobi",
        //                    man = "yes"
        //                }),
        //                decode = Kugou_lyric
        //            };
        //            break;
        //        case ServerProvider.Xiami:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "https://acs.m.xiami.com/h5/mtop.alimusic.music.lyricservice.getsonglyrics/1.0/",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    data = new JObject
        //                    {
        //                        { "songId", id }
        //                    },
        //                    r = "mtop.alimusic.music.lyricservice.getsonglyrics"
        //                }),
        //                encode = Xiami_sign,
        //                decode = Xiami_lyric
        //            };
        //            break;
        //        case ServerProvider.Baidu:
        //            api = new Music_api
        //            {
        //                method = "GET",
        //                url = "http://musicapi.taihe.com/v1/restserver/ting",
        //                body = Common.Dynamic2JObject(new
        //                {
        //                    from = "qianqianmini",
        //                    method = "baidu.ting.song.lry",
        //                    songid = id,
        //                    platform = "darwin",
        //                    version = "1.0.0"
        //                }),
        //                decode = Baidu_lyric
        //            };
        //            break;
        //    }

        //    return this.Exec(api);
        //}

        ///// <summary>
        ///// 根据歌曲ID查歌词
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>返回实体对象</returns>
        //public Music_lyric LyricObj(string id)
        //{
        //    bool tempFormat = this.Format;
        //    this.Format = true;
        //    string jsonStr = Lyric(id);
        //    Music_lyric rtn = MetingTool.LyricJson2Obj(jsonStr);
        //    this.Format = tempFormat;

        //    return rtn;
        //}
        //#endregion

        //#region 歌曲图片(对指定歌曲编号，返回图片地址)
        ///// <summary>
        ///// 歌曲图片(对指定歌曲编号，返回图片地址)
        ///// </summary>
        ///// <param name="id">eg.传递通过 api.Song("35847388") 获取到的 pic_id</param>
        ///// <param name="size"></param>
        ///// <returns>返回json字符串</returns>
        //public virtual string Pic(string id, int size = 300)
        //{
        //    string picUrl = string.Empty;
        //    bool tempFormat;
        //    switch (this.Server)
        //    {
        //        case ServerProvider.Netease:
        //            picUrl = "https://p3.music.126.net/" + this.Netease_encryptId(id) + "/" + id + ".jpg?param=" + size + "y" + size;
        //            break;
        //        case ServerProvider.Tencent:
        //            picUrl = "https://y.gtimg.cn/music/photo_new/T002R" + size + "x" + size + "M000" + id + ".jpg?max_age=2592000";
        //            break;
        //        case ServerProvider.Kugou:
        //            tempFormat = this.Format;
        //            string kugouRawJsonStr = this.FormatMethod(false).Song(id);
        //            this.Format = tempFormat;
        //            dynamic jsonObj = Common.JsonStr2Obj(kugouRawJsonStr);
        //            // 发现酷狗的图片大小有限，对于 e64025c53de70ba1d91aec1f8c38f1ae，尝试 100,200,400可行，其它均 404没有，不知道其它歌曲图片情况如何，这里于是暂时写死
        //            picUrl = jsonObj.imgUrl.ToString().Replace("{size}", "400");
        //            break;
        //        case ServerProvider.Xiami:
        //            tempFormat = this.Format;
        //            string xiamiRawJsonStr = this.FormatMethod(false).Song(id);
        //            this.Format = tempFormat;
        //            dynamic xiamiSongObj = Common.JsonStr2Obj(xiamiRawJsonStr);
        //            picUrl = xiamiSongObj.data.data.songDetail.albumLogo.ToString();
        //            picUrl = picUrl.Replace("http:", "https:") + "@1e_1c_100Q_" + size + "h_" + size + "w";
        //            break;
        //        case ServerProvider.Baidu:
        //            tempFormat = this.Format;
        //            string baiduRawJsonStr = this.FormatMethod(false).Song(id);
        //            this.Format = tempFormat;
        //            dynamic baiduRawJsonObj = Common.JsonStr2Obj(baiduRawJsonStr);
        //            picUrl = Common.IsPropertyExist(baiduRawJsonObj, "songinfo") && Common.IsPropertyExist(baiduRawJsonObj.songinfo, "pic_radio") ? baiduRawJsonObj.songinfo.pic_radio : baiduRawJsonObj.songinfo.pic_small;
        //            break;
        //    }

        //    string jsonStr = Common.Obj2JsonStr(new
        //    {
        //        url = picUrl
        //    });

        //    return jsonStr;
        //}

        ///// <summary>
        ///// 歌曲图片(对指定歌曲编号，返回图片地址)
        ///// </summary>
        ///// <param name="id">eg.传递通过 api.Song("35847388") 获取到的 pic_id</param>
        ///// <param name="size"></param>
        ///// <returns>返回实体对象</returns>
        //public Music_pic PicObj(string id, int size = 300)
        //{
        //    bool tempFormat = this.Format;
        //    this.Format = true;
        //    string jsonStr = Pic(id, size);
        //    Music_pic rtn = MetingTool.PicJson2Obj(jsonStr);
        //    this.Format = tempFormat;

        //    return rtn;
        //}
        //#endregion


    }
}
