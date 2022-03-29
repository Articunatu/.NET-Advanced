using _05___Company_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public class ProjectsRepo : ICompany<Project>
    {
        public Task<Project> Create(Project newProject)
        {
            throw new NotImplementedException();
        }


        public Task<Project> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Project> Update(Project uptProject, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Delete(Project delProject)
        {
            throw new NotImplementedException();
        }

    }
}
