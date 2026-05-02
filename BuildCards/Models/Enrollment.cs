using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCards.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentFullName { get; set; } = null!;
        public string CourseTitle { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal ProgressPercent { get; set; }
        public decimal? FinalGrade { get; set; }
        public string Status { get; set; } = null!;

        // Computed
        public string ProgressText => $"{ProgressPercent}%";
        public string GradeText => FinalGrade.HasValue ? $"{FinalGrade:F1}" : "N/A";
        public string EnrollmentDateFormatted => EnrollmentDate.ToString("dd MMM yyyy");
    }
}
