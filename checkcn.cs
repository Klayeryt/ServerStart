using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ServerStart
{
    class checkcn
    {
        public static bool Testsite(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            bool confirm = true;
            return false;
        }
    }
}
