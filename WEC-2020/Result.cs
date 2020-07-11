using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEC_2020
{
    public class Result
    {
        public Result(string text, string link, string snippet, string displayLink)
        {
            this.text = text;
            this.link = link;
            this.snippet = snippet;
            this.displayLink = displayLink;
        }
        public string text { get; set; }
        public string link { get; set; }
        public string snippet { get; set; }
        public string displayLink { get; set; }

    }
}