using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreUsingVsCode.DTO
{
    public class EmployeeDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}