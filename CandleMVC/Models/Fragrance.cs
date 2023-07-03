using System;
using System.ComponentModel.DataAnnotations;

namespace CandleMVC.Models
{
	public class Fragrance
	{
		public Fragrance()
		{
		}

		public int FragranceID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		[Range(0, 5)]
        public int Rating { get; set; }
		public string NewOrNot { get; set; }
		public string TopNotes { get; set; }
		public string MiddleNotes { get; set; }
		public string BaseNotes { get; set; }
		public string BlendsWith { get; set; }
		public string Colors { get; set; }
		public string BrandIdeas { get; set; }
		public string URL { get; set; }
		public IEnumerable<Note> Notes { get; set; }
		public IEnumerable<Fragrance> Blends { get; set;}
	}
}

