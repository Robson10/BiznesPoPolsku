using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiznesPoPolskuWF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesPoPolskuWF.Tests
{
    [TestClass()]
    public class KoscTests
    {
        [TestMethod()]
        public void RzutKosciaTest()
        {
            int value;
            for (int i = 0; i < 10000; i++)
            {
                value = Kosc.RzutKoscia();
                if (value < 1 || value > 6) { Assert.Fail(); break; }
            }
            Assert.IsTrue(true);
        }
    }
}