using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class TripTypeManager
    {
        public static List<string> GetTripTypes(TravelExpertsContext db)
        {
            List<string> typeNames;
            typeNames = db.TripTypes.Select(t => t.Ttname).ToList();
            return typeNames;
        }
    }
}
