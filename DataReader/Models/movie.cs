using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for movie
/// </summary>
public class Movie
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string actor;

    public string Actor
    {
        get { return actor; }
        set { actor = value; }
    }


	public Movie()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Movie(string name, string actor)
    {

        Name = name;
        Actor = actor;

    }


    public int insert() {

        return 0;

    
    }

    public List<Movie> getByActor(string actor) {
        // ClassEx enter your code here
        return null;
    }


}
