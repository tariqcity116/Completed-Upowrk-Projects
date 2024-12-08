using System;

public class Movie : IMovie
{
    private string title;
    private MovieGenre genre;
    private MovieClassification classification;
    private int duration; // the duration of this movie in minutes
    private int availablecopies; // the number of DVDs (copies) of this movie that are currently available in the library
    private int totalcopies; // the total number of copies of this movie

    public Movie(string t, MovieGenre g, MovieClassification c, int d, int n)
    {
        title = t;
        genre = g;
        classification = c;
        duration = d;
        availablecopies = n;
        totalcopies = n;
    }

    public string Title { get { return title; } set { title = value; } }

    public MovieGenre Genre { get { return genre; } set { genre = value; } }

    public MovieClassification Classification { get { return classification; } set { classification = value; } }

    public int Duration { get { return duration; } set { duration = value;  } }

    public int AvailableCopies { get { return availablecopies; } set { availablecopies = value;  } }

    public int TotalCopies { get { return totalcopies; } set { totalcopies = value;  } }

    public int CompareTo(IMovie another)
    {
        if (another == null) return 1;
        return this.title.CompareTo(another.Title);
    }

    public override string ToString()
    {
        return "Title: " + this.title + ", Genre: " + this.genre + ", Classification: " + this.classification + ", Duration: " + this.duration + ", Available Copies: " + this.availablecopies + ", Total Copies: " + this.totalcopies;
    }
}
