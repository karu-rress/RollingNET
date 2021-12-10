#nullable enable

using System.Net;

namespace RollingRess.Net
{
    public static class Connection
    {
        public static bool IsInternetAvailable
        {
            get
            {
                try
                {
                    using WebClient client = new();
                    using System.IO.Stream? stream = client.OpenRead("http://www.google.com");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
