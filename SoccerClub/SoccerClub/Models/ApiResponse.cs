namespace SoccerClub.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string PublishedAt { get; set; }
       
    }

	public class Competition
	{
		public int id { get; set; }
		public string name { get; set; }
		public string code { get; set; }
		public string type { get; set; }
		public string emblem { get; set; }
	}

	public class Filters
	{
		public string season { get; set; }
		public int limit { get; set; }
	}

	public class Players
	{
		public int id { get; set; }
		public string name { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string dateOfBirth { get; set; }
		public string nationality { get; set; }
		public string section { get; set; }
		public object position { get; set; }
		public int? shirtNumber { get; set; }
		public DateTime lastUpdated { get; set; }
	}

	public class Root
	{
		public int count { get; set; }
		public Filters filters { get; set; }
		public Competition competition { get; set; }
		public Season season { get; set; }
		public List<Scorer> scorers { get; set; }
	}

	public class Scorer
	{
		public Players player { get; set; }
		public Teams team { get; set; }
		public int playedMatches { get; set; }
		public int goals { get; set; }
		public int? assists { get; set; }
		public int? penalties { get; set; }
	}

	public class Season
	{
		public int id { get; set; }
		public string startDate { get; set; }
		public string endDate { get; set; }
		public int currentMatchday { get; set; }
		public object winner { get; set; }
	}

	public class Teams
	{
		public int id { get; set; }
		public string name { get; set; }
		public string shortName { get; set; }
		public string tla { get; set; }
		public string crest { get; set; }
		public string address { get; set; }
		public string website { get; set; }
		public int founded { get; set; }
		public string clubColors { get; set; }
		public string venue { get; set; }
		public DateTime lastUpdated { get; set; }
	}




}
