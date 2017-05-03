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
    public class PlayersListTests
    {
        [TestMethod()]
        public void LosujKolejnoscGraczyTest()
        {
            PlayersList x = new PlayersList();
            bool RandomWorkCorrectly = false;
            int myTry= 3;
            while ( RandomWorkCorrectly == false && myTry!=0)
            {
                x.Add(new PlayerItem() { Nazwa = "0" });
                x.Add(new PlayerItem() { Nazwa = "1" });
                x.Add(new PlayerItem() { Nazwa = "2" });
                x.Add(new PlayerItem() { Nazwa = "3" });
                x.UstalKolejnoscGraczy();
                for (int i = 0; i < x.Count; i++)
                {
                    if (!x[i].Nazwa.Equals((i%4).ToString()))
                    {
                        RandomWorkCorrectly = true;
                        break;
                    }
                }
                myTry--;
            }
            Assert.IsTrue(RandomWorkCorrectly);

        }
    }
}