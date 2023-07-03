using System;
namespace CandleMVC.Models
{
	public class Note
	{
		public Note()
		{
		}

		public int NoteID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Profile { get; set; }
		public string Facts { get; set; }
	}
}

