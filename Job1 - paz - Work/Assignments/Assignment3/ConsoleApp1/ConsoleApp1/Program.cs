using System;
using System;
using System.Collections.Generic;

public class Seat
{
    public char Row { get; set; }
    public int Number { get; set; }

    public Seat(char row, int number)
    {
        Row = row;
        Number = number;
    }
}

public class Theater
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
            Console.WriteLine("Not enough seats available");
            return null;
        }
        else if (numSeats > TotalSeats - ReservedSeats.Count)
        {
            Console.WriteLine("Not enough contiguous seats available");
            return null;
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
            var seatmsg = string.Empty;
            foreach (Seat seat in allocatedSeats)
            {
                AllocatedSeatsMsg.Add(seat.Row.ToString() + seat.Number.ToString());
            }

            return string.Join(",", AllocatedSeatsMsg);
        }
    }
}

class Program
{
    static void Main()
    {
        Theater theater = new Theater();

        Console.WriteLine(theater.AllocateSeats(5));

        Console.WriteLine(theater.AllocateSeats(4));
        //// Allocate 4 more seats
        //allocatedSeats = theater.AllocateSeats(4);
        //if (allocatedSeats != null)
        //{
        //    foreach (Seat seat in allocatedSeats)
        //    {
        //        Console.WriteLine("Seat allocated: Row {0}, Seat {1}", seat.Row, seat.Number);
        //    }
        //}

        //// Try to allocate 7 more seats (not enough contiguous seats available)
        //allocatedSeats = theater.AllocateSeats(7);
        //if (allocatedSeats == null)
        //{
        //    Console.WriteLine("Seats not allocated");
        //}

        //// Allocate 1 more seat
        //allocatedSeats = theater.AllocateSeats(1);
        //if (allocatedSeats != null)
        //{
        //    foreach (Seat seat in allocatedSeats)
        //    {
        //        Console.WriteLine("Seat allocated: Row {0}, Seat {1}", seat.Row, seat.Number);
        //    }
        //}
    }
}
