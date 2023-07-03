using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandleMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandleMVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepo repo;

        public NoteController(INoteRepo repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var notes = repo.GetAllNotes();
            return View(notes);
        }

        public IActionResult ViewNote(int id)
        {
            var note = repo.GetNote(id);
            return View(note);
        }

        public IActionResult UpdateNote(int id)
        {
            Note note = repo.GetNote(id);
            if (note == null)
            {
                return View("NoteNotFound");
            }
            return View(note);
        }

        public IActionResult UpdateNoteToDatabase(Note note)
        {
            repo.UpdateNote(note);

            return RedirectToAction("ViewNote", new { id = note.NoteID });
        }

        public IActionResult InsertNote()
        {
            var note = new Note();
            return View(note);
        }

        public IActionResult InsertNoteToDatabase(Note noteToInsert)
        {
            repo.InsertNote(noteToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNote(Note note)
        {
            repo.DeleteNote(note);
            return RedirectToAction("Index");
        }
    }
}

