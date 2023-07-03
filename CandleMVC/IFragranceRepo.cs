using System;
using System.Collections.Generic;
using CandleMVC.Models;

namespace CandleMVC
{
	public interface IFragranceRepo
	{
		public IEnumerable<Fragrance> GetAllFragrances();

		public Fragrance GetFragrance(int id);

		public void UpdateFragrance(Fragrance fragrance);

		public void InsertFragrance(Fragrance fragranceToInsert);

		public void DeleteFragrance(Fragrance fragrance);

		public IEnumerable<Note> GetNotes();

		public Fragrance AssignNote();
	}
}

