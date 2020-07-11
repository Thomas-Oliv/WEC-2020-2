using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEC_2020
{
    public class Result
    {
        public Result(string text, string link, string snippet)
        {
            this.text = text;
            this.link = link;
            this.snippet = snippet;
        }
        public string text { get; set; }
        public string link { get; set; }
        public string snippet { get; set; }

    }
}