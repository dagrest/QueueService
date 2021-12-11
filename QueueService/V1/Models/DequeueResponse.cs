namespace QueueService.V1.Models
{
    public class DequeueResponse
    {
        public QueueData Data { get; set; }
        public ErrorStatus ErrorStatus { get; set; }
    }
}