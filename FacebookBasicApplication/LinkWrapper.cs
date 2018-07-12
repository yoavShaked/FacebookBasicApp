using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookBasicApplication
{
    public class LinkWrapper
    {
        public string Name { get; set; }

				public string URL { get; set; }

        public LinkWrapper(string i_LinkName, string i_LinkURL)
        {
            Name = i_LinkName;
            URL = i_LinkURL;
        }
    }
}
