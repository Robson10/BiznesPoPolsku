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
        public void RzutKostkaTest_ValueBetweenRange1and6()
        {
            //Arrange
            PlayersList x = new PlayersList();
            for (int i = 0; i < 100000; i++)
            {
                //act
                int z = x.RzutKostka();

                //assert
                if (z < 1 || z > 6)
                    Assert.Fail();
            }
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void RzutKostkaTest_MaxValue6()
        {
            //Arrange
            PlayersList x = new PlayersList();
            bool result = false;
            for (int i = 0; i < 100000; i++)
            {
                //act
                int z = x.RzutKostka();

                //assert
                if (z == 6)
                    result = true;
            }
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void RzutKostkaTest_MinValue1()
        {
            //Arrange
            PlayersList x = new PlayersList();
            bool result = false;
            for (int i = 0; i < 100000; i++)
            {
                //act
                int z = x.RzutKostka();

                //assert
                if (z == 1)
                    result = true;
            }
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void RzutKostkaTest_ChangeFlagCzyRzucanoOnTrue()
        {
            //Arrange
            PlayersList x = new PlayersList();
            bool result = false;
            if (Kosc.CzyRzucano==false)
            {
                //act
                x.RzutKostka();
                result = Kosc.CzyRzucano;
                //assert
                Assert.IsTrue(result);
            }
        }
        [TestMethod()]
        public void NastepnaTuraTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void PrzejrzyjStatystykiTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void UtrataZawoduTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void PobierzOplateZaStartTest()
        {
            //Arrange
            PlayersList x = new PlayersList()
            {
                new PlayerItem() { Nazwa = "gracz1" },
                new PlayerItem() { Nazwa = "gracz2" },
                new PlayerItem() { Nazwa = "gracz3" },
                new PlayerItem() { Nazwa = "gracz4" }
            };
            //act
            x.PobierzOplateZaStart();
            //assert
            Assert.AreEqual(300,x.AktualnyGracz.Saldo);
        }

        [TestMethod()]
        public void OglosBankructwoGraczaTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void LosujKolejnoscGraczyTest()
        {
            //arrange
            PlayersList x = new PlayersList();
            bool RandomWorkCorrectly = false;
            int myTry = 3;
            while (RandomWorkCorrectly == false && myTry != 0)
            {
                x.Add(new PlayerItem() { Nazwa = "0" });
                x.Add(new PlayerItem() { Nazwa = "1" });
                x.Add(new PlayerItem() { Nazwa = "2" });
                x.Add(new PlayerItem() { Nazwa = "3" });
                
                x.UstalKolejnoscGraczy();//act
                for (int i = 0; i < x.Count; i++)
                {
                    if (!x[i].Nazwa.Equals((i % 4).ToString()))
                    {
                        RandomWorkCorrectly = true;
                        break;
                    }
                }
                myTry--;
            }
            //assert
            Assert.IsTrue(RandomWorkCorrectly);
        }

        [TestMethod()]
        public void ZaplacInnemuGraczowiTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void PrzydzielSaldoTest()
        {
            //Arrange
            PlayersList x = new PlayersList()
            {
                new PlayerItem() { Nazwa = "gracz1" },
                new PlayerItem() { Nazwa = "gracz2" },
                new PlayerItem() { Nazwa = "gracz3" },
                new PlayerItem() { Nazwa = "gracz4" }
            };
            //act
            x.PrzydzielSaldo();
            //assert
            Assert.AreEqual(20000, x.AktualnyGracz.Saldo);
        }

        [TestMethod()]
        public void RezygnacjaTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void InwestujTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void ZastosujSieDoInstrukcjiKartyTest()
        {
            //Arrange
            //act
            //assert
            Assert.Fail();
        }
    }
}