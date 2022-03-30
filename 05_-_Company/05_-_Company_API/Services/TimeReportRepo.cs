using _05___Company_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public class TimeReportRepo : ICompany<TimeReport>
    {
        public Task<TimeReport> Create(TimeReport newReport)
        {
            throw new NotImplementedException();
        }

        public Task<TimeReport> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeReport>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<TimeReport> Update(TimeReport uptReport, int id)
        {
            throw new NotImplementedException();
        }

        public Task<TimeReport> Delete(TimeReport delReport)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeReport>> ProjectsEmployees(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TimeReport> WeeklyHours(TimeReport Entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
