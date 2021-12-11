namespace QueueService.V1.Models
{
    public interface IDal
    {
        public Queue RetrieveQueue();
        public bool StoreQueue(Queue queue);
    }
}