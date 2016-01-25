using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    class CourtFilingTests : Driver
    {
        public void RunFirst()
        {
            Login.LoginPortal();
            Screens.cf.clickResetButton();
        }
    }
}
