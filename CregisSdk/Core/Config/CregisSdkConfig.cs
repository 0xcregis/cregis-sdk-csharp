namespace Cregis.Core.Config
{
    public class CregisSdkConfig
    {
        static CregisSdkConfig cregisSdkConfig;
        public static CregisSdkConfig GetCregisSdkConfig()
        {
            if (cregisSdkConfig == null)
            {
                cregisSdkConfig = new CregisSdkConfig();
                cregisSdkConfig.url = "http://t-tmkfhdqp.apple806.cc:81";
                cregisSdkConfig.apiKey = "02a31505bd8547878c482ac34862cc94";
                cregisSdkConfig.pid = 1393025028702208;
                cregisSdkConfig.orderDepositCallbackUrl = "http://192.168.2.175:41913/Api/Callback/OrderDeposit";
                cregisSdkConfig.addressDepositCallbackUrl = "http://192.168.2.175:41913/Api/Callback/AddressDeposit";
                cregisSdkConfig.payoutCallbackUrl = "http://192.168.2.175:41913/Api/Callback/Payout";

            }
            return cregisSdkConfig;
        }

        /// <summary>
        /// SDK调用地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string apiKey { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public long pid { get; set; }
        /// <summary>
        /// 订单充值回调地址
        /// </summary>
        public string orderDepositCallbackUrl { get; set; }
        /// <summary>
        /// 地址充值回调地址
        /// </summary>
        public string addressDepositCallbackUrl { get; set; }
        /// <summary>
        /// 提笔、转账回调地址
        /// </summary>
        public string payoutCallbackUrl { get; set; }
    }
}
