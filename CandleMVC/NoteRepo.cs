using System;
using System.Data;
using CandleMVC.Models;
using Dapper;

namespace CandleMVC
{
	public class NoteRepo : INoteRepo
	{
		private readonly IDbConnection _conn;

		public NoteRepo(IDbConnection conn)
		{
			_conn = conn;
		}

        public void DeleteNote(Note note)
        {
            _conn.Execute("DELETE FROM notes WHERE NoteID = @id;", new { @id = note.NoteID });
        }

        public IEnumerable<Note> GetAllNotes()
        {
			return _conn.Query<Note>("SELECT * FROM notes;");
        }

        public Note GetNote(int id)
        {
            return _conn.QuerySingle<Note>("SELECT * FROM notes WHERE NoteID = @id", new { @id = id });
        }

        public void InsertNote(Note noteToInsert)
        {
            _conn.Execute("INSERT INTO notes (Name, Description, Profile, Facts) VALUES (@name, @description, @profile, @facts);",
                new { @name = noteToInsert.Name, @description = noteToInsert.Description, @profile = noteToInsert.Profile, @facts = noteToInsert.Facts });
        }

        public void UpdateNote(Note note)
        {
            _conn.Execute("UPDATE notes SET Name = @name, Description = @description, Profile = @profile, Facts = @facts WHERE NoteID = @id",
                new { @name = note.Name, @description = note.Description, @profile = note.Profile, @facts = note.Facts, @id = note.NoteID });
        }
    }
}

