using Microsoft.EntityFrameworkCore;
using RestAPI.Db;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Repository
{
    public class CRMRepository : ICRMRepository
    {
        private readonly CRMContext _context;


        public CRMRepository(CRMContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteClientCategory(ClientCategory category)
        {
            _context.ClientCategories.Remove(category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<List<ClientCategory>> GetClientCategories()
        {
            var categories = await _context.ClientCategories.ToListAsync();
            return categories; 
        }

        public async Task<ClientCategory> GetClientCategory(int id)
        {
            var category = await _context.ClientCategories.FindAsync(id);
            return category;
        }

        public async Task<ClientCategory> PostClientCategory(ClientCategory category)
        {
            _context.ClientCategories.Add(category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return category;
        }

        public async Task<ClientCategory> UpdateClientCategory(ClientCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch
            {
                return null;

            }

            return category;
        }
    }
}
