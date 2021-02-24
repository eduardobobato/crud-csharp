using crud_csharp.DAO;
using crud_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Service
{
    class EditEndpointService : IBaseService<Endpoint, Endpoint>
    {
        private EndpointDao dao = EndpointDao.GetInstance;

        public Endpoint Execute(Endpoint endpoint)
        {
            return dao.Edit(endpoint);
        }
    }
}
