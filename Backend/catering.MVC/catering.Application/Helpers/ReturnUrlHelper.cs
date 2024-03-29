﻿using System.Web;

namespace catering.Application.Helpers
{
    public class ReturnUrlHelper
    {
        public string GetReturnUrl(string url)
        {
            string decodedReturnUrl;

            Uri uri = new Uri(url);
            if (uri.Query.Contains('?'))
            {
                decodedReturnUrl = HttpUtility.UrlDecode(uri.Query.TrimStart('?')).ToLower().Replace("returnurl=", "");
            }
            else
            {
                decodedReturnUrl = uri.LocalPath;
            }
            return decodedReturnUrl;
        }
    }
}
