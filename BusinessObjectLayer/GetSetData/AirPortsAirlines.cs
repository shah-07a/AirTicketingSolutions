using Models.DTO;
using System.Collections.Generic;
using DAL = DataAccessLayer;

namespace BusinessObjectLayer.GetSetData
{
    public class AirPortsAirlines
    {
        public List<Parameter> Parameters { get; set; }
        public List <Airports> GetAirports()
        {
            return DAL.DataModel.DbModels.GetSetData.AirPortsAirlines.GetAirports(Parameters);
        }
        public List<Airlines> GetAirlines()
        {
            return DAL.DataModel.DbModels.GetSetData.AirPortsAirlines.GetAirlines(Parameters);
        }
    }
}
