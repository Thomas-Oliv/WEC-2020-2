using System;
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
                string api = "https://www.googleapis.com/customsearch/v1?key=AIzaSyAGNAnJ5faOpyrvkgc4pHkSqQhSzenrlUc&cx=012776195944492167572:vadbep5zpaq&q=";
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
                foreach(SearchObject.Item item in searchObj.items)
                {
                    string body = "<li  class=\"list-group-item\">";
                    body += "<div class=\"row \">";
                    body += $"<h2 class=\"font-weight-bold\">{item.title}</h2>";
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
            for (int i = 0; i < searchObj.items.Length; i++)
            {
                Result retrieved = new Result(searchObj.items[i].title, searchObj.items[i].link, searchObj.items[i].htmlSnippet);
                value.Add(retrieved);
            }
            return value;
        }
    }
}