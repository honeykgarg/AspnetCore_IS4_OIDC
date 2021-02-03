using Vehicle.Search.Api.Model;
using System.Collections.Generic;

namespace Vehicle.Search.Api.Repository
{
    public interface IVehicleStoreRepository
    {
        VehicleDetails FetchVehicleBy(string vrn);
        IEnumerable<VehicleDetails> FetchVehicleByMake(string make);

    }
}
