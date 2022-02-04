using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Models
{
    public class PricingDto
    {
        public double? PoundsPerTonne { get; set; }

        public double? Sheet { get; set; }

        public double? Meter { get; set; }

        public double? SquareMeter { get; set; }

        public double? Length { get; set; }

        public double? kgPerSqrtMeter { get; set; }

        public double? kgPerSheet { get; set; }

        public double? PoundsPerSheet { get; set; }

        public double? PoundsPerMeter { get; set; }

        public double? PoundsPerSquareMeter { get; set; }

        public double? PoundsPerLength { get; set; }

        public double? KgPerMeter { get; set; }

        public double? TotalWeight { get; set; }

        public double? TotalMeters { get; set; }

        public double? StockTakeValue { get; set; }

        public double? TotalSquareMeters { get; set; }

    }
}
