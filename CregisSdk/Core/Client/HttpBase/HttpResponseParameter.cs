using System;
using System.Net;

namespace Cregis.Core.Client.HttpBase
{
    /// <summary>
    /// 响应参数类
    /// </summary>
    public class HttpResponseParameter
    {
        public HttpResponseParameter()
        {
            cookie = new HttpCookieType();
        }
        /// <summary>
        /// 响应资源标识符
        /// </summary>
        public Uri uri { get; set; }
        /// <summary>
        /// 响应状态码
        /// </summary>
        public HttpStatusCode statusCode { get; set; }
        /// <summary>
        /// 响应Cookie对象
        /// </summary>
        public HttpCookieType cookie { get; set; }
        /// <summary>
        /// 响应体
        /// </summary>
        public string body { get; set; }
    }
}
