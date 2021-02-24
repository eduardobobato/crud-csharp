using crud_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.DAO
{
    public class EndpointDao : IBaseDao<Endpoint>
    {
        #region EndpointDao - Singleton Implementation
        private static EndpointDao instance;

        private EndpointDao() { }

        public static EndpointDao GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EndpointDao();
                }
                return instance;
            }
        }
        #endregion

        #region IBaseDao - Implementation
        private List<Endpoint> db = new List<Endpoint>();
        
        public List<Endpoint> ListAll()
        {
            return db;
        }

        public Endpoint Create(Endpoint endpoint)
        {
            db.Add(endpoint);
            return endpoint;
        }

        public Endpoint Edit(Endpoint endpoint)
        {
            var matchedEndpoint = db.Single(e => e.serialNumber == endpoint.serialNumber);
            matchedEndpoint.switchState = endpoint.switchState;
            return matchedEndpoint;
        }

        public Endpoint Delete(Endpoint endpoint)
        {
            db.Remove(endpoint);
            return endpoint;
        }

        public Endpoint FindOne(string identifier)
        {
            var endpoint = (from e in db where e.serialNumber.Equals(identifier) select e).FirstOrDefault();
            return endpoint;
        }
        #endregion
    }
}
