using System;
using System.ComponentModel.DataAnnotations;

namespace Notwork.Api.Contexts.Models
{
    public class Ping
    {
        [Key]
        public int PingId { get; set; }
        
        public DateTime Timestamp { get; set; }

        public Ping()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}