using System.Collections.Generic;
using QueueService.V1.Models;

namespace QueueService.V1
{
    public class DalInMemory : IDal
    {
        private Queue _queue = new() {QueueData = new List<QueueData>()};

        public Queue RetrieveQueue()
        {
            return _queue;
        }

        public bool StoreQueue(Queue queue)
        {
            _queue = queue;
            return true;
        }
    }
}