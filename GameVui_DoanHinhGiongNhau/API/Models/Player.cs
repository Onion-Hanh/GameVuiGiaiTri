﻿namespace API.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int RecordId { get; set; }
        public List<Record> records { get; set; }
    }
}
