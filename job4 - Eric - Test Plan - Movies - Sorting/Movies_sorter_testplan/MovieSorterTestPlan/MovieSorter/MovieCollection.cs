using System;

// A class that models a node of a binary search tree
// An instance of this class is a node in the binary search tree 
public class BTreeNode
{
	private IMovie movie;
	private BTreeNode? lchild; // reference to left child 
	private BTreeNode? rchild; // reference to right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode? LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode? RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicate movie in this movie collection.
public class MovieCollection : IMovieCollection
{
	private BTreeNode? root; // the root of the binary search tree in which movies are stored.
	private int count; // the number of movies currently stored in this movie collection. 

	public int Number { get { return count; } }

	// an empty movie collection.
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	public bool IsEmpty()
	{
		// to be implemented
		return count == 0;
	}


	public bool Insert(IMovie movie)
    {
        if (root == null)
        {
            root = new BTreeNode(movie);
            count++;
            return true;
        }

        BTreeNode parent = null;
        BTreeNode current = root;

        while (current != null)
        {
            int cmp = movie.Title.CompareTo(current.Movie.Title);

            if (cmp == 0) // movie already exists in the tree
            {
                return false;
            }

            parent = current;

            if (cmp < 0)
            {
                current = current.LChild;
            }
            else
            {
                current = current.RChild;
            }
        }

        // create a new node for the movie and add it to the tree
        BTreeNode newNode = new BTreeNode(movie);

        if (movie.Title.CompareTo(parent.Movie.Title) < 0)
        {
            parent.LChild = newNode;
        }
        else
        {
            parent.RChild = newNode;
        }

        count++;
        return true;
    }


	public bool Delete(IMovie movie)
    {
        // Find the node to delete
        BTreeNode? currentNode = root;
        BTreeNode? parentNode = null;
        while (currentNode != null && currentNode.Movie.Title != movie.Title)
        {
            parentNode = currentNode;
            if (movie.Title.CompareTo(currentNode.Movie.Title) < 0)
            {
                currentNode = currentNode.LChild;
            }
            else
            {
                currentNode = currentNode.RChild;
            }
        }

        // If the movie was not found, return false
        if (currentNode == null)
        {
            return false;
        }

        // If the node has two children, replace it with the minimum node in the right subtree
        if (currentNode.LChild != null && currentNode.RChild != null)
        {
            BTreeNode? minParent = currentNode;
            BTreeNode minNode = currentNode.RChild;
            while (minNode.LChild != null)
            {
                minParent = minNode;
                minNode = minNode.LChild;
            }
            currentNode.Movie = minNode.Movie;
            currentNode = minNode;
            parentNode = minParent;
        }

        // If the node has one or no child, replace it with its child (or null)
        BTreeNode? childNode = currentNode.LChild != null ? currentNode.LChild : currentNode.RChild;
        if (parentNode == null)
        {
            root = childNode;
        }
        else if (parentNode.LChild == currentNode)
        {
            parentNode.LChild = childNode;
        }
        else
        {
            parentNode.RChild = childNode;
        }

        // Decrement the count and return true
        count--;
        return true;
    }


    public IMovie? Search(string movietitle)
    {
        BTreeNode currentNode = root;
        while (currentNode != null)
        {
            int comparisonResult = movietitle.CompareTo(currentNode.Movie.Title);
            if (comparisonResult < 0) // movie title is less than current node's movie title
            {
                currentNode = currentNode.LChild;
            }
            else if (comparisonResult > 0) // movie title is greater than current node's movie title
            {
                currentNode = currentNode.RChild;
            }
            else // movie title is equal to current node's movie title
            {
                return currentNode.Movie;
            }
        }
        return null; // movie not found
    }


    public int NoDVDs()
    {
        if (root == null)
        {
            return 0;
        }
        return CountDVDs(root);
    }


    private int CountDVDs(BTreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        return node.Movie.AvailableCopies + CountDVDs(node.LChild) + CountDVDs(node.RChild);
    }


    public IMovie[] ToArray()
    {
        IMovie[] movieArray = new IMovie[count];
        int index = 0;
        BTreeNode currentNode = root;
        BTreeNode predecessor;

        while (currentNode != null)
        {
            if (currentNode.LChild == null)
            {
                movieArray[index++] = currentNode.Movie;
                currentNode = currentNode.RChild;
            }
            else
            {
                predecessor = currentNode.LChild;
                while (predecessor.RChild != null)
                {
                    predecessor = predecessor.RChild;
                }
                predecessor.RChild = currentNode;
                BTreeNode temp = currentNode;
                currentNode = currentNode.LChild;
                temp.LChild = null;
            }
        }
        return movieArray;
    }


    public void Clear()
    {
        root = null;
        count = 0;
    }
}

