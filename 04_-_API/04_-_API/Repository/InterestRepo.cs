using _04___API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public class InterestRepo : IRepository<Interest>
    {
        WebDbContext _webDbContext;
        public InterestRepo(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<Interest> Create(Interest newEntity)
        {
            var result = await _webDbContext.Interests.AddAsync(newEntity);
            await _webDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Interest>> ReadAll(int id)
        {
            var result = (from w in _webDbContext.WebLinks
                         join i in _webDbContext.Interests
                         on w.InterestID equals i.InterestID
                         join p in _webDbContext.Persons
                         on w.PersonID equals p.PersonID
                         where w.PersonID == id
                         select i)
                         .Distinct().ToListAsync();
            return await result;
        }

        public async Task<Interest> ReadSingle(int id)
        {
            return await _webDbContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
        }

        public async Task<Interest> Update(Interest Entity)
        {
            var result = await _webDbContext.Interests.FirstOrDefaultAsync(p => p.InterestID == Entity.InterestID);
            if (result != null)
            {
                result.Title = Entity.Title;
                result.Description = Entity.Description;

                await _webDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _webDbContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
            if (result != null)
            {
                _webDbContext.Interests.Remove(result);
                await _webDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}