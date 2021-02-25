using crud_csharp.DAO;
using crud_csharp.exceptions;
using crud_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Service
{
    class FindEndpointBySerialNumberService : IBaseService<string, Endpoint>
    {
        private EndpointDao dao = EndpointDao.GetInstance;

        public Endpoint Execute(string identifier)
        {
            var endpoint = dao.FindOne(identifier);
            if (endpoint == null)
                throw new AppException(I18nService.GetTranslate("DONT_HAVE_SERIAL_NUMBER"));
            return endpoint;
        }
    }
}
