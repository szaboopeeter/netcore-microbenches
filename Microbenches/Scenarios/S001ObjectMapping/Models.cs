using System;
using System.Collections.Generic;

namespace Microbenches.Scenarios.S001ObjectMapping.SourceModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfService { get; set; }
        public List<Employee> Subordinates { get; set; }
    }
}

namespace Microbenches.Scenarios.S001ObjectMapping.TargetModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfService { get; set; }
        public List<Employee> Subordinates { get; set; }
    }
}