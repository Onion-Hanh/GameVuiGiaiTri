using API.Interfaces;
using CommonStorage.Record;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        public readonly IRecordRepository _recordRepository;
        public RecordController(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
        [HttpGet]
        public async Task<List<RecordDTO>> GetRecords()
        {
            return await _recordRepository.GetRecords();
        }
        [HttpPost]
        public bool AddRecord(RecordDTO newRecord)
        {
            if (_recordRepository.AddRecord(newRecord))
            {
                return true;
            }
            return false;
        }
    }
}
