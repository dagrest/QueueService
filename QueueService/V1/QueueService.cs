using Carter;
using Carter.Response;
using QueueService.V1.Models;

namespace QueueService.V1
{
    public class QueueService : CarterModule
    {
        public QueueService(IQueueServiceApi queueServiceApi, IInputData inputData, IValidation validation)
        {
            // TODO: validate for null
            //inputData;
            //validation;

            Post("/v1/enqueue", async (req, res) =>
            { 
                var bodyArguments = inputData.GetBodyArguments(req, res);
                validation.ValidateMandatoryFields(bodyArguments,
                    new string[] { "data" }, res);
                await res.AsJson(queueServiceApi.Enqueue(bodyArguments["data"]));
            });

            Delete("/v1/dequeue", (req, res) =>
            {
                var response = queueServiceApi.Dequeue().Result;
                if (response.ErrorStatus.ErrorType != ErrorType.OK)
                {
                    res.StatusCode = 404; // Should be created a list of more descriptive error codes.
                }
                return res.AsJson(response);
            });

            Get("/v1/getsnapshot", async (req, res) =>
                await res.AsJson(queueServiceApi.GetSnapshot()));
        }
    }
}