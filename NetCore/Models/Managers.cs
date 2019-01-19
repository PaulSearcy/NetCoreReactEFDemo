using System;
using System.Collections.Generic;

namespace NetCore.Models
{
    public partial class Managers
    {
        public Managers()
        {
            Workers = new HashSet<Workers>();
        }

        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }
    }
}
