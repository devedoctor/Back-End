using System.ComponentModel.DataAnnotations.Schema;
namespace StudentResultsApp.Models
{
    public class StudentResult
    {
        public int Serial { get; set; }
        public int SetNo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }
        public int Grade { get; set; }
        public string StudyYear { get; set; }

        // Subjects 1-10
        public string Subject1Name { get; set; }
        public decimal Subject1MaxDegree { get; set; }
        public decimal Subject1minDegree { get; set; }
        public decimal Subject1StudentDegree { get; set; }
        public string Subject1StudentGraduation { get; set; }
        // ... Repeat for Subjects 2-10
        // Properties for Subject 2
        [Column("Subject2Name")]
        public string Subject2Name { get; set; }
        [Column("Subject2MaxDegree")]
        public decimal? Subject2MaxDegree { get; set; }
        [Column("Subject2MinDegree")]
        public decimal? Subject2MinDegree { get; set; }
        [Column("Subject2StudentDegree")]
        public decimal? Subject2StudentDegree { get; set; }
        [Column("Subject2StudentGraduation")]
        public string Subject2StudentGraduation { get; set; }

        // Properties for Subject 3
        [Column("Subject3Name")]
        public string Subject3Name { get; set; }
        [Column("Subject3MaxDegree")]
        public decimal? Subject3MaxDegree { get; set; }
        [Column("Subject3MinDegree")]
        public decimal? Subject3MinDegree { get; set; }
        [Column("Subject3StudentDegree")]
        public decimal? Subject3StudentDegree { get; set; }
        [Column("Subject3StudentGraduation")]
        public string Subject3StudentGraduation { get; set; }

        // Properties for Subject 4
        [Column("Subject4Name")]
        public string Subject4Name { get; set; }
        [Column("Subject4MaxDegree")]
        public decimal? Subject4MaxDegree { get; set; }
        [Column("Subject4MinDegree")]
        public decimal? Subject4MinDegree { get; set; }
        [Column("Subject4StudentDegree")]
        public decimal? Subject4StudentDegree { get; set; }
        [Column("Subject4StudentGraduation")]
        public string Subject4StudentGraduation { get; set; }

        // Properties for Subject 5
        [Column("Subject5Name")]
        public string Subject5Name { get; set; }
        [Column("Subject5MaxDegree")]
        public decimal? Subject5MaxDegree { get; set; }
        [Column("Subject5MinDegree")]
        public decimal? Subject5MinDegree { get; set; }
        [Column("Subject5StudentDegree")]
        public decimal? Subject5StudentDegree { get; set; }
        [Column("Subject5StudentGraduation")]
        public string Subject5StudentGraduation { get; set; }

        // Properties for Subject 6
        [Column("Subject6Name")]
        public string Subject6Name { get; set; }
        [Column("Subject6MaxDegree")]
        public decimal? Subject6MaxDegree { get; set; }
        [Column("Subject6MinDegree")]
        public decimal? Subject6MinDegree { get; set; }
        [Column("Subject6StudentDegree")]
        public decimal? Subject6StudentDegree { get; set; }
        [Column("Subject6StudentGraduation")]
        public string Subject6StudentGraduation { get; set; }

        // Properties for Subject 7
        [Column("Subject7Name")]
        public string Subject7Name { get; set; }
        [Column("Subject7MaxDegree")]
        public decimal? Subject7MaxDegree { get; set; }
        [Column("Subject7MinDegree")]
        public decimal? Subject7MinDegree { get; set; }
        [Column("Subject7StudentDegree")]
        public decimal? Subject7StudentDegree { get; set; }
        [Column("Subject7StudentGraduation")]
        public string Subject7StudentGraduation { get; set; }

        // Properties for Subject 8
        [Column("Subject8Name")]
        public string Subject8Name { get; set; }
        [Column("Subject8MaxDegree")]
        public decimal? Subject8MaxDegree { get; set; }
        [Column("Subject8MinDegree")]
        public decimal? Subject8MinDegree { get; set; }
        [Column("Subject8StudentDegree")]
        public decimal? Subject8StudentDegree { get; set; }
        [Column("Subject8StudentGraduation")]
        public string Subject8StudentGraduation { get; set; }

        // Properties for Subject 9
        [Column("Subject9Name")]
        public string Subject9Name { get; set; }
        [Column("Subject9MaxDegree")]
        public decimal? Subject9MaxDegree { get; set; }
        [Column("Subject9MinDegree")]
        public decimal? Subject9MinDegree { get; set; }
        [Column("Subject9StudentDegree")]
        public decimal? Subject9StudentDegree { get; set; }
        [Column("Subject9StudentGraduation")]
        public string Subject9StudentGraduation { get; set; }

        // Properties for Subject 10
        [Column("Subject10Name")]
        public string Subject10Name { get; set; }
        [Column("Subject10MaxDegree")]
        public decimal? Subject10MaxDegree { get; set; }
        [Column("Subject10MinDegree")]
        public decimal? Subject10MinDegree { get; set; }
        [Column("Subject10StudentDegree")]
        public decimal? Subject10StudentDegree { get; set; }
        [Column("Subject10StudentGraduation")]
        public string Subject10StudentGraduation { get; set; }

        // Totals
        public decimal TotalMaxDegree { get; set; }
        public decimal TotalminDegree { get; set; }
        public decimal TotalStudentDegree { get; set; }
        public string TotalGraduation { get; set; }
        public string TotalPercentage { get; set; }

        // Helper property for the progress bar color
        public string ProgressBarColor
        {
            get
            {
                if (!string.IsNullOrEmpty(TotalGraduation))
                {
                    string graduation = TotalGraduation.ToLowerInvariant();
                    if (graduation == "excellent") return "bg-primary"; // Blue
                    if (graduation == "very good") return "bg-success"; // Green
                    if (graduation == "good" || graduation == "pass") return "bg-warning"; // Yellow
                    if (graduation == "fail") return "bg-danger"; // Red
                }
                return "bg-secondary"; // Default gray
            }
        }
    }
}