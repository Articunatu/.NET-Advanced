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
        WebDbContext _webDbContext;

        public WeblinkRepo(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<WebLink> Create(WebLink newEntity)
        {
            var result = await _webDbContext.WebLinks.AddAsync(newEntity);
            await _webDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<WebLink> ReadSingle(int id)
        {
            return await _webDbContext.WebLinks.FirstOrDefaultAsync(p => p.WebID == id);
        }

        public async Task<WebLink> Update(WebLink Entity)
        {
            var result = await _webDbContext.WebLinks.FirstOrDefaultAsync(p => p.WebID == Entity.WebID);
            if (result != null)
            {
                result.LinkURL = Entity.LinkURL;
                result.PersonID = Entity.PersonID;
                result.InterestID = Entity.InterestID;

                await _webDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<WebLink> Delete(int id)
        {
            var result = await _webDbContext.WebLinks.FirstOrDefaultAsync(p => p.WebID == id);
            if (result != null)
            {
                _webDbContext.WebLinks.Remove(result);
                await _webDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task<IEnumerable<WebLink>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<object> SearchByPerson(int id)
        {
            var result = (from w in _webDbContext.WebLinks
                          join p in _webDbContext.Persons
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

        public async Task<WebLink> ConnectToPerson(WebLink Entity, int pId, int iId)
        {
            var person = await _webDbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == pId);
            var interest = await _webDbContext.Interests.FirstOrDefaultAsync(i => i.InterestID == iId);
            if (person != null && interest != null)
            {
                var weblink = await _webDbContext.WebLinks.AddAsync(Entity);

                await _webDbContext.SaveChangesAsync();
                await _webDbContext.WebLinks.AddAsync(new WebLink 
                { 
                    InterestID = iId, PersonID = pId, WebID = weblink.Entity.WebID 
                });
                await _webDbContext.SaveChangesAsync();

                return weblink.Entity;
            }
            return null;
        }
    }
}