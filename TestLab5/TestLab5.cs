using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestLab5
{
    [TestClass]
    public class TouringTrip
    {
        [TestMethod]
        public void LastLetter() // остання літера прізвищя
        {
            Lab5.Task1.TouringTrip tt = new Lab5.Task1.TouringTrip();
            List<Lab5.Task1.TouringTrip> list = new List<Lab5.Task1.TouringTrip>
            {
                new Lab5.Task1.TouringTrip("1", "Назва", "Прізвище", "Місто", "2021", "4")
            };

            char res = tt.LastLetter(list, "1").ToCharArray()[0];
            Assert.AreEqual(res, 'е');
        }
    }
}
