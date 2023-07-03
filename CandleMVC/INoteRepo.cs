using System;
using CandleMVC.Models;

namespace CandleMVC
{
	public interface INoteRepo
	{
        public IEnumerable<Note> GetAllNotes();
		public Note GetNote(int id);
		public void UpdateNote(Note note);
		public void InsertNote(Note note);
		public void DeleteNote(Note note);
	}
}

