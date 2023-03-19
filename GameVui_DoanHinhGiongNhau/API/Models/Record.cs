namespace API.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int BonusMoney { get; set; }
        public DateTime CreatedDate { get; set; }
        public Player Player { get; set; }
    }
}
