namespace VueTOView.Common
{
    public static class UrlProvider
    {
        public static string ProvideForAuth(Environment environment)
        {
            string url = string.Empty;
            switch (environment)
            {
                case Environment.None:
                    url = string.Empty;
                    break;
                case Environment.Live:
                    url = Consts.LiveAuth;
                    break;
                case Environment.Test:
                    url = Consts.TestAuth;
                    break;
                case Environment.Edu:
                    url = Consts.EduAuth;
                    break;
                case Environment.Local:
                    url = Consts.LocalAuth;
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
                    url = Consts.LiveTO;
                    break;
                case Environment.Test:
                    url = Consts.TestTO;
                    break;
                case Environment.Edu:
                    url = Consts.EduTO;
                    break;
                case Environment.Local:
                    url = Consts.LocalTO;
                    break;
                default:
                    break;
            }

            return url;
        }
    }
}
