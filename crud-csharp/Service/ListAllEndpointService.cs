using crud_csharp.DAO;
using crud_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Service
{
    class ListAllEndpointService : IBaseService<string, List<Endpoint>>
    {
        private EndpointDao dao = EndpointDao.GetInstance;

        public List<Endpoint> Execute(string _ = null)
        {
            return dao.ListAll();
        }
    }
}
