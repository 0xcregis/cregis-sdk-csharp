using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cregis.Core.Model
{
    /// <summary>
    /// author scottcheng
    /// version 1.0.0
    /// date 2023/11/17
    /// </summary>
    public class PayoutCallback
    {
        /**
         * 项目编号
         */
        public long? pid{ get; set; }

        /**
         * 订单号
         */
        public long? cid{ get; set; }
        /**
         * 地址
         */
        public string address{ get; set; }
        /**
         * 链编号
         */
        public string chain_id{ get; set; }
        /**
         * 代币编号
         */
        public string token_id{ get; set; }
        /**
         * 币种标识
         */
        public string currency{ get; set; }
        /**
         * 金额
         */
        public string amount{ get; set; }
        /**
         * 调用方业务编号
         */
        public string third_party_id{ get; set; }
        /**
         * 备注
         */
        public string remark{ get; set; }
        /**
         * 状态
         */
        public int? status{ get; set; }
        /**
         * 交易哈希
         */
        public string txid{ get; set; }
        /**
         * 区块高度
         */
        public string block_height{ get; set; }
        /**
         * 区块时间
         */
        public long? block_time{ get; set; }
        /**
         * 6位随机字符串
         */
        public string nonce{ get; set; }
        /**
         * 时间戳
         */
        public long? timestamp{ get; set; }
        /**
         * 签名
         */
        public string sign{ get; set; }
    }
}
