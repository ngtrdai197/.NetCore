using System;

namespace NetCoreUsingVsCode.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string UrlPhoto { get; set; }
        public virtual Department Department { get; set; }
    }
}