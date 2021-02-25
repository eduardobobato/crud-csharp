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
    class EditEndpointService : IBaseService<EndpointVO, Endpoint>
    {
        private EndpointDao dao = EndpointDao.GetInstance;

        public Endpoint Execute(EndpointVO endpointVo)
        {
            var matchedEndpoint = dao.FindOne(endpointVo.serialNumber);
            if (matchedEndpoint == null)
                throw new AppException(I18nService.GetTranslate("DONT_HAVE_SERIAL_NUMBER"));
            var endpoint = new Endpoint()
            {
                serialNumber = endpointVo.serialNumber,
            };
            EndpointValidator.ValidateSwitchState(endpointVo.switchState, endpoint);
            return dao.Edit(endpoint);
        }
    }
}
