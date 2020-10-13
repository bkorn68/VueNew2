using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.Common
{
    public static class UrlProvider
    {

        public  static string ProvideForAuth(Environment environment)
        {
            string url = string.Empty;
            switch (environment)
            {
                case Environment.None:
                    url = string.Empty;
                    break;
                case Environment.Live:
                    url = Const.LiveAuth;
                    break;
                case Environment.Test:
                    url = Const.TestAuth;
                    break;
                case Environment.Edu:
                    url = Const.EduAuth;
                    break;
                case Environment.Local:
                    url = Const.LocalAuth;
                    break;
                default:
                    break;
            }

            return url;
        }
        public static string ProvideForTO(Environment environment)
        {
            string url = string.Empty;
            switch (environment)
            {
                case Environment.None:
                    url = string.Empty;
                    break;
                case Environment.Live:
                    url = Const.LiveTO;
                    break;
                case Environment.Test:
                    url = Const.TestTO;
                    break;
                case Environment.Edu:
                    url = Const.EduTO;
                    break;
                case Environment.Local:
                    url = Const.LocalTO;
                    break;
                default:
                    break;
            }

            return url;
        }
    }
}
