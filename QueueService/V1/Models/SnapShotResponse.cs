using System.Collections.Generic;

namespace QueueService.V1.Models
{
    public class SnapShotResponse
    {
        public List<QueueData> DataList { get; set; }
        public ErrorStatus ErrorStatus { get; set; }
    }
}