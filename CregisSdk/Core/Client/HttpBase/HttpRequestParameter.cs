using System.Collections.Generic;
using System.Text;

namespace Cregis.Core.Client.HttpBase
{
    /// <summary>
    /// 请求参数类
    /// </summary>
    public class HttpRequestParameter
    {
        public HttpRequestParameter()
        {
            encoding = Encoding.UTF8;
        }
        /// <summary>
        /// 请求方式
        /// </summary>
        public HttpMethod requestMethod { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 请求Cookie对象
        /// </summary>
        public HttpCookieType cookie { get; set; }
        /// <summary>
        /// 请求编码
        /// </summary>
        public Encoding encoding { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public Dictionary<string, string> parameters { get; set; }
        /// <summary>
        /// 请求头信息
        /// </summary>
        public Dictionary<string, string> headerParameters { get; set; }
        /// <summary>
        /// 无参直流数据[与parameters互斥]
        /// </summary>
        public string contentData{ get; set; }
        /// <summary>
        /// 引用页
        /// </summary>
        public string refererUrl { get; set; }
        /// <summary>
        /// contentType
        /// </summary>
        public string contentType { get; set; }
        /// <summary>
        /// acceptType
        /// </summary>
        public string acceptType { get; set; }
    }
}
