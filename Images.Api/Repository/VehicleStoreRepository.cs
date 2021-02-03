using Vehicle.Search.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vehicle.Search.Api.Data.VehiclesDataStore;

namespace Vehicle.Search.Api.Repository
{
    public class VehicleStoreRepository : IVehicleStoreRepository
    {
        public VehicleDetails FetchVehicleBy(string vrn)
        {
            if (!RegisteredVehicles.ContainsKey(vrn))
            {
                throw new ArgumentException();
            }
            return RegisteredVehicles[vrn];

        }

        public IEnumerable<VehicleDetails> FetchVehicleByMake(string make)
        {
            throw new NotImplementedException();
        }
    }
}
