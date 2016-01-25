using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTests.Tests;

namespace SeleniumTests
{
    class Screens
    {
        #region Court Filing

        private static CourtFiling _cf;

        public static CourtFiling cf
        {
            get
            {
                if (_cf == null)
                {
                    _cf = getCf();
                }

                return _cf;
            }
        }

        private static CourtFiling getCf()
        {
            return new CourtFiling();
        }

        #endregion

        #region HomeScreen

        private static HomeScreen _hs;

        public static HomeScreen hs
        {
            get
            {
                if (_hs == null)
                {
                    _hs = getHs();
                }

                return _hs;
            }
        }

        private static HomeScreen getHs()
        {
            return new HomeScreen();
        }

        #endregion
    }
}
