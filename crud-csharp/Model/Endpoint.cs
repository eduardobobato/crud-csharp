using crud_csharp.enums;
using crud_csharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Model
{
    public class Endpoint : Meter
    {
        public string serialNumber { get; set; }
        public int switchState { get; set; }

        public override string ToString()
        {
            ModelId meterModelIdLabel = (ModelId)meterModelId;
            SwitchState switchStateLabel = (SwitchState)switchState;
            return string.Format("{0}: {1} | " +
                                 "{2}: {3} | " +
                                 "{4}: {5} | " +
                                 "{6}: {7} | " +
                                 "{8}: {9}",
                                 I18nService.GetTranslate("SERIAL_NUMBER"), serialNumber,
                                 I18nService.GetTranslate("METER_MODEL_ID"), meterModelIdLabel,
                                 I18nService.GetTranslate("METER_NUMBER"), meterNumber,
                                 I18nService.GetTranslate("METER_FIRMWARE_VERSION"), meterFirmwareVersion,
                                 I18nService.GetTranslate("SWITCH_STATE"), switchStateLabel);
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Endpoint;
            return serialNumber == toCompareWith.serialNumber &&
                meterModelId == toCompareWith.meterModelId &&
                meterNumber == toCompareWith.meterNumber &&
                meterFirmwareVersion == toCompareWith.meterFirmwareVersion &&
                switchState == toCompareWith.switchState;
        }
    }
}
