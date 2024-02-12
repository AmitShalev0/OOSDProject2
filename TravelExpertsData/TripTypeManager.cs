using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class TripTypeManager
    {
        public static List<TripType> GetTripTypes(TravelExpertsContext db)
        {
            var types = db.TripTypes.ToList();
            return types;
        }
    }
}
