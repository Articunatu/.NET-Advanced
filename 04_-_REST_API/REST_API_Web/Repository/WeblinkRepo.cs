using _04___REST_API.EntityFramework;
using _04___REST_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Web.Repository
{
    public class WeblinkRepo : IRepository<Weblink>
    {
        RestDbContext _restContext;

        public WeblinkRepo(RestDbContext webDbContext)
        {
            _restContext = webDbContext;
        }

        public async Task<Weblink> Create(Weblink newEntity)
        {
            var result = await _restContext.Weblinks.AddAsync(newEntity);
            await _restContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Weblink> ReadSingle(int id)
        {
            return await _restContext.Weblinks.FirstOrDefaultAsync(p => p.WebID == id);
        }

        public async Task<Weblink> Update(Weblink Entity)
        {
            var result = await _restContext.Weblinks.FirstOrDefaultAsync(p => p.WebID == Entity.WebID);
            if (result != null)
            {
                result.LinkURL = Entity.LinkURL;
                result.PersonID = Entity.PersonID;
                result.InterestID = Entity.InterestID;

                await _restContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Weblink> Delete(int id)
        {
            var result = await _restContext.Weblinks.FirstOrDefaultAsync(p => p.WebID == id);
            if (result != null)
            {
                _restContext.Weblinks.Remove(result);
                await _restContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task<IEnumerable<Weblink>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<object> SearchByPerson(int id)
        {
            var result = (from w in _restContext.Weblinks
                          join p in _restContext.Persons
                          on w.PersonID equals p.PersonID
                          where w.PersonID == id
                          select new
                          {
                              Person = p.Name,
                              Website = w.WebID,
                              URL = w.LinkURL
                          }).Distinct();
            return await result.ToListAsync();
        }

        public async Task<Weblink> ConnectToPerson(Weblink Entity, int pId, int iId)
        {
            var person = await _restContext.Persons.FirstOrDefaultAsync(p => p.PersonID == pId);
            var interest = await _restContext.Interests.FirstOrDefaultAsync(i => i.InterestID == iId);
            if (person != null && interest != null)
            {
                var weblink = await _restContext.Weblinks.AddAsync(Entity);

                await _restContext.SaveChangesAsync();
                await _restContext.Weblinks.AddAsync(new Weblink
                {
                    InterestID = iId,
                    PersonID = pId,
                    WebID = weblink.Entity.WebID
                });
                await _restContext.SaveChangesAsync();

                return weblink.Entity;
            }
            return null;
        }
    }
}
