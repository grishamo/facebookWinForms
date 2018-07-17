﻿using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Threading;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class NewsApi
    {
        private static readonly object rs_GoogleNewsKey = new object();
        private static NewsApi s_This;
        private readonly string m_ApiKey = "29eddc60ce2c40f3adcb1f6168422c6c";
        string culture = CultureInfo.CurrentCulture.DisplayName;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

        private NewsApi() {}

        public static NewsApi Instance
        {
            get {

                if (s_This == null)
                {
                    lock (rs_GoogleNewsKey)
                    {
                        if (s_This == null)
                        {
                            s_This = new NewsApi();
                        }
                    }
                }

                return s_This;
            }
        }

        public List<Article> GetNewsContent(string i_UrlParameters = "")
        {
            List<Article> articles = new List<Article>();
            HttpWebResponse response = null;
            string requestUrl = buildRequestUrl(i_UrlParameters);

            // httpWebRequest with API URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

            //Method GET
            request.Method = "GET";

            //HttpWebResponse for result
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                //Mapping of status code
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == "")
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    //Get news data in json string
                    string data = readStream.ReadToEnd();
                    StringReader reader = new StringReader(data);

                    string json = reader.ReadToEnd();
                    ItemNews allNews = JsonConvert.DeserializeObject<ItemNews>(json);

                    articles = allNews.articles;
                }
            }
            catch (Exception e)
            { 
                //TODO Handle request exception 
            }

            return articles;
        }

        private string buildRequestUrl(string i_UrlParameters)
        {
            string cultureAbbreviation = cultureInfo.TwoLetterISOLanguageName;
            string language = "&language=" + cultureAbbreviation;
            language = i_UrlParameters.Length > 1 ? language : language.Replace("&", "");

            string url = "https://newsapi.org/v2/top-headlines?" + i_UrlParameters + language + "&apiKey=" + m_ApiKey;

            return url;
        }
    }


    public class ItemNews
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles = new List<Article>();
    }

    public class Article
    {
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }

    }

}
