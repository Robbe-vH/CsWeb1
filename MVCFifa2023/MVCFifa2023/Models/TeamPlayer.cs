﻿namespace MVCFifa2023.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}