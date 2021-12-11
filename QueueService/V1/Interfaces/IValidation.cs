﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace QueueService.V1
{
    public interface IValidation
    {
        public void ValidateMandatoryFields(Dictionary<string, string> arguments, string[] mandatoryFieldsList,
            HttpResponse res);
    }
}