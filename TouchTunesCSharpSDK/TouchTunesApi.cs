using System;
using Newtonsoft.Json.Linq;

namespace TouchTunesCSharpSDK
{
    public class TouchTunesApi
    {
        private string ApiKey;
        private string BaseUrl;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="baseUrl"></param>
        public TouchTunesApi(string apiKey = "", string baseUrl = "http://dev.touchtunes.com")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Now Playing
        /// curl -ks -X GET "http://dev.touchtunes.com/playqueue/000000B39BBC?api_key=XXXXXXXX"
        /// Example: 
        /// var api = new TouchTunesApi();
        /// api.SetApiKey(/*your api key*/);
        /// var response = api.NowPlaying("11770812");
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns>Response object with two properties: Success - boolean, Data - string of json</returns>
        public Response NowPlaying(int deviceId)
        {
            var hexDeviceId = DecHex(deviceId);
            var url = $"{BaseUrl}/playqueue/{hexDeviceId}?api_key={ApiKey}";
            var response = RequestHelper.GetString(url, new JObject());
            return response;
        }

        /// <summary>
        /// Keyword Search
        /// http://dev.touchtunes.com/music/search?query=King+Crimson&api_key=XXXXXXXX
        /// Example: 
        /// var api = new TouchTunesApi();
        /// api.SetApiKey(/*your api key*/);
        /// var response = api.KeywordSearch("Mad Season");
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public Response KeywordSearch(string keyword)
        {
            var url = $"{BaseUrl}/music/search?query={keyword}&api_key={ApiKey}";
            var response = RequestHelper.GetString(url, new JObject());
            return response;
        }

        /// <summary>
        /// Song ID Search
        /// curl -ks -X GET "http://dev.touchtunes.com/music/song?song_id=92684602&api_key=XXXXXXXX"
        /// Example: 
        /// var api = new TouchTunesApi();
        /// api.SetApiKey(/*your api key*/);
        /// var response = api.SongIdSearch("8675309");
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        public Response SongIdSearch(string songId)
        {
            var url = $"{BaseUrl}/music/song?song_id={songId}&api_key={ApiKey}";
            var response = RequestHelper.GetString(url, new JObject());
            return response;
        }

        /// <summary>
        /// Locate
        /// curl -ks -X GET "http://dev.touchtunes.com/locations?latitude=40.942438&longitude=-72.990088&user_latitude=40.942438&user_longitude=-72.990088&user_horizontal_accuracy=0&radius=2555&limit=10&api_key=XXXXXXXX"
        /// Example: 
        /// var api = new TouchTunesApi();
        /// api.SetApiKey(/*your api key*/);
        /// var response = api.Locate("40.942438","-72.990088","10");
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="limit">Defaults to 20</param>
        /// <returns></returns>
        public Response Locate(string latitude, string longitude, int limit = 20)
        {
            var url = $"{BaseUrl}/locations?latitude={latitude}&longitude={longitude}&limit={limit}&api_key={ApiKey}";
            var response = RequestHelper.GetString(url, new JObject());
            return response;
        }

        /// <summary>
        /// Convert an int to a base 16
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string DecHex(int number)
        {
            return Convert.ToString(number, 16);
        }

        /// <summary>
        /// If not using initializer, can set API key here
        /// </summary>
        /// <param name="key"></param>
        public void SetApiKey(string key)
        {
            ApiKey = key;
        }

        /// <summary>
        /// If not using initialize, can set base url here
        /// </summary>
        /// <param name="url"></param>
        public void SetBaseUrl(string url)
        {
            BaseUrl = url ?? "http://dev.touchtunes.com";
        }
    }
}
