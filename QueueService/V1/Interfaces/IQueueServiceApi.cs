using System.Collections.Generic;
using System.Threading.Tasks;
using QueueService.V1.Models;

namespace QueueService.V1
{
    public interface IQueueServiceApi
    {
        public Task<ErrorStatus> Enqueue(string data);

        public Task<DequeueResponse> Dequeue();

        public Task<SnapShotResponse> GetSnapshot();
    }
}