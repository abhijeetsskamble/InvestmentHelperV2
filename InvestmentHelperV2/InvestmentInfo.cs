using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentHelperV2
{
    public class InvestmentInfo
    {
        public int CustomerId { get; set; }

        public string DOB { get; set; }

        public double Income { get; set; }

        public double OtherIncome { get; set; }

        public double Rent { get; set; }

        public string EF { get; set; }

        public bool NPS { get; set; }

        public string Risk { get; set; }
    }
}
