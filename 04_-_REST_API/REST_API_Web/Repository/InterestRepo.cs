using _04___REST_API.EntityFramework;
using _04___REST_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Web.Repository
{
    public class InterestRepo : IRepository<Interest>
    {
        RestDbContext _restContext;
        public InterestRepo(RestDbContext webDbContext)
        {
            _restContext = webDbContext;
        }

        public async Task<Interest> Create(Interest newEntity)
        {
            var result = await _restContext.Interests.AddAsync(newEntity);
            await _restContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<IEnumerable<Interest>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Interest> ReadSingle(int id)
        {
            return await _restContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
        }

        public async Task<Interest> Update(Interest Entity)
        {
            var result = await _restContext.Interests.FirstOrDefaultAsync(p => p.InterestID == Entity.InterestID);
            if (result != null)
            {
                result.Title = Entity.Title;
                result.Description = Entity.Description;

                await _restContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _restContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
            if (result != null)
            {
                _restContext.Interests.Remove(result);
                await _restContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> SearchByPerson(int id)
        {
            var foundInterests = (from p in _restContext.Persons
                                  join w in _restContext.Weblinks
                                  on p.PersonID equals w.PersonID
                                  join i in _restContext.Interests
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
            if (await _restContext.Persons.AnyAsync(p => p.PersonID == pId))
            {
                var result = await _restContext.Interests.AddAsync(Entity);
                await _restContext.SaveChangesAsync();
                await _restContext.Weblinks.AddAsync(new Weblink
                {
                    InterestID = result.Entity.InterestID,
                    PersonID = pId,
                    WebID = null
                });
                await _restContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }
    }
}
