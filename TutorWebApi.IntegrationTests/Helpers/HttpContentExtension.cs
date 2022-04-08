﻿using Newtonsoft.Json;

namespace TutorWebApi.IntegrationTests.Helpers
{
    public static class HttpContentExtension
    {
        public static HttpContent ToJsonHttpContent(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            return httpContent;
        }
    }
}