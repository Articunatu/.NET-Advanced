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

        public InterestRepo(WebDbContext webDbContext)
        {
            Repo._webDbContext = webDbContext;
        }

        public async Task<Interest> Create(Interest newEntity)
        {
            var result = await Repo._webDbContext.Interests.AddAsync(newEntity);
            await Repo._webDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Interest>> ReadAll(int? id)
        {
            var result = (from i in Repo._webDbContext.Interests
                          join w in Repo._webDbContext.WebLinks
                          on i.InterestID equals w.InterestID
                          where w.PersonID == id
                          select i);
            return await result.ToListAsync();
        }

        public async Task<Interest> ReadSingle(int id)
        {
            return await Repo._webDbContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
        }

        public async Task<Interest> Update(Interest Entity)
        {
            var result = await Repo._webDbContext.Interests.FirstOrDefaultAsync(p => p.InterestID == Entity.InterestID);
            if (result != null)
            {
                result.Title = Entity.Title;
                result.Description = Entity.Description;

                await Repo._webDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await Repo._webDbContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
            if (result != null)
            {
                Repo._webDbContext.Interests.Remove(result);
                await Repo._webDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}