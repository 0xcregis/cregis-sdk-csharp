using Cregis.Core.Client;
using Cregis.Core.Config;
using Cregis.Core.Model;
using java.lang;
using Microsoft.AspNetCore.Mvc;

namespace CregisSdkWebDemo.Controllers.raw
{
    /// <summary>
    /// 通用API
    /// </summary>
    [Route("Api/[controller]/[action]")]
    public class CommonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 检测地址合法性
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="mainCoinType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Common/IsLegalAddress?mainCoinType=195&address=TXhyJ2QrbksRBjdvZusH5fYKU1RwqLG6A1 
        /// test http://localhost:41913/Api/Common/IsLegalAddress?mainCoinType=195&address=TMa9x3K1NVomcLR7L42DymX5zDUgzXJB3M
        public Result<AddressLegal> IsLegalAddress(string mainCoinType, string address)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, "");
            return cregisClient.AddressLegal(mainCoinType, address);
        }

        /// <summary>
        /// 检测地址在项目中是否存在
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="mainCoinType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Common/AddressInner?mainCoinType=195&address=TXhyJ2QrbksRBjdvZusH5fYKU1RwqLG6A1
        public Result<AddressInner> AddressInner(string mainCoinType, string address)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, "");
            return cregisClient.AddressInner(mainCoinType, address);
        }

        /// <summary>
        /// 获取项目支持的币种信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Common/GetCoins
        public Result<ProjectCoins> GetCoins()
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, "");
            return cregisClient.GetProjectCoins();
        }

        /// <summary>
        /// 创建地址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="projectId"></param>
        /// <param name="apiKey"></param>
        /// <param name="mainCoinType"></param>
        /// <param name="callbackUrl"></param>ve
        /// <param name="alias"></param>
        /// <returns></returns>
        /// test http://localhost:41913/Api/Common/AddressCreate?mainCoinType=195&alias=ceshi
        public Result<ProjectAddress> AddressCreate(string mainCoinType, string alias)
        {
            CregisSdkConfig config = CregisSdkConfig.GetCregisSdkConfig();
            ICregisClient cregisClient = new CregisClient(config.url, config.apiKey, config.pid, config.addressDepositCallbackUrl);
            Result<ProjectAddress> result = cregisClient.AddressCreate(mainCoinType, cregisClient.GetCallbackUrl(), alias);
            return result;
        }
    }
}
