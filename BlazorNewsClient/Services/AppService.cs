using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace BlazorNewsClient.Services
{
    public class AppService
    {
        private readonly HttpClient _http;

        public AppService(HttpClient http)
        {
            _http = http;
        }

        public async Task Load()
        {
            this.Data = await this._http.GetJsonAsync<NewsData>(
                "https://newsapi.org/v2/everything?q=blazor&sortBy=publishedAt&apiKey=69817812c6db452884e14cf05efd9561");
        }

        public NewsData Data { get; set; }
    }


    public class NewsData
    {
        public Article[] Articles { get; set; }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string UrlToImage { get; set; }
        public string Url { get; set; }
    }
}