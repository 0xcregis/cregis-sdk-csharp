using java.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cregis.Core.Model
{
    public class Coin
    {
        /// <summary>
        /// author scottcheng
        /// version 1.0.0
        /// date 2023/11/17
        /// </summary>
        /**
         * 币种别名
         */
        public string name { get; set; }
        /**
         * 币种全称
         */
        public string coinName { get; set; }
        /**
         * 币种单位
         */
        public string symbol { get; set; }
        /**
         * 币种类型
         * 0主币 1代币
         */
        public int? type { get; set; }
        /**
         * 主币类型
         */
        public string mainCoinType { get; set; }
        /**
         * 代币类型
         */
        public string coinType { get; set; }
        /**
         * 币种精度
         */
        public string decimals { get; set; }
        /**
       * 余额
       */
        public string balance { get; set; }
        /**
         * 余额
         */
        public BigDecimal getBalance()
        {
            if (balance != null && balance != "")
                return BigDecimal.valueOf(double.Parse(balance));
            return BigDecimal.ZERO;
        }
        /**
         * 币种logo
         */
        public string logo { get; set; }
    }
}
