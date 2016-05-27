using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieInfo;
using System.Collections.Generic;

namespace MovieInfo.BLL.Test
{
    [TestClass]
    public class UnitTestMovieInfoManager
    {
        [TestMethod]
        public void TestGettingAllMovies()
        {
            //Arrange
            Mock<DAL.IMovieRepository> mockMovRepository = new Mock<DAL.IMovieRepository>();
            mockMovRepository.Setup(obj => obj.GetMovieSummary("")).Returns(GetMockDALMovieList());

           MovieInfoManager movMgr = new MovieInfoManager(mockMovRepository.Object);
            var expected = GetMockDTOMovieList();

            //Act
            var actual = movMgr.GetMovieSummary();
            
            //Assert
            var expectedEnumarator = expected.GetEnumerator();
            var actulaEnumarator = actual.GetEnumerator();

            while (actulaEnumarator.MoveNext())
            {
                Assert.IsTrue(expectedEnumarator.MoveNext()); // making sure the count match
                Assert.AreEqual(expectedEnumarator.Current.Title,actulaEnumarator.Current.Title);
                Assert.AreEqual(expectedEnumarator.Current.Description, actulaEnumarator.Current.Description);
                Assert.AreEqual(expectedEnumarator.Current.Year, actulaEnumarator.Current.Year);
                Assert.AreEqual(expectedEnumarator.Current.Genre, actulaEnumarator.Current.Genre);
            }
        }

        private List<DAL.EntityModel.Movie> GetMockDALMovieList()
        {
            var mockMovList = new List<DAL.EntityModel.Movie>();
            mockMovList.Add(new DAL.EntityModel.Movie
            {
                Name = "Test Mov 1",
                Description = "Test Mov 1 Descrption",
                Genre = (int)DTO.Genres.Action,
                Id = 1,
                Year = new DateTime(2015, 1, 1)
            });
            mockMovList.Add(new DAL.EntityModel.Movie
            {
                Name = "Test Mov 2",
                Description = "Test Mov 2 Descrption",
                Genre = (int)DTO.Genres.Cartoon,
                Id = 1,
                Year = new DateTime(2015, 1, 1)
            });
            mockMovList.Add(new DAL.EntityModel.Movie
            {
                Name = "Test Mov 3",
                Description = "Test Mov 3 Descrption",
                Genre = (int)DTO.Genres.Comedy,
                Id = 1,
                Year = new DateTime(2015, 1, 1)
            });
            mockMovList.Add(new DAL.EntityModel.Movie
            {
                Name = "Test Mov 4",
                Description = "Test Mov 4 Descrption",
                Genre = (int)DTO.Genres.Drama,
                Id = 1,
                Year = new DateTime(2015, 1, 1)
            });
            mockMovList.Add(new DAL.EntityModel.Movie
            {
                Name = "Test Mov 5",
                Description = "Test Mov 5 Descrption",
                Genre = (int)DTO.Genres.Scifi,
                Id = 1,
                Year = new DateTime(2015, 1, 1)
            });
            return mockMovList;
        }
        private IEnumerable<DTO.Movie> GetMockDTOMovieList()
        {
            var mockMovList = new List<DTO.Movie>();
            mockMovList.Add(new DTO.Movie
            {
                Title = "Test Mov 1",
                Description = "Test Mov 1 Descrption",
                Genre = DTO.Genres.Action,
                Id = 1,
                Year = 2015
            });
            mockMovList.Add(new DTO.Movie
            {
                Title = "Test Mov 2",
                Description = "Test Mov 2 Descrption",
                Genre = DTO.Genres.Cartoon,
                Id = 1,
                Year = 2015
            });
            mockMovList.Add(new DTO.Movie
            {
                Title = "Test Mov 3",
                Description = "Test Mov 3 Descrption",
                Genre = DTO.Genres.Comedy,
                Id = 1,
                Year = 2015
            });
            mockMovList.Add(new DTO.Movie
            {
                Title = "Test Mov 4",
                Description = "Test Mov 4 Descrption",
                Genre = DTO.Genres.Drama,
                Id = 1,
                Year = 2015
            });
            mockMovList.Add(new DTO.Movie
            {
                Title = "Test Mov 5",
                Description = "Test Mov 5 Descrption",
                Genre = DTO.Genres.Scifi,
                Id = 1,
                Year = 2015
            });
            return mockMovList;
        }
    }
}
