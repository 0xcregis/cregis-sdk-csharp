using Cregis.Core.Client.HttpBase;
using Cregis.Core.Config;
using Cregis.Core.Constant;
using Cregis.Core.Model;
using Cregis.Core.Util;
using CregisSdk.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cregis.Core.Client
{
    /// <summary>
    /// CregisClient
    /// </summary>
    public class CregisClient : ICregisClient
    {
        /**
         * 地址
         */
        public string url;
        /**
         * 密钥
         */
        public string apiKey;
        /**
         * 项目编号
         */
        public long pid;
        /**
         * 默认回调地址，当接口中没有传入回调地址时，使用该地址
         */
        public string callbackUrl;

        public string GetCallbackUrl()
        {
            return callbackUrl;
        }

        public CregisClient(string url, string apiKey, long pid, string callbackUrl)
        {
            this.url = url;
            this.apiKey = apiKey;
            this.pid = pid;
            this.callbackUrl = callbackUrl;
        }


        public Result<AddressLegal> AddressLegal(string chainId, string address)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("chain_id", chainId);
            paramsMap.Add("address", address);
            return DoPost<AddressLegal>(url + ApiPaths.ADDRESS_LEGAL, paramsMap).Result;
        }


        public Result<AddressInner> AddressInner(string chainId, string address)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("chain_id", chainId);
            paramsMap.Add("address", address);
            return DoPost<AddressInner>(url + ApiPaths.ADDRESS_INNER, paramsMap).Result;
        }


        public Result<Payout> Payout(string address, string currency, string amount, string thirdPartyId, string callbackUrl, string remark)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("address", address);
            paramsMap.Add("currency", currency);
            paramsMap.Add("amount", amount);
            paramsMap.Add("callback_url", callbackUrl);
            paramsMap.Add("third_party_id", thirdPartyId);
            paramsMap.Add("remark", remark);
            return DoPost<Payout>(url + ApiPaths.PAYOUT, paramsMap).Result;
            //return DoHttpClientPost<Payout>(url + ApiPaths.PAYOUT, paramsMap);
        }


        public Result<PayoutQuery> PayoutQuery(long cid)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("cid", cid);
            return DoPost<PayoutQuery>(url + ApiPaths.PAYOUT_QUERY, paramsMap).Result;
        }


        public Result<OrderDeposit> Deposit(string currency, string amount, string callbackUrl,
                                            string thirdPartyId, int timeout,
                                            string remark)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("currency", currency);
            paramsMap.Add("amount", amount);
            paramsMap.Add("callback_url", callbackUrl);
            paramsMap.Add("third_party_id", thirdPartyId);
            paramsMap.Add("timeout", timeout);
            paramsMap.Add("remark", remark);
            return DoPost<OrderDeposit>(url + ApiPaths.DEPOSIT, paramsMap).Result;
        }


        public Result<OrderDepositQuery> DepositQuery(long cid)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("cid", cid);
            return DoPost<OrderDepositQuery>(url + ApiPaths.DEPOSIT_QUERY, paramsMap).Result;
        }


        public Result<OrderDepositCancel> DepositCancel(long cid)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("cid", cid);
            return DoPost<OrderDepositCancel>(url + ApiPaths.DEPOSIT_CANCEL, paramsMap).Result;
        }


        public Result<ProjectAddress> AddressCreate(string mainCoinType, string callbackUrl, string alias)
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            paramsMap.Add("chain_id", mainCoinType);
            paramsMap.Add("callback_url", callbackUrl);
            paramsMap.Add("alias", alias);
            return DoPost<ProjectAddress>(url + ApiPaths.ADDRESS_CREATE, paramsMap).Result;
        }


        public Result<ProjectCoins> GetProjectCoins()
        {
            Dictionary<string, object> paramsMap = new Dictionary<string, object>();
            paramsMap.Add("pid", pid);
            return DoPost<ProjectCoins>(url + ApiPaths.PROJECT_COINS, paramsMap).Result;
        }

        public Dictionary<string, object> DoSign(Dictionary<string, object> paramsMap)
        {
            paramsMap.Add("timestamp", DateUtil.GetTimeStamp());
            paramsMap.Add("nonce", RandomUtil.GetNonce(6));
            paramsMap.Add("sign", SignUtil.DoSign(paramsMap, apiKey));
            return paramsMap;
        }

        async Task<Result<T>> DoPost<T>(string url, Dictionary<string, object> paramsMap)
        {
            paramsMap = DoSign(paramsMap);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string requestBody = ModelUtil.DictToStr(paramsMap);
            Dictionary<string, string> headerParameters = new Dictionary<string, string>();
            return HttpProvider.Excute<Result<T>>(url, new Dictionary<string, string>(), new Dictionary<string, string>(), requestBody);
        }
/*
        Result<T> DoHttpClientPost<T>(string url, Dictionary<string, object> paramsMap)
        {
            paramsMap = DoSign(paramsMap);
            string requestBody = ModelUtil.DictToStr(paramsMap);
            return HttpClientUtil.PostResult<T>(url, requestBody);
        }*/
    }
}
