namespace TheatreSeatAllocationTest
{
    internal class Theater : ITheater
    {

        private readonly int SeatsPerRow = 5;
        private readonly int TotalSeats = 15;
        private readonly List<Seat> AvailableSeats = new List<Seat>();
        private readonly List<Seat> ReservedSeats = new List<Seat>();
        private readonly List<string> AllocatedSeatsMsg = new List<string>();

        public Theater()
        {
            for (char row = 'A'; row <= 'C'; row++)
            {
                for (int seatNum = 1; seatNum <= SeatsPerRow; seatNum++)
                {
                    AvailableSeats.Add(new Seat(row, seatNum));
                }
            }
        }

        public string AllocateSeats(int numSeats)
        {
            AllocatedSeatsMsg.Clear();
            if (numSeats > AvailableSeats.Count)
            {
               // Console.WriteLine("Not enough seats available");
                return "Not enough seats available";
            }
            else if (numSeats > TotalSeats - ReservedSeats.Count)
            {
              //  Console.WriteLine("Not enough contiguous seats available");
                return "Not enough contiguous seats available";
            }
            else
            {
                List<Seat> allocatedSeats = new List<Seat>();
                for (int i = 0; i < numSeats; i++)
                {
                    allocatedSeats.Add(AvailableSeats[0]);
                    AvailableSeats.RemoveAt(0);
                }
                ReservedSeats.AddRange(allocatedSeats);
              
                foreach (Seat seat in allocatedSeats)
                {
                    AllocatedSeatsMsg.Add(seat.Row.ToString() + seat.Number.ToString());  
                }

                return string.Join(",", AllocatedSeatsMsg);
            }
        }
    }
}
