using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class Query
    {
        private API api;
        private List<KeyValuePair<string, string>> queryString = new List<KeyValuePair<string, string>>();

        public Query(API api, string module, string action)
        {
            this.api = api;
            AddQueryString("module", module);
            AddQueryString("action", action);
        }

        public Query(API api, string module, string action, KeyValuePair<string,string> requiredQuery)
        {
            this.api = api;
            AddQueryString("module", module);
            AddQueryString("action", action);
            AddQueryString(requiredQuery);
        }

        public Query(API api, string module, string action, KeyValuePair<string, string>[] requiredQueries)
        {
            this.api = api;
            AddQueryString("module", module);
            AddQueryString("action", action);
            AddQueryString(requiredQueries);
        }

        public void AddQueryString(string key, string value)
        {
            AddQueryString(new KeyValuePair<string, string>(key, value));
        }

        public void AddQueryString(KeyValuePair<string, string> keyValuePair)
        {
            queryString.Add(keyValuePair);
        }

        public void AddQueryString(KeyValuePair<string, string>[] keyValuePairs)
        {
            queryString.AddRange(keyValuePairs);
        }

        public string GetQueryString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var keyValuePair in queryString)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append("&");
                }
                stringBuilder.AppendFormat("{0}={1}", WebUtility.UrlEncode(keyValuePair.Key), WebUtility.UrlEncode(keyValuePair.Value));
            }
            return stringBuilder.ToString();
        }

        public string Build(string baseUrl)
        {
            var split = api.ToString().Split('_');
            var currency = split[0].ToLower();
            var net = split[1].ToLower();
            return $"{baseUrl}/{currency}/{net}/api?{GetQueryString()}";
        }
    }
}
