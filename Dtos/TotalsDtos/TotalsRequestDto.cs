using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techverx.Test.Project.Dtos.TotalsDtos
{
    public class TotalsRequestDto
    {
        public int Records { get; set; }
        public double Amount { get; set; }
        public long BranchHash { get; set; }
        public long AccountHash { get; set; }
    }
}
