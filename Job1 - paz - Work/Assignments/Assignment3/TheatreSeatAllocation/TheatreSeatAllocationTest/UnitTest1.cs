namespace TheatreSeatAllocationTest
{
    public class Tests
    {

        Theater _theater;
        [SetUp]
        public void Setup()
        {
            _theater = new Theater();
        }

        
        [Test]
      
        public void Test1()
        {
            var result1 = _theater.AllocateSeats(5);
            Assert.AreEqual("A1,A2,A3,A4,A5", result1);

            var result2 = _theater.AllocateSeats(4);
            Assert.AreEqual("B1,B2,B3,B4", result2);

            var result3 = _theater.AllocateSeats(7);
            Assert.AreEqual("Not enough seats available", result3);

            var result4 = _theater.AllocateSeats(1);
            Assert.AreEqual("B5", result4);

        }

    }
}