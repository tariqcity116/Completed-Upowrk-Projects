using System;

public enum MovieGenre
{
    Action = 1,
    Comedy = 2,
    History = 3,
    Drama = 4,
    Western = 5
}

public enum MovieClassification
{
    G = 1,
    PG = 2,
    M = 3,
    M15Plus = 4
}


public interface IMovie
{
    string Title { get; set; }

    MovieGenre Genre { get; set; }

    MovieClassification Classification { get; set; }

    int Duration { get; set; }

    int AvailableCopies { get; set; }

    public int TotalCopies { get; set; }


    // This movie's title is compared to another movie's title.
    // Pre-condition: nil
    // Post-condition:  return -1, if this movie's title is less than another movie's title by dictionary order.
    //                  return 0, if this movie's title equals to another movie's title by dictionary order.
    //                  return +1, if this movie's title is greater than another movie's title by dictionary order.
    public int CompareTo(IMovie another);


    // Return a string containing the title, genre, classification, duration, and the number of copies of this movie currently in the library. 
    // Pre-condition: nil
    // Post-condition: A string containing the title, genre, classification, duration,
    //                 and the number of available copies of this movie has been returned.
    string ToString();

}

