using DAL.Models;

public interface IParticipantService
{
    Task RegisterEvent(ParticipantEventDetails data);
    Task<IEnumerable<ParticipantEventDetails>> GetUserEvents(string email);
    Task MarkAttendance(int id);
}