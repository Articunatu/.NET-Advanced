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

        public async Task<IEnumerable<Interest>> ReadAll()
        {
            return await Repo._webDbContext.Interests.ToListAsync();
        }

        public async Task<Interest> ReadSingle(int id)
        {
            var personsInterests = (from w in Repo._webDbContext.WebLinks
                                    join p in Repo._webDbContext.Persons
                                    on w.PersonID equals p.PersonID
                                    join i in Repo._webDbContext.Interests
                                    on w.InterestID equals i.InterestID
                                    where w.PersonID == id
                                    select new
                                    {
                                        ID = w.InterestID,
                                        i.Title,
                                        i.Description
                                    }
                                    ).ToListAsync();
            return (Interest)(IEnumerable<Interest>)await personsInterests;
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