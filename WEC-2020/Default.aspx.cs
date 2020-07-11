using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                // Perform Search method on SearchQuery.Text
            }
        }
    }
}