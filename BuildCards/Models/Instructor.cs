namespace BuildCards.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateOnly HireDate { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }

        public bool IsActive { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Initials => $"{FirstName[0]}{LastName[0]}";

        public int YearsOfExperience => GetYears(HireDate);

        public string SalaryFormatted => $"{Salary} MAD";

        public string StatusText => IsActive ? "Active" : "Inactive";

        private static int GetYears(DateOnly startDate)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int years = today.Year - startDate.Year;

            if (startDate > today.AddYears(-years))
                years--;

            return years;
        }

    }
}
