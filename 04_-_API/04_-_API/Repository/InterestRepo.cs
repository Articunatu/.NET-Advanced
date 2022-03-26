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

            //if (await _context.Persons.AnyAsync(p => p.PersonId == personId))
            //{
            //    var result = await _context.Interests.AddAsync(interest);
            //    await _context.SaveChangesAsync();
            //    await _context.PersonWebsiteInterests.AddAsync(new PersonWebsiteInterest { InterestId = result.Entity.Id, PersonId = personId, WebsiteId = null });
            //    await _context.SaveChangesAsync();
            //    return result.Entity;
            //}
            //return null;
        }

        public Task<IEnumerable<Interest>> ReadAll()
        {
            throw new NotImplementedException();
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

        public async Task<object> SearchByPerson(int id)
        {
            var foundInterests = (from p in _webDbContext.Persons
                                 join w in _webDbContext.WebLinks
                                 on p.PersonID equals w.PersonID
                                 join i in _webDbContext.Interests
                                 on w.InterestID equals i.InterestID
                                 where p.PersonID == id
                                 select new
                                 {
                                     Person = p.Name,
                                     Interest = i.Title
                                 }).Distinct();
            return await foundInterests.ToListAsync();
        }

        public async Task<Interest> ConnectToPerson(Interest Entity, int pId, int iId)
        {
            if (await _webDbContext.Persons.AnyAsync(p => p.PersonID == pId))
            {
                var result = await _webDbContext.Interests.AddAsync(Entity);
                await _webDbContext.SaveChangesAsync();
                await _webDbContext.WebLinks.AddAsync(new WebLink
                {
                    InterestID = result.Entity.InterestID,
                    PersonID = pId,
                    WebID = null
                });
                await _webDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }
    }
}