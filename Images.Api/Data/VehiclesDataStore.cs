using System.Collections.Generic;
using Vehicle.Search.Api.Model;

namespace Vehicle.Search.Api.Data
{
    public static class VehiclesDataStore
    {
        static VehiclesDataStore()
        {
            RegisteredVehicles = new Dictionary<string, VehicleDetails>();
            RegisteredVehicles.Add("abc123",
                new VehicleDetails
                {
                    VRN = "ABC123",
                    Make = "Audi",
                    Model = "Q20",
                    ManufacturingYear = 2019
                });
        }

        //stored by VRN
        public static Dictionary<string, VehicleDetails> RegisteredVehicles { get; set; }
        //Stored by Make
        public static Dictionary<string, VehicleDetails> ManufacturedVehiclesModels { get; set; }
    }
}
