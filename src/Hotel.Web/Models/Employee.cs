using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
    [PrimaryKey(nameof(Id))]
    public sealed class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime AdmissionDate { get; set; }
        public decimal Salary { get; set; }
        public string PIS { get; set; } = string.Empty;
        public bool IsAdministrator { get; set; }
    }
}
