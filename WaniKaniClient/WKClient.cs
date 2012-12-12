using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaniKaniClient
{
    public class WKClient
    {
        public string APIKey { get; private set; }

        public WKClient(string apiKey)
        {
            APIKey = apiKey;
        }
    }
}
