using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class Data
    {
        workingOutAPIContext20160326123516Context db = new workingOutAPIContext20160326123516Context();

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
