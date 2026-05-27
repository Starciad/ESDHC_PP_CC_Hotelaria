using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
    [PrimaryKey("Id")]
    public sealed class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime AdmissionDate { get; set; }
        public decimal Salary { get; set; }
        public string PIS { get; set; }
        public bool IsAdministrator { get; set; }
    }
}
