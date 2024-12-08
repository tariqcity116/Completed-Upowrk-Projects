using NUnit.Framework.Interfaces;
using NUnit.Framework;
using NUnit.Framework;


namespace MovieSorter
{
   
    public class MovieTests
    {
        MovieCollection movieCollection ;
        
        public  MovieTests()
        {
           movieCollection = new MovieCollection();
            IMovie movie1 = new Movie(t: "The Shawshank Redemption", g: MovieGenre.Drama, c: MovieClassification.PG, d: 90, n: 1);
            IMovie movie2 = new Movie(t: "The Godfather", g: MovieGenre.Drama, c: MovieClassification.M, d: 120, n: 1);
         
            movieCollection.Insert(movie1);
            movieCollection.Insert(movie2);

        }

        [Test("Movie.IsEmpty() should return false")]
        public TestResult Checking_IsEmpty_Not()
        {
            // Arrange

            bool expectedResult = false;

            // Act
            bool actualResult = movieCollection.IsEmpty();

            
            return new TestResult(null, expectedResult.ToString(), actualResult.ToString(), actualResult == false); 
        }


        [Test("Movie.Insert(movie3) should return true")]
        public TestResult Checking_Insert()
        {
            // Arrange
            IMovie movie3 = new Movie(t: "Terminator", g: MovieGenre.Action, c: MovieClassification.G, d: 100, n: 2);

            bool expectedResult = true;

            // Act
            bool actualResult = movieCollection.Insert(movie3);

            // Assert
           
            return new TestResult("Terminator", expectedResult.ToString(), actualResult.ToString(), actualResult == true);
        }

        [Test("Movie.CompareTo(movie2) should return 1")]
        public TestResult Checking_CompareTo_Greater()
        {
            // Arrange

            IMovie movie1 = new Movie(t: "The Shawshank Redemption", g: MovieGenre.Drama, c: MovieClassification.PG, d: 90, n: 1);
            IMovie movie2 = new Movie(t: "The Godfather", g: MovieGenre.Drama, c: MovieClassification.M, d: 120, n: 1);
            int expectedResult = 1;

            // Act
            int actualResult = movie1.CompareTo(movie2);

            // Assert
            return new TestResult("The Godfather", expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.CompareTo(movie2) should return 0")]
        public TestResult Checking_CompareTo_equal()
        {
            // Arrange

            IMovie movie1 = new Movie(t: "The Godfather", g: MovieGenre.Drama, c: MovieClassification.M, d: 120, n: 1);
            IMovie movie2 = new Movie(t: "The Godfather", g: MovieGenre.Drama, c: MovieClassification.M, d: 120, n: 1);
            int expectedResult = 0;

            // Act
            int actualResult = movie1.CompareTo(movie2);

            // Assert
            return new TestResult("The Godfather", expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.CompareTo(movie2) should return -1")]
        public TestResult Checking_CompareTo_Less()
        {
            // Arrange

            IMovie movie1 = new Movie(t: "The Shawshank Redemption", g: MovieGenre.Drama, c: MovieClassification.PG, d: 90, n: 1);
            IMovie movie2 = new Movie(t: "The Godfather", g: MovieGenre.Drama, c: MovieClassification.M, d: 120, n: 1);
            int expectedResult = -1;

            // Act
            int actualResult = movie2.CompareTo(movie1);

            // Assert
            return new TestResult("The Shawshank Redemption", expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.Insert(movie1) should return false")]
        public TestResult Checking_Insert_IfExist()
        {
            // Arrange

            IMovie movie1 = new Movie(t: "The Shawshank Redemption", g: MovieGenre.Drama, c: MovieClassification.PG, d: 90, n: 1);
            bool expectedResult = false;

            // Act
            bool actualResult = movieCollection.Insert(movie1);

            // Assert
            return new TestResult("The Shawshank Redemption", expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.ToString() should return string")]
        public TestResult Checking_ToString()
        {
            // Arrange

            IMovie movie1 = new Movie(t: "The Shawshank Redemption", g: MovieGenre.Drama, c: MovieClassification.PG, d: 90, n: 1);
            string expectedResult = "Title: " + movie1.Title + ", Genre: " + movie1.Genre + ", Classification: " + movie1.Classification + ", Duration: " + movie1.Duration + ", Available Copies: " + movie1.AvailableCopies + ", Total Copies: " + movie1.TotalCopies;

            // Act
            string actualResult = movie1.ToString();

            // Assert
            return new TestResult(null, expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.Delete(movie1) should return true")]
        public TestResult Checking_Delete()
        {
            // Arrange

            IMovie movie1 = new Movie(t: "The Shawshank Redemption", g: MovieGenre.Drama, c: MovieClassification.PG, d: 90, n: 1);
            bool expectedResult = true;

            // Act
            bool actualResult = movieCollection.Delete(movie1);

            // Assert
            return new TestResult(null, expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.Search(moviename) should return 1")]
        public TestResult Checking_Search_NotExist()
        {
            // Arrange

            IMovie movie1 = new Movie(t: "The Shawshank Redemption", g: MovieGenre.Drama, c: MovieClassification.PG, d: 90, n: 1);
            int expectedResult = 1;
            string movieTitle = "The Shawshank Redemption";

            // Act
            IMovie movie = movieCollection.Search(movieTitle);
            int actualResult = movie1.CompareTo(movie);

            // Assert
            return new TestResult("The Godfather", expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.Search(movieName) should return 0")]
        public TestResult Checking_Search_Exist()
        {
            // Arrange

            IMovie movie2 = new Movie(t: "The Godfather", g: MovieGenre.Drama, c: MovieClassification.M, d: 120, n: 1);
            string movieTitle = "The Godfather";
            int expectedResult = 0;

            // Act
            IMovie movie = movieCollection.Search(movieTitle);
            int actualResult = movie2.CompareTo(movie);

            // Assert
            return new TestResult("The Godfather", expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }


        [Test("Movie.NoDVDs() should return 1")]
        public TestResult Checking_NoDVDs()
        {
            int expectedResult = 1;
            // Act
            int actualResult = movieCollection.NoDVDs();

            // Assert
            return new TestResult(null, expectedResult.ToString(), actualResult.ToString(), actualResult > 0);
        }


        [Test("Movie.ToArray() should return number")]
        public TestResult Checking_ToArray_Exist()
        {
            // Act
            var lstMovies = movieCollection.ToArray();
            int actualResult = lstMovies.Length;

            // Assert
            return new TestResult(null, null, actualResult.ToString(), actualResult > 0);
        }

        [Test("Movie.NoDVDs() should return 0")]
        public TestResult Checking_Clean()
        {
            // Arrange
            int expectedResult = 0;

            // Act
            movieCollection.Clear();
            int actualResult = movieCollection.NoDVDs();

            // Assert
            return new TestResult(null, expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.ToArray() should return 0")]
        public TestResult Checking_ToArray_NotExist()
        {
            // Arrange
            int expectedResult = 0;

            // Act
            movieCollection.Clear();
            var lstMovies = movieCollection.ToArray();
            int actualResult = lstMovies.Length;

            // Assert
            return new TestResult(null, expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

        [Test("Movie.IsEmpty() should return true")]
        public TestResult Checking_IsEmpty()
        {
            // Arrange

            bool expectedResult = true;

            // Act
            movieCollection.Clear();
            bool actualResult = movieCollection.IsEmpty();

            // Assert
            return new TestResult(null, expectedResult.ToString(), actualResult.ToString(), actualResult == expectedResult);
        }

    }
}