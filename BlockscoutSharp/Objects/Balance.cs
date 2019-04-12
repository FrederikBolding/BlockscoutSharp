using BlockscoutSharp.Util;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class Balance
    {
        public BigInteger wei;

        public BigDecimal gwei;

        public BigDecimal eth;

        public Balance(BigInteger wei)
        {
            this.wei = wei;
            this.gwei = UnitConversion.Convert.FromWeiToBigDecimal(wei, UnitConversion.EthUnit.Gwei);
            this.eth = UnitConversion.Convert.FromWeiToBigDecimal(wei, UnitConversion.EthUnit.Ether);
        }
    }
}
