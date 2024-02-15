using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class Checks
    {
            public static bool UserCheck(TravelExpertsContext db, string username)
            {
                bool UsernameOk = true;//unique
                string msg = "";
                if (!string.IsNullOrEmpty(username))
                {
                    var customer = db.Customers.FirstOrDefault(
                        c => c.CustUserName.ToLower() == username.ToLower());
                    if (customer != null) //already exists
                    {
                        msg = $"Username {username} already in use.";
                        UsernameOk = false;
                    }

                }
                return UsernameOk;
            }
        
    }
}
