using Microsoft.EntityFrameworkCore;

namespace EmpleadoPrueba.Models
{
    // Campos que usa el archivo .JSON enviado
    [PrimaryKey(nameof(EmployeeNumber))]
    public class Empleados
    {
        public int EmployeeNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly EntryDate { get; set; }
        public required DateOnly ExitDate { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string Description { get; set; }
        public required string Gender { get; set; }
        public required DateOnly Birthday { get; set; }
        public string? MobilePhone { get; set; } = null;
        public string? Phone { get; set; } = null;
        public required string EMail { get; set; }
        public required string Street { get; set; }
        public required string District { get; set; }
        public required string PostalCode { get; set; }
        public string[] AdditionalData { get; set; } = [];
    }
}
