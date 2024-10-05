using PC1DAW.Data;

namespace PC1DAW.Interfaces
{
    public interface IAttendeesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetAttendees();
        Task<int> Insert(Attendees attendees);
    }
}