using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Models.Calculation {
    public class KgPerSqrtMeterDto : CalculationsBaseDto {

        protected const int Density = 8500;

        protected const int DivideBy = 1000;

        private double thickness_;

        public double Thickness_ {
            get { return thickness_; }
            set {
                thickness_ = value;
            }
        }

        public override void AssignValues(List<Productssize> productsizes) {

            foreach (var dimensionType in productsizes) {

                if (dimensionType.Name == "Thickness") {
                    thickness_ = float.Parse(dimensionType.Value);
                }

            }
            
        }

        public int getValue() {
            return Density / DivideBy;
        }
    }
}
