using System;
namespace CandleMVC.Models
{
	public class Candle
	{
		public Candle()
		{
		}

		public int CandleID { get; set; }
		public string Name { get; set; }
		public string Fragrances { get; set; }
		public string Notes { get; set; }
		public string Container { get; set; }
		public string Wick { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }
        public IEnumerable<Fragrance> FragrancesList { get; set; }
		public IEnumerable<Note> NotesList { get; set; }
	}
}

