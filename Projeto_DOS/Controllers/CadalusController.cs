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
    public class CadalusController : Controller
    {
        private readonly Projeto_DOSContext _context;

        public CadalusController(Projeto_DOSContext context)
        {
            _context = context;
        }

        // GET: Cadalus
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in _context.Cadalu
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Nome.Contains(searchString)
                                       || s.Apelido.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Nome);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.Apelido);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Cadalu.ToListAsync());
        //}

        // GET: Cadalus/Details/5
        public async Task<IActionResult> DTDetalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadalu = await _context.Cadalu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadalu == null)
            {
                return NotFound();
            }

            return View(cadalu);
        }

        // GET: Cadalus/Create
        public IActionResult DTCriar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DTCriar([Bind("ID,NFicha,NoCIC,CodCuR,Turma,CodAlu,Nome,Apelido,Fpag,Dia,Curri,Certi,Histo,CIC,RG,Crea,Contrato,Foto,EmDia,Status,Lista,Carta,DataInc,Status1")] Cadalu cadalu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadalu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadalu);
        }

        public async Task<IActionResult> DTEditar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadalu = await _context.Cadalu.FindAsync(id);
            if (cadalu == null)
            {
                return NotFound();
            }
            return View(cadalu);
        }

        // POST: Cadalus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DTEditar(int id, [Bind("ID,NFicha,NoCIC,CodCuR,Turma,CodAlu,Nome,Apelido,Fpag,Dia,Curri,Certi,Histo,CIC,RG,Crea,Contrato,Foto,EmDia,Status,Lista,Carta,DataInc,Status1")] Cadalu cadalu)
        {
            if (id != cadalu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadalu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadaluExists(cadalu.ID))
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
            return View(cadalu);
        }

        // GET: Cadalus/Delete/5
        public async Task<IActionResult> DTExcluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadalu = await _context.Cadalu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadalu == null)
            {
                return NotFound();
            }

            return View(cadalu);
        }

        // POST: Cadalus/Delete/5
        [HttpPost, ActionName("DTExcluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadalu = await _context.Cadalu.FindAsync(id);
            _context.Cadalu.Remove(cadalu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadaluExists(int id)
        {
            return _context.Cadalu.Any(e => e.ID == id);
        }
    }
}
