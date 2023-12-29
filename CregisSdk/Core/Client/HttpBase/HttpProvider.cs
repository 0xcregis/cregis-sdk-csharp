using Cregis.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cregis.Core.Client.HttpBase
{
    public class HttpProvider
    {
        public static HttpResponseParameter Excute(HttpRequestParameter requestParameter)
        {
            if (string.IsNullOrEmpty(requestParameter.contentType))
                requestParameter.contentType = "application/x-www-form-urlencoded";
            if (string.IsNullOrEmpty(requestParameter.acceptType))
                requestParameter.acceptType = "application/json;charset=UTF-8";
            return HttpUtil.Excute(requestParameter);
        }

        public static string Excute(string url, Dictionary<string, string> headerParameters, Dictionary<string, string> parameters, string requestBody)
        {
            HttpResponseParameter reponseParameter = Excute(new HttpRequestParameter
            {
                url = url,
                requestMethod = HttpMethod.Post,
                encoding = Encoding.UTF8,
                headerParameters = headerParameters,
                parameters = parameters,
                contentData = requestBody,
                contentType = "application/json; charset=UTF-8"
            });
            return reponseParameter.body;
        }

        public static string Excute(string url, HttpMethod requestMethod, Encoding encoding, Dictionary<string, string> headerParameters,
            Dictionary<string, string> parameters, string requestBody, string contentType)
        {
            HttpResponseParameter reponseParameter = Excute(new HttpRequestParameter
            {
                url = url,
                requestMethod = requestMethod,
                encoding = encoding,
                headerParameters = headerParameters,
                parameters = parameters,
                contentData = requestBody,
                contentType = contentType
            });
            return reponseParameter.body;
        }

        public static T Excute<T>(string url, Dictionary<string, string> headerParameters, Dictionary<string, string> parameters, string requestBody)
        {
            string response = "";
            try
            {
                response = Excute(url, headerParameters, parameters, requestBody);
            }
            catch (Exception ex)
            {
                response = GetInternetException<T>(ex.Message);
            }
            T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        /// <summary>
        /// 测试使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headerParameters"></param>
        /// <param name="parameters"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public static T Excute<T>(string url, Dictionary<string, string> headerParameters, Dictionary<string, string> parameters, string requestBody, out string response)
        {
            try
            {
                response = Excute(url, headerParameters, parameters, requestBody);
            }
            catch (Exception ex)
            {
                response = GetInternetException<T>(ex.Message);
            }
            T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        public static T Excute<T>(string url, HttpMethod requestMethod, Encoding encoding, Dictionary<string, string> headerParameters,
            Dictionary<string, string> parameters, string requestBody, string contentType)
        {
            string response = Excute(url, requestMethod, encoding, headerParameters, parameters, requestBody, contentType);
            T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        static string GetInternetException<T>(string message)
        {
            Result<T> commonResult = new Model.Result<T>() { code = "-1000", msg = message };
            string internetException = Newtonsoft.Json.JsonConvert.SerializeObject(commonResult);
            return internetException; 
        }
    }
}
