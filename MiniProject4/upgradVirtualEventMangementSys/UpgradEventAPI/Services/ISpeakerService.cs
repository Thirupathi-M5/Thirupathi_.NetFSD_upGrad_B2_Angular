using DAL.Models;

public interface ISpeakerService
{
    Task<IEnumerable<SpeakerDetails>> GetAllSpeakers();
    Task AddSpeaker(SpeakerDetails speaker);
    Task DeleteSpeaker(int id);
}