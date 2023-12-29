using Cregis.Core.Client;
using Cregis.Core.Config;
using Cregis.Core.Model;
using java.lang;
using Microsoft.AspNetCore.Mvc;

namespace CregisSdkWebDemo.Controllers.raw
{
    /// <summary>
    /// 提币API
    /// </summary>
    [Route("Api/[controller]/[action]")]
    public class PayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成提币订单
        /// </summary>
        /// <param name="PayoutDTO"></param>
        /// <param name=""></param>
        /// <returns></returns>
        /// test  http://localhost:41913/Api/Payout/PayoutCreate?currency=195@195&amount=0.1&thirdPartyId=234516&remark=ceshi&address=
        public Result<Payout> PayoutCreate(string address, string currency, string amount, string thirdPartyId, string remark)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, config.payoutCallbackUrl);
            if (string.IsNullOrEmpty(thirdPartyId))
                thirdPartyId = System.Guid.NewGuid().ToString();
            return cregisClient.Payout(address, currency, amount, thirdPartyId, cregisClient.GetCallbackUrl(), remark);
        }

        /// <summary>
        /// 查询提币信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        /// http://localhost:41913/Api/Payout/PayoutQuery?cid=
        public Result<PayoutQuery> PayoutQuery(long cid)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, "");
            return cregisClient.PayoutQuery(cid);
        }
    }
}
