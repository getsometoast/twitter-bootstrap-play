using System;
using System.Collections.Generic;
using Nest;

namespace bootstrap.Models
{
	public class PlaylistRepository
	{
		private readonly ElasticClient _client;

		public PlaylistRepository(string host, string indexName)
		{
			var connectionSettings = new ConnectionSettings(new Uri(host));
			connectionSettings.SetDefaultIndex(indexName);
			_client = new ElasticClient(connectionSettings);
		}

		public Playlist Get(string id)
		{
			return _client.Get<Playlist>(id);
		}

		public string Add(Playlist playlist)
		{
			playlist.Id = Guid.NewGuid().ToString();
			return _client.Index(playlist).Id;
		}
	}

	public class Playlist
	{
		public List<Comment> Comments { get; set; }
		public List<Track> Tracks { get; set; }
		public int Plays { get; set; }
		public int Favourites { get; set; }
		public int Booms { get; set; }
		public string Genre { get; set; }
		public string ImageLocation { get; set; }
		public string Description { get; set; }
		public DateTime Ends { get; set; }
		public DateTime Begins { get; set; }
		public string Name { get; set; }
		public int BelongsToUserId { get; set; }
		public string Id { get; set; }
	}

	public class Track
	{
		public string Description { get; set; }
		public DateTime Depart { get; set; }
		public DateTime Arrive { get; set; }
		public Venue Venue { get; set; }
	}

	public class Venue
	{
		private readonly string _name;
		private readonly string _location;
		private readonly string _type;
		private readonly string _description;
		private readonly string _imageLocation;

		public Venue(string name, string location, string type, string description, string imageLocation)
		{
			_imageLocation = imageLocation;
			_description = description;
			_type = type;
			_location = location;
			_name = name;
		}

		public string Name
		{
			get { return _name; }
		}

		public string Location
		{
			get { return _location; }
		}

		public string Type
		{
			get { return _type; }
		}

		public string Description
		{
			get { return _description; }
		}

		public string ImageLocation
		{
			get { return _imageLocation; }
		}
	}

	public class Comment
	{
		private readonly string _title;
		private readonly string _author;
		private readonly string _body;

		public Comment(string title, string author, string body)
		{
			_body = body;
			_author = author;
			_title = title;
		}

		public string Title
		{
			get { return _title; }
		}

		public string Author
		{
			get { return _author; }
		}

		public string Body
		{
			get { return _body; }
		}
	}
}
