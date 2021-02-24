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
            return listAllEndpointService.Execute(null);
        }

        public Endpoint FindOne(string identifier)
        {
            var findEndpointBySerialNumberService = new FindEndpointBySerialNumberService();
            return findEndpointBySerialNumberService.Execute(identifier);
        }

        public Endpoint Create(EndpointVO endpointVo)
        {
            var endpoint = new Endpoint()
            {
                serialNumber = endpointVo.serialNumber,
                meterFirmwareVersion = endpointVo.meterFirmwareVersion,
            };
            EndpointValidator.ValidateModelId(endpointVo.meterModelId, endpoint);
            EndpointValidator.ValidateSwitchState(endpointVo.switchState, endpoint);
            var createEndpointService = new CreateEndpointService();
            return createEndpointService.Execute(endpoint);
        }

        public Endpoint Edit(EndpointVO endpointVo)
        {
            var endpoint = new Endpoint()
            {
                serialNumber = endpointVo.serialNumber,
            };
            EndpointValidator.ValidateSwitchState(endpointVo.switchState, endpoint);
            var editEndpointService = new EditEndpointService();
            return editEndpointService.Execute(endpoint);
        }

        public Endpoint Delete(string identifier)
        {
            var deleteEndpointService = new DeleteEndpointService();
            return deleteEndpointService.Execute(identifier);
        }
    }
}
