using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieInfo.DAL.Test
{
    [TestClass]
    public class UnitTestMovieRepository
    {
        [TestMethod]
        public void TestRetrivingMovieInformation()
        {
            //Arrange
            IMovieRepository db = new MovieRepository();

            //act
            var actual = db.GetMovieSummary();
            var enu = actual.GetEnumerator();

            //Assert
            Assert.IsTrue(enu.MoveNext(), "No data found in DB");
        }
    }
}
