using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.ViewObject
{
    public class EndpointVO
    {
        public string serialNumber { get; set; }
        public string meterModelId { get; set; }
        public string meterNumber { get; set; }
        public string meterFirmwareVersion { get; set; }
        public string switchState { get; set; }
    }
}
