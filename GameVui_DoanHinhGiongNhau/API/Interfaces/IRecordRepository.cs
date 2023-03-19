using CommonStorage.Record;

namespace API.Interfaces
{
    public interface IRecordRepository
    {
        Task<List<RecordDTO>> GetRecords();
        bool AddRecord(RecordDTO newRecord);
    }
}
