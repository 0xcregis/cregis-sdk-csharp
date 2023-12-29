using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Cregis.Core.Client.HttpBase
{
    public class HttpUtil
    {
        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="requestParameter">请求报文</param>
        /// <returns>响应报文</returns>
        public static HttpResponseParameter Excute(HttpRequestParameter requestParameter)
        {
            // 1.实例化
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(requestParameter.url, UriKind.RelativeOrAbsolute));
            webRequest.Timeout = 20000;
            // 2.设置请求头
            SetHeader(webRequest, requestParameter);

            // 3.设置请求Cookie
            SetCookie(webRequest, requestParameter);
            // 4.ssl/https请求设置
            if (Regex.IsMatch(requestParameter.url, "^https://"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            }
            // 5.设置请求参数[Post方式下]
            SetParameter(webRequest, requestParameter);
            // 6.设置请求无参直流数据参数[Post方式下]
            SetRequestStream(webRequest, requestParameter);
            // 7.返回响应报文
            return SetResponse(webRequest, requestParameter);
        }

        /// <summary>
        /// 设置请求无参直流数据参数
        /// </summary>
        /// <param name="webRequest"></param>
        /// <param name="requestParameter"></param>
        private static void SetRequestStream(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            if (string.IsNullOrEmpty(requestParameter.contentData)) return;
            if (requestParameter.requestMethod == HttpMethod.Post)
            {
                byte[] bytePosts = requestParameter.encoding.GetBytes(requestParameter.contentData);
                webRequest.ContentLength = bytePosts.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(bytePosts, 0, bytePosts.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
            }
            
        }

        /// <summary>
        /// 设置请求头
        /// </summary>
        /// <param name="webRequest">HttpWebRequest对象</param>
        /// <param name="requestParameter">请求参数对象</param>
        static void SetHeader(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            webRequest.Method = HttpMethod.Post.Method;
            webRequest.ContentType = requestParameter.contentType;
            webRequest.Accept = requestParameter.acceptType;
            webRequest.KeepAlive = true;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko/20100101 Firefox/22.0";
            webRequest.AllowAutoRedirect = true;
            webRequest.ProtocolVersion = HttpVersion.Version11;
            foreach (KeyValuePair<string, string> header in requestParameter.headerParameters)
            {
                webRequest.Headers.Add(header.Key, header.Value);
            }
        }

        /// <summary>
        /// 设置请求Cookie
        /// </summary>
        /// <param name="webRequest">HttpWebRequest对象</param>
        /// <param name="requestParameter">请求参数对象</param>
        private static void SetCookie(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            // 必须实例化，否则响应中获取不到Cookie
            webRequest.CookieContainer = new CookieContainer();
            if (requestParameter.cookie != null && !string.IsNullOrEmpty(requestParameter.cookie.cookieString))
            {
                webRequest.Headers[HttpRequestHeader.Cookie] = requestParameter.cookie.cookieString;
            }
            if (requestParameter.cookie != null && requestParameter.cookie.cookieCollection != null && requestParameter.cookie.cookieCollection.Count > 0)
            {
                webRequest.CookieContainer.Add(requestParameter.cookie.cookieCollection);
            }
        }

        /// <summary>
        /// ssl/https请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        /// <summary>
        /// 设置请求参数（只有Post请求方式才设置）
        /// </summary>
        /// <param name="webRequest">HttpWebRequest对象</param>
        /// <param name="requestParameter">请求参数对象</param>
        static void SetParameter(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            if (requestParameter.parameters == null || requestParameter.parameters.Count <= 0) return;
            if (requestParameter.requestMethod == HttpMethod.Post)
            {
                StringBuilder data = new StringBuilder(string.Empty);
                foreach (KeyValuePair<string, string> keyValuePair in requestParameter.parameters)
                {
                    data.AppendFormat("{0}={1}&", keyValuePair.Key, keyValuePair.Value);
                }
                string para = data.Remove(data.Length - 1, 1).ToString();

                byte[] bytePosts = requestParameter.encoding.GetBytes(para);
                webRequest.ContentLength = bytePosts.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(bytePosts, 0, bytePosts.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
            }
        }

        /// <summary>
        /// 返回响应报文
        /// </summary>
        /// <param name="webRequest">HttpWebRequest对象</param>
        /// <param name="requestParameter">请求参数对象</param>
        /// <returns>响应对象</returns>
        static HttpResponseParameter SetResponse(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            HttpResponseParameter responseParameter = new HttpResponseParameter();
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                responseParameter.uri = webResponse.ResponseUri;
                responseParameter.statusCode = webResponse.StatusCode;
                responseParameter.cookie = new HttpCookieType
                {
                    cookieCollection = webResponse.Cookies,
                    cookieString = webResponse.Headers["Set-Cookie"]
                };
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(), requestParameter.encoding))
                {
                    responseParameter.body = reader.ReadToEnd();
                }
            }
            return responseParameter;
        }
    }
}
