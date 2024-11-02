using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class Types
    {
        public enum DataTypes
        {
            String,
            Int,
            Double,
            DateTime,
            Bool
        };

        public enum ProjectNames
        {
            DataAccessLayer,
            BusinessObjectLayer,
            HttpServices,
            PresentationLayer,
            GlobalDistributionSystem
        }
    }
}
