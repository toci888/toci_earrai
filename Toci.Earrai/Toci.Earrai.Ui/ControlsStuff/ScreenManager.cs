using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Ui.ControlsStuff
{
    public class ScreenManager
    {
        protected double ResolutionX;
        protected double ResolutionY;

        private const double DesiredScreenX = 1920;
        private const double DesiredScreenY = 1080;

        protected double ScreenXQuotient;
        protected double ScreenYQuotient;

        public ScreenManager(int resolutionX, int resolutionY)
        {
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;

            ScreenXQuotient = ResolutionX / DesiredScreenX;
            ScreenYQuotient = ResolutionY / DesiredScreenY;
        }

        public virtual Size GetDimensions(int clientX, int clientY)
        {
            int x = (int)(clientX * ScreenXQuotient);
            int y = (int)(clientY * ScreenYQuotient);

            return new Size(x, y);
        }

        public virtual Point GetLocation(int clientX, int clientY)
        {
            int x = (int)(clientX * ScreenXQuotient);
            int y = (int)(clientY * ScreenYQuotient);

            return new Point(x, y);
        }
    }
}
