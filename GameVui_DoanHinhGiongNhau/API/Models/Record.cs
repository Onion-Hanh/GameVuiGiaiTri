namespace API.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TotalPoint { get; set; }
        public Player Player { get; set; }
    }
}
