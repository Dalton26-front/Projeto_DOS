using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_DOS.Data;
using Projeto_DOS.Models;
using X.PagedList;

namespace Projeto_DOS.Controllers
{
    public class CodcursoesController : Controller
    {
        private readonly Projeto_DOSContext _context;

        public CodcursoesController(Projeto_DOSContext context)
        {
            _context = context;
        }
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Disciplina = from s in _context.Codcur
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Disciplina = Disciplina.Where(s => s.CODCURSO.Contains(searchString)
                                       || s.DISCIPLINA.Contains(searchString) 
                                       || s.PROFESSOR.Contains(searchString));
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Disciplina.ToPagedList(pageNumber, pageSize));
        }
     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codcurso = await _context.Codcur
                .FirstOrDefaultAsync(m => m.ID == id);
            if (codcurso == null)
            {
                return NotFound();
            }

            return View(codcurso);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CODCURSO,TURMA,LISTA,DATAMOV,DISCIPLINA,SUBDIS,PROFESSOR,CODDIS,CODPRO")] Codcurso codcurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codcurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codcurso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codcurso = await _context.Codcur.FindAsync(id);
            if (codcurso == null)
            {
                return NotFound();
            }
            return View(codcurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CODCURSO,TURMA,LISTA,DATAMOV,DISCIPLINA,SUBDIS,PROFESSOR,CODDIS,CODPRO")] Codcurso codcurso)
        {
            if (id != codcurso.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codcurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodcursoExists(codcurso.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(codcurso);
        }

      public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codcurso = await _context.Codcur
                .FirstOrDefaultAsync(m => m.ID == id);
            if (codcurso == null)
            {
                return NotFound();
            }

            return View(codcurso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codcurso = await _context.Codcur.FindAsync(id);
            _context.Codcur.Remove(codcurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodcursoExists(int id)
        {
            return _context.Codcur.Any(e => e.ID == id);
        }
    }
}
