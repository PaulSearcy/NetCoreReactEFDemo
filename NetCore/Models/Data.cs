using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class Data
    {
        APIDBContext db = new APIDBContext();

        public IEnumerable<Workers> GetAllEmployees()
        {
            try
            {
                return db.Workers.ToList();
            }
            catch
            {
                throw;
            }
        }

    }
}
