﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace WEC_2020
{
    public partial class _Default : Page
    {
        private List<SearchObject> searchResults = new List<SearchObject>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery.Text))
            {
                string apiID = "006472699420085524376:lsvl8mcfohs";
                string key = "AIzaSyCYKYo5Knbq9FoMTELupi6iVXSaXcVLZ0g";
                string api = "https://www.googleapis.com/customsearch/v1?key=" + key + "&cx=" + apiID + "&q=";
                string q = SearchQuery.Text.Replace(' ', '+');
                api += q;
                string json = "Does not Work!";
                try
                {
                     json = new WebClient().DownloadString(api);
                }
                catch
                {

                }
                SearchObject.Rootobject searchObj = JsonConvert.DeserializeObject<SearchObject.Rootobject>(json);

                var results = fillTable(searchObj);
                //string link = searchObj.items[1].link;
                // Perform Search method on SearchQuery.Text
                foreach(Result item in results)
                {
                    string body = "<li  class=\"list-group-item\">";
                    body += "<div class=\"row \">";
                    body += $"<h2 class=\"font-weight-bold\">{item.text}</h2>";
                    body += "</div>";
                    body += "<div class=\"row \">";
                    body += $"<a href = \"{item.link}\">{item.displayLink}</a>";
                    body += "</div>";
                    body += "<div class=\"row \">";
                    body += $"<h6>{item.snippet}</h6>";
                    body += "</div>";
                    body += "</li>";
                    ResultList.InnerHtml += body;
                }
            }
        }
        public List <Result> fillTable(SearchObject.Rootobject searchObj)
        {
            List<Result> value = new List<Result>();
            try {
                for (int i = 0; i < searchObj.items.Length; i++)
                {
                    Result retrieved = new Result(searchObj.items[i].title, searchObj.items[i].link, searchObj.items[i].htmlSnippet
                        , searchObj.items[i].displayLink);
                    value.Add(retrieved);
                }
            }
            catch
            {
                return new List<Result>();
            }
            
            return value;
        }
    }
}