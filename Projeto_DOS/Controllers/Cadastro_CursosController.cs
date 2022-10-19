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
    public class Cadastro_CursosController : Controller
    {
        private readonly Projeto_DOSContext _context;

        public Cadastro_CursosController(Projeto_DOSContext context)
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

            var RelacaoCurso = from s in _context.Cadastro_Curso
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                RelacaoCurso = RelacaoCurso.Where(s => s.CodCur.Contains(searchString)
                                                 || s.Descricao.Contains(searchString));
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(RelacaoCurso.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro_Curso = await _context.Cadastro_Curso
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastro_Curso == null)
            {
                return NotFound();
            }

            return View(cadastro_Curso);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CodCur,Descricao,Sigla,Ano,Inicio,Fim,Aluno,CargaHor,Apelido,CodPro,Hora1,Hora2,Valor,Classe")] Cadastro_Curso cadastro_Curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro_Curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro_Curso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro_Curso = await _context.Cadastro_Curso.FindAsync(id);
            if (cadastro_Curso == null)
            {
                return NotFound();
            }
            return View(cadastro_Curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CodCur,Descricao,Sigla,Ano,Inicio,Fim,Aluno,CargaHor,Apelido,CodPro,Hora1,Hora2,Valor,Classe")] Cadastro_Curso cadastro_Curso)
        {
            if (id != cadastro_Curso.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro_Curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cadastro_CursoExists(cadastro_Curso.ID))
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
            return View(cadastro_Curso);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro_Curso = await _context.Cadastro_Curso
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastro_Curso == null)
            {
                return NotFound();
            }

            return View(cadastro_Curso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro_Curso = await _context.Cadastro_Curso.FindAsync(id);
            _context.Cadastro_Curso.Remove(cadastro_Curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cadastro_CursoExists(int id)
        {
            return _context.Cadastro_Curso.Any(e => e.ID == id);
        }
    }
}
