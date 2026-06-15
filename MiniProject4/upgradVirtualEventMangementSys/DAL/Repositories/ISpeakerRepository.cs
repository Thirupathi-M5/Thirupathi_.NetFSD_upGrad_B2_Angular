using DAL.Models;

namespace DAL.Repositories
{
    public interface ISpeakerRepository
    {
        List<SpeakerDetails> GetAll();
        SpeakerDetails GetById(int id);
        void Add(SpeakerDetails speaker);
        void Update(SpeakerDetails speaker);
        void Delete(int id);
    }
}