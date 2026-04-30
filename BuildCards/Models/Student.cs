using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCards.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public DateTime RegisteredAt { get; set; }

        public string Status { get; set; } = null!;

        public string? PhoneNumber { get; set; }
    }
}
