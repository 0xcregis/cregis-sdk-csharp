using Cregis.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cregis.Core.Client
{
    public interface ICregisClient
    {
        string GetCallbackUrl();

        /// <summary>
        /// 检测地址在项目中是否存在
        /// </summary>
        /// <param name="chainId">链编号</param>
        /// <param name="address">地址</param>
        /// <returns>结果</returns>
        Result<AddressLegal> AddressLegal(string chainId, string address);

        /// <summary>
        /// 检测地址在项目中是否存在
        /// </summary>
        /// <param name="chainId">链编号</param>
        /// <param name="address">地址</param>
        /// <returns>结果</returns>
        Result<AddressInner> AddressInner(string chainId, string address);


        /**
         * 发送提币请求
         *
         * @param address      提币地址
         * @param amount       金额
         * @param thirdPartyId 业务编号
         * @param callbackUrl  回调地址
         * @return 结果
         */
        Result<Payout> Payout(string address, string currency, string amount,
                              string thirdPartyId, string callbackUrl,
                              string remark);

        /**
         * @param cid 业务编号
         * @return 结果
         */
        Result<PayoutQuery> PayoutQuery(long cid);

        /**
         * 充值地址
         *
         * @param amount       金额
         * @param callbackUrl  回调地址
         * @param thirdPartyId 三方业务编号
         * @param current      币种
         * @param remark       备注
         * @return 结果
         */
        Result<OrderDeposit> Deposit(string current, string amount, string callbackUrl, string thirdPartyId, int timeout, string remark);

        /**
         * @param cid cid
         * @return 结果
         */
        Result<OrderDepositQuery> DepositQuery(long cid);

        /**
         * 生成地址
         * @param mainCoinType 主币编号
         * @param callbackUrl 回调地址
         * @param alias 地址别名
         * @return 地址信息
         */
        Result<ProjectAddress> AddressCreate(string mainCoinType, string callbackUrl, string alias);

        /**
         * 获取项目支持的币种
         */
        Result<ProjectCoins> GetProjectCoins();

        /**
         * 取消操作
         * @param cid 订单id
         */
        Result<OrderDepositCancel> DepositCancel(long cid);
    }
}
