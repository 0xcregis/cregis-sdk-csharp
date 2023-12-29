using Cregis.Core.Client;
using Cregis.Core.Config;
using Cregis.Core.Model;
using CregisSdk.Core.Util;
using java.math;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CregisSdkWebDemo.Controllers.Batch
{
    [Route("Api/[controller]/[action]")]

    public class BatchController : Controller
    {
        private readonly ILogger<BatchController> _logger;

        public BatchController(ILogger<BatchController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 批量提币
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="currency">mainCoinType@coinType</param>
        /// <param name="toAddress"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="remark"></param>
        /// <param name="max"></param>
        /// <param name="scale"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Batch/BatchPayout?toAddress=TXhyJ2QrbksRBjdvZusH5fYKU1RwqLG6A1&currency=195@195&max=6&scale=6&number=10&remark=ceshi
        public object BatchPayout(string currency,
                               string toAddress, string remark,
                               string max, int scale, int number)
        {
            string[] addresses = toAddress.Split(",");
            List<object> list = new List<object>();
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, config.payoutCallbackUrl);
            for (int i = 0; i < number; i++)
            {
                int index = i % addresses.Length;
                string address = addresses[index];
                BigDecimal amount = BigDecimal.valueOf(RandomUtil.GetLong(Int32.Parse(max))).divide(BigDecimal.TEN.pow(scale)).setScale(scale, RoundingMode.DOWN);
                Result<Payout> result = cregisClient.Payout(address, currency, amount.toEngineeringString(), System.Guid.NewGuid().ToString(), cregisClient.GetCallbackUrl(), remark);
                list.Add(result);
            }
            return list;
        }

        /// <summary>
        /// 批量生成订单
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="projectId">项目编号</param>
        /// <param name="apiKey">密钥</param>
        /// <param name="currency">币种</param>
        /// <param name="remark">备注</param>
        /// <param name="callbackUrl">回调地址</param>
        /// <param name="timeout"></param>
        /// <param name="max">最大值</param>
        /// <param name="scale">精度</param>
        /// <param name="number">次数</param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Batch/BatchDeposit?currency=195@195&max=6&scale=6&number=10&remark=ceshi

        public object BatchDeposit(string currency, string remark, int timeout, string max, int scale, int number)
        {
            List<object> list = new List<object>();
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, config.orderDepositCallbackUrl);
            for (int i = 0; i < number; i++)
            {
                BigDecimal amount = BigDecimal.valueOf(RandomUtil.GetLong(Int32.Parse(max))).divide(BigDecimal.TEN.pow(scale)).setScale(scale, RoundingMode.DOWN);
                Result<OrderDeposit> result = cregisClient.Deposit(currency, amount.toEngineeringString(), cregisClient.GetCallbackUrl(), System.Guid.NewGuid().ToString(), timeout, remark);
                list.Add(result);
            }
            return list;
        }
    }
}
