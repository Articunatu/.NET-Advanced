using _04___API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public class WeblinkRepo : IRepository<WebLink>
    {
        public WeblinkRepo(WebDbContext webDbContext)
        {
            Repo._webDbContext = webDbContext;
        }

        public async Task<WebLink> Create(WebLink newEntity)
        {
            var result = await Repo._webDbContext.WebLinks.AddAsync(newEntity);
            await Repo._webDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<WebLink>> ReadAll(int? id)
        {
            var result = (from w in Repo._webDbContext.WebLinks
                          where w.PersonID == id
                          select w);
            return await result.ToListAsync();
        }

        public async Task<WebLink> ReadSingle(int id)
        {
            return await Repo._webDbContext.WebLinks.FirstOrDefaultAsync(p => p.WebID == id);
        }

        public async Task<WebLink> Update(WebLink Entity)
        {
            var result = await Repo._webDbContext.WebLinks.FirstOrDefaultAsync(p => p.WebID == Entity.WebID);
            if (result != null)
            {
                result.LinkURL = Entity.LinkURL;
                result.PersonID = Entity.PersonID;
                result.InterestID = Entity.InterestID;

                await Repo._webDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<WebLink> Delete(int id)
        {
            var result = await Repo._webDbContext.WebLinks.FirstOrDefaultAsync(p => p.WebID == id);
            if (result != null)
            {
                Repo._webDbContext.WebLinks.Remove(result);
                await Repo._webDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
