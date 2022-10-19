using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_DOS.Data;
using Projeto_DOS.Models;
using Projeto_DOS.Services;
using Projeto_DOS.Models.ViewModels;
using SalesWebMvc.Services.Exceptions;
using X.PagedList;

namespace Projeto_DOS.Controllers
{
    public class CadalusController : Controller
    {
        private readonly Projeto_DOSContext _context;
        private readonly CadaluService _cadaluService;
        public CadalusController(Projeto_DOSContext context, CadaluService cadaluService)
        {
            _context = context;
            _cadaluService = cadaluService;
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

            var CadAluno = from s in _context.Cadalu
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                CadAluno = CadAluno.Where(s => s.Nome.Contains(searchString)
                                       || s.CodCuR.Contains(searchString));
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(CadAluno.ToPagedList(pageNumber, pageSize));
        }

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
        //public async Task<IActionResult> DTEditar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        //    }
        //    var obj = await _cadaluService.FindByIdAsync(id.Value);
        //    if (id == null)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = "Id not found" });
        //    }
        //    List<Cadalu> cadalus = await _cadaluService.FindAllAsync();
        //    StudiesFormViewModel viewModel = new StudiesFormViewModel(Cadalu = obj, Cadalu = cadalus);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DTEditar(int id, [Bind("ID,NFicha,NoCIC,CodCuR,Turma,CodAlu,Nome,Apelido,Fpag,Dia,Curri,Certi,Histo,CIC,RG,Crea,Contrato,Foto,EmDia,Status,Lista,Carta,DataInc,Status1")] Cadalu cadalu)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var aluno = await _cadaluService.FindAllAsync();
        //        var viewModel = new SellerFormViewModel { Cadalu = cadalu, Aluno = aluno };
        //        return View(viewModel);
        //    }
        //    if (id != cadalu.ID)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = "mismatch" });
        //    }
        //    try
        //    {
        //        await _cadaluService.UpdateAsync(cadalu);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (ApplicationException e)
        //    {
        //        return RedirectToAction(nameof(Error), new { message = e.Message });
        //    }
        //}
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
        public async Task<IActionResult> DTExcluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _cadaluService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DTExcluir(int id)
        {
            try
            {
                await _cadaluService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        //public async Task<IActionResult> DTExcluir(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cadalu = await _context.Cadalu
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (cadalu == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cadalu);
        //}

        //[HttpPost, ActionName("DTExcluir")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cadalu = await _context.Cadalu.FindAsync(id);
        //    _context.Cadalu.Remove(cadalu);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CadaluExists(int id)
        {
            return _context.Cadalu.Any(e => e.ID == id);
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
