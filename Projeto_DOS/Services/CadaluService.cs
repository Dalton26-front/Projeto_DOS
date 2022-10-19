using Microsoft.EntityFrameworkCore;
using Projeto_DOS.Data;
using Projeto_DOS.Models;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Projeto_DOS.Services

{
    public class CadaluService
    {
        private readonly Projeto_DOSContext _context;
        public CadaluService(Projeto_DOSContext context)
        {
            _context = context;
        }
        public async Task <List<Cadalu>> FindAllAsync()
        {
            return await _context.Cadalu.ToListAsync();
        }
        //public void Insert(Cadalu obj)
        //{
        //    _context.Add(obj);
        //    _context.SaveChanges();
        //}
        public async Task<Cadalu> FindByIdAsync(int id)
        {
            return await _context.Cadalu.FirstOrDefaultAsync(obj => obj.ID == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Cadalu.FindAsync(id);
                _context.Cadalu.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can't delete student because he/she has student");
            }
        }
        public async Task UpdateAsync(Cadalu obj)
        {
            bool hasAny = await _context.Cadalu.AnyAsync(x => x.ID == obj.ID);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}

