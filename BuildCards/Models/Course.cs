using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCards.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string Level { get; set; } = null!;

        public int DurationHours { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string Status { get; set; } = null!;

        public string PriceFormatted => $"{Price} MAD";

        public string DurationFormatted => $"{DurationHours}h";

        public string Icon { get; set; } = "📚";

    }
}
