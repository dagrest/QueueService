using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Extensions;
using QueueService.V1.Models;

namespace QueueService.V1
{
    public class QueueServiceApi : IQueueServiceApi
    {
        private readonly IDal _dal;

        public QueueServiceApi(IDal dal)
        {
            _dal = dal;
        }

        public Task<DequeueResponse> Dequeue()
        {
            var queue = _dal.RetrieveQueue();
            // find the first element for dequeue in queue
            // with the most earlier time
            var sortedDataList = queue.QueueData.OrderBy(o => o.Timestamp).ToList();
            if (sortedDataList.Any())
            {
                var removedData = sortedDataList[0];
                sortedDataList.Remove(removedData);
                queue.QueueData = sortedDataList;
                _dal.StoreQueue(queue);
                return Task.FromResult(new DequeueResponse
                {
                    Data = removedData,
                    ErrorStatus = new ErrorStatus { ErrorType = ErrorType.OK }
                });
            }
            return Task.FromResult(new DequeueResponse
            {
                ErrorStatus = new ErrorStatus { ErrorType = ErrorType.QueueIsEmpty, ErrorMessage = ErrorMessage.QueueIsEmpty }
            });
        }

        public Task<ErrorStatus> Enqueue(string data)
        {
            var queue = _dal.RetrieveQueue();
            queue.QueueData.Add(new QueueData(data));
            _dal.StoreQueue(queue);
            return Task.FromResult(new ErrorStatus
            { ErrorType = ErrorType.OK });
        }

        public Task<SnapShotResponse> GetSnapshot()
        {
            return Task.FromResult(new SnapShotResponse
            {
                DataList = _dal.RetrieveQueue().QueueData,
                ErrorStatus = new ErrorStatus {ErrorType = ErrorType.OK}
            });
        }
    }
}