using crud_csharp.enums;
using crud_csharp.exceptions;
using crud_csharp.Model;
using crud_csharp.Service;
using crud_csharp.utils;
using crud_csharp.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Controller
{
    public class EndpointController
    {
        public EndpointController() { }

        public List<Endpoint> ListAll()
        {
            var listAllEndpointService = new ListAllEndpointService();
            return listAllEndpointService.Execute();
        }

        public Endpoint FindOne(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new AppException(I18nService.GetTranslate("INVALID_SERIAL_NUMBER"));

            var findEndpointBySerialNumberService = new FindEndpointBySerialNumberService();
            return findEndpointBySerialNumberService.Execute(identifier);
        }

        public Endpoint Create(EndpointVO endpointVo)
        {
            if (string.IsNullOrEmpty(endpointVo.serialNumber))
                throw new AppException(I18nService.GetTranslate("INVALID_SERIAL_NUMBER"));
            if (string.IsNullOrEmpty(endpointVo.meterFirmwareVersion))
                throw new AppException(I18nService.GetTranslate("INVALID_METER_FIRMWARE_VERSION"));
            int number;
            if (string.IsNullOrEmpty(endpointVo.meterNumber) || !int.TryParse(endpointVo.meterNumber, out number))
                throw new AppException(I18nService.GetTranslate("INVALID_METER_NUMBER"));
            
            var createEndpointService = new CreateEndpointService();
            return createEndpointService.Execute(endpointVo);
        }

        public Endpoint Edit(EndpointVO endpointVo)
        {
            if (string.IsNullOrEmpty(endpointVo.serialNumber))
                throw new AppException(I18nService.GetTranslate("INVALID_SERIAL_NUMBER"));

            var editEndpointService = new EditEndpointService();
            return editEndpointService.Execute(endpointVo);
        }

        public Endpoint Delete(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new AppException(I18nService.GetTranslate("INVALID_SERIAL_NUMBER"));
            var deleteEndpointService = new DeleteEndpointService();
            return deleteEndpointService.Execute(identifier);
        }
    }
}
