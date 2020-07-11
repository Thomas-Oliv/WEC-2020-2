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

        string apiID = "006472699420085524376:lsvl8mcfohs";
        string key = "AIzaSyCYKYo5Knbq9FoMTELupi6iVXSaXcVLZ0g";
        string api;

        List<Result> results;
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_Current_Page.Text = Convert.ToString(Convert.ToInt32(Session["Page"])+1);
            api = "https://www.googleapis.com/customsearch/v1?key=" + key + "&cx=" + apiID + "&q=";
            if (string.IsNullOrWhiteSpace(SearchQuery.Text) && Convert.ToInt32(Session["Page"]) == 0)
            {
                Btn_Prev.Enabled = false;
                Btn_Prev.Visible = false;
                Btn_Next.Enabled = false;
                Btn_Next.Visible = false;
                Btn_Current_Page.Visible = false;
                Btn_Current_Page.Enabled = false;
            }
            else if (Convert.ToInt32(Session["Page"]) == 0)
            {
                Btn_Prev.Enabled = false;
                Btn_Prev.Visible = false;
                Btn_Next.Enabled = true;
                Btn_Next.Visible = true;
                Btn_Current_Page.Visible = true;
                Btn_Current_Page.Enabled = true;
            }
            else
            {
                Btn_Current_Page.Visible = true;
                Btn_Current_Page.Enabled = true;
                Btn_Prev.Enabled = true;
                Btn_Prev.Visible = true;
                Btn_Next.Enabled = true;
                Btn_Next.Visible = true;
            }
        }
        
        protected void Search(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery.Text))
            {
                Session["Page"] = 0;
                ResultList.InnerHtml = string.Empty;
                Session["Query"] = SearchQuery.Text.Replace(' ', '+');
                string query = api+ Session["Query"];

                string json = string.Empty;
                try
                {
                     json = new WebClient().DownloadString(query);
                }
                catch
                {

                }
                SearchObject.Rootobject searchObj = JsonConvert.DeserializeObject<SearchObject.Rootobject>(json);

                results = Get_Results(searchObj);
                populateHtml(results);
            }
        }
        public void populateHtml(List<Result> results)
        {
            ResultList.InnerHtml = "";
                // Perform Search method on SearchQuery.Text
                foreach (Result item in results)
                {
                    string body = "<li  class=\"list-group-item\">";
                    body += "<div class=\"row \">";
                    body += $"<a href=\"{item.link}\">";
                    body += $"<h2 class=\"font-weight-bold text-info \">{item.text}</h2>";
                    body += "</a>";
                    body += "</div>";
                    body += "<div class=\"row \">";
                    body += $"<a href = \"{item.link}\">{item.displayLink}</a>";
                    body += "</div>";
                    body += "<div class=\"row \">";
                    body += $"<h6 class=\"text-secondary\">{item.snippet}</h6>";
                    body += "</div>";
                    body += "</li>";
                    ResultList.InnerHtml += body;
                }
        }
        
        protected void Page_Previous(object sender, EventArgs e)
        {
            Tabify(true);

        }
        protected void Page_Next(object sender, EventArgs e)
        {
            Tabify(false);
        }


        protected List<Result> Get_Results(SearchObject.Rootobject searchObj)
        {
            List<Result> value = new List<Result>();
            try {
                if (searchObj != null)
                {
                    if (searchObj.items != null)
                    {
                        for (int i = 0; i < searchObj.items.Length; i++)
                        {
                            Result retrieved = new Result(searchObj.items[i].title, searchObj.items[i].link, searchObj.items[i].htmlSnippet
                                , searchObj.items[i].displayLink);
                            value.Add(retrieved);
                        }
                    }
                }
            }
            catch( NullReferenceException ex)
            {
                return new List<Result>();
            }

            return value;
        }
        public void Tabify(bool isprevious)
        {

            if (isprevious && Convert.ToInt32(Session["Page"]) != 0)
            {
                Session["Page"] = Convert.ToInt32(Session["Page"]) - 1;
            }
            else if (!isprevious)
            {
                Session["Page"] = Convert.ToInt32(Session["Page"]) + 1;
            }

            string query = api + Session["Query"] + "&start=" + (Convert.ToInt32(Session["Page"]) * 10 + 1).ToString();

            string json = string.Empty;
            try
            {
                json = new WebClient().DownloadString(query);
            }
            catch
            {
                
            }
            SearchObject.Rootobject searchObj = JsonConvert.DeserializeObject<SearchObject.Rootobject>(json);
            var results = Get_Results(searchObj);
            populateHtml(results);
            
        }
    }
}