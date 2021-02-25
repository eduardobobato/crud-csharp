using crud_csharp.DAO;
using crud_csharp.exceptions;
using crud_csharp.Model;
using crud_csharp.utils;
using crud_csharp.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Service
{
    public class CreateEndpointService : IBaseService<EndpointVO, Endpoint>
    {
        private EndpointDao dao = EndpointDao.GetInstance;

        public Endpoint Execute(EndpointVO endpointVo)
        {
            if (dao.FindOne(endpointVo.serialNumber) != null)
                throw new AppException(I18nService.GetTranslate("SERIAL_NUMBER_DUPLICATED"));

            var endpoint = new Endpoint()
            {
                serialNumber = endpointVo.serialNumber,
                meterFirmwareVersion = endpointVo.meterFirmwareVersion,
                meterNumber = int.Parse(endpointVo.meterNumber),
            };
            EndpointValidator.ValidateModelId(endpointVo.meterModelId, endpoint);
            EndpointValidator.ValidateSwitchState(endpointVo.switchState, endpoint);
            
            return dao.Create(endpoint);
        }
    }
}
