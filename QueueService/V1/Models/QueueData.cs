using System;
using System.ComponentModel.DataAnnotations;

namespace QueueService.V1.Models
{
    public class QueueData
    {
        public string Id { get; }
        public string Data { get; set; }
        public DateTime Timestamp { get; }

        public QueueData(string data)
        {
            Data = data;
            Id = new Guid().ToString();
            Timestamp = DateTime.UtcNow;
        }
    }
}