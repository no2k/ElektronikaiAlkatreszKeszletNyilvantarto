using ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParameterListaUnitTest
{
    [TestClass]
    public class ParameterTeszt
    {
        [TestMethod]
        public void ParameterFelvitelTeszt()
        {
            Parameter tesztparameter = new Parameter(1, "Első Paraméter típus neve:", "10", 1);
            Assert.ThrowsException<ArgumentNullException>(() => new Parameter(1,"","2",1)); ;
            //StringAssert
            //CollectionAssert lista tömb stb adatszerkezetre...
        }
    }
}
