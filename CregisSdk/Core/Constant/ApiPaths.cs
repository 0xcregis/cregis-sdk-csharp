using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cregis.Core.Constant
{
    /// <summary>
    /// author scottcheng
    /// version 1.0.0
    /// date 2023/11/17
    /// </summary>
    public class ApiPaths
    {

        public static string URL_PREFIX = "/api/v1";

        public static string PAYOUT = URL_PREFIX + "/payout";

        public static string PAYOUT_QUERY = URL_PREFIX + "/payout/query";

        public static string DEPOSIT = URL_PREFIX + "/deposit";

        public static string DEPOSIT_QUERY = URL_PREFIX + "/deposit/query";

        public static string DEPOSIT_CANCEL = URL_PREFIX + "/deposit/cancel";

        public static string ADDRESS_LEGAL = URL_PREFIX + "/address/legal";

        public static string ADDRESS_CREATE = URL_PREFIX + "/address/create";

        public static string ADDRESS_INNER = URL_PREFIX + "/address/inner";

        public static string PROJECT_COINS = URL_PREFIX + "/coins";

    }
}
