using Microsoft.EntityFrameworkCore;
using PC1DAW.Data;
using PC1DAW.Interfaces;

namespace PC1DAW.Repositories
{
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public AttendeesRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Attendees>> GetAttendees()
        {
            var attendees = await _dbContext.Attendees.ToListAsync();
            return attendees;
        }

        public async Task<int> Insert(Attendees attendees)
        {
            await _dbContext.Attendees.AddAsync(attendees);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0 ? attendees.Id : -1;
        }

        public async Task<bool> Delete(int id)
        {
            var attendees = await _dbContext
            .Attendees
            .FirstOrDefaultAsync(c => c.Id == id);

            if (attendees == null) return false;

            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);

            //_dbContext.Category.Remove(category);

        }
    }
}
