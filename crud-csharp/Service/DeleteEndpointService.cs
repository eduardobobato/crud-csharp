using crud_csharp.DAO;
using crud_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Service
{
    public class DeleteEndpointService : IBaseService<string, Endpoint>
    {
        private EndpointDao dao = EndpointDao.GetInstance;

        public Endpoint Execute(string identifier)
        {
            return dao.Delete(dao.FindOne(identifier));
        }
    }
}
