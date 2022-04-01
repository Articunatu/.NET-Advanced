using _05___Company_API.Database;
using _05___Company_DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public class ProjectsRepo : ICompany<Project>
    {
        private CompanyDbContext _context;

        public ProjectsRepo(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<Project> Create(Project newProject)
        {
            var created = await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<Project> Read(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectID == id);
        }

        public async Task<IEnumerable<Project>> ReadAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> Update(Project newProject)
        {
            var updated = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectID == newProject.ProjectID);
            updated.Title = newProject.Title;
            updated.Description = newProject.Description;
            await _context.SaveChangesAsync();
            return newProject;
        }

        public async Task<Project> Delete(Project delProject)
        {
            var deleted = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectID == delProject.ProjectID);
            _context.Projects.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
    }
}