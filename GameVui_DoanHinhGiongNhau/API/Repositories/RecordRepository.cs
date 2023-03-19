using API.Data;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonStorage.Record;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        public readonly GameVuiDBContext _gameVuiDBContext;
        public readonly IMapper _mapper;
        public RecordRepository(GameVuiDBContext gameVuiDBContext, IMapper mapper)
        {
            _gameVuiDBContext = gameVuiDBContext;
            _mapper = mapper;
        }
        public async Task<List<RecordDTO>> GetRecords()
        {
            return await _gameVuiDBContext.records.ProjectTo<RecordDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public bool AddRecord(RecordDTO newRecord)
        {
            Record record = new Record();
            record.PlayerId = newRecord.PlayerId;
            record.BonusMoney = newRecord.BonusMoney;
            record.CreatedDate = DateTime.Now.Date;
            try
            {
                _gameVuiDBContext.records.Add(record);
                _gameVuiDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
