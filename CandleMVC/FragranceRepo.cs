using System;
using System.Data;
using CandleMVC.Models;
using Dapper;

namespace CandleMVC
{
	public class FragranceRepo : IFragranceRepo
	{
        private readonly IDbConnection _conn;

		public FragranceRepo(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<Fragrance> GetAllFragrances()
        {
            return _conn.Query<Fragrance>("SELECT * FROM fragrances;");
        }

        public Fragrance GetFragrance(int id)
        {
            return _conn.QuerySingle<Fragrance>("SELECT * FROM fragrances WHERE FragranceID = @id", new { @id = id });
        }

        public void InsertFragrance(Fragrance fragranceToInsert)
        {
            _conn.Execute("INSERT INTO fragrances(Name, Price, Rating, TopNotes, MiddleNotes, BaseNotes, BlendsWith) VALUES (@name, @price, @rating, @note1, @note2, @note3, @blend);",
                new { @name = fragranceToInsert.Name, @price = fragranceToInsert.Price, @rating = fragranceToInsert.Rating, @note1 = fragranceToInsert.TopNotes, @note2 = fragranceToInsert.MiddleNotes, @note3 = fragranceToInsert.BaseNotes, @blend = fragranceToInsert.BlendsWith });
        }

        public void UpdateFragrance(Fragrance fragrance)
        {
            _conn.Execute("UPDATE fragrances SET Name = @name, Price = @price, Rating = @rating, TopNotes = @note1, MiddleNotes = @note2, BaseNotes = @note3, BlendsWith = @blend WHERE FragranceID = @id",
                new { @name = fragrance.Name, @price = fragrance.Price, @rating = fragrance.Rating, @note1 = fragrance.TopNotes, @note2 = fragrance.MiddleNotes, @note3 = fragrance.BaseNotes, @blend = fragrance.BlendsWith, @id = fragrance.FragranceID });
        }

        public void DeleteFragrance(Fragrance fragrance)
        {
            _conn.Execute("DELETE FROM fragrances WHERE FragranceID = @id;",
                new { @id = fragrance.FragranceID });
        }

        public IEnumerable<Note> GetNotes()
        {
            return _conn.Query<Note>("SELECT * FROM notes;");
        }

        public Fragrance AssignNote()
        {
            var noteList = GetNotes();
            var fragList = GetAllFragrances();
            var fragrance = new Fragrance();
            fragrance.Notes = noteList;
            fragrance.Blends = fragList;
            return fragrance;
        }
    }
}

