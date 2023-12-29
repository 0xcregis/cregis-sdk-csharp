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
    public class ProjectCoins
    {
        public List<ProjectCoin> payout_coins { get; set; }
        public List<ProjectCoin> address_coins { get; set; }
        public List<ProjectCoin> order_coins { get; set; }
    }
}
