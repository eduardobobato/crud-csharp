using crud_csharp.enums;
using crud_csharp.exceptions;
using crud_csharp.Model;
using crud_csharp.Service;
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
            if (modelId.ToUpper() == ModelId.NSX1P2W.ToString().ToUpper())
            {
                endpoint.meterModelId = (int)ModelId.NSX1P2W;
            }
            else if (modelId.ToUpper() == ModelId.NSX1P3W.ToString().ToUpper())
            {
                endpoint.meterModelId = (int)ModelId.NSX1P3W;
            }
            else if (modelId.ToUpper() == ModelId.NSX1P4W.ToString().ToUpper())
            {
                endpoint.meterModelId = (int)ModelId.NSX1P4W;
            }
            else if (modelId.ToUpper() == ModelId.NSX1P5W.ToString().ToUpper())
            {
                endpoint.meterModelId = (int)ModelId.NSX1P5W;
            }
            else
            {
                throw new AppException(I18nService.GetTranslate("INVALID_METER_MODE_INPUT"));
            }
        }

        public static void ValidateSwitchState(string switchState, Endpoint endpoint)
        {
            if (switchState.ToLower() == SwitchState.Disconnected.ToString().ToLower())
            {
                endpoint.switchState = (int)SwitchState.Disconnected;
            }
            else if (switchState.ToLower() == SwitchState.Connected.ToString().ToLower())
            {
                endpoint.switchState = (int)SwitchState.Connected;
            }
            else if (switchState.ToLower() == SwitchState.Armed.ToString().ToLower())
            {
                endpoint.switchState = (int)SwitchState.Armed;
            }
            else
            {
                throw new AppException(I18nService.GetTranslate("INVALID_SWITCH_STATE_INPUT"));
            }
        }
    }
}
