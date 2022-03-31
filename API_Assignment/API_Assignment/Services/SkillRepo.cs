using API_Assignment.Data;
using API_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment.Services
{
    public class SkillRepo : IService<Skill>
    {
        private ApiDbContext _apiContext;
        public SkillRepo(ApiDbContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Skill> Create(Skill Entity)
        {
            var newPerson = await _apiContext.Skills.AddAsync(Entity);
            await _apiContext.SaveChangesAsync();
            return newPerson.Entity;
        }

        public async Task<Skill> Delete(int id)
        {
            var delPerson = await _apiContext.Skills.FirstOrDefaultAsync(p => p.SkillID == id);
            _apiContext.Skills.Remove(delPerson);
            await _apiContext.SaveChangesAsync();
            return delPerson;
        }

        public async Task<IEnumerable<Skill>> ReadAll()
        {
            return await _apiContext.Skills.ToListAsync();
        }

        public async Task<IEnumerable<Object>> ReadConnectedEntities(int id)
        {
            var personsSkills = (from ps in _apiContext.PersonSkills
                                 join s in _apiContext.Skills
                                 on ps.SkillID equals s.SkillID
                                 join p in _apiContext.Persons
                                 on ps.PersonID equals p.PersonID
                                 where p.PersonID == id
                                 select new
                                 {
                                     Namn = p.FirstName + " " + p.LastName,
                                     Färdighet = s.Title
                                 }).ToListAsync();
            return await personsSkills;
        }

        public async Task<Skill> ReadSingle(int id)
        {
            return await _apiContext.Skills.FirstOrDefaultAsync(p => p.SkillID == id);
        }

        public async Task<IEnumerable<Object>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Skill> Update(Skill Entity)
        {

            var uptPerson = await _apiContext.Skills.FirstOrDefaultAsync(p => p.SkillID == Entity.SkillID);
            if (uptPerson != null)
            {
                uptPerson.Title = Entity.Title;
                uptPerson.Description = Entity.Description;
                await _apiContext.SaveChangesAsync();

                return uptPerson;
            }
            return null;
        }
    }
}
