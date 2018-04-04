using System;
using Newtonsoft.Json.Linq;

namespace TouchTunesCSharpSDK
{
    public class Api
    {
        private string ApiKey;
        private string BaseUrl;

        public Response NowPlaying(int deviceId)
        {
            var hexDeviceId = Dechex(deviceId);
            var nowPlayingUrl = $"{BaseUrl}/playqueue/{hexDeviceId}?api_key={ApiKey}";
            var response = RequestHelper.GetString(nowPlayingUrl, new JObject());
            return response;
        }

        private string Dechex(int number)
        {
            return Convert.ToString(number, 16);
        }

        public void SetApiKey(string key)
        {
            ApiKey = key;
        }

        public void SetBaseUrl(string url)
        {
            BaseUrl = url ?? "http://dev.touchtunes.com";
        }
    }
}
