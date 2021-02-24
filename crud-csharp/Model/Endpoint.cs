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
            return String.Format("Serial number: {0} | Meter model id: {1} | Meter Number: {2} | Meter firmware version: {3} | Switch state: {4}", serialNumber, meterModelId, meterNumber, meterFirmwareVersion, switchState);
        }
    }
}
