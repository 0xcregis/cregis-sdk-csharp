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
    public class OrderDeposit
    {
        /**
         * 充值订单编号
         */
        public long? cid{ get; set; }
        /**
         * 充值地址
         */
        public string address{ get; set; }
    }
}
