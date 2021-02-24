using crud_csharp.enums;
using crud_csharp.exceptions;
using crud_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.utils
{
    public class EndpointValidator
    {
        public static void ValidateModelId(string modelId, Endpoint endpoint)
        {
            if (modelId == "NSX1P2W")
            {
                endpoint.meterModelId = 16;
            }
            else if (modelId == "NSX1P3W")
            {
                endpoint.meterModelId = 17;
            }
            else if (modelId == "NSX1P4W")
            {
                endpoint.meterModelId = 18;
            }
            else if (modelId == "NSX1P5W")
            {
                endpoint.meterModelId = 19;
            }
            else
            {
                throw new AppException("Invalid Meter mode id input.");
            }
        }

        public static void ValidateSwitchState(string switchState, Endpoint endpoint)
        {
            if (switchState == "Disconnected")
            {
                endpoint.switchState = (int)ModelId.Disconnected;
            }
            else if (switchState == "Connected")
            {
                endpoint.switchState = (int)ModelId.Connected;
            }
            else if (switchState == "Armed")
            {
                endpoint.switchState = (int)ModelId.Armed;
            }
            else
            {
                throw new AppException("Invalid switch state input.");
            }
        }
    }
}
