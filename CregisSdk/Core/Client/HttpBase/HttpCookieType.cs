using System.Net;

namespace Cregis.Core.Client.HttpBase
{
    /// <summary>
    /// Cookie对应类
    /// </summary>
    public class HttpCookieType
    {
        /// <summary>
        /// cookie集合
        /// </summary>
        public CookieCollection cookieCollection { get; set; }
        /// <summary>
        /// cookie字符串
        /// </summary>
        public string cookieString { get; set; }
    }
}
