﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AdminApplication
{

    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

       static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:59031/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("appication/json")); 
        }
            

    }
}