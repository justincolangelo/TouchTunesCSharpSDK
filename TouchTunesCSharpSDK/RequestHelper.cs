using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace TouchTunesCSharpSDK
{
    public static class RequestHelper
    {
        public static Response ExecuteRequest(HttpRequestMessage requestMessage, HttpMethod method)
        {
            var result = new Response()
            {
                Success = false,
                Data = "There was an error processing your request"
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.SendAsync(requestMessage).Result;
                    var responseText = response.Content.ReadAsStringAsync().Result;

                    result.Success = true;
                    result.Data = responseText;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Data = ex.Message;
            }

            return result;
        }

        private static HttpRequestMessage GetRequestMessage(HttpMethod method, JObject requestOptions)
        {
            var request = new HttpRequestMessage();

            try
            {
                var data = requestOptions?.ToString();

                if (data != null)
                {
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return request;
        }

        private static HttpRequestMessage GetRequestMessage(HttpMethod method, Dictionary<string, string> requestOptions)
        {
            var request = new HttpRequestMessage();

            try
            {
                if (method != HttpMethod.Get && requestOptions.Any())
                {
                    request.Content = new FormUrlEncodedContent(requestOptions);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return request;
        }

        public static Response GetString(string url, JObject requestOptions)
        {
            var wr = GetRequestMessage(HttpMethod.Get, requestOptions);

            return ExecuteRequest(wr, HttpMethod.Get);
        }

        public static Response GetString(string url, Dictionary<string, string> requestOptions)
        {
            var wr = GetRequestMessage(HttpMethod.Get, requestOptions);

            return ExecuteRequest(wr, HttpMethod.Get);
        }

        public static Response PutString(string url, JObject requestOptions)
        {
            var wr = GetRequestMessage(HttpMethod.Put, requestOptions);

            return ExecuteRequest(wr, HttpMethod.Put);
        }

        public static Response PutString(string url, Dictionary<string, string> requestOptions)
        {
            var wr = GetRequestMessage(HttpMethod.Put, requestOptions);

            return ExecuteRequest(wr, HttpMethod.Put);
        }

        public static Response PostString(string url, JObject requestOptions)
        {
            var wr = GetRequestMessage(HttpMethod.Post, requestOptions);

            return ExecuteRequest(wr, HttpMethod.Post);
        }
        public static Response PostString(string url, Dictionary<string, string> requestOptions)
        {
            var wr = GetRequestMessage(HttpMethod.Post, requestOptions);

            return ExecuteRequest(wr, HttpMethod.Post);
        }
    }
}
