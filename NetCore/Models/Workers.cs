using System;
using System.Collections.Generic;

namespace NetCore.Models
{
    public partial class Workers
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StartDate { get; set; }
        public string TechLevel { get; set; }
        public int ManagerId { get; set; }

        public virtual Managers Manager { get; set; }
    }
}
