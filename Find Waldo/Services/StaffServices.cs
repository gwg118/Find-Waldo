using Find_Waldo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Find_Waldo.Services
{
    public class StaffServices
    {
        private ApplicationDbContext db;

        public StaffServices(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateStaff (string firstName, string lastName, string userId )
        {
            
            var accountNumber = (123456 + db.Staffs.Count()).ToString().PadLeft(10, '0');
            var staff = new Staff { FirstName = firstName, LastName = lastName, AccountNumber = accountNumber, ApplicationUserId = userId };
            db.Staffs.Add(staff);
            db.SaveChanges();
        }
    }
}