using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Models.Calculation
{
    public class KgPerSheetDto : CalculationsBaseDto
    {
        public double length_ { private set;  get; }
        public double width_ { private set;  get; }
        public KgPerSqrtMeterDto kgPerSqrtMeterDto_ { private set; get; }
        public KgPerSheetDto(CalculationsBaseDto kgPerSqrtMeterDto) {
            kgPerSqrtMeterDto_ = (KgPerSqrtMeterDto)kgPerSqrtMeterDto;
        }

        public override void AssignValues(List<Productssize> productsizes) {

            foreach (var dimensionType in productsizes) {

                if (dimensionType.Name == "Length") {
                    length_ = float.Parse(dimensionType.Value);
                } else if (dimensionType.Name == "Width") {
                    width_ = float.Parse(dimensionType.Value);
                }

            }

        }


    }
}
