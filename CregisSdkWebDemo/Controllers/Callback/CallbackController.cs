using Cregis.Core.Config;
using Cregis.Core.Model;
using Cregis.Core.Util;
using CregisSdk.Core.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CregisSdkWebDemo.Controllers.Callback
{
    /// <summary>
    /// 提币API
    /// </summary>
    [Route("Api/[controller]/[action]")]
    public class CallbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 订单充值回调处理
        /// </summary>
        /// <param name="orderDepositCallback"></param>
        /// <returns></returns>
        [HttpPost]
        public object OrderDeposit([FromBody] OrderDepositCallback orderDepositCallback)
        {
            Console.WriteLine("地址充值回调:" + JsonConvert.SerializeObject(orderDepositCallback));
            if (SignUtil.verifySign(ModelUtil.ModelToDict(orderDepositCallback), CregisSdkConfig.GetCregisSdkConfig().apiKey, orderDepositCallback.sign))
            {
                Console.WriteLine("验签成功");
                return "success";
            }
            return "error";
        }

        /// <summary>
        /// 地址充值回调
        /// </summary>
        /// <param name="addressDepositCallback"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public object AddressDeposit([FromBody] AddressDepositCallback addressDepositCallback)
        {
            Console.WriteLine("地址充值回调:" + JsonConvert.SerializeObject(addressDepositCallback));
            if (SignUtil.verifySign(ModelUtil.ModelToDict(addressDepositCallback), CregisSdkConfig.GetCregisSdkConfig().apiKey, addressDepositCallback.sign))
            {
                Console.WriteLine("验签成功");
                return "success";
            }
            return "error";
        }

        /// <summary>
        /// 提币充值回调处理
        /// </summary>
        /// <param name="payoutCallback"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public object Payout([FromBody] PayoutCallback payoutCallback)
        {
            Console.WriteLine("提币回调:"+ JsonConvert.SerializeObject(payoutCallback));
            if (SignUtil.verifySign(ModelUtil.ModelToDict(payoutCallback), CregisSdkConfig.GetCregisSdkConfig().apiKey, payoutCallback.sign))
            {
                Console.WriteLine("验签成功");
                return "success";
            }
            return "error";
        }

    }
}
