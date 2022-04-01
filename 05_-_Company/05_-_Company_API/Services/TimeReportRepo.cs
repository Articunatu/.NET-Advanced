using _05___Company_API.Database;
using _05___Company_DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public class TimeReportRepo : ICompany<TimeReport>
    {
        private CompanyDbContext _context;

        public TimeReportRepo(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<TimeReport> Create(TimeReport newTimeReport)
        {
            var created = await _context.TimeReports.AddAsync(newTimeReport);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<TimeReport> Read(int id)
        {
            return await _context.TimeReports.FirstOrDefaultAsync(t => t.TR_ID == id);
        }

        public async Task<IEnumerable<TimeReport>> ReadAll()
        {
            return await _context.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> Update(TimeReport newTimeReport)
        {
            var updated = await _context.TimeReports.FirstOrDefaultAsync(p => p.TR_ID == newTimeReport.TR_ID);
            updated.Hours = newTimeReport.Hours;
            updated.Week = newTimeReport.Week;
            await _context.SaveChangesAsync();
            return newTimeReport;
        }

        public async Task<TimeReport> Delete(TimeReport delTimeReport)
        {
            var deleted = await _context.TimeReports.FirstOrDefaultAsync(p => p.TR_ID == delTimeReport.TR_ID);
            _context.TimeReports.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
    }
}