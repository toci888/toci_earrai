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
        protected double length_;
        protected double width_;
        protected double thickness_;
        public double thickness { get; private set; }

        public double Length_ {
            get { return length_; }
            set { length_ = value; }
        }

        public double Thickness_ {
            get { return thickness_; }
            set { thickness_ = value; }
        }

        public double Width_ {
            get { return width_; }
            set { width_ = value; }
        }


        public override void AssignValues(List<Productssize> productsizes) {

            foreach (var dimensionType in productsizes) {

                if (dimensionType.Name == "Length") {
                    Length_ = float.Parse(dimensionType.Value);
                } else if (dimensionType.Name == "Width") {
                    Width_ = float.Parse(dimensionType.Value);
                } else if (dimensionType.Name == "Thickness") {
                    Width_ = float.Parse(dimensionType.Value);
                }

            }

        }

    }
}
