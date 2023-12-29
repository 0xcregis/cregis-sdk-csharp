using Cregis.Core.Client;
using Cregis.Core.Config;
using Cregis.Core.Model;
using java.lang;
using Microsoft.AspNetCore.Mvc;

namespace CregisSdkWebDemo.Controllers.raw
{
    /// <summary>
    /// 充值API
    /// </summary>
    [Route("Api/[controller]/[action]")]
    public class DepositController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成充值订单
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="currency">mainCoinType@coinType</param>
        /// <param name="thirdPartyId">三方订单ID</param>
        /// <param name="timeout"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Deposit/DepositCreate?currency=195@195&amount=0.1&thirdPartyId=123456&timeout=30&remark=20231122
        public Result<OrderDeposit> DepositCreate(string currency, string amount, string thirdPartyId, int timeout, string remark)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, config.orderDepositCallbackUrl);
            if (string.IsNullOrEmpty(thirdPartyId))
                thirdPartyId =  System.Guid.NewGuid().ToString();
            return cregisClient.Deposit(currency, amount, cregisClient.GetCallbackUrl(), thirdPartyId, timeout, remark);
        }

        /// <summary>
        /// 查询充值订单信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Deposit/DepositQuery?cid=1393160661245952
        public Result<OrderDepositQuery> DepositQuery(long cid)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, "");
            return cregisClient.DepositQuery(cid);
        }


        /// <summary>
        /// 取消充值订单信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        /// test  http://localhost:41913/Api/Deposit/DepositCancel?cid=1393160661245952
        public Result<OrderDepositCancel> DepositCancel(long cid)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, "");
            return cregisClient.DepositCancel(cid);
        }
    }
}
