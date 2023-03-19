using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonStorage.Record
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int BonusMoney { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PlayerName { get; set; }
    }
}
